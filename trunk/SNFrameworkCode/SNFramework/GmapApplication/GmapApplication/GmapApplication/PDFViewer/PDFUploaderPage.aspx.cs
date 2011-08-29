using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace GmapApplication.PDFViewer
{
    public partial class PDFUploaderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadClick(object sender, DirectEventArgs e)
        {
 

            if (this.fufPDF.HasFile)
            {
                string fileName = System.DateTime.Now.Ticks.ToString("D16");

                this.fufPDF.PostedFile.SaveAs(this.Server.MapPath("~/PDFViewer/Files/" + fileName + ".pdf"));

                PDFSWFConvert.ConvertPdfToSwf(this.Server.MapPath("~/PDFViewer/Files/" + fileName + ".pdf"));


                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Success",
                    Message = "File "+fileName+".pdf upload ok "
                });
            }
 
        }

    }
}