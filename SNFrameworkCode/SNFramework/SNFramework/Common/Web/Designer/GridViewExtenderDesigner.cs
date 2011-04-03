using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;

namespace Legendigital.Framework.Common.Web.Designer
{
    /// <summary>
    /// </summary>
    public class GridViewExtenderDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return "<div style=\"background-color: #C8C8C8; border: groove 2 Gray;\"><b>GridViewExtender</b> - " + this.Component.Site.Name + "</div>";
        }
    }
}