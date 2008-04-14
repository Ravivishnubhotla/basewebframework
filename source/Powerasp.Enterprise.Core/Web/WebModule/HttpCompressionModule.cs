/// 
/// As a starting point for this module i used the Blowery module written by Ben Lowery.
/// his blog is located at : http://www.blowery.org/blog/
/// After studying the module that he wrote I couldn't see the point of all the inherited streams
/// because the one we use is already limited with a bunch of constraints.
/// http://www.blowery.org/code/HttpCompressionModule.html
/// The version he has for .net 2.0 is ported from .net 1.1 and the configuration properties don't follow 
/// the new schema anymore. 
/// Because of the change from #ziplib to the native .net 2.0 everything that has to do with quality 
/// doesn't count anymore.
/// I decided to rewrite his library to a .net 2.0 version of it which turned out to be much shorter.
/// So this module is copyrighted by Ivan Porto Carrero, Flanders International Marketing Ltd. 2006
/// Blog : http://www.flanders.co.nz/blog
/// You are free to use this module as long as you keep this notice in the source files
/// 
/// 23/01/2006
/// I changed the module to do work at the post release request state event in stead of at begin request.
/// When fired with begin request the parameters get zipped and form values get affected which kills the correct processing of the page.
/// The compression now takes place after the entire content has been created.
/// 
/// The above was written by Flanders.
/// The Items I added are marked with DC.
/// 
/// A quick explanation of the web resource compression.  A call to WebResource.axd using
/// the module breaks it for some reason.  I tried a lot of different things to get around this
/// but to no avail.  Finally I came up with the following solution.  Hook into the begin request
/// and check if it is a webResource.axd.  If it is then call CompleteRequest so it goes straight
/// to the EndRequest method.  This is so no processing is done on the request.  In EndRequest,
/// send it to the CompressWebResource object.  This then checks to see if there is an Etag (cached on browser),
/// if there is it sends a Not Modified header. (The webresource is loaded every time normally, this adds
/// browser cache ability to WebResource files.)  Then I check if a file is cached, if it is then I 
/// send the cached file.  Otherwise, I create a HttpWebRequest and request the WebResource.axd, but add a 'u=1'
/// to the query string so I know to let it pass through the above and retrieves the WebResource.
/// Then I check the content-type, if it is neither javascript or css then I send it to the 
/// browser, first adding an Etag to allow browser caching.  If it is javascript or css,
/// then get the allowed encoding and encode the data and cache it on disk.
/// 
/// 
/// I expect the credit to be given where credit is due.  The module is created by Flanders
/// and the above copyright applies.  The Compress.cs,CompressHandler.cs,and CompressWebResource.cs
/// were created by me, Darick Carpenter.  The CompressHandler is a port from PHP obtained here:
/// http://rakaz.nl/item/make_your_pages_load_faster_by_combining_and_compressing_javascript_and_css_files
/// and the copyright from that port is on CompressHandler.cs.  The CompressWebResource was
/// created by me and I echo the copyright notice in CompressHandler.cs offering no warranty.  
/// 
/// Darick Carpenter
///
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Configuration;

namespace Powerasp.Enterprise.Core.Web.WebModule
{
    /// <summary>
    /// The Http Module that will compress the outputstream to the browser if it is supported by the browser.
    /// </summary>
    public class HttpCompressionModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            /* The Post Release Request State is the event most fitted for the task of adding a filter
            // Everything else is too soon or too late. At this point in the execution phase the entire 
             * response content is created and the page has fully executed but still has a few modules to go through
             * from an asp.net perspective.  We filter the content here and all of the javascript renders correctly.*/
            context.PostReleaseRequestState += new EventHandler(context_PostReleaseRequestState);
            // DC
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        // DC
        void context_EndRequest(object sender, EventArgs e)
        {
            // Check if the request is for a webResource.  If it doesn't have a query paramenter
            // 'u', send it to the CompressResource object. CompressResource adds the 'u'
            // so we know if it's already come through.
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;
            if (context.Request.Path.Contains("WebResource.axd") && app.Context.Request.QueryString["u"] == null)
            {
                CompressWebResource compress = new CompressWebResource();
                compress.CompressResource(context);
            }
        }

