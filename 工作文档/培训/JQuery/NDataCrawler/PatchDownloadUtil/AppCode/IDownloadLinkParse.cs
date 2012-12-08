using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatchDownloadUtil.AppCode
{
    public interface IDownloadLinkParse
    {
        string Name { get; }
        List<DownloadLink> Parse(string parseUrl);
        void PatchDownloadByClient(List<DownloadLink> allDownloadLinks);
        bool CanPatchDownloadByClient { get; }
    }
}
