using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;

namespace Legendigital.Framework.Common.Resources
{
    public class XmlResourceProviderFactory : ResourceProviderFactory
    {

        public override IResourceProvider CreateGlobalResourceProvider(string classKey)
        {

            string directory = HttpContext.Current.Server.MapPath("GlobalResources");

            return new XmlResourceProvider(directory, classKey);

        }



        public override IResourceProvider CreateLocalResourceProvider(string virtualPath)
        {

            string directory = HttpContext.Current.Server.MapPath(VirtualPathUtility.GetDirectory(virtualPath) + "\\App_LocalResources");

            string baseName = VirtualPathUtility.GetFileName(virtualPath);

            return new XmlResourceProvider(directory, baseName);

        }

    }
}
