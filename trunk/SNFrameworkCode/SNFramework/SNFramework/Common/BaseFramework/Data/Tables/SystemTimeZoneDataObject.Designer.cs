// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemTimeZoneDataObject.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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
    public partial class SystemTimeZoneDataObject : BaseNHibernateDataObject<SystemTimeZoneEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_NAMECN = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_NAMECN));		
		public static readonly StringProperty PROPERTY_DISPLAYNAME = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_DISPLAYNAME));		
		public static readonly StringProperty PROPERTY_DISPLAYNAMECN = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_DISPLAYNAMECN));		
		public static readonly StringProperty PROPERTY_STANDARDNAME = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_STANDARDNAME));		
		public static readonly StringProperty PROPERTY_STANDARDNAMECN = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_STANDARDNAMECN));		
		public static readonly StringProperty PROPERTY_DAYLIGHTNAME = new StringProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_DAYLIGHTNAME));		
		public static readonly IntProperty PROPERTY_UTCOFFSET = new IntProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_UTCOFFSET));		
		public static readonly BoolProperty PROPERTY_SUPPORTDST = new BoolProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_SUPPORTDST));		
		public static readonly IntProperty PROPERTY_DAYLIGHTDELTA = new IntProperty(Property.ForName(SystemTimeZoneEntity.PROPERTY_NAME_DAYLIGHTDELTA));		
      
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
                case "NameCn":
                    return typeof (string);
                case "DisplayName":
                    return typeof (string);
                case "DisplayNameCn":
                    return typeof (string);
                case "StandardName":
                    return typeof (string);
                case "StandardNameCn":
                    return typeof (string);
                case "DaylightName":
                    return typeof (string);
                case "UTCOffset":
                    return typeof (int);
                case "SupportDST":
                    return typeof (bool);
                case "DaylightDelta":
                    return typeof (int);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemTimeZoneEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
