// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Data.Tables;
using SPS.Entity.Tables;
using SPS.Data.Tables.Container;




namespace SPS.Bussiness.ServiceProxys.Tables
{

    public interface ISPUpperServiceProxyDesigner
    {
    }

    internal partial class SPUpperServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPUpperEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPUpperDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPUpperDataObject)selfDataObject;
            }
        }





		
    }
}
