using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.BaseFramework.Web;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.AppCode
{
    public class SPClientViewPage : BaseSecurityPage
    {
        public SPSClientWrapper Client 
        {
            get
            {
                if (this.CurrentLoginUser == null)
                    return 0;
                if (!this.Context.User.IsInRole(RoleCodeList.ROLE_CODE_SPDOWNUSER))
                    return 0;

                return SPSClientWrapper.GetClientByUserID(this.CurrentLoginUser.UserID);
            }

        }
    }
}