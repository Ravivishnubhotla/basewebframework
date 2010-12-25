using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.Data.Interfaces
{
    public interface IGenericViewDataObject<T>
    {
        //查询出所有数据
        List<T> FindAll();

        //分页查询出所有数据
        List<T> FindAllByPage(PageQueryParams pageQueryParams);

        //通过ID加载数据
        T Load(object id);

        T FullLoad(object id);

        //通过ID加载数据
        void Load(T instance, object id);

        //刷新数据
        void Refresh(T instance);
    }
}