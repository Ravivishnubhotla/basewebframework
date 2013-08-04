using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class DetailRecordView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            SPClientWrapper spClientWrapper = SPClientWrapper.FindById(this.SPClientID);

            SPClientChannelSettingWrapper clientChannelSettingWrapper = spClientWrapper.DefaultClientChannelSetting;

            bool isSycnData = (clientChannelSettingWrapper != null && clientChannelSettingWrapper.SyncData.HasValue &&
                               clientChannelSettingWrapper.SyncData.Value);

            storeData.Reader.Add(GetJsonReaderByDataTable(SPChannelWrapper.FindById(this.ChannleID), isSycnData));

            this.GridPanel1.StoreID = "storeData";

            this.PagingToolBar1.StoreID = "storeData";
        }


        protected void storeData_Submit(object sender, StoreSubmitDataEventArgs e)
        {


            XmlNode xml = e.Xml;

            this.Response.Clear();


            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=downloaddata.xls");
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(Server.MapPath("Excel.xsl"));
            xtExcel.Transform(xml, null, Response.OutputStream);


            this.Response.End();
        }


        protected void ToExcel(object sender, EventArgs e)
        {
            DataTable dt =
                SPPaymentInfoWrapper.FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate(ChannleID,
                this.SPClientID, Convert.ToDateTime(this.StartDate),
                Convert.ToDateTime(this.EndDate), DType, "CreateDate", true);

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.AppendLine("<td>" + dt.Columns[i].ColumnName + "</td>");
            }
            sb.AppendLine("</tr>");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                sb.AppendLine("<tr>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.AppendLine("<td style='mso-number-format:\"\\@\"'>" + dt.Rows[j][dt.Columns[i].ColumnName] + "</td>");
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");

            this.Response.Write(sb.ToString());

            this.Response.End();
        }




        private DataReader GetJsonReaderByDataTable(SPChannelWrapper channelWrapper, bool isSycnData)
        {
            JsonReader reader = new JsonReader();

            reader.ReaderID = "RecordID";

            reader.Fields.Add("RecordID", RecordFieldType.Int);
            reader.Fields[reader.Fields.Count - 1].Mapping = "RecordID";

            reader.Fields.Add("CreateDate", RecordFieldType.Date);
            reader.Fields[reader.Fields.Count - 1].Mapping = "CreateDate";
            this.GridPanel1.ColumnModel.Columns.Add(NewColumn("colCreateDate", "日期", false, "CreateDate", "Ext.util.Format.dateRenderer('n/d/Y H:i:s A')", RendererFormat.None));
            this.GridPanel1.ColumnModel.Columns[this.GridPanel1.ColumnModel.Columns.Count - 1].Width = 150;

            reader.Fields.Add("Province", RecordFieldType.String);
            reader.Fields[reader.Fields.Count - 1].Mapping = "Province";
            this.GridPanel1.ColumnModel.Columns.Add(NewColumn("colProvince", "省份", false, "Province", "", RendererFormat.None));

            reader.Fields.Add("City", RecordFieldType.String);
            reader.Fields[reader.Fields.Count - 1].Mapping = "City";
            this.GridPanel1.ColumnModel.Columns.Add(NewColumn("colCity", "城市", false, "City", "", RendererFormat.None));

            if(isSycnData)
            {

                reader.Fields.Add("IsSycnData", RecordFieldType.String);
                reader.Fields[reader.Fields.Count - 1].Mapping = "IsSycnData";
                this.GridPanel1.ColumnModel.Columns.Add(NewColumn("colIsSycnData", "同步", false, "IsSycnData", "", RendererFormat.None));

                reader.Fields.Add("SucesssToSend", RecordFieldType.String);
                reader.Fields[reader.Fields.Count - 1].Mapping = "SucesssToSend";
                this.GridPanel1.ColumnModel.Columns.Add(NewColumn("colSucesssToSend", "成功", false, "SucesssToSend", "", RendererFormat.None));

                reader.Fields.Add("SycnRetryTimes", RecordFieldType.String);
                reader.Fields[reader.Fields.Count - 1].Mapping = "SycnRetryTimes";
                this.GridPanel1.ColumnModel.Columns.Add(NewColumn("colSycnRetryTimes", "重试", false, "SycnRetryTimes", "", RendererFormat.None));

            }

            List<SPChannelParamsWrapper> channelParams = channelWrapper.GetAllShowParams();

            foreach (SPChannelParamsWrapper channelParam in channelParams)
            {
                string pName = channelParam.Name.ToString();
                reader.Fields.Add(channelParam.ParamsMappingName, RecordFieldType.String);
                reader.Fields[reader.Fields.Count - 1].Mapping = channelParam.ParamsMappingName.ToString();
                this.GridPanel1.ColumnModel.Columns.Add(NewColumn("col" + pName, pName, false, channelParam.ParamsMappingName.ToString(), "", RendererFormat.None));
            }

            reader.Fields.Add("SendUrl", RecordFieldType.String);
            reader.Fields[reader.Fields.Count - 1].Mapping = "SendUrl";

            return reader;




        }

        private Column NewColumn(string id, string header, bool cansort, string dataIndex, string render, RendererFormat rendererFormat)
        {
            Column col1 = new Column();
            col1.ColumnID = id;
            col1.Header = header;
            col1.Sortable = cansort;
            col1.DataIndex = dataIndex;
            if (!string.IsNullOrEmpty(render))
            {
                if (col1.Renderer == null)
                    col1.Renderer = new Renderer();
                col1.Renderer.Fn = render;
            }

            if (rendererFormat != RendererFormat.None)
            {
                if (col1.Renderer == null)
                    col1.Renderer = new Renderer();
                col1.Renderer.Format = rendererFormat;
            }

            return col1;
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
            int recordCount = 0;
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = this.PagingToolBar1.PageSize;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;

            DataTable dt = SPPaymentInfoWrapper.FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate(ChannleID, this.SPClientID, Convert.ToDateTime(this.StartDate), Convert.ToDateTime(this.EndDate), DType, "CreateDate", true, pageIndex, limit, out recordCount);

            SPClientWrapper spClientWrapper = SPClientWrapper.FindById(this.SPClientID);

            SPClientChannelSettingWrapper clientChannelSettingWrapper = spClientWrapper.DefaultClientChannelSetting;

            bool isSycnData = (clientChannelSettingWrapper != null && clientChannelSettingWrapper.SyncData.HasValue &&
                               clientChannelSettingWrapper.SyncData.Value); 

            if (storeData.Reader.Count == 0)
                storeData.Reader.Add(GetJsonReaderByDataTable(SPChannelWrapper.FindById(this.ChannleID), isSycnData));

            storeData.DataSource = dt;
            e.TotalCount = recordCount;

            storeData.DataBind();


        }
    }
}
