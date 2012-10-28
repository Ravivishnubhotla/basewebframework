  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Reports
{
 
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdReportAdd")]
    public partial class UCSPAdReportAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPAdReportAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPAdReport_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdReportWrapper obj = new SPAdReportWrapper();
          //obj.ID = Convert.ToInt32(this.numID.Value.Trim());        	
          //obj.SPAdID = Convert.ToInt32(this.numSPAdID.Value.Trim());        	
          //obj.SPPackID = Convert.ToInt32(this.numSPPackID.Value.Trim());        	
          //obj.SPClientID = Convert.ToInt32(this.numSPClientID.Value.Trim());        	
          //obj.ReportDate = UIHelper.SaftGetDateTime(this.dateReportDate.Value.Trim());        	
          //obj.ClientCount = Convert.ToInt32(this.numClientCount.Value.Trim());        	
          //obj.AdCount = Convert.ToInt32(this.numAdCount.Value.Trim());        	
          //obj.AdAmount = Convert.ToDecimal(this.numAdAmount.Value.Trim());        	
          //obj.CreateBy = Convert.ToInt32(this.numCreateBy.Value.Trim());        	
          //obj.CreateAt = UIHelper.SaftGetDateTime(this.dateCreateAt.Value.Trim());        	
          //obj.LastModifyBy = Convert.ToInt32(this.numLastModifyBy.Value.Trim());        	
          //obj.LastModifyAt = UIHelper.SaftGetDateTime(this.dateLastModifyAt.Value.Trim());        	
          obj.LastModifyComment = this.txtLastModifyComment.Text.Trim();        	





                SPAdReportWrapper.Save(obj);

                winSPAdReportAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }




}

