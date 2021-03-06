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
    public partial class SystemEmailSettingsDataObject : BaseNHibernateDataObject<SystemEmailSettingsEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_EMAILSETTINGID = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_EMAILSETTINGID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_DESCRIPRSION = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_DESCRIPRSION);
		public static readonly Property PROPERTY_HOST = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_HOST);
		public static readonly Property PROPERTY_PORT = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_PORT);
		public static readonly Property PROPERTY_SSL = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_SSL);
		public static readonly Property PROPERTY_FROMEMAIL = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_FROMEMAIL);
		public static readonly Property PROPERTY_FROMNAME = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_FROMNAME);
		public static readonly Property PROPERTY_LOGINEMAIL = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LOGINEMAIL);
		public static readonly Property PROPERTY_LOGINPASSWORD = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_LOGINPASSWORD);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_ISDEFAULT = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_ISDEFAULT);
		public static readonly Property PROPERTY_CREATEDATE = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_CREATEDATE);
		public static readonly Property PROPERTY_CREATEBY = Property.ForName(SystemEmailSettingsEntity.PROPERTY_NAME_CREATEBY);
      
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
                case "CreateDate":
                    return typeof (DateTime);
                case "CreateBy":
                    return typeof (int);
          }
			return typeof(string);
        }
		

		
		
    }
}
