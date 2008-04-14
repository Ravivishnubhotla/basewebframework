using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Powerasp.Enterprise.Core.Resource
{
    public class ResourceReaderHelper
    {
        private static SortedList<string, ResourceManager> resourceManagerlist =
            new SortedList<string, ResourceManager>(); 

        public static string GetStringFromResource(string key,string resourcePath)
        {
            if(!resourceManagerlist.ContainsKey(resourcePath))
            {
                resourceManagerlist.Add(key, new ResourceManager(resourcePath, Type.GetType("Powerasp.Enterprise.Core.Resource.ResourceReader").Assembly));
            }
            return resourceManagerlist[resourcePath].GetString(key);
        }
    }
}
