// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemAddressDataObject.Designer.cs">
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
    public partial class SystemAddressDataObject : BaseNHibernateDataObject<SystemAddressEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_TYPE = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_TYPE));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly StringProperty PROPERTY_COUNTRY = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_COUNTRY));		
		public static readonly StringProperty PROPERTY_PROVINCE = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_PROVINCE));		
		public static readonly StringProperty PROPERTY_CITY = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_CITY));		
		public static readonly StringProperty PROPERTY_ADDRESS1 = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_ADDRESS1));		
		public static readonly StringProperty PROPERTY_ADDRESS2 = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_ADDRESS2));		
		public static readonly StringProperty PROPERTY_ADDRESS3 = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_ADDRESS3));		
		public static readonly StringProperty PROPERTY_ZIPCODE = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_ZIPCODE));		
		public static readonly StringProperty PROPERTY_PARENTTYPE = new StringProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_PARENTTYPE));		
		public static readonly IntProperty PROPERTY_PARENTID = new IntProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_PARENTID));		
		public static readonly DecimalProperty PROPERTY_LONGITUDE = new DecimalProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_LONGITUDE));		
		public static readonly DecimalProperty PROPERTY_LATITUDE = new DecimalProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_LATITUDE));		
		public static readonly IntProperty PROPERTY_TIMEZONEID = new IntProperty(Property.ForName(SystemAddressEntity.PROPERTY_NAME_TIMEZONEID));		
      
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
                case "Type":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "Country":
                    return typeof (string);
                case "Province":
                    return typeof (string);
                case "City":
                    return typeof (string);
                case "Address1":
                    return typeof (string);
                case "Address2":
                    return typeof (string);
                case "Address3":
                    return typeof (string);
                case "ZipCode":
                    return typeof (string);
                case "ParentType":
                    return typeof (string);
                case "ParentID":
                    return typeof (int);
                case "Longitude":
                    return typeof (decimal);
                case "Latitude":
                    return typeof (decimal);
                case "TimeZoneID":
                    return typeof (int);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemAddressEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
