// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables")]
    public interface ISystemDepartmentServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemDepartmentEntity, int>, ISystemDepartmentServiceProxyDesigner
    {
        IList<SystemDepartmentEntity> FindAllByOrder();

        SystemDepartmentEntity GetNewMaxOrder(SystemDepartmentEntity systemDepartmentEntity);

    }

    public partial class SystemDepartmentServiceProxy :BaseSpringNHibernateEntityServiceProxy<SystemDepartmentEntity,int>, ISystemDepartmentServiceProxy
    {
        public IList<SystemDepartmentEntity> FindAllByOrder()
        {
            return this.SelfDataObj.FindAllByOrder();
        }



        #region ISystemDepartmentServiceProxy Members


        public SystemDepartmentEntity GetNewMaxOrder(SystemDepartmentEntity systemDepartmentEntity)
        {
            return this.SelfDataObj.GetNewMaxOrderDepartment(systemDepartmentEntity);
        }

        #endregion

    }
}
