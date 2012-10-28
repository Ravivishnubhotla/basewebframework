  

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

namespace SPSWeb.Moudles.SPS.Ads
{




    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPAdAssignedHistortyEdit")]
    public partial class UCSPAdAssignedHistortyEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPAdAssignedHistortyWrapper obj = SPAdAssignedHistortyWrapper.FindById(id);

                if (obj != null)
                {
					              	this.numSPAdID.Value = obj.SPAdID.ToString();          	
              	this.numSPAdPackID.Value = obj.SPAdPackID.ToString();          	
              	this.numSPClientID.Value = obj.SPClientID.ToString();          	
              	this.dateStartDate.Value = obj.StartDate.ToString();          	
              	this.dateEndDate.Value = obj.EndDate.ToString();          	
              	this.numCreateBy.Value = obj.CreateBy.ToString();          	
              	this.dateCreateAt.Value = obj.CreateAt.ToString();          	
              	this.numLastModifyBy.Value = obj.LastModifyBy.ToString();          	
              	this.dateLastModifyAt.Value = obj.LastModifyAt.ToString();          	
              	this.txtLastModifyComment.Text = ValueConvertUtil.ConvertStringValue(obj.LastModifyComment);          	
 



                    hidId.Text = id.ToString();


                    winSPAdAssignedHistortyEdit.Show();

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

        protected void btnSaveSPAdAssignedHistorty_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPAdAssignedHistortyWrapper obj = SPAdAssignedHistortyWrapper.FindById(int.Parse(hidId.Text.Trim()));
          //obj.SPAdID = Convert.ToInt32(this.numSPAdID.Value.Trim());        	
          //obj.SPAdPackID = Convert.ToInt32(this.numSPAdPackID.Value.Trim());        	
          //obj.SPClientID = Convert.ToInt32(this.numSPClientID.Value.Trim());        	
          //obj.StartDate = UIHelper.SaftGetDateTime(this.dateStartDate.Value.Trim());        	
          //obj.EndDate = UIHelper.SaftGetDateTime(this.dateEndDate.Value.Trim());        	
          //obj.CreateBy = Convert.ToInt32(this.numCreateBy.Value.Trim());        	
          //obj.CreateAt = UIHelper.SaftGetDateTime(this.dateCreateAt.Value.Trim());        	
          //obj.LastModifyBy = Convert.ToInt32(this.numLastModifyBy.Value.Trim());        	
          //obj.LastModifyAt = UIHelper.SaftGetDateTime(this.dateLastModifyAt.Value.Trim());        	
          //obj.LastModifyComment = this.txtLastModifyComment.Text.Trim();        	


                SPAdAssignedHistortyWrapper.Update(obj);

                winSPAdAssignedHistortyEdit.Hide();
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

