using System;
using System.Collections.Generic;
using System.Text;


namespace Legendigital.Framework.Common.Data.Interfaces
{
    public interface IGenericDataObject<T> : IGenericViewDataObject<T>
    {
        //添加数据
        void Save(T instance);

        //添加数据
        void SaveOrUpdate(T instance);

        //局部更新数据
        void PartUpdate(T instance, object id, string[] updatePropertyNames);

        //更新数据
        void Update(T instance);

        //删除数据
        void Delete(T instance);

        //通过ID删除数据
        void DeleteByID(object id);

        //删除所有的数据
        void DeleteAll();

    }
}