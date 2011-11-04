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
	    List<SystemTerminologyEntity> FindAllByCode(string terminologyCode);
	    bool IsExisted(string terminologyCode, string lang);
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

        public List<SystemTerminologyEntity> FindAllByCode(string terminologyCode)
        {
            return this.SelfDataObj.GetAllTerminologyByCode(terminologyCode);
        }

        public bool IsExisted(string terminologyCode, string lang)
        {
            SystemTerminologyEntity systemTerminologyEntity =
                this.SelfDataObj.GetLocalizationNameByTypeAndCode(lang, terminologyCode);

            if (systemTerminologyEntity == null)
                return false;

            return true;
        }
    }
}
