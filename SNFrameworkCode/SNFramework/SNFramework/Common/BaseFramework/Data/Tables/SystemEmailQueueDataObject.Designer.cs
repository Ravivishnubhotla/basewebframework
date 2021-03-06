// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemEmailQueueDataObject.Designer.cs">
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
    public partial class SystemEmailQueueDataObject : BaseNHibernateDataObject<SystemEmailQueueEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_QUEUEID = new IntProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_QUEUEID));		
		public static readonly StringProperty PROPERTY_TITLE = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_TITLE));		
		public static readonly StringProperty PROPERTY_BODY = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_BODY));		
		public static readonly StringProperty PROPERTY_FROMADDRESS = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_FROMADDRESS));		
		public static readonly StringProperty PROPERTY_FROMNAME = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_FROMNAME));		
		public static readonly StringProperty PROPERTY_TOADDRESSS = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_TOADDRESSS));		
		public static readonly StringProperty PROPERTY_TONAMES = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_TONAMES));		
		public static readonly StringProperty PROPERTY_CCADDRESSS = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_CCADDRESSS));		
		public static readonly StringProperty PROPERTY_CCNAMES = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_CCNAMES));		
		public static readonly StringProperty PROPERTY_BCCADDRESSS = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_BCCADDRESSS));		
		public static readonly StringProperty PROPERTY_BCCNAMES = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_BCCNAMES));		
		public static readonly IntProperty PROPERTY_EMAILTEMPLATEID = new IntProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_EMAILTEMPLATEID));		
		public static readonly StringProperty PROPERTY_STATUES = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_STATUES));		
		public static readonly IntProperty PROPERTY_SENDRETRY = new IntProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_SENDRETRY));		
		public static readonly IntProperty PROPERTY_MAXRETRYTIME = new IntProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_MAXRETRYTIME));		
		public static readonly StringProperty PROPERTY_MAILLOG = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_MAILLOG));		
		public static readonly DateTimeProperty PROPERTY_CREATEDATE = new DateTimeProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_CREATEDATE));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly StringProperty PROPERTY_SENDCONFIG = new StringProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_SENDCONFIG));		
		public static readonly DateTimeProperty PROPERTY_SENDDATE = new DateTimeProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_SENDDATE));		
		public static readonly IntProperty PROPERTY_ORDERINDEX = new IntProperty(Property.ForName(SystemEmailQueueEntity.PROPERTY_NAME_ORDERINDEX));		
      












		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "QueueID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "QueueID":
                    return typeof (int);
                case "Title":
                    return typeof (string);
                case "Body":
                    return typeof (string);
                case "FromAddress":
                    return typeof (string);
                case "FromName":
                    return typeof (string);
                case "ToAddresss":
                    return typeof (string);
                case "ToNames":
                    return typeof (string);
                case "CCAddresss":
                    return typeof (string);
                case "CCNames":
                    return typeof (string);
                case "BCCAddresss":
                    return typeof (string);
                case "BCCNames":
                    return typeof (string);
                case "EmailTemplateID":
                    return typeof (int);
                case "Statues":
                    return typeof (string);
                case "SendRetry":
                    return typeof (int);
                case "MaxRetryTime":
                    return typeof (int);
                case "MailLog":
                    return typeof (string);
                case "CreateDate":
                    return typeof (DateTime);
                case "CreateBy":
                    return typeof (int);
                case "SendConfig":
                    return typeof (string);
                case "SendDate":
                    return typeof (DateTime);
                case "OrderIndex":
                    return typeof (int);
          }
			return typeof(string);
        }

		#region 获取外键字段类型
		
		public override Type GetFieldTypeByFieldName(string fieldName, string parent_alias)
        {
            switch (parent_alias)
            {
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemEmailQueueEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
