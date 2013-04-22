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
                    tfDayTimeLimitRangeStart.Value = CodeID.DayTimeLimitRangeStart;
                    tfDayTimeLimitRangeEnd.Value = CodeID.DayTimeLimitRangeEnd;
                }
                else
                {
                    tfDayTimeLimitRangeStart.Value = "";
                    tfDayTimeLimitRangeEnd.Value = "";
                }


                if (chkDayMonthTotalLimit.Checked)
                {
                    nfPhoneLimitDayCount.Value = CodeID.PhoneLimitDayCount;
                    nfPhoneLimitMonthCount.Value = CodeID.PhoneLimitMonthCount;
                }
                else
                {
                    nfPhoneLimitDayCount.Value = 0;
                    nfPhoneLimitMonthCount.Value = 0;
                }

                if (chkDayTotalLimit.Checked)
                {
                    nfDayTotalLimit.Value = CodeID.DayTotalLimitCount;
                }
                else
                {
                    nfDayTotalLimit.Value = 0;
                }

                if (CodeID.LimitProvince.HasValue && CodeID.LimitProvince.Value)
                {
                    this.fsLimitProvince.Disabled = false;
                    this.fsLimitProvince.Expand();

                    storeAreaCountList.DataSource = CodeID.PhoneLimitAreas;

                    storeAreaCountList.DataBind();

                }
                else
                {
                    this.fsLimitProvince.Disabled = true;
                    this.fsLimitProvince.Collapse();
                }


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