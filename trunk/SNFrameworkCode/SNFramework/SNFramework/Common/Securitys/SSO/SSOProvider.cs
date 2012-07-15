using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.Securitys.SSO
{
    /// <summary>
    /// 登陆类型（指常规登陆还是key登陆，手机登陆）
    /// </summary>
    public enum LoginType
    {
        /// <summary>
        /// 普通登陆
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 通过Key登陆
        /// </summary>
        UseKey = 2
    }
    /// <summary>
    /// 子页面验证方式
    /// </summary>
    public enum SecurityMode
    {
        /// <summary>
        /// 需要验证
        /// </summary>
        Authentication = 1,
        /// <summary>
        /// 不需要验证
        /// </summary>
        None = 2
    }

    public class SSOProvider
    {
        public const string NODE_NAME_SSFToken = "SSFToken";
        public const string ELEMENT_NAME_LoginUserID = "LoginUserID";
        public const string ELEMENT_NAME_Password = "Password";
        public const string ELEMENT_NAME_LoginDate = "LoginDate";
        public const string ELEMENT_NAME_IPAddress = "IPAddress";
        public const string ELEMENT_NAME_SSOKey = "SSOKey";
        public const string QUERY_STRING_NAME_SSFToken = "_SSFToken";
        public const string Session_Key_LoginUser = "CurrentLoginUser";
 
        public static string GetSSFToken(string loginUserID, string password, DateTime loginDate, string ipAddress, string ssoKey, string SSFTokenKey)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode SSFTokenNode = doc.CreateElement(NODE_NAME_SSFToken);
            doc.AppendChild(SSFTokenNode);

            XmlAttribute UsernameAttribute = doc.CreateAttribute(ELEMENT_NAME_LoginUserID);
            UsernameAttribute.Value = loginUserID;
            SSFTokenNode.Attributes.Append(UsernameAttribute);

            XmlAttribute PasswordAttribute = doc.CreateAttribute(ELEMENT_NAME_Password);
            PasswordAttribute.Value = password;
            SSFTokenNode.Attributes.Append(PasswordAttribute);

            XmlAttribute DateAttribute = doc.CreateAttribute(ELEMENT_NAME_LoginDate);
            DateAttribute.Value = loginDate.ToString("yyyy-MM-dd HH:mm:ss");
            SSFTokenNode.Attributes.Append(DateAttribute);

            XmlAttribute ipAddressAttribute = doc.CreateAttribute(ELEMENT_NAME_IPAddress);
            ipAddressAttribute.Value = ipAddress;
            SSFTokenNode.Attributes.Append(ipAddressAttribute);

            XmlAttribute SSOKeyAttribute = doc.CreateAttribute(ELEMENT_NAME_SSOKey);
            SSOKeyAttribute.Value = ssoKey;
            SSFTokenNode.Attributes.Append(SSOKeyAttribute);

            StringWriter sw = new StringWriter();
            doc.Save(sw);

            return CryptographyUtil.EncryptDES(sw.ToString(), SSFTokenKey);

        }
 
        /// <summary>
        /// 返回从Token中出来的用户名和密码
        /// </summary>
        /// <param name="SSFToken"></param>
        /// <returns></returns>
        internal static Hashtable GetUserNameAndPasswordFromSSFToken(string SSFToken,string SSFTokenKey)
        {
            Hashtable SSFTokenUserNameAndPassword = new Hashtable();
            try
            {
                XmlDocument xdc = new XmlDocument();
                xdc.LoadXml(CryptographyUtil.DecryptDES(SSFToken, SSFTokenKey));
                SSFTokenUserNameAndPassword.Add(ELEMENT_NAME_LoginUserID, xdc.DocumentElement.GetAttribute(ELEMENT_NAME_LoginUserID).ToString());
                SSFTokenUserNameAndPassword.Add(ELEMENT_NAME_Password, xdc.DocumentElement.GetAttribute(ELEMENT_NAME_Password).ToString());
                SSFTokenUserNameAndPassword.Add(ELEMENT_NAME_LoginDate, xdc.DocumentElement.GetAttribute(ELEMENT_NAME_LoginDate).ToString());
                SSFTokenUserNameAndPassword.Add(ELEMENT_NAME_IPAddress, xdc.DocumentElement.GetAttribute(ELEMENT_NAME_IPAddress).ToString());
                SSFTokenUserNameAndPassword.Add(ELEMENT_NAME_SSOKey, xdc.DocumentElement.GetAttribute(ELEMENT_NAME_SSOKey).ToString());
                return SSFTokenUserNameAndPassword;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
 
 
        /// <summary>
        /// 生成登录的SSOKey，只在登录时调用一次
        /// </summary>
        /// <returns></returns>
        public static string GenerateSSOKey(string userLoginID)
        {
            string SSOKey = Guid.NewGuid().ToString();
            //UserInfo.UpdateSSOKey(userLoginID, SSOKey);
            return SSOKey;
        }


 
 
 
    }
}
