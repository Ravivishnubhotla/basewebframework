using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Codes
{

    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPCodeInfoEdit")]
    public partial class UCSPCodeInfoEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPCodeInfoWrapper obj = SPCodeInfoWrapper.FindById(id);

                if (obj != null)
                {

                    if (obj.ChannelID != null)
                        this.cmbChannelID.Value = obj.ChannelID.Id;



                    cmbOperatorType.Value = obj.OperatorType;
                    txtMo.Text = obj.Mo;
                    cmbCodeType.Value = obj.CodeType;
                    txtSPCode.Text = obj.SPCode;
                    this.chkIsLimit.Checked = obj.IsLimit;
                    this.chkIsEnable.Checked = obj.IsEnable;
                    this.txtProvince.Text = obj.Province;
                    this.txtSendText.Text = obj.SendText;

                    this.txtComent.Text = obj.Comment;

                    this.txtDayMonthLimit.Text = obj.DayMonthLimit;
                    this.txtDisableArea.Text = obj.DisableArea;
                    this.txtPrice.Text = obj.Price;




                    hidId.Text = id.ToString();

                    winSPCodeInfoEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPCodeInfo_Click(object sender, AjaxEventArgs e)
        {
            try
            {

                SPCodeInfoWrapper obj = SPCodeInfoWrapper.FindById(int.Parse(hidId.Text.Trim()));
                if (this.cmbChannelID.SelectedItem != null)
                    obj.ChannelID =
                        SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannelID.SelectedItem.Value.ToString()));

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


                SPCodeInfoWrapper.Update(obj);

                winSPCodeInfoEdit.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}