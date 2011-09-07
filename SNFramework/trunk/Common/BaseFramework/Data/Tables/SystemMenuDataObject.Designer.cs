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
    public partial class SystemMenuDataObject : BaseNHibernateDataObject<SystemMenuEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_MENUID = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUID);
		public static readonly Property PROPERTY_MENUNAME = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUNAME);
		public static readonly Property PROPERTY_MENUDESCRIPTION = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUDESCRIPTION);
		public static readonly Property PROPERTY_MENUURL = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUURL);
		public static readonly Property PROPERTY_MENUURLTARGET = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUURLTARGET);
		public static readonly Property PROPERTY_MENUICONURL = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUICONURL);
		public static readonly Property PROPERTY_MENUISCATEGORY = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUISCATEGORY);
		public static readonly Property PROPERTY_PARENTMENUID = Property.ForName(SystemMenuEntity.PROPERTY_NAME_PARENTMENUID);
		public static readonly Property PROPERTY_MENUORDER = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUORDER);
		public static readonly Property PROPERTY_MENUTYPE = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUTYPE);
		public static readonly Property PROPERTY_MENUISSYSTEMMENU = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUISSYSTEMMENU);
		public static readonly Property PROPERTY_MENUISENABLE = Property.ForName(SystemMenuEntity.PROPERTY_NAME_MENUISENABLE);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemMenuEntity.PROPERTY_NAME_APPLICATIONID);
		#region applicationID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemMenuEntity> InClude_ApplicationID_Query(NHibernateDynamicQueryGenerator<SystemMenuEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemMenuEntity.PROPERTY_NAME_APPLICATIONID, PROPERTY_APPLICATIONID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemMenuEntity_Alias";
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationID");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationName");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationDescription");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationUrl");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationIsSystemApplication");
		#endregion
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "MenuID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "MenuID":
                    return typeof (int);
                case "MenuName":
                    return typeof (string);
                case "MenuDescription":
                    return typeof (string);
                case "MenuUrl":
                    return typeof (string);
                case "MenuUrlTarget":
                    return typeof (string);
                case "MenuIconUrl":
                    return typeof (string);
                case "MenuIsCategory":
                    return typeof (bool);
                case "ParentMenuID":
                    return typeof (int);
                case "MenuOrder":
                    return typeof (int);
                case "MenuType":
                    return typeof (string);
                case "MenuIsSystemMenu":
                    return typeof (bool);
                case "MenuIsEnable":
                    return typeof (bool);
                case "ApplicationID":
                    return typeof (int);
          }
			return typeof(string);
        }
		
		public List<SystemMenuEntity> GetList_By_ApplicationID_SystemApplicationEntity(SystemApplicationEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemMenuEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_APPLICATIONID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemMenuEntity> GetPageList_By_ApplicationID_SystemApplicationEntity(string orderByColumnName, bool isDesc, SystemApplicationEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemMenuEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_APPLICATIONID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}