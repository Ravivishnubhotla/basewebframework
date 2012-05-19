using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public abstract class BaseProceducesSelectorForm<T> : BaseObjectSelectorForm<T, IProcedure>
    {
        protected override string GetItemName(IProcedure obj)
        {
            return obj.Name;
        }
    }
}
