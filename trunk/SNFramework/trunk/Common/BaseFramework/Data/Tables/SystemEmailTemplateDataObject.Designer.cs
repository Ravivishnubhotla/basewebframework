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
    public partial class SystemEmailTemplateDataObject : BaseNHibernateDataObject<SystemEmailTemplateEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_EMAILTEMPLATEID = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_EMAILTEMPLATEID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_CODE = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_CODE);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_TEMPLATETYPE = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_TEMPLATETYPE);
		public static readonly Property PROPERTY_TITLETEMPLATE = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_TITLETEMPLATE);
		public static readonly Property PROPERTY_BODYTEMPLATE = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_BODYTEMPLATE);
		public static readonly Property PROPERTY_ISHTMLEMAIL = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_ISHTMLEMAIL);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_CREATEDATE = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_CREATEDATE);
		public static readonly Property PROPERTY_CREATEBY = Property.ForName(SystemEmailTemplateEntity.PROPERTY_NAME_CREATEBY);
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "EmailTemplateID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "EmailTemplateID":
                    return typeof (int);
                case "Name":
                    return typeof (string);
                case "Code":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "TemplateType":
                    return typeof (string);
                case "TitleTemplate":
                    return typeof (string);
                case "BodyTemplate":
                    return typeof (string);
                case "IsHtmlEmail":
                    return typeof (bool);
                case "IsEnable":
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
