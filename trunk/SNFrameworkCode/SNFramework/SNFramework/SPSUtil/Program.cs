using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using SPS.Bussiness.Wrappers;
using SubSonic.Repository;

namespace SPSUtil
{
    static class Program
    {

        //public static SimpleRepository DbRepository = null; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                //List<SystemConfigWrapper> settings = SystemConfigWrapper.FindAll();

                //SystemShortMessageWrapper shortMessage = new SystemShortMessageWrapper();
                //shortMessage.Title = "";
                //shortMessage.MessageType = "1";
                //shortMessage.SendDate = System.DateTime.Now;
                //SystemShortMessageWrapper.Save(shortMessage);
                //Console.WriteLine(shortMessage.Id);
                //Console.WriteLine(settings[0].ConfigGroupID.Code);




                //SPAdvertisementWrapper.TestTransateion();

                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException +=
                    new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException +=
                    new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                //DbRepository = new SimpleRepository("SPSDb", SimpleRepositoryOptions.RunMigrations);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch(Exception ex)
            {
                ProcessError(ex);
            }
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
    }
}
