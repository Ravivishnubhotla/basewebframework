using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class DataProviceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            SPClientWrapper spClientWrapper = SPClientWrapper.FindById(this.SPClientID);

            if (IsClientShow)
            {
                this.lblTitle.Text = string.Format(" 通道 【{0}】 ", spClientWrapper.DisplayName);

                this.lblTitle.Text += string.Format(" 日期 【{0}】 到 【{1}】 ", StartDate.ToShortDateString(),EndDate.ToShortDateString());

                this.lblTitle.Text += " 数据省份分布 ";
            }

            this.grdReport.Reload();
        }

        public bool IsClientShow
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["IsClientShow"]))
                {
                    return (this.Request.QueryString["IsClientShow"].Equals("1"));
                }
                return false;
            }          
        }


        public int ChannleID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["ChannleID"]))
                {
                    return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
                }
                return 0;
            }
        }

        public int SPClientID
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["ClientID"]))
                {
                    return Convert.ToInt32(this.Request.QueryString["ClientID"]);
                }
                return 0;
            }
        }


        public DateTime StartDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["StartDate"]))
                {
                    return Convert.ToDateTime(this.Request.QueryString["StartDate"].Replace("\"", ""));
                }
                return DateTime.MinValue;
            }
        }


        public DateTime EndDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["EndDate"]))
                {
                    return Convert.ToDateTime(this.Request.QueryString["EndDate"].Replace("\"", ""));
                }
                return DateTime.MinValue;
            }
        }


        public DataType DType
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["DataType"]))
                {
                    string dataType = this.Request.QueryString["DataType"];

                    switch (dataType.ToLower())
                    {
                        case "totalcountdetail":
                            return DataType.All;
                        case "interceptcountdetail":
                            return DataType.Intercept;
                        case "downcountdetail":
                            return DataType.Down;
                        case "downsycncountdetail":
                            return DataType.DownSycn;
                    }

                }
                return DataType.DownSycn;
            }
        }

        protected void storeData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            DataTable dt = SPDayReportWrapper.GetProvinceCountReport(ChannleID, this.SPClientID, Convert.ToDateTime(this.StartDate), Convert.ToDateTime(this.EndDate), DType);

            //object result = dt.Compute("Sum(DataCount)","");

            //if (result != System.DBNull.Value)
            //    this.txtTotalCount.Text = "总计：0";
            //else
            //    this.txtTotalCount.Text = "总计：" + result.ToString();

            storeData.DataSource = dt;

            storeData.DataBind();
        }
    }
}