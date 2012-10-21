// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Aop;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    public interface ISystemEmailTemplateServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemEmailTemplateEntity, int>, ISystemEmailTemplateServiceProxyDesigner
    {
	    SystemEmailTemplateEntity GetTemplateByName(string name);
    }

    [RecordAuditorClass(EnableVersion = false)]
    public partial class SystemEmailTemplateServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemEmailTemplateEntity,int>, ISystemEmailTemplateServiceProxy
    {
        //[RecordAuditorMethod(AuditorActionHandle = )]
        //public override void Save(SystemEmailTemplateEntity obj)
        //{
        //    base.Save(obj);
        //}




        public SystemEmailTemplateEntity GetTemplateByName(string name)
        {
            return this.SelfDataObj.GetTemplateByName(name);
        }
    }
}
