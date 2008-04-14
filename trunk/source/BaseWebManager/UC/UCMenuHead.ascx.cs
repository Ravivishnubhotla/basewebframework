using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing.Design;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Web;

namespace BaseWebManager.UC
{
    [
DefaultProperty("ButtonList"),
ParseChildren(true, "ButtonList"),
Description("头部菜单web控件")
]


    public partial class UCMenuHead : System.Web.UI.UserControl
    {
        private string moudleName = "";
        private string operationName = "";
        private List<HeadMenuButtonItem> _ButtonList;

        /// <summary>
        /// 按钮集合
        /// </summary>
        [
        Category("Behavior"),
        Description("按钮集合"),
        Editor(typeof(CollectionEditor), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<HeadMenuButtonItem> ButtonList
        {
            get
            {
                return _ButtonList;
            }
            set
            {
                _ButtonList = value;
            }
        }

        public string MoudleName
        {
            get { return moudleName; }
            set { moudleName = value; }
        }

        public string OperationName
        {
            get { return operationName; }
            set { operationName = value; }
        }

        private string CreateButtonHtml()
        {
            StringBuilder sb = new StringBuilder();
            if (_ButtonList != null && _ButtonList.Count > 0)
            {
                sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
                string OnUrlJs = "";
                string ButtonIcon = "";
                string ButtonTxt = "";
                for (int i = 0; i < _ButtonList.Count; i++)
                {
                    if (_ButtonList[i].ButtonVisible)
                    {
                        OnUrlJs = "";
                        ButtonIcon = "";
                        ButtonTxt = "";
                        switch (_ButtonList[i].ButtonUrlType)
                        {
                            case UrlType.Href:
                                OnUrlJs = string.Format("JavaScript:window.location.href='{0}';", this.Page.ResolveUrl(_ButtonList[i].ButtonUrl));
                                break;
                            case UrlType.JavaScript:
                                OnUrlJs = string.Format("JavaScript:{0}", _ButtonList[i].ButtonUrl);
                                break;
                            case UrlType.VBScript:
                                OnUrlJs = string.Format("VBScript:{0}", _ButtonList[i].ButtonUrl);
                                break;
                        }

                        ButtonIcon = _ButtonList[i].ButtonIcon;

                        sb.AppendFormat("<td class=\"menubar_button\" id=\"button_{1}\" OnClick=\"{0}\" OnMouseOut=\"javascript:MenuOnMouseOver(this);\" OnMouseOver=\"javascript:MenuOnMouseOut(this);\">", OnUrlJs, i);
                        sb.AppendFormat("<img border=\"0\" align=\"texttop\" src=\"{0}\">&nbsp;", this.Page.ResolveUrl(ButtonIcon));
                        sb.AppendFormat("{0}{1}</td>", ButtonTxt, _ButtonList[i].ButtonName);
                    }
                }
                sb.Append("</tr></table>");
            }
            if (sb.ToString() == string.Empty)
                sb.Append("&nbsp");
            return sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page.IsPostBack )
                return;
            this.lblMoudleName.Text = this.moudleName;
            this.lblOperationName.Text = this.operationName;
            this.tdButtonList.InnerHtml = CreateButtonHtml();
        }
    }
}