using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNFramework.BSF.AppCode
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        public BasePage ParentPage
        {
            get
            {
                return (BasePage)this.Page;
            }
        }
    }
}