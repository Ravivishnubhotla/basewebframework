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
    public partial class ReportForCodeCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
                dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-3);
                dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);
                dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1);
                dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

                BindData();
            }
        }

        private void BindData()
        {


            DataTable dt = SPDayReportWrapper.GetDayCountReportForMaster((DateTime)dfReportStartDate.DateField.Value, (DateTime)dfReportEndDate.DateField.Value);

            if (dt.Columns["SPClientGroupName"]==null)
            {
                dt.Columns.Add("SPClientGroupName");
            }

            foreach (DataRow dataRow in dt.Rows)
            {
                if(dataRow["ClientID"]==System.DBNull.Value || dataRow["ClientID"].Equals(0))
                {
                    dataRow["SPClientGroupName"] = "";
                }
                else if (dataRow["ClientGroupID"] != System.DBNull.Value && !dataRow["ClientGroupID"].Equals(0))
                {
                    SPClientGroupWrapper clientGroupWrapper = SPClientGroupWrapper.FindById((int)dataRow["ClientGroupID"]);

                    if (clientGroupWrapper != null)
                    {
                        dataRow["SPClientGroupName"] = clientGroupWrapper.Name;
                    }
                    else
                    {
                        dataRow["SPClientGroupName"] = "";
                    }
                }
                else
                {
                    SPClientWrapper clientWrapper = SPClientWrapper.FindById((int)dataRow["ClientID"]);

                    if (clientWrapper != null)
                    {
                        dataRow["SPClientGroupName"] = clientWrapper.ClientGroupName;
                    }
                    else
                    {
                        dataRow["SPClientGroupName"] = "";
                    }
                }
            }


            this.Store1.DataSource = dt;
            this.Store1.DataBind();
 
        }


 


        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            BindData();
        }
    }
}