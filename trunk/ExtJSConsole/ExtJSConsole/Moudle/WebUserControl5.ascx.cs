using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExtJSConsole.Moudle
{
    public partial class WebUserControl5 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            this.SystemApplicationInfoDetailsWindow.Show();
        }

        public void Hide()
        {
            this.SystemApplicationInfoDetailsWindow.Hide();
        }

        protected void SendClick(object sender, EventArgs e)
        {
 
            Hide();
        }
    }
}