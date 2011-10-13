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
    public partial class SystemEmailSettingsDataObject : BaseNHibernateDataObject<SystemEmailSettingsEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_EMAILSETTINGID = new IntProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_EMAILSETTINGID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_CODE = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_CODE));		
		public static readonly StringProperty PROPERTY_DESCRIPRSION = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_DESCRIPRSION));		
		public static readonly StringProperty PROPERTY_HOST = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_HOST));		
		public static readonly StringProperty PROPERTY_PORT = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_PORT));		
		public static readonly BoolProperty PROPERTY_SSL = new BoolProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_SSL));		
		public static readonly StringProperty PROPERTY_FROMEMAIL = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_FROMEMAIL));		
		public static readonly StringProperty PROPERTY_FROMNAME = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_FROMNAME));		
		public static readonly StringProperty PROPERTY_LOGINEMAIL = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LOGINEMAIL));		
		public static readonly StringProperty PROPERTY_LOGINPASSWORD = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LOGINPASSWORD));		
		public static readonly BoolProperty PROPERTY_ISENABLE = new BoolProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_ISENABLE));		
		public static readonly BoolProperty PROPERTY_ISDEFAULT = new BoolProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_ISDEFAULT));		
		public static readonly IntProperty PROPERTY_ORDERINDEX = new IntProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_ORDERINDEX));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "EmailSettingID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "EmailSettingID":
                    return typeof (int);
                case "Name":
                    return typeof (string);
                case "Code":
                    return typeof (string);
                case "Descriprsion":
                    return typeof (string);
                case "Host":
                    return typeof (string);
                case "Port":
                    return typeof (string);
                case "Ssl":
                    return typeof (bool);
                case "FromEmail":
                    return typeof (string);
                case "FromName":
                    return typeof (string);
                case "LoginEmail":
                    return typeof (string);
                case "LoginPassword":
                    return typeof (string);
                case "IsEnable":
                    return typeof (bool);
                case "IsDefault":
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
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemEmailSettingsEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
