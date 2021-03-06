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
    public partial class SystemOperationDataObject : BaseNHibernateDataObject<SystemOperationEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_OPERATIONID = Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONID);
		public static readonly Property PROPERTY_OPERATIONNAMECN = Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONNAMECN);
		public static readonly Property PROPERTY_OPERATIONNAMEEN = Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONNAMEEN);
		public static readonly Property PROPERTY_OPERATIONDESCRIPTION = Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONDESCRIPTION);
		public static readonly Property PROPERTY_ISSYSTEMOPERATION = Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISSYSTEMOPERATION);
		public static readonly Property PROPERTY_ISCANSINGLEOPERATION = Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISCANSINGLEOPERATION);
		public static readonly Property PROPERTY_ISCANMUTILOPERATION = Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISCANMUTILOPERATION);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_ISINLISTPAGE = Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISINLISTPAGE);
		public static readonly Property PROPERTY_ISINSINGLEPAGE = Property.ForName(SystemOperationEntity.PROPERTY_NAME_ISINSINGLEPAGE);
		public static readonly Property PROPERTY_OPERATIONORDER = Property.ForName(SystemOperationEntity.PROPERTY_NAME_OPERATIONORDER);
      
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
