using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Web
{
    public enum MessageType : byte
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
}
