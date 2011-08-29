using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GmapApplication.NewFolder1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextBox1.Text.Trim()))
                File.WriteAllText(this.Server.MapPath("~/" + this.TextBox1.Text.Trim() + ".txt"), this.TextBox1.Text.Trim()); 

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextBox1.Text.Trim()))
            {
                Directory.CreateDirectory(this.Server.MapPath("~/" + this.TextBox1.Text.Trim()));
            }
 
        }
    }
}