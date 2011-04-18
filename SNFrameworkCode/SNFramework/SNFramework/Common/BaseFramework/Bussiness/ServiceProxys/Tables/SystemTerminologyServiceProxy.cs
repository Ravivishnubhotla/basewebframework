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
	public interface ISystemTerminologyServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemTerminologyEntity> ,ISystemTerminologyServiceProxyDesigner
    {
	    string GetLocalizationNameByTypeAndCode(string localizationType, string localizationCode);
    }

    public partial class SystemTerminologyServiceProxy : ISystemTerminologyServiceProxy
    {
        public string GetLocalizationNameByTypeAndCode(string localizationType, string localizationCode)
        {
            SystemTerminologyEntity systemTerminologyEntity =
                this.SelfDataObj.GetLocalizationNameByTypeAndCode(localizationType, localizationCode);

            if (systemTerminologyEntity == null)
                return "";

            return systemTerminologyEntity.Text;
        }
    }
}