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
    public partial class SystemViewItemDataObject : BaseNHibernateDataObject<SystemViewItemEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMVIEWITEMID = Property.ForName(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWITEMID);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMNAMEEN = Property.ForName(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWITEMNAMEEN);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMNAMECN = Property.ForName(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWITEMNAMECN);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMDESCRIPTION = Property.ForName(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWITEMDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMDISPLAYFORMAT = Property.ForName(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWITEMDISPLAYFORMAT);
		public static readonly Property PROPERTY_SYSTEMVIEWID = Property.ForName(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWID);
		#region systemViewID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemViewItemEntity> InClude_SystemViewID_Query(NHibernateDynamicQueryGenerator<SystemViewItemEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemViewItemEntity.PROPERTY_NAME_SYSTEMVIEWID, PROPERTY_SYSTEMVIEWID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_SYSTEMVIEWID_ALIAS_NAME = "SystemViewID_SystemViewItemEntity_Alias";
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWID = Property.ForName(PROPERTY_SYSTEMVIEWID_ALIAS_NAME + ".SystemViewID");
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWNAMECN = Property.ForName(PROPERTY_SYSTEMVIEWID_ALIAS_NAME + ".SystemViewNameCn");
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWNAMEEN = Property.ForName(PROPERTY_SYSTEMVIEWID_ALIAS_NAME + ".SystemViewNameEn");
		public static readonly Property PROPERTY_SYSTEMVIEWID_APPLICATIONID = Property.ForName(PROPERTY_SYSTEMVIEWID_ALIAS_NAME + ".ApplicationID");
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWDESCRIPTION = Property.ForName(PROPERTY_SYSTEMVIEWID_ALIAS_NAME + ".SystemViewDescription");
		#endregion
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "SystemViewItemID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "SystemViewItemID":
                    return typeof (int);
                    break;
                case "SystemViewItemNameEn":
                    return typeof (string);
                    break;
                case "SystemViewItemNameCn":
                    return typeof (string);
                    break;
                case "SystemViewItemDescription":
                    return typeof (string);
                    break;
                case "SystemViewItemDisplayFormat":
                    return typeof (string);
                    break;
                case "SystemViewID":
                    return typeof (int);
                    break;
          }
			return typeof(string);
        }
    }
}