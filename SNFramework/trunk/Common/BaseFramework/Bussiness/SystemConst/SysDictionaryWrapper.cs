using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst
{
    public class SysDictionaryWrapper
    {
        public const string Dictionary_Key_UserRoleType = "UserRoleType";

        public static List<SystemDictionaryWrapper> UserRoleTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_UserRoleType);
            }
        }

        public static string ParseUserRoleTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_UserRoleType, key);
        }

        public static void BindDictionaryToListControl(ListControl list, string categoryName)
        {
            list.DataSource = SystemDictionaryWrapper.GetDictionaryByCategoryName(categoryName);
            list.DataTextField = SystemDictionaryWrapper.PROPERTY_NAME_SYSTEMDICTIONARYVALUE;
            list.DataValueField = SystemDictionaryWrapper.PROPERTY_NAME_SYSTEMDICTIONARYKEY;
            list.DataBind();

            if (list.Items.Count > 0)
            {
                list.SelectedIndex = 0;
            }
        }

    }
    }
