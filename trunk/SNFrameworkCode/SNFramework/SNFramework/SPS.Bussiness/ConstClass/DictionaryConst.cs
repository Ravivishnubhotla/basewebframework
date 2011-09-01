using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SPS.Bussiness.ConstClass
{

    public static class DictionaryConst
    {
        public const string Dictionary_Key_UserType = "UserType";

        public static List<SystemDictionaryWrapper> UserTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_UserType);
            }
        }

        public static string ParseUserTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_UserType, key);
        }
        #region KeyList
        public const string Dictionary_UserType_普通用户_Key = "1";
        public const string Dictionary_UserType_高级用户_Key = "2";
        public const string Dictionary_UserType_管理员_Key = "3";
        #endregion

        public const string Dictionary_Key_RoleType = "RoleType";

        public static List<SystemDictionaryWrapper> RoleTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_RoleType);
            }
        }

        public static string ParseRoleTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_RoleType, key);
        }
        #region KeyList
        public const string Dictionary_RoleType_普通角色_Key = "1";
        public const string Dictionary_RoleType_高级角色_Key = "2";
        public const string Dictionary_RoleType_管理员_Key = "3";
        #endregion

        public const string Dictionary_Key_SPField = "SPField";

        public static List<SystemDictionaryWrapper> SPFieldDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_SPField);
            }
        }

        public static string ParseSPFieldDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_SPField, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_Key_ChannelStatus = "ChannelStatus";

        public static List<SystemDictionaryWrapper> ChannelStatusDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_ChannelStatus);
            }
        }

        public static string ParseChannelStatusDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_ChannelStatus, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_Key_ChannelDataAdapterType = "ChannelDataAdapterType";

        public static List<SystemDictionaryWrapper> ChannelDataAdapterTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_ChannelDataAdapterType);
            }
        }

        public static string ParseChannelDataAdapterTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_ChannelDataAdapterType, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_Key_ChannelType = "ChannelType";

        public static List<SystemDictionaryWrapper> ChannelTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_ChannelType);
            }
        }

        public static string ParseChannelTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_ChannelType, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_Key_ChannelStateReportType = "ChannelStateReportType";

        public static List<SystemDictionaryWrapper> ChannelStateReportTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByCategoryName(Dictionary_Key_ChannelStateReportType);
            }
        }

        public static string ParseChannelStateReportTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByCategoryNameAndKey(Dictionary_Key_ChannelStateReportType, key);
        }
        #region KeyList
        #endregion

    }
}
