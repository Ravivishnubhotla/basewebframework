using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            this.SystemApplicationInfoAddWindows.Show();
        }

        public void Hide()
        {
            this.SystemApplicationInfoAddWindows.Hide();
        }


        protected void SaveAction(object sender, AjaxEventArgs e)
        {
            SystemApplicationWrapper systemApplicationWrapper = new SystemApplicationWrapper();

            systemApplicationWrapper.SystemApplicationName = this.txtSystemApplicationName.Text;
            systemApplicationWrapper.SystemApplicationDescription = this.txtSystemApplicationDescription.Text;
            systemApplicationWrapper.SystemApplicationUrl = this.txtSystemApplicationUrl.Text;
            systemApplicationWrapper.SystemApplicationIsSystemApplication =
                this.chkSystemApplicationIsSystemApplication.Checked;

            SystemApplicationWrapper.Save(systemApplicationWrapper);

            ((WebForm1)this.Page).ReLoadData();

            e.Success = true;

            Hide();
        }

    }
}