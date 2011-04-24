// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemPrivilegeDataObject : BaseNHibernateDataObject<SystemPrivilegeEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_PRIVILEGEID = new IntProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGEID));		
		public static readonly EntityProperty<SystemOperationEntity> PROPERTY_OPERATIONID = new EntityProperty<SystemOperationEntity>(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_OPERATIONID));
		#region operationID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> InClude_OperationID_Query(NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPrivilegeEntity.PROPERTY_NAME_OPERATIONID, PROPERTY_OPERATIONID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_OPERATIONID_ALIAS_NAME = "OperationID_SystemPrivilegeEntity_Alias";
		public static readonly IntProperty PROPERTY_OPERATIONID_OPERATIONID = new IntProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationID"));
		public static readonly StringProperty PROPERTY_OPERATIONID_OPERATIONNAMECN = new StringProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationNameCn"));
		public static readonly StringProperty PROPERTY_OPERATIONID_OPERATIONNAMEEN = new StringProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationNameEn"));
		public static readonly StringProperty PROPERTY_OPERATIONID_OPERATIONDESCRIPTION = new StringProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationDescription"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISSYSTEMOPERATION = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsSystemOperation"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISCANSINGLEOPERATION = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsCanSingleOperation"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISCANMUTILOPERATION = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsCanMutilOperation"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISENABLE = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsEnable"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISINLISTPAGE = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsInListPage"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISINSINGLEPAGE = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsInSinglePage"));
		public static readonly IntProperty PROPERTY_OPERATIONID_OPERATIONORDER = new IntProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationOrder"));
		public static readonly BoolProperty PROPERTY_OPERATIONID_ISCOMMONOPERATION = new BoolProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsCommonOperation"));
		public static readonly IntProperty PROPERTY_OPERATIONID_RESOURCEID = new IntProperty(Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".ResourceID"));
		#endregion
		public static readonly EntityProperty<SystemResourcesEntity> PROPERTY_RESOURCESID = new EntityProperty<SystemResourcesEntity>(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_RESOURCESID));
		#region resourcesID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> InClude_ResourcesID_Query(NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPrivilegeEntity.PROPERTY_NAME_RESOURCESID, PROPERTY_RESOURCESID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_RESOURCESID_ALIAS_NAME = "ResourcesID_SystemPrivilegeEntity_Alias";
		public static readonly IntProperty PROPERTY_RESOURCESID_RESOURCESID = new IntProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesID"));
		public static readonly StringProperty PROPERTY_RESOURCESID_RESOURCESNAMECN = new StringProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesNameCn"));
		public static readonly StringProperty PROPERTY_RESOURCESID_RESOURCESNAMEEN = new StringProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesNameEn"));
		public static readonly StringProperty PROPERTY_RESOURCESID_RESOURCESDESCRIPTION = new StringProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesDescription"));
		public static readonly StringProperty PROPERTY_RESOURCESID_RESOURCESTYPE = new StringProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesType"));
		public static readonly StringProperty PROPERTY_RESOURCESID_RESOURCESCATEGORY = new StringProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesCategory"));
		public static readonly StringProperty PROPERTY_RESOURCESID_RESOURCESLIMITEXPRESSION = new StringProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesLimitExpression"));
		public static readonly BoolProperty PROPERTY_RESOURCESID_RESOURCESISRELATEUSER = new BoolProperty(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesIsRelateUser"));
		public static readonly EntityProperty<SystemMoudleEntity> PROPERTY_RESOURCESID_MOUDLEID = new EntityProperty<SystemMoudleEntity>(Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".MoudleID"));
		#endregion
		public static readonly StringProperty PROPERTY_PRIVILEGECNNAME = new StringProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGECNNAME));		
		public static readonly StringProperty PROPERTY_PRIVILEGEENNAME = new StringProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGEENNAME));		
		public static readonly StringProperty PROPERTY_DEFAULTVALUE = new StringProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_DEFAULTVALUE));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly IntProperty PROPERTY_PRIVILEGEORDER = new IntProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGEORDER));		
		public static readonly StringProperty PROPERTY_PRIVILEGECATEGORY = new StringProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGECATEGORY));		
		public static readonly StringProperty PROPERTY_PRIVILEGETYPE = new StringProperty(Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGETYPE));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "PrivilegeID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "PrivilegeID":
                    return typeof (int);
                case "OperationID":
                    return typeof (int);
                case "ResourcesID":
                    return typeof (int);
                case "PrivilegeCnName":
                    return typeof (string);
                case "PrivilegeEnName":
                    return typeof (string);
                case "DefaultValue":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "PrivilegeOrder":
                    return typeof (int);
                case "PrivilegeCategory":
                    return typeof (string);
                case "PrivilegeType":
                    return typeof (string);
          }
			return typeof(string);
        }
		
		public List<SystemPrivilegeEntity> GetList_By_OperationID_SystemOperationEntity(SystemOperationEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_OPERATIONID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPrivilegeEntity> GetPageList_By_OperationID_SystemOperationEntity(string orderByColumnName, bool isDesc, SystemOperationEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_OPERATIONID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SystemPrivilegeEntity> GetList_By_ResourcesID_SystemResourcesEntity(SystemResourcesEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_RESOURCESID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPrivilegeEntity> GetPageList_By_ResourcesID_SystemResourcesEntity(string orderByColumnName, bool isDesc, SystemResourcesEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_RESOURCESID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
