

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Net;
using Powerasp.Enterprise.Core.Web.WebModule;

namespace Powerasp.Enterprise.Core.Web.WebModule
{
    public class CompressWebResource : Compress
    {
        protected string assemblyName, assemblyTime;

        public CompressWebResource()
            : base()
        {
        }

        public void CompressResource(HttpContext context)
        {            
            this.context = context;
            // initialize the data
            Init();
            // get the query data
            assemblyName = context.Request.QueryString["d"];
            assemblyTime = context.Request.QueryString["t"];
            // get the encoding we want to use
            SetEncoding();

            // get the string for the Etag
            hash = string.Format("{0}-{1}", assemblyTime, assemblyName);

            // check the 'HTTP_IF_NONE_MATCH' string to see if it is cached on the browser
            // this is for content types other than javascript and css
            if (IsCachedOnBrowser())
                return;

            // get Etag to see if javascript or css is cached on browser with the type of encoding
            hash = string.Format("{0}-{1}-{2}", assemblyTime, assemblyName, encoding);

            // check the 'HTTP_IF_NONE_MATCH' string to see if it is cached on the browser
            if (IsCachedOnBrowser())
                return;

            // it's not cached on browser, so check if cached to disk.  We don't know the 
            // content-type since no processing has been done.  So we try javascript, if none found
            // try css.

            // check if chache files is true
            if (Settings.CacheSettings.CacheFiles)
            {
                type = FileType.javascript;
                SetCachefile();
                if (File.Exists(cachefile))
                {
                    SendCachedFile();
                    return;
                }
                type = FileType.css;
                SetCachefile();
                if (File.Exists(cachefile))
                {
                    SendCachedFile();
                    return;
                }
            }

            // resource was not chached on disk, so we need to get the data.
            // Tag a '&u=1' on the url and get the data.  The 'u' will be checked in the beginRequest
            // method in the HttpCompressionModule, if it is present, it won't be sent through here.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(context.Request.Url.OriginalString + "&u=1");
            HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
            string content_type = resp.ContentType.ToLower();
            Stream recDataStream = resp.GetResponseStream();
            // if the retrieved data is not javascript or css
            if (content_type != "application/x-javascript" && content_type != "text/javascript" && content_type != "text/css")
            {
                // set the Etag so the webresource will be cached by the browser and send it off.
                hash = string.Format("{0}-{1}", assemblyTime, assemblyName);
                context.Response.ClearHeaders();
                context.Response.AppendHeader("Etag", hash);
                context.Response.ContentType = resp.ContentType;
                CopyToStream(recDataStream, context.Response.OutputStream);
                return;
            }
            else
            {
                // Set the content type
                if (content_type.Contains("javascript"))
                    type = FileType.javascript;
                else if (content_type.Contains("text/css"))
                    type = FileType.css;

                // set the cach file
                SetCachefile();
                // get the data
                CopyToStream(recDataStream, dataStream);
                // sometimes when compressed, the data is cut off, not sure why.
                // but this assures all data is present.
                byte[] LFCR = StrToByteArray(Environment.NewLine + Environment.NewLine);
                dataStream.Write(LFCR, 0, LFCR.Length);
                dataStream.Write(StrToByteArray("    "), 0, 4);

                // compresses the data, cache it on disk, send it.
                SendFile();

            }
        }

        // copy one stream to another
        private void CopyToStream(Stream inStream, Stream outStream)
        {
            byte[] buff = new byte[1000];
            int read;
            int totalRead = 0;
            do
            {
                read = inStream.Read(buff, totalRead, 1000);
                outStream.Write(buff, 0, read);
            } while (read > 0);
        }
        // gets the file to be cached or has been cached
        protected override void SetCachefile()
        {
            if (string.IsNullOrEmpty(encoding))
                SetEncoding();
            cachefile = Cachedir + string.Format("webResource-{0}.{1}{2}", hash, type, encoding != "none" ? "." + encoding : "");
        }
    }
}