using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SPS.Bussiness.Wrappers;
using SPSUtil.Moudles;
using SubSonic.Repository;

namespace SPSUtil
{
    static class Program
    {
        public static ILog logger = LogManager.GetLogger("ConsoleLog");
        //public static SimpleRepository DbRepository = null; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {

                //命令行方式批处理运行
                //if (args.Length > 0 && args[0].ToLower() == "-c")
                //{
                //    RunAsCmd(args);
                //    return;
                //}

                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException +=
                    new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException +=
                    new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch(Exception ex)
            {
                ProcessError(ex);
            }
        }

        private static void RunAsCmd(string[] args)
        {
            AllocConsole();

            string cmdName = args[1];

            //Console.WriteLine("短信发送程序命令行方式启动,按任意键盘退出。");

            int clientID = 0;

            if (args.Length > 2)
               int.TryParse(args[2],out clientID);

            int codeID = 0;

            if (args.Length > 3)
                int.TryParse(args[3],out codeID);

            switch (cmdName.ToLower())
            {
                case "sendtodaydata":

                    string sendobj = string.Empty;

                    SPSClientWrapper client = null;

                    if ((clientID != 0))
                    {
                        client = SPSClientWrapper.FindById(clientID);

                        if (client != null)
                        {
                            sendobj += " 客户【" + client.Name + "】";
                        }
                    }

                    SPCodeWrapper code = null;

                    if ((codeID != 0))
                    {
                        code = SPCodeWrapper.FindById(codeID);

                        if (code != null)
                        {
                            sendobj += " 指令【" + code.MoCode + "】";
                        }
                    }

                    sendobj += " 所有数据 ";

                    

                    logger.Info("开始发送“" + sendobj + "”当日数据。。。");

                    logger.Info("发送“" + sendobj + "”当日数据完成。。。");


                    break;
                case "sendhistorydata":
                    //logger.Info("开始发送历史数据。。。");

                    //logger.Info("发送历史数据完成。。。");
                    break;
            }

            Console.ReadKey();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ProcessError(e.ExceptionObject as Exception);
        }

        private static void ProcessError(Exception ex)
        {
            string str = "";
 
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            if (ex != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", ex.Message,
                                    ex.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", ex);
            }

            //writeLog(str);
            MessageBox.Show("发生致命错误，请停止当前操作并及时联系作者！\n" + str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ProcessError(e.Exception as Exception);
        }


        /// <summary>
        /// 启动控制台
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        /// <summary>
        /// 释放控制台
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}
