using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Common.Logging;
using SPSSiteTask.SPDataService;

namespace SPSSiteTask
{
    class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

        private static SPDataService.SPDataServiceSoapClient client = new SPDataServiceSoapClient();

        private static bool isDebug = false;

        private static string debugCmd = "";

        private static bool ReadAppConfigBoolean(string configkey,bool defaultValue)
        {
            try
            {
                return bool.Parse(ConfigurationManager.AppSettings[configkey]);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        private static string ReadAppConfigString(string configkey, string defaultValue)
        {
            try
            {
                return ConfigurationManager.AppSettings[configkey];
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        static void Main(string[] args)
        {
            isDebug = ReadAppConfigBoolean("IsDebug",isDebug);

            debugCmd = ReadAppConfigString("DebugCmd", debugCmd);

            string[] cmds;

            if (!string.IsNullOrEmpty(debugCmd))
            {
                cmds = new string[] { debugCmd };
            }
            else
            {
                cmds = args;             
            }

            if (cmds.Length < 1)
            {
                Console.WriteLine("Please input command name:");

                Console.WriteLine("\t -rsr resend all request.");

                if (isDebug)
                    Console.ReadKey();
                
                return;
            }
 
            try
            {
                logger.Info("连接到webservice....");

                client.Connect();

                logger.Info("连接到webservice成功！");
            }
            catch (Exception ex)
            {
                logger.Error("连接到webservice失败！", ex);

                if (isDebug)
                    Console.ReadKey();

                return;
            }

            switch (cmds[0].ToLower())
            {
                case "-rsr":
                    ReSendAllSendFailedRequest();
                    break;

            }

            EndApplication(); 
        }

        private static void ReSendAllSendFailedRequest()
        {
            List<SPSSendUrlEntity> sendUrlEntities = null;

            try
            {
                logger.Info("获取发送请求数据开始....");

                sendUrlEntities = client.GetAllClientChannelNeedSendData();

                logger.Info(string.Format("获取发送请求数据成功,共{0}条请求！", sendUrlEntities.Count));
            }
            catch (Exception ex)
            {
                logger.Error("获取发送请求数据失败！", ex);

                if (isDebug)
                    Console.ReadKey();

                return;
            }


            try
            {
                logger.Info("批量发送请求开始....");

                foreach (SPSSendUrlEntity spsSendUrlEntity in sendUrlEntities)
                {
                    if (string.IsNullOrEmpty(spsSendUrlEntity.SendUrl))
                    {
                        logger.Error(string.Format("请求略过，ID{0}", spsSendUrlEntity.PaymentID));
                        continue;
                    }

                    try
                    {
                        int retryTimes = 0;

                        bool requestOk = false;

                        do
                        {

                            string errorMessage = string.Empty;

                            requestOk = SendRequest(spsSendUrlEntity.SendUrl, 10000, "ok", out errorMessage);

                            if (!requestOk)
                            {
                                logger.Error(string.Format("请求失败，ID{0},错误信息：{1}", spsSendUrlEntity.PaymentID, errorMessage));

                                Thread.Sleep(1000);

                            }

                            retryTimes++;

                            if (retryTimes >= 3)
                                break;

                        } while (!requestOk);

                        logger.Info(string.Format("请求成功，ID:{0},Url:{1}", spsSendUrlEntity.PaymentID, spsSendUrlEntity.SendUrl));

                        client.UpdatePaymentSend(spsSendUrlEntity.PaymentID, requestOk, spsSendUrlEntity.SendUrl, spsSendUrlEntity.SycnRetryTimes+1);

                    }
                    catch (Exception ex)
                    {
                        logger.Error(string.Format("请求失败，ID{0}", spsSendUrlEntity.PaymentID), ex);

                    }
                }

                logger.Info(string.Format("批量发送请求成功！共{0}请求，", sendUrlEntities.Count));
            }
            catch (Exception ex)
            {
                logger.Error("批量发送请求失败！", ex);

                if (isDebug)
                    Console.ReadKey();

                return;
            }
        }

        private static void EndApplication()
        {
            if(isDebug)
            {
                Console.WriteLine("程序结束，按任意键退出。");
                Console.ReadKey();
            }
        }


        private static bool SendRequest(string requesturl, int timeOut, string okMessage, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    string responseText = sr.ReadToEnd();

                    return responseText.Trim().ToLower().Equals(okMessage);
                }

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }
    }
}
