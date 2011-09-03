using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst
{
    public static class DictionaryConst
    {
        public const string Dictionary_GroupCode_UserType = "UserType";

        public static List<SystemDictionaryWrapper> UserTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_UserType);
            }
        }

        public static string ParseUserTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_UserType, key);
        }
        #region KeyList
        ///普通用户
        public const string Dictionary_UserType_NormalUser_Key = "1";
        ///高级用户
        public const string Dictionary_UserType_AdvUser_Key = "2";
        ///管理员
        public const string Dictionary_UserType_AdmUser_Key = "3";
        #endregion

        public const string Dictionary_GroupCode_RoleType = "RoleType";

        public static List<SystemDictionaryWrapper> RoleTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_RoleType);
            }
        }

        public static string ParseRoleTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_RoleType, key);
        }
        #region KeyList
        ///普通角色
        public const string Dictionary_RoleType_NormalRole_Key = "1";
        ///高级角色
        public const string Dictionary_RoleType_AdvRole_Key = "2";
        ///管理员
        public const string Dictionary_RoleType_AdmRole_Key = "3";
        #endregion

        public const string Dictionary_GroupCode_SPField = "SPField";

        public static List<SystemDictionaryWrapper> SPFieldDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_SPField);
            }
        }

        public static string ParseSPFieldDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_SPField, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_GroupCode_ChannelStatus = "ChannelStatus";

        public static List<SystemDictionaryWrapper> ChannelStatusDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_ChannelStatus);
            }
        }

        public static string ParseChannelStatusDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_ChannelStatus, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_GroupCode_ChannelDataAdapterType = "ChannelDataAdapterType";

        public static List<SystemDictionaryWrapper> ChannelDataAdapterTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_ChannelDataAdapterType);
            }
        }

        public static string ParseChannelDataAdapterTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_ChannelDataAdapterType, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_GroupCode_ChannelType = "ChannelType";

        public static List<SystemDictionaryWrapper> ChannelTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_ChannelType);
            }
        }

        public static string ParseChannelTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_ChannelType, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_GroupCode_ChannelStateReportType = "ChannelStateReportType";

        public static List<SystemDictionaryWrapper> ChannelStateReportTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_ChannelStateReportType);
            }
        }

        public static string ParseChannelStateReportTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_ChannelStateReportType, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_GroupCode_System_DataType = "System_DataType";

        public static List<SystemDictionaryWrapper> System_DataTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_System_DataType);
            }
        }

        public static string ParseSystem_DataTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_System_DataType, key);
        }
        #region KeyList
        ///字符串
        public const string Dictionary_System_DataType_string_Key = "1";
        ///整数
        public const string Dictionary_System_DataType_int_Key = "2";
        ///小数
        public const string Dictionary_System_DataType_decimal_Key = "3";
        ///日期
        public const string Dictionary_System_DataType_datetime_Key = "4";
        ///布尔
        public const string Dictionary_System_DataType_bool_Key = "5";
        #endregion



    }

}
