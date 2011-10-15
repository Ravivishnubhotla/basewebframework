using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Entity
{
    [Serializable]
    public abstract class BaseTableEntity : BaseViewEntity
    {
        protected bool _isChanged;
        protected bool _isDeleted;


 




        /// <summary>
        /// 返回对象是否被改变。
        /// </summary>
        public virtual bool IsChanged
        {
            get { return _isChanged; }
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public virtual bool IsDeleted
        {
            get { return _isDeleted; }
        }


        #region 公共方法

        /// <summary>
        /// mark the item as deleted
        /// </summary>
        public virtual void MarkAsDeleted()
        {
            _isDeleted = true;
            _isChanged = true;
        }

        #endregion





    }
}
