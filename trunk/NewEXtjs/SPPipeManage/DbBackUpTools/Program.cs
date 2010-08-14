using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Logging;

namespace DbBackUpTools
{
    class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            logger.Info("备份开始");

            try
            {
                string appRoot = Application.StartupPath;

                string backupfileformat = ConfigurationManager.AppSettings["backupfileformat"];

                bool comperssionbak = bool.Parse(ConfigurationManager.AppSettings["comperssionbak"]);

                string backupfile = Path.Combine(appRoot,string.Format(backupfileformat, Convert.ToInt32(DateTime.Now.DayOfWeek)));

                if(File.Exists(backupfile))
                    File.Delete(backupfile);

                using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["backupdb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();

                        string sql = string.Format("BACKUP DATABASE {1} TO DISK='{0}' ", backupfile, connection.Database);

                        if(comperssionbak)
                        {
                            sql = sql + " WITH COMPRESSION ";
                        }

                        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                        {
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    catch (Exception e)
                    {
                        logger.Error("备份执行错误：", e);
                    }
                    finally
                    {
                        if(connection!=null && connection.State!=ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                    logger.Info("备份ok");
                }
            }
            catch (Exception e)
            {
                logger.Error("备份错误：", e);
            }

            logger.Info("备份结束");
        }
    }
}
