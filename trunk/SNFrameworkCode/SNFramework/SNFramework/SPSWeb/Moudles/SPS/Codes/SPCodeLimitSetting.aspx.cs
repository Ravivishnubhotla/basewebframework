using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Code;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Codes
{
    public partial class SPCodeLimitSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            if (CodeID != null)
            {
                chkIsDayTimeLimit.Checked = CodeID.IsDayTimeLimit.HasValue && CodeID.IsDayTimeLimit.Value;

                chkDayMonthTotalLimit.Checked = CodeID.HasDayMonthLimit.HasValue && CodeID.HasDayMonthLimit.Value;

                chkDayTotalLimit.Checked = CodeID.HasDayTotalLimit;

                if (chkIsDayTimeLimit.Checked)
                {
                    tfDayTimeLimitRangeStart.SetValue(CodeID.DayTimeLimitRangeStart);
                    tfDayTimeLimitRangeEnd.SetValue(CodeID.DayTimeLimitRangeEnd);
                }
                //else
                //{
                //    tfDayTimeLimitRangeStart.SetValue("");
                //    tfDayTimeLimitRangeEnd.SetValue("");
                //}


                if (chkDayMonthTotalLimit.Checked)
                {
                    nfPhoneLimitDayCount.SetValue(CodeID.PhoneLimitDayCount);
                    nfPhoneLimitMonthCount.SetValue(CodeID.PhoneLimitMonthCount);
                }
                else
                {
                    nfPhoneLimitDayCount.SetValue(0);
                    nfPhoneLimitMonthCount.SetValue(0);
                }

                if (chkDayTotalLimit.Checked)
                {
                    nfDayTotalLimit.SetValue(CodeID.DayTotalLimitCount);
                }
                else
                {
                    nfDayTotalLimit.SetValue(0);
                }

                this.fsLimitProvince.Disabled = !(CodeID.LimitProvince.HasValue && CodeID.LimitProvince.Value);

                if (CodeID.LimitProvince.HasValue && CodeID.LimitProvince.Value)
                {
                    if (CodeID.DayTotalLimitInProvince.HasValue && CodeID.DayTotalLimitInProvince.Value)
                        this.fsLimitProvince.Expand();
                    else
                        this.fsLimitProvince.Collapse();

                    storeAreaCountList.DataSource = CodeID.PhoneLimitAreas;

                    storeAreaCountList.DataBind();

                }
                else
                {
                    storeAreaCountList.DataSource = CodeID.PhoneLimitAreas;

                    storeAreaCountList.DataBind();
                }


            }


        }

        protected void btnSaveSPCodeLimitSetting_Click(object sender, DirectEventArgs e)
        {

            try
            {
            SPCodeWrapper code = CodeID;

            code.IsDayTimeLimit = chkIsDayTimeLimit.Checked;

            code.HasDayMonthLimit = chkDayMonthTotalLimit.Checked;

            code.HasDayTotalLimit = chkDayTotalLimit.Checked;

            if (chkIsDayTimeLimit.Checked)
            {
                if (!string.IsNullOrEmpty(tfDayTimeLimitRangeStart.Text))
                {
                    CodeID.DayTimeLimitRangeStart = new DateTime(2013, 1, 1, Convert.ToInt32(tfDayTimeLimitRangeStart.Text.Split(':')[0]), Convert.ToInt32(tfDayTimeLimitRangeStart.Text.Split(':')[1]), 0);
                }
                else
                {
                    CodeID.DayTimeLimitRangeStart = new DateTime(2013, 1, 1, 0, 0, 0);
                }
                if (!string.IsNullOrEmpty(tfDayTimeLimitRangeEnd.Text))
                {
                    CodeID.DayTimeLimitRangeEnd = new DateTime(2013, 1, 1, Convert.ToInt32(tfDayTimeLimitRangeEnd.Text.Split(':')[0]), Convert.ToInt32(tfDayTimeLimitRangeEnd.Text.Split(':')[1]), 0);
                }
                else
                {
                    CodeID.DayTimeLimitRangeEnd = new DateTime(2013, 1, 1, 0, 0, 0);
                }
            }
            else
            {
                CodeID.DayTimeLimitRangeStart = new DateTime(2013,1,1,0,0,0);
                CodeID.DayTimeLimitRangeEnd = new DateTime(2013, 1, 1, 0, 0, 0);
            }
 


            if (chkDayMonthTotalLimit.Checked)
            {
                CodeID.PhoneLimitDayCount = Convert.ToInt32(nfPhoneLimitDayCount.Value);
                CodeID.PhoneLimitMonthCount = Convert.ToInt32(nfPhoneLimitMonthCount.Value);
            }
            else
            {
                CodeID.PhoneLimitDayCount = 0;
                CodeID.PhoneLimitMonthCount = 0;
            }

            if (chkDayTotalLimit.Checked)
            {
                CodeID.DayTotalLimitCount = Convert.ToInt32(nfDayTotalLimit.Value);
            }
            else
            {
                CodeID.DayTotalLimitCount = 0;
            }

            if (CodeID.LimitProvince.HasValue && CodeID.LimitProvince.Value)
            {
                CodeID.DayTotalLimitInProvince = !fsLimitProvince.Collapsed;

                CodeID.DayTotalLimitInProvinceAssignedCount = hidAreaCountList.Text;
            }

            SPCodeWrapper.Update(CodeID);


                        }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
                return;
            }
 
        }

        protected void storeAreaCountList_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeAreaCountList.DataSource = CodeID.PhoneLimitAreas;
            storeAreaCountList.DataBind();
        }


        public SPCodeWrapper CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return
                        SPCodeWrapper.FindById(int.Parse(this.Request.QueryString["CodeID"]));
                }
                return null;
            }
        }
    }
}