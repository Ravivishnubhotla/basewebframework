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
    public partial class WebUserControl1 : Spring.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindDate(SystemApplicationWrapper systemApplicationWrapper)
        {
            this.txtSystemApplicationID.Text = systemApplicationWrapper.SystemApplicationID.ToString();

            this.txtSystemApplicationName.Text = systemApplicationWrapper.SystemApplicationName.ToString();

            this.txtSystemApplicationDescription.Text = systemApplicationWrapper.SystemApplicationDescription.ToString();

            this.txtSystemApplicationUrl.Text = systemApplicationWrapper.SystemApplicationUrl.ToString();

            this.chkSystemApplicationIsSystemApplication.Checked = systemApplicationWrapper.SystemApplicationIsSystemApplication.HasValue?systemApplicationWrapper.SystemApplicationIsSystemApplication.Value:false;
        }

        public void Show()
        {
            this.SystemApplicationInfoDetailsWindow.Show();
        }

        public void Hide()
        {
            this.SystemApplicationInfoDetailsWindow.Hide();
        }


        protected void SaveAction(object sender, AjaxEventArgs e)
        {
          


            SystemApplicationWrapper systemApplicationWrapper =
                SystemApplicationWrapper.FindById(int.Parse(this.txtSystemApplicationID.Text));

            if (systemApplicationWrapper!=null)
            {
                systemApplicationWrapper.SystemApplicationName = this.txtSystemApplicationName.Text;
                systemApplicationWrapper.SystemApplicationDescription = this.txtSystemApplicationDescription.Text;
                systemApplicationWrapper.SystemApplicationUrl = this.txtSystemApplicationUrl.Text;
                systemApplicationWrapper.SystemApplicationIsSystemApplication =
                    this.chkSystemApplicationIsSystemApplication.Checked;

                SystemApplicationWrapper.Update(systemApplicationWrapper);

                

                e.Success = true;
            }

            ((WebForm1)this.Page).ReLoadData();
            Hide();


        }
    }
}