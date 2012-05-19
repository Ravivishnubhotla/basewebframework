using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public abstract class BaseTablesSelectorForm<T> : BaseObjectSelectorForm<T,ITable>
    {
        protected override string GetItemName(ITable obj)
        {
            return obj.Name;
        }
    }
}
