using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class RecordSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SPChannelWrapper.PROPERTY_NAME_ISDISABLE, "false", FilterFunction.EqualTo));

            List<SPChannelWrapper> channels = SPChannelWrapper.FindAllByOrderByAndFilter(filters, SPChannelWrapper.PROPERTY_NAME_ID, true);

            storeSPChannel.DataSource = channels;

            storeSPChannel.DataBind();

        }

        protected void storeSPChannelClientSetting_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int channelID = int.Parse(e.Parameters["ChannelID"].ToString());

            SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(channelID);

            storeSPChannelClientSetting.DataSource = channelWrapper.GetAllClientChannelSetting();

            storeSPChannelClientSetting.DataBind();
        }

        protected void ToExcel(object sender, EventArgs e)
        {
            int channelID = 0;
            if (this.cmbChannelID.SelectedItem != null && !string.IsNullOrEmpty(this.cmbChannelID.SelectedItem.Value.ToString()))
            {
                channelID = Convert.ToInt32(this.cmbChannelID.SelectedItem.Value.ToString());
            }
            int clientChannelID = 0;
            if (this.cmbCode.SelectedItem != null && !string.IsNullOrEmpty(this.cmbCode.SelectedItem.Value.ToString()))
            {
                clientChannelID = Convert.ToInt32(this.cmbCode.SelectedItem.Value.ToString());
            }
            List<string> phones = new List<string>();
            if (!string.IsNullOrEmpty(this.txtPhone.Text.Trim()))
            {
                string[] arrays = this.txtPhone.Text.Trim().Replace("\r\n", "\n").Replace("\n", "|").Split('|');

                foreach (string line in arrays)
                {
                    if (!string.IsNullOrEmpty(line.Trim()))
                    {
                        phones.Add(line);
                    }
                }
            }

            int recordCount = 0;

            List<SPPaymentInfoWrapper> paymentInfoWrappers = SPPaymentInfoWrapper.FindAllByChannelIDAndClientChannelIDAndPhoneListByOrderBy(channelID, clientChannelID, phones, SPPaymentInfoWrapper.PROPERTY_NAME_ID,
                                                                      false,
                                                                      1, 1000, out recordCount);

 

            this.Response.Clear();
            this.Response.ContentType = "application/vnd.ms-excel";
            this.Response.AddHeader("Content-Disposition", "attachment; filename=exportData.xls");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<td>linkid</td><td>手机号</td><td>上行指令</td><td>通道号码</td><td>日期</td>");
            sb.AppendLine("</tr>");
            foreach (SPPaymentInfoWrapper spPaymentInfoWrapper in paymentInfoWrappers)
            {
                sb.AppendLine("<tr>");
                sb.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td><td style='vnd.ms-excel.numberformat:@'>{1}</td><td style='vnd.ms-excel.numberformat:@'>{2}</td><td style='vnd.ms-excel.numberformat:@'>{3}</td><td style='vnd.ms-excel.numberformat:@'>{4}</td>", spPaymentInfoWrapper.Linkid,spPaymentInfoWrapper.MobileNumber,spPaymentInfoWrapper.Ywid,spPaymentInfoWrapper.Cpid,spPaymentInfoWrapper.CreateDate);
                sb.AppendLine("");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");
            this.Response.Write(sb.ToString());
            this.Response.End();
        }

        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            int channelID = 0;
            if (!string.IsNullOrEmpty(e.Parameters["ChannelID"]))
            {
                channelID = Convert.ToInt32(e.Parameters["ChannelID"]);
            }
            int clientChannelID = 0;
            if (!string.IsNullOrEmpty(e.Parameters["ChannelClientID"]))
            {
                clientChannelID = Convert.ToInt32(e.Parameters["ChannelClientID"]);
            }
            List<string> phones  = new List<string>();
            if (!string.IsNullOrEmpty(e.Parameters["txtPhone"]))
            {
                string[] arrays = e.Parameters["txtPhone"].Replace("\r\n","|").Split('|');

                foreach (string line in arrays)
                {
                    if(!string.IsNullOrEmpty(line.Trim()))
                    {
                        phones.Add(line);
                    }
                }
            }

            store1.DataSource = SPPaymentInfoWrapper.FindAllByChannelIDAndClientChannelIDAndPhoneListByOrderBy(channelID, clientChannelID, phones, sortFieldName,
                                                                      (e.Dir == Coolite.Ext.Web.SortDirection.DESC),
                                                                      pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            store1.DataBind();


        }
    }
}