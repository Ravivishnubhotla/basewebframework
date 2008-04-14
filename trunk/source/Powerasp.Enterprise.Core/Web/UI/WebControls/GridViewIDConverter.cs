using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Powerasp.Enterprise.Core.Web.UI.WebControls
{
    public class GridViewIDConverter : ControlIDConverter
    {
        // Methods
        protected override bool FilterControl(Control control)
        {
            return control is GridView;
        }
    }
}
