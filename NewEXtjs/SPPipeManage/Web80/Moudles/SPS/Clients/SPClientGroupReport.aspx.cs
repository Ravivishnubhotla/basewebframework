using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using System.Text;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientGroupReport : System.Web.UI.Page
    {
        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

            dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1);

            dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

            dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-8);

            this.gridPanelSPClientChannelSetting.Reload();
        }

 

        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            DataTable tb = SPDayReportWrapper.GetClientGroupPriceReport(ClientGroupID,Convert.ToDateTime( dfReportStartDate.DateField.Value).Date, Convert.ToDateTime(this.dfReportEndDate.DateField.Value).Date);

            store1.DataSource = tb;
            store1.DataBind();
        }

        protected void storeData_Submit(object sender, StoreSubmitDataEventArgs e)
        {


            XmlNode xml = e.Xml;

            this.Response.Clear();

            this.Response.Charset = "GB2312";
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform(); 
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            string temp = "";
            System.IO.Stream str = new System.IO.MemoryStream();

            xtExcel.Transform(xml, null, str);

            str.Flush();
            str.Position = 0;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(str, System.Text.Encoding.GetEncoding("GB2312")))
            {
                temp = sr.ReadToEnd();
            };


            temp = temp.Replace("encoding=\"utf-8\"", "encoding=\"GB2312\"");


            this.Response.Write(temp);


            this.Response.End();
        }
    }
}