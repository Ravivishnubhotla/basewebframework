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
    public interface ISystemMoudleFieldServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemMoudleFieldEntity, int>, ISystemMoudleFieldServiceProxyDesigner
    {


    }

    public partial class SystemMoudleFieldServiceProxy :BaseSpringNHibernateEntityServiceProxy<SystemMoudleFieldEntity,int>, ISystemMoudleFieldServiceProxy
    {


    }
}
