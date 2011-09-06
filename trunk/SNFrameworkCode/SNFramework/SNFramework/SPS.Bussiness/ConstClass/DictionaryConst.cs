using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SPS.Bussiness.ConstClass
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
        ///主键
        public const string Dictionary_SPField_LinkID_Key = "LinkID";
        ///上行指令
        public const string Dictionary_SPField_MO_Key = "MO";
        ///手机号码
        public const string Dictionary_SPField_Mobile_Key = "Mobile";
        ///通道号码
        public const string Dictionary_SPField_SpNumber_Key = "SpNumber";
        ///省份
        public const string Dictionary_SPField_Province_Key = "Province";
        ///地市
        public const string Dictionary_SPField_City_Key = "City";
        ///创建日期
        public const string Dictionary_SPField_CreateDate_Key = "CreateDate";
        ///状态
        public const string Dictionary_SPField_State_Key = "State";
        ///计费时长
        public const string Dictionary_SPField_FeeTime_Key = "FeeTime";
        ///计费开始时间
        public const string Dictionary_SPField_StartTime_Key = "StartTime";
        ///计费结束时间
        public const string Dictionary_SPField_EndTime_Key = "EndTime";
        ///扩展字段1
        public const string Dictionary_SPField_ExtendField1_Key = "ExtendField1";
        ///扩展字段2
        public const string Dictionary_SPField_ExtendField2_Key = "ExtendField2";
        ///扩展字段3
        public const string Dictionary_SPField_ExtendField3_Key = "ExtendField3";
        ///扩展字段4
        public const string Dictionary_SPField_ExtendField4_Key = "ExtendField4";
        ///扩展字段5
        public const string Dictionary_SPField_ExtendField5_Key = "ExtendField5";
        ///扩展字段6
        public const string Dictionary_SPField_ExtendField6_Key = "ExtendField6";
        ///扩展字段7
        public const string Dictionary_SPField_ExtendField7_Key = "ExtendField7";
        ///扩展字段8
        public const string Dictionary_SPField_ExtendField8_Key = "ExtendField8";
        ///扩展字段9
        public const string Dictionary_SPField_ExtendField9_Key = "ExtendField9";
        ///扩展字段10
        public const string Dictionary_SPField_ExtendField10_Key = "ExtendField10";
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
        ///正常
        public const string Dictionary_ChannelStatus_Run_Key = "1";
        ///暂停
        public const string Dictionary_ChannelStatus_Stop_Key = "2";
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
        ///HttpGetPost适配器
        public const string Dictionary_ChannelDataAdapterType_HttpGetPostAdapter_Key = "0";
        ///XMLtPost适配器
        public const string Dictionary_ChannelDataAdapterType_XMLAdapter_Key = "1";
        ///自定义数据适配器
        public const string Dictionary_ChannelDataAdapterType_CustomerAdapter_Key = "2";
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
        ///短信通道(SP)
        public const string Dictionary_ChannelType_SPChannel_Key = "0";
        ///声讯通道(IVR)
        public const string Dictionary_ChannelType_IVRChannel_Key = "1";
        ///自定义通道
        public const string Dictionary_ChannelType_CustomerChannel_Key = "2";
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
        ///单次发送
        public const string Dictionary_ChannelStateReportType_SendOnce_Key = "0";
        ///双次发送
        public const string Dictionary_ChannelStateReportType_SendTwice_Key = "1";
        ///双次发送请求分类型
        public const string Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key = "2";
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

        public const string Dictionary_GroupCode_CodeMatchType = "CodeMatchType";

        public static List<SystemDictionaryWrapper> CodeMatchTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_CodeMatchType);
            }
        }

        public static string ParseCodeMatchTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_CodeMatchType, key);
        }
        #region KeyList
        #endregion

        public const string Dictionary_GroupCode_CodeType = "CodeType";

        public static List<SystemDictionaryWrapper> CodeTypeDictionary
        {
            get
            {
                return SystemDictionaryWrapper.GetDictionaryByGroupCode(Dictionary_GroupCode_CodeType);
            }
        }

        public static string ParseCodeTypeDictionaryKey(string key)
        {
            return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey(Dictionary_GroupCode_CodeType, key);
        }
        #region KeyList
        ///默认指令
        public const string Dictionary_CodeType_CodeDefault_Key = "0";
        ///精准指令
        public const string Dictionary_CodeType_CodeEQ_Key = "1";
        ///模糊指令
        public const string Dictionary_CodeType_CodeStartWith_Key = "2";
        ///结束指令
        public const string Dictionary_CodeType_CodeEndWith_Key = "3";
        ///包含指令
        public const string Dictionary_CodeType_CodeContain_Key = "4";
        ///正则指令
        public const string Dictionary_CodeType_CodeRegex_Key = "5";
        ///自定义指令
        public const string Dictionary_CodeType_CodeCustom_Key = "6";
        ///多条件指令
        public const string Dictionary_CodeType_CodeMutilCondition_Key = "7";
        ///表达式指令
        public const string Dictionary_CodeType_CodeExpression_Key = "8";
        #endregion



    }
}
