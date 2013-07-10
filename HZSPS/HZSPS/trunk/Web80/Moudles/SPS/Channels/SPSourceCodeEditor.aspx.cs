using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    public partial class SPSourceCodeEditor : System.Web.UI.Page
    {
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            string sourceText = File.ReadAllText(FileName, Encoding.GetEncoding("gb2312"));

            File.WriteAllText(FileName, sourceText, Encoding.UTF8);
 
            sourceText = File.ReadAllText(FileName, Encoding.UTF8);

            if (sourceText.Contains("</script>"))
                sourceText = sourceText.Replace("</script>", "</ script>");
            
            this.txtSource.Text = sourceText;

            //this.txtSource.Text = sourceText;
        }


        public string FileName
        {
            get
            {
                if (this.Request.QueryString["FileName"] == null)
                    return "";
                return this.Request.QueryString["FileName"];
            }
        }

        protected void btnSaveSource_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                string sourceText = this.txtSource.Text.Trim();
                if (sourceText.Contains("</ script>"))
                    sourceText = sourceText.Replace("</ script>", "</script>");
                File.WriteAllText(FileName, sourceText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}