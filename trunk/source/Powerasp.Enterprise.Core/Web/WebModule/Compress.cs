using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Net;
using System.Configuration;

namespace Powerasp.Enterprise.Core.Web.WebModule
{
    public abstract class Compress
    {
        protected bool gzip, deflate;
        protected string cachedir, cachefile, encoding, hash;
        protected FileType type;
        protected MemoryStream dataStream;
        protected HttpContext context;
        private HttpCompressionModuleConfigurationSection settings;

        // get the settings
        protected HttpCompressionModuleConfigurationSection Settings
        {
            get 
            {
                if (settings == null)
                {
                    if (context.Cache["DCCompressModuleConfig"] == null)
                    {
                        settings = (HttpCompressionModuleConfigurationSection)ConfigurationManager.GetSection("DCWeb/HttpCompress");
                        context.Cache["DCCompressModuleConfig"] = settings;
                    }
                    else
                        settings = (HttpCompressionModuleConfigurationSection)context.Cache["DCCompressModuleConfig"];
                    if (settings != null)
                    {
                        context.Cache.Insert("DCCompressModuleConfig", settings);
                    }
                }
                return settings; 
            }
        }
        // get the cache directory
        public string Cachedir
        {
            get
            {
                if (cachedir == null)
                {
                    cachedir = GetDirectory(Settings.CacheSettings.Path);
                }
                return cachedir;
            }
            set { cachedir = value; }
        }

        public void Init()
        {
            gzip = deflate = false;
            encoding = "none";
            dataStream = new MemoryStream();            
        }

        protected abstract void SetCachefile();

        // check if 'HTTP_IF_NONE_MATCH' is set. Denotes file is cached on browser.
        protected bool IsCachedOnBrowser()
        {
            
            if (!string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_IF_NONE_MATCH"]) &&
                context.Request.ServerVariables["HTTP_IF_NONE_MATCH"].Equals(hash))
            {
                context.Response.ClearHeaders();
                context.Response.AppendHeader("Etag", hash);
                context.Response.Status = "304 Not Modified";
                context.Response.AppendHeader("Content-Length", "0");
                return true;
            }
            return false;
        }
        // Send a chached file
        protected void SendCachedFile()
        {
            context.Response.ClearHeaders();
            context.Response.AppendHeader("Etag", hash);
            FileInfo info = new FileInfo(cachefile);
            if (encoding != "none")
                context.Response.AppendHeader("Content-Encoding", encoding);
            context.Response.ContentType = "text/" + type;
            context.Response.AppendHeader("Content-Length", info.Length.ToString());
            context.Response.WriteFile(cachefile);
        }
        // Send the data
        protected void SendFile()
        {
            byte[] data;

            context.Response.ClearHeaders();
            context.Response.AppendHeader("Etag", hash);            
            // compress the data
            if (encoding != "none")
            {
                data = CompressData(dataStream.ToArray(), encoding);
                context.Response.AppendHeader("Content-Encoding", encoding);
            }
            else
            {
                data = dataStream.ToArray();
            }
            // write the data out
            context.Response.ContentType = "text/" + type;
            context.Response.AppendHeader("Content-Length", data.Length.ToString());
            context.Response.BinaryWrite(data);
            // cache the file
            if (Settings.CacheSettings.CacheFiles)
                File.WriteAllBytes(cachefile, data);

            dataStream.Dispose();
        }

        // get the encoding type, not sure if this is the best way, but I got if from somewhere else.
        // Also can be converted to use the enums
        protected void SetEncoding()
        {
            // get the type of compression to use
            if (!string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_ACCEPT_ENCODING"]))
            {
                // get supported compression methods
                gzip = context.Request.ServerVariables["HTTP_ACCEPT_ENCODING"].ToLower().Contains("gzip");
                deflate = context.Request.ServerVariables["HTTP_ACCEPT_ENCODING"].ToLower().Contains("deflate");
            }

            //determin which to use
            encoding = gzip ? "gzip" : (deflate ? "deflate" : "none");

            // check for buggy versions of Internet Explorer
            if (context.Request.Browser.Browser == "IE")
            {
                if (context.Request.Browser.MajorVersion < 6)
                    encoding = "none";
                else if (context.Request.Browser.MajorVersion == 6 &&
                         !string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_USER_AGENT"]) &&
                         context.Request.ServerVariables["HTTP_USER_AGENT"].Contains("EV1"))
                    encoding = "none";
            }
        }
        protected static byte[] StrToByteArray(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }
        // compress the data
        protected byte[] CompressData(byte[] data, string type)
        {
            byte[] returnData;
            MemoryStream memStream = new MemoryStream();
            Stream compress = null;

            if (type == "gzip")
                compress = new GZipStream(memStream, CompressionMode.Compress);
            else if (type == "deflate")
                compress = new DeflateStream(memStream, CompressionMode.Compress);
            else
                throw new ApplicationException("Invalid compression type");

            compress.Write(data, 0, data.Length);
            returnData = memStream.ToArray();
            compress.Dispose();
            memStream.Dispose();
            return returnData;
        }
        // gets the directory set in the config file and deals with '/', '~/'
        protected string GetDirectory(string path)
        {
            path = path.Replace("/", "\\");
            if (path.StartsWith("\\"))
                path = path.Substring(1);
            else if (path.StartsWith("~\\"))
                path = path.Substring(2);
            path = context.Request.PhysicalApplicationPath + path;
            if (!path.EndsWith("\\"))
                path += "\\";
            return path;
        }
    }
}