using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Powerasp.Enterprise.Core.Web.ControlHelper
{
    public static class UIHelper
    {
        public static Control FindPagesControlByID(string cid,Page page)
        {
            if (page.Master == null)
                return page.FindControl(cid);
            else
                return page.Master.FindControl(cid);
        }


        /// <summary>
        /// 获得某个控件的子控件的ID的前缀
        /// </summary>
        /// <param name="control">控件（本方法用于获得该控件的子控件的ID的前缀）</param>
        /// <returns></returns>
        public static string GetChildControlPrefix(Control control)
        {
            if (control.NamingContainer.Parent == null)
            {
                return control.ID;
            }
            else
            {
                return String.Format("{0}_{1}", control.NamingContainer.ClientID, control.ID);
            }
        }
    }
}
