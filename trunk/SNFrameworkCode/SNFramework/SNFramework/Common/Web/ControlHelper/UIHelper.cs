using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Legendigital.Framework.Common.Web.ControlHelper
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



        public static string FormatBoolField(object obj)
        {
            if (obj == DBNull.Value)
                return "否";
            if (obj is bool)
            {
                if ((bool)obj)
                    return "是";
                else
                    return "否";
            }
            else
            {
                return "";
            }
        }

        public static string FormatDateTimeField(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            else
                return datetime.Value.ToShortDateString();
        }

        public static string FormatDateTimeField(string dateTimeString, string format)
        {
            if (string.IsNullOrEmpty(dateTimeString))
                return "";
            else
                return DateTime.Parse(dateTimeString).ToString(format);
        }

        public static DateTime? SaftGetDateTime(string parsevalue)
        {
            if (string.IsNullOrEmpty(parsevalue))
                return null;
            if (parsevalue.Trim() == "")
                return null;
            else
                return DateTime.Parse(parsevalue);
        }

        public static bool? GetBool(string parsevalue)
        {
            if (parsevalue.Trim() == "")
                return false;
            else
                return bool.Parse(parsevalue);
        }

        public static bool SafeGetBoolValueString(object parsevalue)
        {
            if (parsevalue == null || parsevalue == DBNull.Value)
                return false;
            bool returnvalue = false;
            if (bool.TryParse(parsevalue.ToString(), out returnvalue))
                return returnvalue;
            else
                return false;
        }

    }
}