        // DC
        void context_BeginRequest(object sender, EventArgs e)
        {
            // Check if the request is for a webResource. If it is, call complete request
            // so it doesn't do any unnecessary processing.
            // Also, if a query parameter 'u' is included, do not call complete.
            // This was added so I could call a webResource without processing it.
            HttpApplication app = (HttpApplication)sender;
            if (app.Context.Request.Path.Contains("WebResource.axd") && app.Context.Request.QueryString["u"] == null)
                app.CompleteRequest();
        }

        void context_PostReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            // DC - Added so update panel (AspAtlas) works
            if (app.Request["HTTP_X_MICROSOFTAJAX"] != null || app.Request["Anthem_CallBack"] != null)
                return;

             

            string realPath = "";
            HttpCompressionModuleConfigurationSection settings = null;
            // get the config settings
            if (app.Context.Cache["DCCompressModuleConfig"] == null)
            {
                settings = (HttpCompressionModuleConfigurationSection)ConfigurationManager.GetSection("DCWeb/HttpCompress");
                app.Context.Cache["DCCompressModuleConfig"] = settings;
            }
            else
                settings = (HttpCompressionModuleConfigurationSection)app.Context.Cache["DCCompressModuleConfig"];
            if (settings != null)
            {
                app.Context.Cache.Insert("DCCompressModuleConfig", settings);
                if (settings.CompressionType == CompressionType.None)
                    // skip if the CompressionLevel is set to 'None'
                    return ;
                realPath = app.Request.Path.Remove(0, app.Request.ApplicationPath.Length);
                realPath = (realPath.StartsWith("/")) ? realPath.Remove(0, 1) : realPath;

                // DC - added to use included paths and mime types
                bool isIncludedPath,isIncludedMime;

                isIncludedPath = (settings.IncludedPaths.Contains(realPath) | settings.IncludedPaths.Contains("~/" + realPath));
                isIncludedMime = (settings.IncludedMimeTypes.Contains(app.Response.ContentType));

                if (!isIncludedPath && !isIncludedMime)
                {
                    // path was not included, so skip it
                    return;
                }

                if (settings.ExcludedPaths.Contains(realPath) | settings.ExcludedPaths.Contains("~/" + realPath))
                {
                    // skip if the file path excludes compression
                    return ;
                }

                if (settings.ExcludedMimeTypes.Contains(app.Response.ContentType))
                {
                    // skip if the MimeType excludes compression
                    return ;
                }
            }
            // fix to handle caching appropriately
            // see http://www.pocketsoap.com/weblog/2003/07/1330.html
            // Note, this header is added only when the request
            // has the possibility of being compressed...
            // i.e. it is not added when the request is excluded from
            // compression by CompressionLevel, Path, or MimeType          

            // DC - I had to move this because it was messing up the compressHandler and 
            //      compressWebResource Etag values.  This affected the caching of the files
            app.Context.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;
            string acceptedTypes = app.Request.Headers["Accept-Encoding"];

            // if we couldn't find the header, bail out
            if (acceptedTypes == null)
                return;

            // Current response stream
            Stream baseStream = app.Response.Filter;

            // If there are more than one possibility offered by the browser default to the preffered one from the web.config
            // If nothing is specified in the web.config default to GZip
            acceptedTypes = acceptedTypes.ToLower();

            if ((acceptedTypes.Contains("gzip") || acceptedTypes.Contains("x-gzip") || acceptedTypes.Contains("*")) && (settings.CompressionType != CompressionType.Deflate))
            {
                app.Response.Filter = new GZipStream(baseStream, CompressionMode.Compress);
                //This won't show up in a trace log but if you use fiddler or nikhil kothari's web dev helper BHO you can see it appended
                app.Response.AppendHeader("Content-Encoding", "gzip");
            }
            else if (acceptedTypes.Contains("deflate"))
            {
                app.Response.Filter = new DeflateStream(baseStream, CompressionMode.Compress);
                //This won't show up in a trace log but if you use fiddler or nikhil kothari's web dev helper BHO you can see it appended
                app.Response.AppendHeader("Content-Encoding", "deflate");
            }
        }
        
        #endregion
        
       
    }
}