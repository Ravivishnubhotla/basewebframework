using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Parameter = Ext.Net.Parameter;

namespace GmapApplication.PDFViewer
{
    public partial class PDFManage : System.Web.UI.Page
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

                this.Panel3.AutoLoad.Url = "PDFViewer.aspx";
                this.Panel3.AutoLoad.Mode = LoadMode.IFrame;
                this.Panel3.AutoLoad.NoCache = true;
                this.Panel3.AutoLoad.Params.Clear();
                this.Panel3.AutoLoad.Params.Add(new Parameter("FileName",fileName));
                this.Panel3.LoadContent();

 
 
            }

        }
    }
}