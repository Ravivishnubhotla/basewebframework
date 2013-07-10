using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    public partial class SPSourceCodeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            if (!string.IsNullOrEmpty(CopyFilePath))
            {
                this.txtFileName.Text = "cp"+Path.GetFileName(CopyFilePath);

                string sourceText = File.ReadAllText(CopyFilePath, Encoding.GetEncoding("gb2312"));

                File.WriteAllText(CopyFilePath, sourceText, Encoding.UTF8);

                sourceText = File.ReadAllText(CopyFilePath, Encoding.UTF8);

                if (sourceText.Contains("</script>"))
                    sourceText = sourceText.Replace("</script>", "</ script>");

                this.txtSource.Text = sourceText;
            }
 
        }


        protected void btnSaveSource_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                string sourceText = this.txtSource.Text.Trim();
                if (sourceText.Contains("</ script>"))
                    sourceText = sourceText.Replace("</ script>", "</script>");
                string saveFilePath = Path.Combine(SaveFilePath, this.txtFileName.Text.Trim());
                File.WriteAllText(saveFilePath, sourceText, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }



        public string CopyFilePath
        {
            get
            {
                if (this.Request.QueryString["CopyFilePath"] == null)
                    return "";
                return this.Request.QueryString["CopyFilePath"];
            }
        }

        public string SaveFilePath
        {
            get
            {
                if (this.Request.QueryString["SaveFilePath"] == null)
                    return "";
                return this.Request.QueryString["SaveFilePath"];
            }
        }

 
    }
}