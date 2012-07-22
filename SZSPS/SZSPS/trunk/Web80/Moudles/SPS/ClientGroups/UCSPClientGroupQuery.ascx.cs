using System;
using System.Collections.Generic;
using System.Linq;
 
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
 

namespace Legendigital.Common.Web.Moudles.SPS.ClientGroups
{
        [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientGroupQuery")]
    public partial class UCSPClientGroupQuery : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void storeSPChannelClientSetting_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            if(!string.IsNullOrEmpty(hidId.Text))
            {
                int clientGroupID = int.Parse(hidId.Text);

                SPClientGroupWrapper obj = SPClientGroupWrapper.FindById(clientGroupID);

                storeSPChannelClientSetting.DataSource = obj.GetAllChannelClientSetting();

                storeSPChannelClientSetting.DataBind();
            }

        }

        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientGroupWrapper obj = SPClientGroupWrapper.FindById(id);

                if (obj != null)
                {
                    //this.lblChannelClientCode.Text = obj.ChannelClientCode;

                    //this.lblChannelName.Text = obj.ChannelName;

                    //this.lblClientGroupName.Text = obj.ClientGroupName;

                    this.lblName.Text = obj.Name;

                    this.lblResult.Text = "";

                    hidId.Text = id.ToString();

                    winSPClientGroupQuery.Show();

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


        protected void btnSPClientGroupQuery_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientGroupWrapper obj = SPClientGroupWrapper.FindById(int.Parse(hidId.Text.Trim()));


                int? channelClientID = null;


                if (this.cmbCode.SelectedItem != null && this.cmbCode.SelectedItem.Value.ToString() != "")
                {
                    channelClientID = int.Parse(this.cmbCode.SelectedItem.Value);
                }

                string province = string.Empty;


                if (this.cmbProvince.SelectedItem != null)
                {
                    province = this.cmbProvince.SelectedItem.Value.ToString();
                }

                int dataCount = obj.QueryDataCount(dfStart.SelectedDate, dfEnd.SelectedDate, channelClientID, false, province,this.txtMo.Text.Trim(),this.txtSpcode.Text.Trim(),this.chkIncludeSubCode.Checked);
                int dataCountAfterIntercept = obj.QueryDataCount(dfStart.SelectedDate, dfEnd.SelectedDate, channelClientID, true, province, this.txtMo.Text.Trim(), this.txtSpcode.Text.Trim(), this.chkIncludeSubCode.Checked);
                int phoneCount = obj.QueryPhoneCount(dfStart.SelectedDate, dfEnd.SelectedDate, channelClientID, false, province, this.txtMo.Text.Trim(), this.txtSpcode.Text.Trim(), this.chkIncludeSubCode.Checked);
                int phoneCountAfterIntercept = obj.QueryPhoneCount(dfStart.SelectedDate, dfEnd.SelectedDate, channelClientID, true, province, this.txtMo.Text.Trim(), this.txtSpcode.Text.Trim(), this.chkIncludeSubCode.Checked);


                string message = "";

                if (channelClientID.HasValue)
                {
                    SPClientChannelSettingWrapper code = SPClientChannelSettingWrapper.FindById(channelClientID.Value);
                    message += "指令：" + code.MoCode;
                }

                this.lblResult.Text = string.Format(message+"总数扣前：{0},用户数扣前{1},总数扣后：{2},用户数扣后{3}", dataCount, phoneCount, dataCountAfterIntercept, phoneCountAfterIntercept);



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