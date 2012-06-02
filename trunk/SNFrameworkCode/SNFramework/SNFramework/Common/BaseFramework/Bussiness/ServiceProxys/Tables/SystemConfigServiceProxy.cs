// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    public interface ISystemConfigServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemConfigEntity, int>, ISystemConfigServiceProxyDesigner
    {
	    SystemConfigEntity GetConfigByKey(string key);
    }

    public partial class SystemConfigServiceProxy : ISystemConfigServiceProxy
    {
        public SystemConfigEntity GetConfigByKey(string key)
        {
            return this.SelfDataObj.GetConfigByKey(key);
        }
    }
}
