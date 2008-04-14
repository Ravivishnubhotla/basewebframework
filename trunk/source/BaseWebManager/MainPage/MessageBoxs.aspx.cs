using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BaseWebManager.UC;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Utility;

namespace BaseWebManager.MainPage
{
    public partial class MessageBoxs : System.Web.UI.Page
    {
        public string ReturnScript = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string CMD = this.Request.QueryString["CMD"];
            if (!Page.IsPostBack)
            {
                WebMessage MBx = new WebMessage();
                ArrayList lst = new ArrayList();
                if (CMD == "AppError")
                {
                    List<WebNavigationUrl> ListUrl = new List<WebNavigationUrl>();
                    ListUrl.Add(new WebNavigationUrl("确定", "default.aspx", "", UrlType.Href, true));

                    MBx.M_Body = "抱歉，处理您的请求时发生了错误。错误信息已被记录，我们将追踪解决。";
                    MBx.M_Title = "系统错误";
                    MBx.M_IconType = Icon_Type.Error;
                    MBx.M_ButtonList = ListUrl;
                }
                else
                {
                    MBx = WebMessageBox.CurrentWebMessage;
                }
                ReturnScript = MBx.M_ReturnScript;
                Header.Title = MBx.M_Title;
                
                lst.Add(MBx);
                MessageDispBox.DataSource = lst;
                MessageDispBox.DataBind();
            }
        }

        /// <summary>
        /// 根据icon类型返回图片名称
        /// </summary>
        /// <param name="I_type"></param>
        /// <returns></returns>
        public string Get_M_IconType(Icon_Type I_type)
        {
            switch (I_type)
            {
                case Icon_Type.Error:
                    return "MessageError.gif";
                case Icon_Type.Alert:
                    return "MessageAlert.gif";
                case Icon_Type.OK:
                    return "MessageOk.gif";
            }
            return "MessageAlert.gif";
        }

        public string Get_M_ButtonList(List<WebNavigationUrl> M_ButtonList)
        {
            string DefaultSelectButtonName = "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < M_ButtonList.Count; i++)
            {
                string NameKey = string.Format("Message_Button{0}", i);
                string url = "";
                if (M_ButtonList[i].btnDefaultSelect)
                    DefaultSelectButtonName = NameKey;
                switch (M_ButtonList[i].btnType)
                {
                    case UrlType.Href:
                        url = string.Format("JavaScript:window.location.href='{0}';", ResolveClientUrl(M_ButtonList[i].btnUrl));
                        break;
                    case UrlType.JavaScript:
                        url = string.Format("JavaScript:{0}", M_ButtonList[i].btnUrl);
                        break;
                    case UrlType.VBScript:
                        url = string.Format("VBScript:{0}", M_ButtonList[i].btnUrl);
                        break;
                }
                sb.AppendFormat("<input type='button' ID='{3}' class='AdminButton' onClick=\"{0}\" value='{1}' title='{2}'> ", url, M_ButtonList[i].btnText, M_ButtonList[i].btnHint, NameKey);
            }

            if (DefaultSelectButtonName != "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "kk", string.Format("document.all.{0}.focus();", DefaultSelectButtonName), true);
            }
            return sb.ToString();
        }

        protected void MessageDispBox_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Control c = e.Item.FindControl("tdHead");
            if(c is HtmlTableCell)
            {
                HtmlTableCell tdHead = (HtmlTableCell)c;
                tdHead.Attributes["background"] = this.ResolveUrl(tdHead.Attributes["background"]);
            }

            Control c1 = e.Item.FindControl("tdBody");
            if (c1 is HtmlTableCell)
            {
                HtmlTableCell tdBody = (HtmlTableCell)c1;
                tdBody.Attributes["background"] = this.ResolveUrl(tdBody.Attributes["background"]);
            }
        }
    }
}
