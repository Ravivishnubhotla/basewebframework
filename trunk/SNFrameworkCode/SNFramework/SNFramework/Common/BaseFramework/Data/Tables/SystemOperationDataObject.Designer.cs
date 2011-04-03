// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemOperationDataObject : BaseNHibernateDataObject<SystemOperationEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_OPERATIONID = new IntProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONID));		
		public static readonly StringProperty PROPERTY_OPERATIONNAMECN = new StringProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONNAMECN));		
		public static readonly StringProperty PROPERTY_OPERATIONNAMEEN = new StringProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONNAMEEN));		
		public static readonly StringProperty PROPERTY_OPERATIONDESCRIPTION = new StringProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONDESCRIPTION));		
		public static readonly BoolProperty PROPERTY_ISSYSTEMOPERATION = new BoolProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISSYSTEMOPERATION));		
		public static readonly BoolProperty PROPERTY_ISCANSINGLEOPERATION = new BoolProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISCANSINGLEOPERATION));		
		public static readonly BoolProperty PROPERTY_ISCANMUTILOPERATION = new BoolProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISCANMUTILOPERATION));		
		public static readonly BoolProperty PROPERTY_ISENABLE = new BoolProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISENABLE));		
		public static readonly BoolProperty PROPERTY_ISINLISTPAGE = new BoolProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISINLISTPAGE));		
		public static readonly BoolProperty PROPERTY_ISINSINGLEPAGE = new BoolProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISINSINGLEPAGE));		
		public static readonly IntProperty PROPERTY_OPERATIONORDER = new IntProperty(Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONORDER));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "OperationID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "OperationID":
                    return typeof (int);
                case "OperationNameCn":
                    return typeof (string);
                case "OperationNameEn":
                    return typeof (string);
                case "OperationDescription":
                    return typeof (string);
                case "IsSystemOperation":
                    return typeof (bool);
                case "IsCanSingleOperation":
                    return typeof (bool);
                case "IsCanMutilOperation":
                    return typeof (bool);
                case "IsEnable":
                    return typeof (bool);
                case "IsInListPage":
                    return typeof (bool);
                case "IsInSinglePage":
                    return typeof (bool);
                case "OperationOrder":
                    return typeof (int);
          }
			return typeof(string);
        }
		

		
		
    }
}
