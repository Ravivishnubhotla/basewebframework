﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin.ADOFrameworks
{
    public abstract class AdoTableBaseSelector<TC> : BaseObjectSelectorForm<TC, ITable> where TC : AdoBaseTableConfig
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
