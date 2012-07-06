using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;

namespace Legendigital.Framework.Common.Securitys.LDAP
{
    public class ADUser
    {
        private ADUser(SearchResult searchResultItem,string defaultMailDomain)
        {
            if (searchResultItem.Properties.Contains("samaccountname"))
            {
                ResultPropertyValueCollection resultValue = searchResultItem.Properties["samaccountname"];
                if (resultValue != null && resultValue.Count > 0 && resultValue[0] != null)
                {
                    this.UserId = resultValue[0].ToString();
                    this.Email = this.UserId + defaultMailDomain;
                }
            }

            if (searchResultItem.Properties.Contains("mail"))
            {
                ResultPropertyValueCollection resultValue = searchResultItem.Properties["mail"];
                if (resultValue != null && resultValue.Count > 0 && resultValue[0] != null)
                {
                    this.Email = resultValue[0].ToString();
                }
            }

            if (searchResultItem.Properties.Contains("displayname"))
            {
                ResultPropertyValueCollection resultValue = searchResultItem.Properties["displayname"];
                if (resultValue != null && resultValue.Count > 0 && resultValue[0] != null)
                {
                    this.UserName = resultValue[0].ToString();
                }
            }        
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }



        public static List<ADUser> GetAllDomainUserInfo(string primaryDomainName, string domainUser, string domainPassword)
        {
            List<ADUser> infolist = new List<ADUser>();

            DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + primaryDomainName, domainUser, domainPassword, AuthenticationTypes.Secure);

            DirectorySearcher mySearcher = new DirectorySearcher(adRoot);
            mySearcher.Filter = "(objectClass=*)";
            mySearcher.PropertiesToLoad.Clear();

            SearchResultCollection searchResultCollection = null;

            try
            {
                searchResultCollection = mySearcher.FindAll();

                foreach (SearchResult result in searchResultCollection)
                {
                    ADUser info = new ADUser(result, SystemConfigConst.CFG_DEFAULT_VALUE_SYSUSERDEFAULTEMAIL);

                    if (!string.IsNullOrEmpty(info.UserId))
                    {
                        infolist.Add(info);
                    }
                }
            }
            catch
            {
                // 处理异常
            }

            return infolist;
        }

 
    }
}
