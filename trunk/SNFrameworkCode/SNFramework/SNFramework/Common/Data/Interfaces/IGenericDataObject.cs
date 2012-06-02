using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Entity;


namespace Legendigital.Framework.Common.Data.Interfaces
{
    public interface IGenericDataObject<T, EntityKeyType> : IGenericViewDataObject<T, EntityKeyType> where T : BaseViewEntity<EntityKeyType>
    {
        //添加数据
        void Save(T instance);

        //添加数据
        void SaveOrUpdate(T instance);

        //局部更新数据
        void PartUpdate(T instance, EntityKeyType id, string[] updatePropertyNames);

        //更新数据
        void Update(T instance);

        //删除数据
        void Delete(T instance);

        //通过ID删除数据
        void DeleteByID(EntityKeyType id);

        //删除所有的数据
        void DeleteAll();

    }
}