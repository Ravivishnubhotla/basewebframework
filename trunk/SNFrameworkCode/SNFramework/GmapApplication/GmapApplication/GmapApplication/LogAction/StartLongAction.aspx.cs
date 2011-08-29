using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace GmapApplication.LogAction
{
    public partial class StartLongAction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected const string SessionName_CurrentStep = "CurrentStep";

        public int CurrentStep
        {
            get
            {
                if(this.Session[SessionName_CurrentStep] == null)
                {
                    this.Session[SessionName_CurrentStep] = 0;
                }
                return (int) this.Session[SessionName_CurrentStep];
            }
            set
            {
                this.Session[SessionName_CurrentStep] = value;
            }
        }

        protected void OnStartLongAction(object sender, DirectEventArgs e)
        {
            CurrentStep = 0;
            prgProcess.Text = "";
            ThreadPool.QueueUserWorkItem(LongAction);
            ResourceManager1.AddScript("{0}.startTask('longactionprogress');", TaskManager1.ClientID);
        }

        protected void OnCancel(object sender, DirectEventArgs e)
        {
            prgProcess.UpdateProgress(1f, "Action is Canceled");
            CurrentStep = -2;
        }

        private void LongAction(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                
                if (CurrentStep<0)
                {
                    return;
                }
                
                CurrentStep = i + 1;
            }
            CurrentStep = -1;
        }

        protected void RefreshProgress(object sender, DirectEventArgs e)
        {
            int progress = CurrentStep;

            if (progress >= 0)
            {
                prgProcess.UpdateProgress(((int)progress) / 10f, string.Format("Step {0} of {1}...", progress.ToString(), 10));
            }
            else if (progress == -2)
            {
                ResourceManager1.AddScript("{0}.stopTask('longactionprogress');", TaskManager1.ClientID);
                prgProcess.UpdateProgress(1, "Task is Cancel!");
            }
            else
            {
                ResourceManager1.AddScript("{0}.stopTask('longactionprogress');", TaskManager1.ClientID);
                prgProcess.UpdateProgress(1, "All finished!");
            }
        }
    }
}