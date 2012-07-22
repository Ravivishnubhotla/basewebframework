using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = System.Web.UI.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientEdit")]
    public partial class UCSPClientEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
            }

        }

        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                if (ClientGroupID > 0)
                {
                    this.cmbClientGroupID.Hide();
                }

                SPClientWrapper obj = SPClientWrapper.FindById(id);

                if (obj != null)
                {
                    if (obj.Name!=null)
                        this.txtName.Text = obj.Name.ToString();
                    else
                        this.txtName.Text = "";

                    if (obj.Description != null)
                        this.txtDescription.Text = obj.Description.ToString();
                    else
                        this.txtDescription.Text = "";

                    if (obj.Alias != null)
                        this.txtAlias.Text = obj.Alias.ToString();
                    else
                        this.txtAlias.Text = "";

                    if (obj.SPClientGroupID != null)
                        this.hidClientGroupID.Text = obj.SPClientGroupID.Id.ToString();

                    int channelRate = 0;

                    if (obj.DefaultClientChannelSetting != null && obj.DefaultClientChannelSetting.ChannelID != null && obj.DefaultClientChannelSetting.ChannelID.Rate.HasValue)
                    {
                        channelRate = obj.DefaultClientChannelSetting.ChannelID.Rate.Value;
                    }

                    if (obj.DefaultClientChannelSetting != null && obj.DefaultClientChannelSetting.ChannelID != null)
                        lblDefaultChannelIntercept.Text = string.Format("上家“" + obj.DefaultClientChannelSetting.ChannelID.Name + "”默认扣率({0})", channelRate);
                    else
                        lblDefaultChannelIntercept.Text = "";


                    //if (obj.DefaultClientChannelSetting != null && obj.DefaultClientChannelSetting.ChannelID != null && obj.DefaultClientChannelSetting.ChannelID.Price.HasValue)
                    //    numPrice.Text = obj.DefaultClientChannelSetting.ChannelID.Price.Value.ToString("N2"); 
                    //else
                    //    numPrice.Text = obj.Price.ToString("N2");


                    if (obj.DefaultClientChannelSetting != null && obj.DefaultClientChannelSetting.DefaultClientPrice.HasValue && obj.DefaultClientChannelSetting.DefaultClientPrice.Value>0)
                        numPrice.Text = obj.DefaultClientChannelSetting.DefaultClientPrice.Value.ToString("N2");
                    else
                        numPrice.Text = obj.Price.ToString("N2");

   


                    hidId.Text = id.ToString();

                    winSPClientEdit.Show();

                }
                else
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
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

        protected void btnSaveSPClient_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientWrapper obj = SPClientWrapper.FindById(int.Parse(hidId.Text.Trim()));

                int oldClientGroupID = 0;

                if (obj.SPClientGroupID!=null)
                {
                    oldClientGroupID = obj.SPClientGroupID.Id;
                }

                obj.Name = this.txtName.Text.Trim();
                obj.Alias = this.txtAlias.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                if (ClientGroupID <= 0)
                {
                    if (this.cmbClientGroupID.SelectedItem!=null)
                    {
                        obj.SPClientGroupID =
                            SPClientGroupWrapper.FindById(Convert.ToInt32(this.cmbClientGroupID.SelectedItem.Value));
                    }
                }
                else
                {
                    obj.SPClientGroupID = SPClientGroupWrapper.FindById(ClientGroupID);
                }

                SPClientWrapper.Update(obj);

                int newClientGroupID = 0;

                if (obj.SPClientGroupID != null)
                {
                    newClientGroupID = obj.SPClientGroupID.Id;
                }

                if (newClientGroupID != 0 && oldClientGroupID != newClientGroupID)
                {
                    int interceptRate = 15;

                    if(rgdCustomIntercept.Checked)
                    {
                        interceptRate = Convert.ToInt32(numCustomerIntercept.Value);
                    }
                    if (rgdDefaultChannelIntercept.Checked)
                    {
                        if (obj.DefaultClientChannelSetting.ChannelID.Rate.HasValue)
                            interceptRate = obj.DefaultClientChannelSetting.ChannelID.Rate.Value;
                        else
                            interceptRate = 15;
                    }
                    if (rgdDefaultClientIntercept.Checked)
                    {
                        interceptRate = obj.SPClientGroupID.DefaultInterceptRate;
                    }

                    obj.UpdateSyncDataSetting(interceptRate);
                }

                //更新为通道价格
                //if (obj.DefaultClientChannelSetting != null && obj.DefaultClientChannelSetting.ChannelID != null && obj.DefaultClientChannelSetting.ChannelID.Price.HasValue)
                //    obj.SetClientPrice(obj.DefaultClientChannelSetting.ChannelID.Price.Value);
                //else
                obj.SetClientPrice(Convert.ToDecimal(numPrice.Value));

                winSPClientEdit.Hide();
                
            }
            catch (Exception ex)
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                    return;
                }

 
        }

        protected void storeSPChannelGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannelGroup.DataSource = SPClientGroupWrapper.FindAll();
            this.storeSPChannelGroup.DataBind();
        }
    }
}
 