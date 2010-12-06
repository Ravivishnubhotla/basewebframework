using System;
using System.Collections;
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

        private static int maxDataCount = 500;

        private static int maxAllDataCount = 1500;

        private static int historyDateCount = 2;

        private static int sendClientChannelID = 0;

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

        private static int ReadAppConfigInt(string configkey, int defaultValue)
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings[configkey]);
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

            maxDataCount = ReadAppConfigInt("MaxDataCount", maxDataCount);

            maxAllDataCount = ReadAppConfigInt("MaxAllDataCount", maxAllDataCount);

            historyDateCount = ReadAppConfigInt("HistoryDateCount", historyDateCount);

            sendClientChannelID = ReadAppConfigInt("SendClientChannelID", sendClientChannelID);


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
                    ReSendAllSendTodayNoSendRequest();
                    break;
                case "-rhsr":
                    ReSendAllSendHistoryNoSendRequest();
                    break;
                case "-rsrtt":
                    ReSendNoSendRequestThreads(System.DateTime.Now.Date, System.DateTime.Now.Date,3);
                    break;
                case "-rhsrtt":
                    DateTime endDate = System.DateTime.Now.AddDays(-1);
                    DateTime startDate = endDate.AddDays(-1 * historyDateCount);
                    ReSendNoSendRequestThreads(startDate.Date, endDate.Date, 3);
                    break;
            }

            EndApplication(); 
        }

 

        private static void ReSendNoSendRequestThreads(DateTime startDate,DateTime endDate,int reyTryCount)
        {
            ThreadPool.SetMaxThreads(15, 15);

            System.Threading.WaitCallback waitCallback = new WaitCallback(SendRequest);

            ArrayOfInt clientChannleIDs = client.GetGetAllClientChannelIDNeed(startDate.Date, endDate.Date);

            List<SendTask> allSendTask = new List<SendTask>();

            Hashtable hashtable = new Hashtable();

            foreach (int clientChannleID in clientChannleIDs)
            {
                if (sendClientChannelID != 0)
                {
                    if (clientChannleID != sendClientChannelID)
                    {
                        continue;
                    }
                }

                string host = "";

                try
                {
                    host = client.GetAllClientChannelSendWebDomain(clientChannleID);
                }
                catch (Exception ex)
                {
                    logger.Error("获取host失败！", ex);
                }

                if (!hashtable.ContainsKey(host))
                {
                    SendTask sendTask = new SendTask();
                    sendTask.IsEnd = false;
                    sendTask.StartDate = startDate.Date;
                    sendTask.EndDate = endDate.Date;
                    sendTask.ChanneClientIds = new List<int>();
                    sendTask.Host = host;
                    allSendTask.Add(sendTask);
                    hashtable.Add(host, sendTask);
                }

                ((SendTask)hashtable[host]).ChanneClientIds.Add(clientChannleID);
            }

            foreach (DictionaryEntry dictionaryEntry in hashtable)
            {
                ThreadPool.QueueUserWorkItem(SendRequest, dictionaryEntry.Value);
                Thread.Sleep(60000);
            }

            while (allSendTask.Exists(p=>!p.IsEnd))
            {
                Thread.Sleep(5000);
            }
        }

        private static void SendRequest(object request)
        {
            SendTask sendTask = request as SendTask;

            if (sendTask == null)
                throw new AbandonedMutexException(" sendTask is null ");

            logger.Info("批量发送" + sendTask.Host + "开始");

            try
            {
                foreach (int channeClientId in sendTask.ChanneClientIds)
                {
                    try
                    {
                        logger.Info("批量发送" + channeClientId.ToString() + "开始");

                        List<SPSSendUrlEntity> sendUrlEntities =
                            client.GetSSendUrlByClientChannelIDAndDate(sendTask.StartDate, sendTask.EndDate,
                                                                       channeClientId, 2);

                        PatchSend(sendUrlEntities);

                        logger.Info("批量发送" + channeClientId.ToString() + "结束");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("批量发送请求数据失败！", ex);
                    }   
                }

                logger.Info("批量发送" + sendTask.Host + "开始");

                sendTask.IsEnd = true;
            }
            catch (Exception ex)
            {
                logger.Error("批量发送请求数据失败！", ex);
                sendTask.IsEnd = true;
            }
        }

        private static void ReSendAllSendHistoryNoSendRequest()
        {
            List<SPSSendUrlEntity> sendUrlEntities = null;

            try
            {
                logger.Info("获取发送请求数据开始....");

                DateTime endDate = System.DateTime.Now.AddDays(-1);

                DateTime startDate = endDate.AddDays(-1*historyDateCount);

                sendUrlEntities = client.GetAllClientChannelNeedSendHistoryData(maxDataCount, maxAllDataCount, startDate, endDate);

                logger.Info(string.Format("获取发送请求数据成功,共{0}条请求！", sendUrlEntities.Count));
            }
            catch (Exception ex)
            {
                logger.Error("获取发送请求数据失败！", ex);

                if (isDebug)
                    Console.ReadKey();

                return;
            }


            PatchSend(sendUrlEntities);
        }


        private static void ReSendAllSendTodayNoSendRequest()
        {
            List<SPSSendUrlEntity> sendUrlEntities = null;

            try
            {
                logger.Info("获取发送请求数据开始....");

                sendUrlEntities = client.GetAllClientChannelNeedSendData(maxDataCount,maxAllDataCount);

                logger.Info(string.Format("获取发送请求数据成功,共{0}条请求！", sendUrlEntities.Count));
            }
            catch (Exception ex)
            {
                logger.Error("获取发送请求数据失败！", ex);

                if (isDebug)
                    Console.ReadKey();

                return;
            }


            PatchSend(sendUrlEntities);
        }

        private static void PatchSend(List<SPSSendUrlEntity> sendUrlEntities)
        {
            try
            {
                logger.Info("批量发送请求开始....");

                int i = 0;

                int titalCOunt = sendUrlEntities.Count;

                foreach (SPSSendUrlEntity spsSendUrlEntity in sendUrlEntities)
                {
                    i++;

                    string progress = string.Format("({0}/{1})", i, titalCOunt);

                    if (!client.CheckPaymentNeedSend(spsSendUrlEntity.PaymentID))
                    {
                        logger.Error(string.Format(progress + "请求已发送略过，ID{0}", spsSendUrlEntity.PaymentID));
                        continue;
                    }

                    if (string.IsNullOrEmpty(spsSendUrlEntity.SendUrl))
                    {
                        logger.Error(string.Format(progress + "请求略过，ID{0}", spsSendUrlEntity.PaymentID));
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
                                logger.Error(string.Format(progress + "请求失败，ID{0},错误信息：{1}", spsSendUrlEntity.PaymentID, errorMessage));

                                Thread.Sleep(1000);

                            }

                            retryTimes++;

                            if (retryTimes >= 3)
                                break;

                        } while (!requestOk);

                        logger.Info(string.Format(progress + "请求成功，ID:{0},Url:{1}", spsSendUrlEntity.PaymentID, spsSendUrlEntity.SendUrl));

                        client.UpdatePaymentSend(spsSendUrlEntity.PaymentID, requestOk, spsSendUrlEntity.SendUrl, spsSendUrlEntity.SycnRetryTimes+1);

                    }
                    catch (Exception ex)
                    {
                        logger.Error(string.Format(progress + "请求失败，ID{0}", spsSendUrlEntity.PaymentID), ex);
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
