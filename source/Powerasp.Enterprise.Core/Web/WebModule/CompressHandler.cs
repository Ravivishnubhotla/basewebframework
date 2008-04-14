///
/// This is based on the article found here: http://rakaz.nl/item/make_your_pages_load_faster_by_combining_and_compressing_javascript_and_css_files
/// which talks about the benefits of combining javascript and css into one file as well as 
/// compressing it. I am including the 'copyright' from the php file which this was ported from
///    /************************************************************************ 
///     * CSS and Javascript Combinator 0.5
///     * Copyright 2006 by Niels Leenheer 
///     * 
///     * Permission is hereby granted, free of charge, to any person obtaining 
///     * a copy of this software and associated documentation files (the 
///     * "Software"), to deal in the Software without restriction, including 
///     * without limitation the rights to use, copy, modify, merge, publish, 
///     * distribute, sublicense, and/or sell copies of the Software, and to 
///     * permit persons to whom the Software is furnished to do so, subject to 
///     * the following conditions: 
///     *  
///     * The above copyright notice and this permission notice shall be 
///     * included in all copies or substantial portions of the Software. 
///     * 
///     * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
///     * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
///     * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
///     * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
///     * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
///     * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
///     * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
///     */ 
/// I echo the copy right for this software
/// 

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using Powerasp.Enterprise.Core.Web.WebModule;

namespace Powerasp.Enterprise.Core.Web.WebModule
{
    public class CompressionHandler : Compress,IHttpHandler
    {
        private string appPath, fileBasePath;
        private StringCollection files;
        public string AppPath
        {
            get 
            { 
                if(appPath == null)
                    appPath = context.Request.PhysicalApplicationPath;
                return appPath; 
            }
        }        
        DateTime lastmodified;

        public void SetFileBasePath()
        {
            if (type == FileType.javascript)
                fileBasePath = Settings.PathSettings.JsPath;
            else if (type == FileType.css)
                fileBasePath = Settings.PathSettings.CssPath;
            else
                throw new ApplicationException("Invalid type");
            fileBasePath = GetDirectory(fileBasePath);
            
        }

        #region IHttpHandler Members

        public void Init()
        {
            base.Init();
            fileBasePath = null;
            appPath = null;
            lastmodified = DateTime.MinValue;
            files = new StringCollection();
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext _context)
        {
            this.context = _context;
            Init();

            string tempType = context.Request.QueryString["type"];
            if (tempType != null)
                type = tempType == "javascript" || tempType == "js" ? FileType.javascript : tempType == "css" ? FileType.css : FileType.none;
            else
            {
                string path = Path.GetFileNameWithoutExtension(context.Request.Path);
                type = path == "js" || path == "javascript" ? FileType.javascript : (path == "css" ? FileType.css : FileType.none);
                
            }
            SetFileBasePath();

            // get list of files
            string[] tempFiles = context.Request.QueryString["files"].Split(',');

            // determine the last modification date of the files

            foreach (string file in tempFiles)
            {
                string tempfile = file.Replace("/","\\");
                if (file.EndsWith("*"))
                    tempfile = tempfile.Substring(0,tempfile.Length - 1);
                if(!CheckFiles(fileBasePath + tempfile))
                    return;

            }

            // get the type of compression to use
            SetEncoding();

            // Send E-tag hash
            hash = string.Format("{0}-{1}-{2}", lastmodified.ToFileTime(), GetMd5Sum(context.Request.QueryString["files"]), encoding);
            
            if (IsCachedOnBrowser())
                return;
            
            // determine the cache file to store data in
            SetCachefile();

            // if the cachefile exists, send it.
            if (File.Exists(cachefile))
            {
                SendCachedFile();
                return;
            }

            // Get contents of the file

            StringBuilder fileText = new StringBuilder();
            byte[] data;
            foreach (string file in files)
            {
                fileText.Append(File.ReadAllText(file));
                fileText.Append(Environment.NewLine);
                fileText.Append(Environment.NewLine);
            }
            // Add some new lines so javascript doesn't get cut off
            fileText.Append(Environment.NewLine);
            fileText.Append(Environment.NewLine);
            data = StrToByteArray(fileText.ToString());
            dataStream.Write(data, 0, data.Length);

            SendFile();                           
            
        }

        #endregion

        protected override void SetCachefile()
        {
            if (string.IsNullOrEmpty(encoding))
                SetEncoding();
            cachefile = Cachedir + string.Format("cache-{0}.{1}{2}", hash, type, encoding != "none" ? "." + encoding : "");
        }
        private string GetMd5Sum(string str)
        {
            // First we need to convert the string into bytes, which
            // means using a text encoder.
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            // Now that we have a byte array we can ask the CSP to hash it
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            // Build the final string by converting each byte
            // into hex and appending it to a StringBuilder
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            // And return it
            return sb.ToString();
        }        
        private bool CheckFiles(string filePath)
        {
            if (File.Exists(filePath))
            {
                if (type == FileType.javascript && !filePath.EndsWith(".js") ||
                    type == FileType.css && !filePath.EndsWith(".css"))
                {
                    context.Response.Status = "403 Forbidden";
                    return false;
                }
                files.Add(filePath);
                if (lastmodified < File.GetLastWriteTime(filePath))
                    lastmodified = File.GetLastWriteTime(filePath);
                return true;
            }
            else if (Directory.Exists(filePath))
            {
                string fileType = type == FileType.javascript ? "js" : "css";
                DirectoryInfo info = new DirectoryInfo(filePath);
                foreach (FileInfo file in info.GetFiles("*." + fileType))
                {
                    if (!CheckFiles(file.FullName))
                        return false;
                }
                return true;
            }
            else
            {
                context.Response.Status = "404 File not found";
                return false;
            }
        }
    }
}