using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.Web.AppClass
{
    public class SPClientGroupViewPage : BaseSecurityPage
    {
        public int ClientGroupID 
        {
            get
            {
                if (this.CurrentLoginUser == null)
                    return 0;
                if (!this.Context.User.IsInRole("SPDownGroupUser") && !this.Context.User.IsInRole("SPDownGroupUser2"))
                    return 0;

                return SPClientGroupWrapper.GetByUserID(this.CurrentLoginUser.UserID).Id;
            }

        }
    }
}