using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst
{
    public static class SystemConfigConst
    {
        public const string CFG_DEFAULT_VALUE_SYSDEFAULTUSERMAIL = "@qq.com";
        public const string CFG_DEFAULT_VALUE_SYSTABOPENTYPE = "1";
        public const string CFG_DEFAULT_VALUE_SYSMENUSTYLE = "1";
        public const string CFG_DEFAULT_VALUE_SYSDEFAULTTHEME = "Default";
        public const string CFG_DEFAULT_VALUE_SYSDEFAULTLANG = "zh-CHS";
        public const string CFG_DEFAULT_VALUE_SYSUSERDEFAULTEMAIL = "@qq.com";
        public const string CFG_DEFAULT_VALUE_SYSDEFAULTUSERPASS = "123456";
        public const string CFG_DEFAULT_VALUE_SYSDEFAULTDEVUSERID = "DeveloperAdministrator";
        public const string CFG_DEFAULT_VALUE_SYSDEFAULTSYSADMINID = "SystemAdministrator";


        public const string CFG_KEY_SYSDEFAULTUSERMAIL = "SYS_DEFAULT_USERMAIL";
        public const string CFG_KEY_SYSTABOPENTYPE = "SYS_TAB_OPENTYPE";
        public const string CFG_KEY_SYSMENUSTYLE = "SYS_MENU_STYLE";
        public const string CFG_KEY_SYSDEFAULTTHEME = "SYS_DEFAULT_THEME";
        public const string CFG_KEY_SYSDEFAULTLANG = "SYS_DEFAULT_LANG";
        public const string CFG_KEY_SYSUSERDEFAULTEMAIL = "SYS_USER_DEFAULTEMAIL";
        public const string CFG_KEY_SYSDEFAULTUSERPASS = "SYS_DEFAULT_USERPASS";
        public const string CFG_KEY_SYSDEFAULTDEVUSERID = "SYS_DEFAULT_DEVUSERID";
        public const string CFG_KEY_SYSDEFAULTSYSADMINID = "SYS_DEFAULT_SYSADMINID";


        public static string Config_SysDefaultUsermail
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSDEFAULTUSERMAIL, CFG_DEFAULT_VALUE_SYSDEFAULTUSERMAIL);
            }
        }
        public static string Config_SysTabOpentype
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSTABOPENTYPE, CFG_DEFAULT_VALUE_SYSTABOPENTYPE);
            }
        }
        public static string Config_SysMenuStyle
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSMENUSTYLE, CFG_DEFAULT_VALUE_SYSMENUSTYLE);
            }
        }
        public static string Config_SysDefaultTheme
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSDEFAULTTHEME, CFG_DEFAULT_VALUE_SYSDEFAULTTHEME);
            }
        }
        public static string Config_SysDefaultLang
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSDEFAULTLANG, CFG_DEFAULT_VALUE_SYSDEFAULTLANG);
            }
        }
        public static string Config_SysUserDefaultemail
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSUSERDEFAULTEMAIL, CFG_DEFAULT_VALUE_SYSUSERDEFAULTEMAIL);
            }
        }
        public static string Config_SysDefaultUserpass
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSDEFAULTUSERPASS, CFG_DEFAULT_VALUE_SYSDEFAULTUSERPASS);
            }
        }
        public static string Config_SysDefaultDevuserid
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSDEFAULTDEVUSERID, CFG_DEFAULT_VALUE_SYSDEFAULTDEVUSERID);
            }
        }
        public static string Config_SysDefaultSysadminid
        {
            get
            {
                return SystemConfigWrapper.GetValueByConfigKey(CFG_KEY_SYSDEFAULTSYSADMINID, CFG_DEFAULT_VALUE_SYSDEFAULTSYSADMINID);
            }
        }



    }

}
