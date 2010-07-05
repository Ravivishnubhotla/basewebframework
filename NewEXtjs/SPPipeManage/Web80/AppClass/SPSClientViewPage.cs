using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.Web.AppClass
{
    public class SPSClientViewPage : BaseSecurityPage
    {

        public int ClientID
        {
            get
            {
                if (this.CurrentLoginUser == null)
                    return 0;
                if (!this.Context.User.IsInRole("SPDownUser"))
                    return 0;

                return SPClientWrapper.GetClientIDByUserID(this.CurrentLoginUser.UserID);
            }

        }
    }
}
