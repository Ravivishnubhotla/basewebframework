  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Reports
{




    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdReportEdit")]
    public partial class UCSPAdReportEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPAdReportWrapper obj = SPAdReportWrapper.FindById(id);

                if (obj != null)
                {
                //                    this.numID.Value = obj.ID.ToString();          	
                    this.lblAdName.Value = obj.SPPackID.SPAdID.Name;
                    this.lblAdPackName.Value = obj.SPPackID.Name;
                    this.lblSPClientName.Value = obj.SPClientID.Name;
                    this.dateReportDate.Value = obj.ReportDate.Value.ToShortDateString();
                    this.numClientCount.Value = obj.ClientCount.ToString();
                    this.numAdCount.Value = obj.AdCount.ToString();
                    this.numAdClientUseCount.Value = obj.AdClientUseCount;
                    this.numAdUseCount.Value = obj.AdUseCount;
                    this.numAdClientDownCount.Value = obj.AdClientDownCount;
                    this.numAdDownCount.Value = obj.AdDownCount;
 
 



                    hidId.Text = id.ToString();


                    winSPAdReportEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPAdReport_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdReportWrapper obj = SPAdReportWrapper.FindById(int.Parse(hidId.Text.Trim()));


                obj.ClientCount = Convert.ToInt32(this.numClientCount.Value);
                obj.AdCount = Convert.ToInt32(this.numAdCount.Value);
                obj.AdClientUseCount = Convert.ToInt32(this.numAdClientUseCount.Value);
                obj.AdUseCount = Convert.ToInt32(this.numAdUseCount.Value);
                obj.AdClientDownCount = Convert.ToInt32(this.numAdClientDownCount.Value);
                obj.AdDownCount = Convert.ToInt32(this.numAdDownCount.Value);
                

                SPAdReportWrapper.Update(obj);

                winSPAdReportEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }
    }













}

