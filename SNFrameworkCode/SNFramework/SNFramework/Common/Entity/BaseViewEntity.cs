using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Entity
{
    [Serializable]
    public abstract class BaseViewEntity<EntityKeyType>
    {
        public abstract EntityKeyType GetDataEntityKey();

        public virtual bool DataKeyIsEmpty
        {
            get
            {
                if(GetDataEntityKey() is int)
                {
                    return(Convert.ToInt32(GetDataEntityKey()) == 0);
                }
                if (GetDataEntityKey() is string)
                {
                    string key = GetDataEntityKey() as string;

                    return (string.IsNullOrEmpty(key));
                }
                if (GetDataEntityKey() is Guid)
                {
                    Guid guidkey = (Guid)Convert.ChangeType(GetDataEntityKey(), typeof(Guid));

                    return (guidkey == null || guidkey == Guid.Empty);
                }
                return false;
            }
        }

        #region Equals 和 HashCode 方法覆盖
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public virtual bool CheckEquals(BaseViewEntity<EntityKeyType> obj)
        {
            if (this == obj) return true;

            if ((obj == null) || (obj.GetType() != this.GetType())) return false;

            return (obj != null) && CheckKeyEqual(this.GetDataEntityKey(),obj.GetDataEntityKey());
        } 

        public virtual bool CheckKeyEqual(EntityKeyType key1,EntityKeyType key2)
        {
            if (key1 is int)
            {
                return (Convert.ToInt32(key1) == Convert.ToInt32(key2));
            }
            if (GetDataEntityKey() is string)
            {
                string skey1 = key1 as string;

                string skey2 = key2 as string;

                return (skey1 == skey2);
            }
            if (GetDataEntityKey() is Guid)
            {
                Guid guidkey1 = (Guid)Convert.ChangeType(key1, typeof(Guid));

                Guid guidkey2 = (Guid)Convert.ChangeType(key2, typeof(Guid));

                return (guidkey1 == guidkey2);
            }
            return false;
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
