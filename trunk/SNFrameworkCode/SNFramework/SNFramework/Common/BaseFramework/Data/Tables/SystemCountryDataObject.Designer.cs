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
    public partial class SystemCountryDataObject : BaseNHibernateDataObject<SystemCountryEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_CODENUMBER = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_CODENUMBER));		
		public static readonly StringProperty PROPERTY_CODE2 = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_CODE2));		
		public static readonly StringProperty PROPERTY_CODE3 = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_CODE3));		
		public static readonly StringProperty PROPERTY_ABBRNAMECN = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_ABBRNAMECN));		
		public static readonly StringProperty PROPERTY_ABBRNAMEEN = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_ABBRNAMEEN));		
		public static readonly StringProperty PROPERTY_FULLNAMECN = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_FULLNAMECN));		
		public static readonly StringProperty PROPERTY_FULLNAMEEN = new StringProperty(Property.ForName(SystemCountryEntity.PROPERTY_NAME_FULLNAMEEN));		
      
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
                case "CodeNumber":
                    return typeof (string);
                case "Code2":
                    return typeof (string);
                case "Code3":
                    return typeof (string);
                case "AbbrNameCN":
                    return typeof (string);
                case "AbbrNameEN":
                    return typeof (string);
                case "FullNameCn":
                    return typeof (string);
                case "FullNameEn":
                    return typeof (string);
          }
			return typeof(string);
        }
		

		
		
    }
}
