// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Data.Tables.Container;
using LD.SPPipeManage.Data.AdoNet;




namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{

    public interface ISPRequestInfoServiceProxyDesigner
    {
    }


    internal partial class SPRequestInfoServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPRequestInfoEntity> , ISPRequestInfoServiceProxyDesigner
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPRequestInfoDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPRequestInfoDataObject)selfDataObject;
            }
        }

		
		
        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
