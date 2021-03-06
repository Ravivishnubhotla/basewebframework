// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    public interface ISystemCountryServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemCountryEntity, int>, ISystemCountryServiceProxyDesigner
    {
        SystemCountryEntity FindByCode3(string code3);
    }

    public partial class SystemCountryServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemCountryEntity,int>, ISystemCountryServiceProxy
    {
        public SystemCountryEntity FindByCode3(string code3)
        {
            return this.SelfDataObj.FindByCode3(code3);
        }
    }
}
