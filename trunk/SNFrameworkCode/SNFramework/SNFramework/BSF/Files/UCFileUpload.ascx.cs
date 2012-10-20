using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SNFramework.BSF.AppCode;

namespace SNFramework.BSF.Files
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCFileUpload")]
    public partial class UCFileUpload : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show(string cpath)
        {
            try
            {
                this.hidUploadPath.Value = cpath;
                this.winFileUpload.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }

        protected void btnSaveUploadFile_Click(object sender, DirectEventArgs e)
        {
            try
            {
                string saveFileName = Path.GetFileName(this.fufUploadNewfile.PostedFile.FileName);

                string saveFilePath = this.hidUploadPath.Value.ToString();

                saveFileName = IOUtil.GenerateSaveFile(saveFilePath, saveFileName);

                this.fufUploadNewfile.PostedFile.SaveAs(Path.Combine(saveFilePath, saveFileName));


                winFileUpload.Hide();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message : " + ex.Message;
            }
        }
    }
}