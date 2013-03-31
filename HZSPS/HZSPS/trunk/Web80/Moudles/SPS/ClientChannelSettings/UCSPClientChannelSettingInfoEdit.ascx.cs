using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingInfoEdit")]
    public partial class UCSPClientChannelSettingInfoEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(id);

                if (obj != null)
                {

                    this.lblChannelName.Text = obj.ChannelName;

                    this.lblClientName.Text = obj.ClientName;

                    this.lblClientName.Text = obj.ClientGroupName;

                    this.lblName.Text = obj.Name;

                    this.lblChannelClientCode.Text = obj.ChannelClientCode;

                    chkHasDayTotalLimit.Checked = obj.HasDayTotalLimit.HasValue && obj.HasDayTotalLimit.Value;
 
                    if (this.chkHasDayTotalLimit.Checked)
                    {
                        if (obj.DayTotalLimit.HasValue)
                            this.txtDayTotalLimit.Text = obj.DayTotalLimit.Value.ToString();
                        else
                            this.txtDayTotalLimit.Text = "0";

                        if (obj.DayTotalLimitInProvince.HasValue && obj.DayTotalLimitInProvince.Value)
                            this.chkDayTotalLimitInProvince.Checked = true;
                        else
                            this.chkDayTotalLimitInProvince.Checked = false;


                        
                    }
                    else
                    {
                        this.txtDayTotalLimit.Text = "0";
                        this.chkDayTotalLimitInProvince.Checked = false;
                    }

                    chkHasDayTimeLimit.Checked = obj.HasDayTimeLimit.HasValue && obj.HasDayTimeLimit.Value;

                    if (chkHasDayTimeLimit.Checked)
                    {
                        this.tfStart.Value = obj.DaylimitStartTime;
                        this.tfEnd.Value = obj.DaylimitEndTime;
                    }


                    this.txtDayTotalLimit.Hidden = !chkHasDayTotalLimit.Checked;
                    this.chkDayTotalLimitInProvince.Hidden = !chkHasDayTotalLimit.Checked;

                    if (obj.DefaultClientPrice.HasValue)
                        this.numDefaultPrice.Text = obj.DefaultClientPrice.Value.ToString("N2");
                    else
                        this.numDefaultPrice.Text = "0.00";


                    hidId.Text = id.ToString();

                    this.storeAreaCountList.DataSource = obj.LimitAreaAssigneds;
                    this.storeAreaCountList.DataBind();

                    this.grdAreaCountList.Hidden = !this.chkDayTotalLimitInProvince.Checked;

                    winSPClientChannelSettingInfoEdit.Show();

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

        protected void btnSaveSPClientChannelSetting_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(int.Parse(hidId.Text.Trim()));


                obj.HasDayTotalLimit = this.chkHasDayTotalLimit.Checked;
                obj.DayTotalLimit = Convert.ToInt32(this.txtDayTotalLimit.Value);
                obj.DayTotalLimitInProvince = chkDayTotalLimitInProvince.Checked;

                obj.DefaultPrice = Convert.ToDecimal(this.numDefaultPrice.Value);


                List<PhoneLimitAreaAssigned> phoneLimitAreaAssigneds = JsonConvert.DeserializeObject<List<PhoneLimitAreaAssigned>>(hidAreaCountList.Text);

                List<PhoneLimitAreaAssigned> phoneLimits = phoneLimitAreaAssigneds.FindAll(p => (p.LimitCount > 0 && !string.IsNullOrEmpty(p.AreaName)));

                obj.DayTotalLimitInProvinceAssignedCount = JsonConvert.SerializeObject(phoneLimits);



                obj.HasDayTimeLimit = chkHasDayTimeLimit.Checked;

                if (obj.HasDayTimeLimit.Value)
                {
                    List<TimeSpan> times = new List<TimeSpan>();

                    times.Add(this.tfStart.SelectedTime);
                    times.Add(this.tfEnd.SelectedTime);

                    obj.DayTimeLimit = JsonConvert.SerializeObject(times);

                }
                else
                {
                    obj.DayTimeLimit = "";
                }


                SPClientChannelSettingWrapper.Update(obj);


                if (obj.DefaultPrice.HasValue && obj.DefaultPrice.Value>0)
                    obj.ClinetID.SetClientPrice(obj.DefaultPrice.Value);

                obj.ChannelID.RefreshChannelInfo();

                winSPClientChannelSettingInfoEdit.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }

        protected void storeAreaCountList_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(int.Parse(hidId.Text.Trim()));

            this.storeAreaCountList.DataSource = obj.LimitAreaAssigneds;
            this.storeAreaCountList.DataBind();

        }
    }
}