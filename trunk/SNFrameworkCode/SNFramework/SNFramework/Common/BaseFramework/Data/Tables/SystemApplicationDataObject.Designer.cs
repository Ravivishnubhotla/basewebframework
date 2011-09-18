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
    public partial class SystemApplicationDataObject : BaseNHibernateDataObject<SystemApplicationEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_SYSTEMAPPLICATIONID = new IntProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONID));		
		public static readonly StringProperty PROPERTY_SYSTEMAPPLICATIONNAME = new StringProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONNAME));		
		public static readonly StringProperty PROPERTY_SYSTEMAPPLICATIONCODE = new StringProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONCODE));		
		public static readonly StringProperty PROPERTY_SYSTEMAPPLICATIONDESCRIPTION = new StringProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONDESCRIPTION));		
		public static readonly StringProperty PROPERTY_SYSTEMAPPLICATIONURL = new StringProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONURL));		
		public static readonly BoolProperty PROPERTY_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = new BoolProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONISSYSTEMAPPLICATION));		
		public static readonly IntProperty PROPERTY_ORDERINDEX = new IntProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_ORDERINDEX));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SystemApplicationEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "SystemApplicationID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "SystemApplicationID":
                    return typeof (int);
                case "SystemApplicationName":
                    return typeof (string);
                case "SystemApplicationCode":
                    return typeof (string);
                case "SystemApplicationDescription":
                    return typeof (string);
                case "SystemApplicationUrl":
                    return typeof (string);
                case "SystemApplicationIsSystemApplication":
                    return typeof (bool);
                case "OrderIndex":
                    return typeof (int);
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
		

		
		
    }
}
