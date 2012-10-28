  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Ads
{
 
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdAssignedHistortyAdd")]
    public partial class UCSPAdAssignedHistortyAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPAdAssignedHistortyAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPAdAssignedHistorty_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdAssignedHistortyWrapper obj = new SPAdAssignedHistortyWrapper();
          //obj.SPAdID = Convert.ToInt32(this.numSPAdID.Value);        	
          //obj.SPAdPackID = Convert.ToInt32(this.numSPAdPackID.Value);        	
          //obj.SPClientID = Convert.ToInt32(this.numSPClientID);        	
                obj.StartDate = this.dateStartDate.SelectedDate;        	
          //obj.EndDate = UIHelper.SaftGetDateTime(this.dateEndDate.Value.Trim());        	
          //obj.CreateBy = Convert.ToInt32(this.numCreateBy.Value.Trim());        	
          //obj.CreateAt = UIHelper.SaftGetDateTime(this.dateCreateAt.Value.Trim());        	
          //obj.LastModifyBy = Convert.ToInt32(this.numLastModifyBy.Value.Trim());        	
          //obj.LastModifyAt = UIHelper.SaftGetDateTime(this.dateLastModifyAt.Value.Trim());        	
          obj.LastModifyComment = this.txtLastModifyComment.Text.Trim();        	





                SPAdAssignedHistortyWrapper.Save(obj);

                winSPAdAssignedHistortyAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }




}

