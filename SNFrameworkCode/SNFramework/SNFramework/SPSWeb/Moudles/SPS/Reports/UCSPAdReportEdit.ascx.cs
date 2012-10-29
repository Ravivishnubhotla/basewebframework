  

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

