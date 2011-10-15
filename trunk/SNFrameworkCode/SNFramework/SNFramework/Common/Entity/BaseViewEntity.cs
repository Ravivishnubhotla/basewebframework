using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Entity
{
    [Serializable]
    public abstract class BaseViewEntity
    {
        public abstract object GetDataEntityKey();

        public virtual bool DataKeyIsEmpty
        {
            get
            {
                if(GetDataEntityKey() is int)
                {
                    return((int)GetDataEntityKey() == 0);
                }
                if (GetDataEntityKey() is string)
                {
                    return (string.IsNullOrEmpty((string)GetDataEntityKey()));
                }
                if (GetDataEntityKey() is Guid)
                {
                    return ((Guid)GetDataEntityKey()==null || (Guid)GetDataEntityKey()==Guid.Empty);
                }
                return false;
            }
        }

        #region Equals 和 HashCode 方法覆盖
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public virtual bool  CheckEquals(BaseViewEntity obj)
        {
            if (this == obj) return true;

            if ((obj == null) || (obj.GetType() != this.GetType())) return false;

            return (obj != null) && (this.GetDataEntityKey() == obj.GetDataEntityKey());
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public virtual int GetEntityHashCode()
        {

            int hash = 57;
            hash = 27 * hash * GetDataEntityKey().GetHashCode();

            return hash;
        }
        #endregion

    }
}
