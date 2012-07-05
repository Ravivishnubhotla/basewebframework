using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Web
{
    /// <summary>
    /// 页面验证模式
    /// </summary>
    public enum PageSecurityMode
    {
        /// <summary>
        /// 不需要
        /// </summary>
        None = 0,

        /// <summary>
        /// 需要验证
        /// </summary>
        Authentication = 1
    }
}
