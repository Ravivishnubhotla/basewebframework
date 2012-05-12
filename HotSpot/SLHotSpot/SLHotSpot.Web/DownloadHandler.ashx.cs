using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SLHotSpot.Web
{
    /// <summary>
    /// Summary description for DownloadHandler
    /// </summary>
    public class DownloadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            HttpResponse Response = context.Response;
            HttpRequest Request = context.Request;

            

 

            try
            {
                string fileurl = Request["url"];  

                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(fileurl);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream str = response.GetResponseStream();

                    MemoryStream ms = new MemoryStream();

                    byte[] read = new byte[255];

                    int count = str.Read(read, 0, read.Length);

                    while (count>0)
                    {
                        ms.Write(read, 0, count);
                        count = str.Read(read, 0, read.Length);
                    }

                    byte[] files = ms.ToArray();
 
 
                    Response.Clear();
                    Response.AddHeader("Content-Length", files.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(System.Text.Encoding.GetEncoding(65001).GetBytes(Path.GetFileName(fileurl))));

                    Response.BinaryWrite(files);
                    Response.Flush();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error : " + ex.Message);
            }
            finally
            {
 
                Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}