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

        #region Equals 和 HashCode 方法覆盖
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public bool CheckEquals(BaseViewEntity obj)
        {
            if (this == obj) return true;

            if ((obj == null) || (obj.GetType() != this.GetType())) return false;

            return (obj != null) && (this.GetDataEntityKey() == obj.GetDataEntityKey());
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public int GetEntityHashCode()
        {

            int hash = 57;
            hash = 27 * hash * GetDataEntityKey().GetHashCode();

            return hash;
        }
        #endregion

    }
}
