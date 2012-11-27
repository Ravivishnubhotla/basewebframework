using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin.ADOFrameworks
{
    public abstract class AdoViewBaseSelector<TC> : BaseObjectSelectorForm<TC, IView> where TC : AdoBaseViewConfig
    {
        protected override List<string> GetDefaultSelectObject()
        {
            return new List<string>();
        }

        protected override string GetDefaultDataBaseName()
        {
            return "";
        }
    }
}
