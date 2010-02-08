using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.Web.Handler
{
    public class DocumentViewHandler : IHttpHandler
    {
        public string GetFilePath(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.QueryString["FilePath"]))
                return "";
            return context.Request.QueryString["FilePath"];
        }


        public void ProcessRequest(HttpContext context)
        {
            //if (!context.Request.Url.IsFile)
            //    return;

            string filePath = GetFilePath(context);

            filePath = StringUtil.WebStringDecrypt(filePath);

            //string filePath = StringUtil.WebStringDecrypt(Path.GetFileNameWithoutExtension(context.Request.PhysicalPath));

            if (!File.Exists(filePath))
                return;

            byte[] fileContent = GetFileByte(filePath);

            context.Response.Clear();
            context.Response.AddHeader("content-disposition", "inline; filename=" + Path.GetFileName(filePath));
            context.Response.AddHeader("Content-Type", GetContentTypeByFileExtention(Path.GetExtension(filePath).ToUpper())); 
            context.Response.AddHeader("content-length", fileContent.Length.ToString());
            context.Response.BinaryWrite(fileContent);
            context.Response.Flush();
            context.Response.Close();
            context.Response.End();


        }

        protected byte[] GetFileByte(string filePath)
        {
            byte[] fileContent = null;

            using(FileStream myFile = File.OpenRead(filePath)) //读取文件进入FileStream
            {
                fileContent = new byte[myFile.Length];

                myFile.Read(fileContent, 0, (int)myFile.Length);  //将文件流中的内容转成byte数组

                myFile.Close();
            }

            return fileContent;
        }


        protected string GetContentTypeByFileExtention(string fileExt)
        {
            switch (fileExt)
            {
                case ".DOC":
                case ".DOCX":
                    return "application/msword";
                case ".XLS":
                case ".XLSX":
                    return "application/vnd.ms-excel";
                case ".PPT":
                case ".PPTX":
                    return "application/vnd.ms-powerpoint";
                case ".PDF":
                    return "application/pdf";
                case ".TXT":
                    return "text/plain";
                case ".JPG":
                case ".JPEG":
                    return "image/jpeg";
                case ".BMP":
                    return "application/x-bmp";
                case ".GIF":
                    return "image/gif";
                case ".TIF":
                    return "image/tif";
                case ".TIFF":
                    return "image/tiff";
                case ".HTM":
                case ".HTML":
                    return "text/HTML";
                default:
                    return "application/octet-stream";
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
