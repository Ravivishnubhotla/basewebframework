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
using Legendigital.TroniTechRMTS.Data.AdoNet;




namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
    internal partial class SPChannelServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPChannelEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPChannelDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPChannelDataObject)selfDataObject;
            }
        }
		
        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
