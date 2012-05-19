using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin.ADOFrameworks
{
    public abstract class ADOFrameworkBaseSingleObjectForm<TC, TT> : BaseObjectSelectorForm<TC, TT>
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
