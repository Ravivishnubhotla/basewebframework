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
    public partial class SystemPrivilegeDataObject : BaseNHibernateDataObject<SystemPrivilegeEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_PRIVILEGEID = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGEID);
		public static readonly Property PROPERTY_OPERATIONID = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_OPERATIONID);
		#region operationID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> InClude_OperationID_Query(NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPrivilegeEntity.PROPERTY_NAME_OPERATIONID, PROPERTY_OPERATIONID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_OPERATIONID_ALIAS_NAME = "OperationID_SystemPrivilegeEntity_Alias";
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONID = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationID");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONNAMECN = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationNameCn");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONNAMEEN = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationNameEn");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONDESCRIPTION = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationDescription");
		public static readonly Property PROPERTY_OPERATIONID_ISSYSTEMOPERATION = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsSystemOperation");
		public static readonly Property PROPERTY_OPERATIONID_ISCANSINGLEOPERATION = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsCanSingleOperation");
		public static readonly Property PROPERTY_OPERATIONID_ISCANMUTILOPERATION = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsCanMutilOperation");
		public static readonly Property PROPERTY_OPERATIONID_ISENABLE = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsEnable");
		public static readonly Property PROPERTY_OPERATIONID_ISINLISTPAGE = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsInListPage");
		public static readonly Property PROPERTY_OPERATIONID_ISINSINGLEPAGE = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".IsInSinglePage");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONORDER = Property.ForName(PROPERTY_OPERATIONID_ALIAS_NAME + ".OperationOrder");
		#endregion
		public static readonly Property PROPERTY_RESOURCESID = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_RESOURCESID);
		#region resourcesID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> InClude_ResourcesID_Query(NHibernateDynamicQueryGenerator<SystemPrivilegeEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPrivilegeEntity.PROPERTY_NAME_RESOURCESID, PROPERTY_RESOURCESID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_RESOURCESID_ALIAS_NAME = "ResourcesID_SystemPrivilegeEntity_Alias";
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESID = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesID");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESNAMECN = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesNameCn");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESNAMEEN = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesNameEn");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESDESCRIPTION = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesDescription");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESTYPE = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesType");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESCATEGORY = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesCategory");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESLIMITEXPRESSION = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesLimitExpression");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESISRELATEUSER = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".ResourcesIsRelateUser");
		public static readonly Property PROPERTY_RESOURCESID_MOUDLEID = Property.ForName(PROPERTY_RESOURCESID_ALIAS_NAME + ".MoudleID");
		#endregion
		public static readonly Property PROPERTY_PRIVILEGECNNAME = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGECNNAME);
		public static readonly Property PROPERTY_PRIVILEGEENNAME = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGEENNAME);
		public static readonly Property PROPERTY_DEFAULTVALUE = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_DEFAULTVALUE);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_PRIVILEGEORDER = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGEORDER);
		public static readonly Property PROPERTY_PRIVILEGECATEGORY = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGECATEGORY);
		public static readonly Property PROPERTY_PRIVILEGETYPE = Property.ForName(SystemPrivilegeEntity.PROPERTY_NAME_PRIVILEGETYPE);
      
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
                    break;
                case "OperationID":
                    return typeof (int);
                    break;
                case "ResourcesID":
                    return typeof (int);
                    break;
                case "PrivilegeCnName":
                    return typeof (string);
                    break;
                case "PrivilegeEnName":
                    return typeof (string);
                    break;
                case "DefaultValue":
                    return typeof (string);
                    break;
                case "Description":
                    return typeof (string);
                    break;
                case "PrivilegeOrder":
                    return typeof (int);
                    break;
                case "PrivilegeCategory":
                    return typeof (string);
                    break;
                case "PrivilegeType":
                    return typeof (string);
                    break;
          }
			return typeof(string);
        }
    }
}
