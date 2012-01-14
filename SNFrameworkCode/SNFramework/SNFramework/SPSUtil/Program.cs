using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SubSonic.Repository;

namespace SPSUtil
{
    static class Program
    {

        public static SimpleRepository DbRepository = null; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DbRepository = new SimpleRepository("SPSDb", SimpleRepositoryOptions.RunMigrations);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
