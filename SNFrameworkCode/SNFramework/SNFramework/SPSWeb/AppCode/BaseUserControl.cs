using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SPSWeb.AppCode
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        public SystemUserWrapper CurrentLoginUser
        {
            get
            {
                if(!(this.Page is BasePage))
                {
                    return null;
                }
                return  ((BasePage)this.Page).CurrentLoginUser;
            }
        }

    }
}