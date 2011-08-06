using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;

namespace Legendigital.Common.Web.AppClass
{
    public abstract class UCLongActionOp : System.Web.UI.UserControl
    {
        public int CurrentStep
        {
            get
            {
                if (this.Session[GetSessionName_CurrentStep()] == null)
                {
                    this.Session[GetSessionName_CurrentStep()] = 0;
                }
                return (int)this.Session[GetSessionName_CurrentStep()];
            }
            set
            {
                this.Session[GetSessionName_CurrentStep()] = value;
            }
        }

        public int CurrentStepCount
        {
            get
            {
                if (this.Session[GetSessionName_CurrentStepCount()] == null)
                {
                    this.Session[GetSessionName_CurrentStepCount()] = 0;
                }
                return (int)this.Session[GetSessionName_CurrentStepCount()];
            }
            set
            {
                this.Session[GetSessionName_CurrentStepCount()] = value;
            }
        }

        public abstract string GetSessionName_CurrentStep();

        public abstract string GetSessionName_CurrentStepCount();

        public abstract Coolite.Ext.Web.ProgressBar GetControl_ProgressBar();

        public abstract Coolite.Ext.Web.ScriptManagerProxy GetControl_ScriptManager();

        public abstract Coolite.Ext.Web.TaskManager GetControl_TaskManager();

        public abstract void ExecuteLongAction(object state);

        public void LongAction(object state)
        {
            ExecuteLongAction(state);
        }

        public void OnCancel(object sender, AjaxEventArgs e)
        {
            GetControl_ProgressBar().UpdateProgress(1f, "任务被取消");
            CurrentStep = -2;
        }

        public void RefreshProgress(object sender, AjaxEventArgs e)
        {
            int progress = CurrentStep;

            int maxCount = CurrentStepCount;

            if (progress >= 0)
            {
                GetControl_ProgressBar().UpdateProgress(Convert.ToSingle(progress) / Convert.ToSingle(maxCount), string.Format("任务处理中（{0}/{1})...", progress.ToString(), maxCount));
            }
            else if (progress == -2)
            {
                GetControl_ScriptManager().AddScript("{0}.stopTask('longactionprogress');", GetControl_TaskManager().ClientID);
                GetControl_ProgressBar().UpdateProgress(1, "任务被取消!");
            }
            else
            {
                GetControl_ScriptManager().AddScript("{0}.stopTask('longactionprogress');", GetControl_TaskManager().ClientID);
                GetControl_ProgressBar().UpdateProgress(1, "任务完成!");
            }
        }
    }
}