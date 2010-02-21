using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle
{
    public partial class WebUserControl3 : System.Web.UI.UserControl
    {
        public void Show()
        {
            this.SeachWindow.Show();
        }

        public void Hide()
        {
            this.SeachWindow.Hide();
        }


        protected void SaveAction(object sender, AjaxEventArgs e)
        {
            WebForm1 page = ((WebForm1)this.Page);

            List<QueryFilter> query = new List<QueryFilter>();
            
            if(!string.IsNullOrEmpty(this.txtName.Text.Trim()))
                query.Add(new QueryFilter(SystemApplicationWrapper.PROPERTY_NAME_SYSTEMAPPLICATIONNAME,this.txtName.Text.Trim(),FilterFunction.Contains));

            page.ReLoadData();
            
            Hide();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}