using System;
using System.Collections.Generic;
using System.Text;

namespace Powerasp.Enterprise.Core.BaseManager.Web
{
    /// <summary>
    /// 按钮链接类型
    /// </summary>
    public enum UrlType : byte
    {
        /// <summary>
        /// 超级链接
        /// </summary>
        Href,
        /// <summary>
        /// JavaScript 脚本
        /// </summary>
        JavaScript,
        /// <summary>
        /// VBScript 脚本
        /// </summary>
        VBScript
    }


    #region "提示框图标类型"

    /// <summary>
    /// 提示Icon类型
    /// </summary>
    public enum Icon_Type : byte
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        OK,
        /// <summary>
        /// 操作标示
        /// </summary>
        Alert,
        /// <summary>
        /// 操作失败
        /// </summary>
        Error
    }
    #endregion
}
