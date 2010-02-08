using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Legendigital.Framework.Common.Utility
{
    public static class WebControlHelper
    {



        public static void BindCheckValuesToCheckBoxList(List<string> checkValues, CheckBoxList chkl)
        {
            foreach (ListItem item in chkl.Items)
            {
                item.Selected = checkValues.Contains(item.Value);
            }
        }


        public static List<string>  GetCheckBoxListCheckValues(CheckBoxList chkl)
        {
            List<string> checkValues = new List<string>();
            foreach (ListItem item in chkl.Items)
            {
                if(item.Selected)
                    checkValues.Add(item.Value);
            }
            return checkValues;
        }

        public static TControlType FindTypedControl<TControlType>(Control parentControl,string controlID) where TControlType: Control
        {
            Control findcontrol = parentControl.FindControl(controlID);
            if (findcontrol != null)
                return (TControlType)findcontrol;
            else
                return default(TControlType);

        }
    }
}
