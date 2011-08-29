using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GmapApplication.PDFViewer
{
    public class PDFSWFConvert
    {
        public const string swfToolsDir = "C:\\Program Files (x86)\\SWFTools\\pdf2swf.exe";
        public static void ConvertPdfToSwf(string pdfPath)
        {
            Process pc = new Process();
 
            ProcessStartInfo psi = new ProcessStartInfo(swfToolsDir, pdfPath + " -o " + pdfPath.Replace(".pdf",".swf") + " -f -T 9 -t -s storeallcharacters");
            psi.CreateNoWindow = true;
            pc.StartInfo = psi;
            pc.Start();
            pc.WaitForExit();
        }
    }
}