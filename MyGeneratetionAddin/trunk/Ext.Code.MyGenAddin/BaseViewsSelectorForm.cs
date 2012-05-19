using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public abstract class BaseViewsSelectorForm<T> : BaseObjectSelectorForm<T, IView>
    {
        protected override string GetItemName(IView obj)
        {
            return obj.Name;
        }
    }
}
