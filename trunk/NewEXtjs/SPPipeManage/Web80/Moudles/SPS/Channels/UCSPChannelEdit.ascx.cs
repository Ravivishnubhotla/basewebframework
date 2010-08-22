using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
   [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPChannelEdit")]
    public partial class UCSPChannelEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(id);

                if (obj != null)
                {
				    this.txtName.Text = obj.Name.ToString();          	
              	    this.txtDescription.Text = obj.Description.ToString();          	
              	    this.txtArea.Text = obj.Area.ToString();

                    if (!string.IsNullOrEmpty(obj.ChannelCodeParamsName))
                        this.cmbChannelCodeParamsName.SetValue(obj.ChannelCodeParamsName);
                    else
                        this.cmbChannelCodeParamsName.SetValue("");

              	    this.txtChannelCode.Text = obj.ChannelCode.ToString();

              	    this.txtFuzzyCommand.Text = obj.FuzzyCommand.ToString();
                    this.txtPort.Text = obj.Port.ToString();          	
              	    this.txtChannelType.Text = obj.ChannelType.ToString();
                    this.txtPrice.Text = obj.Price.ToString();
                    this.txtRate.Text = obj.Rate.ToString();
                    this.txtOkMessage.Text = obj.OkMessage;
                    this.txtFailedMessage.Text = obj.FailedMessage;
 



                    hidId.Text = id.ToString();


                    winSPChannelEdit.Show();

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

        protected void btnSaveSPChannel_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.Area = this.txtArea.Text.Trim();

                obj.ChannelCode = this.txtChannelCode.Text.Trim();

                if (this.cmbChannelCodeParamsName.SelectedItem != null)
                    obj.ChannelCodeParamsName = this.cmbChannelCodeParamsName.SelectedItem.Value;
                else
                    obj.ChannelCodeParamsName = "";

                obj.FuzzyCommand = this.txtFuzzyCommand.Text.Trim();
                obj.Port = this.txtPort.Value.ToString();
                obj.ChannelType = this.txtChannelType.Text.Trim();
                obj.Price = Convert.ToDecimal(this.txtPrice.Value);
                obj.Rate = Convert.ToInt32(this.txtRate.Value);
                obj.Status = 0;
                obj.OkMessage = txtOkMessage.Text.Trim();
                obj.FailedMessage = txtFailedMessage.Text.Trim();


                SPChannelWrapper.Update(obj);

                winSPChannelEdit.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }

}