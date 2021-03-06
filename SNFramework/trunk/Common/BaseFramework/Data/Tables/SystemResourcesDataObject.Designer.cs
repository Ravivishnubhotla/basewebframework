// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemResourcesDataObject : BaseNHibernateDataObject<SystemResourcesEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_RESOURCESID = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESID);
		public static readonly Property PROPERTY_RESOURCESNAMECN = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESNAMECN);
		public static readonly Property PROPERTY_RESOURCESNAMEEN = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESNAMEEN);
		public static readonly Property PROPERTY_RESOURCESDESCRIPTION = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESDESCRIPTION);
		public static readonly Property PROPERTY_RESOURCESTYPE = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESTYPE);
		public static readonly Property PROPERTY_RESOURCESCATEGORY = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESCATEGORY);
		public static readonly Property PROPERTY_RESOURCESLIMITEXPRESSION = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESLIMITEXPRESSION);
		public static readonly Property PROPERTY_RESOURCESISRELATEUSER = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_RESOURCESISRELATEUSER);
		public static readonly Property PROPERTY_MOUDLEID = Property.ForName(SystemResourcesEntity.PROPERTY_NAME_MOUDLEID);
		#region moudleID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemResourcesEntity> InClude_MoudleID_Query(NHibernateDynamicQueryGenerator<SystemResourcesEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemResourcesEntity.PROPERTY_NAME_MOUDLEID, PROPERTY_MOUDLEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_MOUDLEID_ALIAS_NAME = "MoudleID_SystemResourcesEntity_Alias";
		public static readonly Property PROPERTY_MOUDLEID_MOUDLEID = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".MoudleID");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLENAMECN = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".MoudleNameCn");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLENAMEEN = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".MoudleNameEn");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLENAMEDB = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".MoudleNameDb");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLEDESCRIPTION = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".MoudleDescription");
		public static readonly Property PROPERTY_MOUDLEID_APPLICATIONID = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".ApplicationID");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLEISSYSTEMMOUDLE = Property.ForName(PROPERTY_MOUDLEID_ALIAS_NAME + ".MoudleIsSystemMoudle");
		#endregion
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "ResourcesID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "ResourcesID":
                    return typeof (int);
                case "ResourcesNameCn":
                    return typeof (string);
                case "ResourcesNameEn":
                    return typeof (string);
                case "ResourcesDescription":
                    return typeof (string);
                case "ResourcesType":
                    return typeof (string);
                case "ResourcesCategory":
                    return typeof (string);
                case "ResourcesLimitExpression":
                    return typeof (string);
                case "ResourcesIsRelateUser":
                    return typeof (bool);
                case "MoudleID":
                    return typeof (int);
          }
			return typeof(string);
        }
		
		public List<SystemResourcesEntity> GetList_By_MoudleID_SystemMoudleEntity(SystemMoudleEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemResourcesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_MOUDLEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemResourcesEntity> GetPageList_By_MoudleID_SystemMoudleEntity(string orderByColumnName, bool isDesc, SystemMoudleEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemResourcesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_MOUDLEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
