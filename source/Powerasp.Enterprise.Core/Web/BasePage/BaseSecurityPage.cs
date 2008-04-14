using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.Web.BasePage
{


    public class BaseSecurityPage : BaseWebContainerPage
    {
        public const string LoginUserContextKey = "Context_Key_LoginUser";
        public const string LoginUserAssignRoleContextKey = "Context_Key_LoginUserAssignRole";
        //public const string LoginUserSessionKey = "Session_Key_LoginUser";
        //public const string LoginUserAssignRoleSessionKey = "Session_Key_LoginUserAssignRole";

        public SystemUser CurrentLoginUser
        {
            get
            {
                if (this.Context.Items[LoginUserContextKey] == null)
                    return null;
                else
                    return (SystemUser)this.Context.Items[LoginUserContextKey];
            }
        }
        public List<SystemRole> CurrentLoginUserAssginedRole
        {
            get
            {
                if (this.Context.Items[LoginUserAssignRoleContextKey] == null)
                    return null;
                else
                    return (List<SystemRole>)this.Context.Items[LoginUserAssignRoleContextKey];
            }
        }
    }
}
