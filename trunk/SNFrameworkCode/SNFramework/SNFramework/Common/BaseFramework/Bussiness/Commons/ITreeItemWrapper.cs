using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Web.UI;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Commons
{
    public interface ITreeItemWrapper
    {
        List<ITreeItemWrapper> FindAllItems();

        ITreeItemWrapper ParentDataItemID { get; }

        object DataKeyId { get;  }

        string NodeName { get; }

        string NodeCode { get; }     

    }
}
