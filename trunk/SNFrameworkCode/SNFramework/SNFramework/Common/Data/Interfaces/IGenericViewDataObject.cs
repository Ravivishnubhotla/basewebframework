using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;


namespace Legendigital.Framework.Common.Data.Interfaces
{
    public interface IGenericViewDataObject<T, EntityKeyType> where T : BaseViewEntity<EntityKeyType>
    {
        //查询出所有数据
        List<T> FindAll();

        //分页查询出所有数据
        List<T> FindAllByPage(PageQueryParams pageQueryParams);

        //通过ID加载数据
        T Load(EntityKeyType id);

        T FullLoad(EntityKeyType id);

        //通过ID加载数据
        void Load(T instance, EntityKeyType id);

        //刷新数据
        void Refresh(T instance);
    }
}