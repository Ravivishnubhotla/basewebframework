using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.Web.Moudles.SPS.Codes
{
        [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPCodeInfoAdd")]
    public partial class UCSPCodeInfoAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show()
        {
            try
            {
 

                this.winSPCodeInfoAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


        protected void btnSaveSPCodeInfo_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPCodeInfoWrapper obj = new SPCodeInfoWrapper();

                if(this.cmbChannelID.SelectedItem!=null)
                    obj.ChannelID = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannelID.SelectedItem.Value.ToString()));

                obj.OperatorType = cmbOperatorType.SelectedItem.Value;
                obj.Mo = txtMo.Text.Trim();
                obj.CodeType = cmbCodeType.SelectedItem.Value;
                obj.SPCode = txtSPCode.Text.Trim();
                obj.IsLimit = this.chkIsLimit.Checked;
                obj.IsEnable = this.chkIsEnable.Checked;

                obj.Province = this.txtProvince.Text.Trim();
                obj.SendText = this.txtSendText.Text.Trim();
                obj.Comment = this.txtComent.Text.Trim();
                obj.DayMonthLimit = this.txtDayMonthLimit.Text.Trim();
                obj.DisableArea = this.txtDisableArea.Text.Trim();
                obj.Price = this.txtPrice.Text.Trim();
                obj.CreateTime = System.DateTime.Now;
                obj.CreateUser = this.ParentPage.CurrentLoginUser.UserID;
 
                SPCodeInfoWrapper.Save(obj);

                winSPCodeInfoAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}