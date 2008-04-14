using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Powerasp.Enterprise.Core.Web.ControlHelper
{
    public static class InputControlHelper
    {
        public static void ClearInputButton(HtmlInputButton btn,string[] clearAtrr)
        {
            foreach (string s in clearAtrr)
            {
                btn.Attributes.Remove(s);
            }
        }
    }
}
