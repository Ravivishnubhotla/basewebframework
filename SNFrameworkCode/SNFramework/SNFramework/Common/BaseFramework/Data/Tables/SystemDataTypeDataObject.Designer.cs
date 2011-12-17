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
    public partial class SystemDataTypeDataObject : BaseNHibernateDataObject<SystemDataTypeEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_CODE = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_CODE));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly StringProperty PROPERTY_TABLENAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_TABLENAME));		
		public static readonly StringProperty PROPERTY_IDFIELDNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_IDFIELDNAME));		
		public static readonly StringProperty PROPERTY_CLASSFULLNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_CLASSFULLNAME));		
		public static readonly StringProperty PROPERTY_ASSEMBLYNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_ASSEMBLYNAME));		
		public static readonly StringProperty PROPERTY_LOADMETHODNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_LOADMETHODNAME));		
		public static readonly StringProperty PROPERTY_SAVEMETHODNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_SAVEMETHODNAME));		
		public static readonly StringProperty PROPERTY_UPDATEMETHODNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_UPDATEMETHODNAME));		
		public static readonly StringProperty PROPERTY_DELETEMETHODNAME = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_DELETEMETHODNAME));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SystemDataTypeEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "Id" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "Id":
                    return typeof (int);
                case "Name":
                    return typeof (string);
                case "Code":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "TableName":
                    return typeof (string);
                case "IDFieldName":
                    return typeof (string);
                case "ClassFullName":
                    return typeof (string);
                case "AssemblyName":
                    return typeof (string);
                case "LoadMethodName":
                    return typeof (string);
                case "SaveMethodName":
                    return typeof (string);
                case "UpdateMethodName":
                    return typeof (string);
                case "DeleteMethodName":
                    return typeof (string);
                case "CreateBy":
                    return typeof (int);
                case "CreateAt":
                    return typeof (DateTime);
                case "LastModifyBy":
                    return typeof (int);
                case "LastModifyAt":
                    return typeof (DateTime);
                case "LastModifyComment":
                    return typeof (string);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemDataTypeEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}