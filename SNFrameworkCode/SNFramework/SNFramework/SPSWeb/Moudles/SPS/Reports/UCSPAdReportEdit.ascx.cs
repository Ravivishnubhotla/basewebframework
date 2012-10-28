  

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
                //this.numSPAdID.Value = obj.SPAdID.ToString();          	
                //this.numSPPackID.Value = obj.SPPackID.ToString();          	
                //this.numSPClientID.Value = obj.SPClientID.ToString();          	
                //this.dateReportDate.Value = obj.ReportDate.ToString();          	
                //this.numClientCount.Value = obj.ClientCount.ToString();          	
                //this.numAdCount.Value = obj.AdCount.ToString();          	
                //this.numAdAmount.Value = obj.AdAmount.ToString();          	
                //this.numCreateBy.Value = obj.CreateBy.ToString();          	
                //this.dateCreateAt.Value = obj.CreateAt.ToString();          	
                //this.numLastModifyBy.Value = obj.LastModifyBy.ToString();          	
                //this.dateLastModifyAt.Value = obj.LastModifyAt.ToString();          	
                //this.txtLastModifyComment.Text = ValueConvertUtil.ConvertStringValue(obj.LastModifyComment);          	
 



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
          //obj.LastModifyComment = this.txtLastModifyComment.Text.Trim();        	


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

