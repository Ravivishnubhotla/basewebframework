using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Spring.Web.UI;

namespace Legendigital.Framework.Common.BaseFramework.Web
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        public BaseSecurityPage ParentPage
        {
            get
            {
                return (BaseSecurityPage)this.Page;
            }
        }


  
    }
}