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


        public static List<string> GetCheckBoxListCheckValues(CheckBoxList chkl)
        {
            List<string> checkValues = new List<string>();
            foreach (ListItem item in chkl.Items)
            {
                if (item.Selected)
                    checkValues.Add(item.Value);
            }
            return checkValues;
        }


        public static void BindChoiceValues(ListControl chkl, string choiceSetting, string splitRow, string splitChar)
        {

            chkl.Items.Clear();
            string[] str;

            List<string> list = new List<string>();
            list.AddRange(choiceSetting.Split(splitRow.ToCharArray()));

            foreach (string s in list)
            {
                if (s.Contains(splitChar))
                {
                    str = s.Split(splitChar.ToCharArray());
                    chkl.Items.Add(new ListItem(str[1], str[0]));

                }
                else
                {
                    chkl.Items.Add(new ListItem(s));
                }
            }

        }



        public static string GetChoiceValues(ListControl chkl, string splitChar)
        {
            string result = string.Empty;

            foreach (ListItem item in chkl.Items)
            {
                if (item.Selected)
                {
                    result += item.Value;
                    result += splitChar;
                }

            }

            if (result != string.Empty)
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;

        }

        public static void SetChoiceValues(ListControl chkl, string checkvalue, string splitChar)
        {


            string[] str = checkvalue.Split(splitChar.ToCharArray());

            foreach (ListItem item in chkl.Items)
            {

                if (str.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }


        }

        public static string GetFullWebUrl(Page page, string url)
        {
            string rooturl = page.ResolveUrl(url);

            Uri baseUrl;

            if (page.Request.Url.Port!=80)
                baseUrl = new Uri(string.Format("{0}://{1}:{2}/", page.Request.Url.Scheme, page.Request.Url.Host, page.Request.Url.Port));
            else
                baseUrl = new Uri(string.Format("{0}://{1}/", page.Request.Url.Scheme, page.Request.Url.Host));

            return new Uri(baseUrl, rooturl).ToString();
        }


        public static TControlType FindTypedControl<TControlType>(Control parentControl, string controlID) where TControlType : Control
        {
            Control findcontrol = parentControl.FindControl(controlID);
            if (findcontrol != null)
                return (TControlType)findcontrol;
            else
                return default(TControlType);

        }
    }
}
