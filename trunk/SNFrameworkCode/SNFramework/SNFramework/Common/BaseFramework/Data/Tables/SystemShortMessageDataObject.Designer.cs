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
    public partial class SystemShortMessageDataObject : BaseNHibernateDataObject<SystemShortMessageEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_SHORTMESSAGEID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGEID));		
		public static readonly StringProperty PROPERTY_SHORTMESSAGETITLE = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGETITLE));		
		public static readonly StringProperty PROPERTY_SHORTMESSAGECATEGORY = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGECATEGORY));		
		public static readonly StringProperty PROPERTY_SHORTMESSAGECONTENT = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGECONTENT));		
		public static readonly StringProperty PROPERTY_SHORTMESSAGESENDERNAME = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGESENDERNAME));		
		public static readonly StringProperty PROPERTY_SHORTMESSAGETONAME = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGETONAME));		
		public static readonly DateTimeProperty PROPERTY_SHORTMESSAGESENDDATE = new DateTimeProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGESENDDATE));		
		public static readonly IntProperty PROPERTY_SHORTMESSAGESENDUSERID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGESENDUSERID));		
		public static readonly IntProperty PROPERTY_SHORTMESSAGERECEIVERUSERID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGERECEIVERUSERID));		
		public static readonly BoolProperty PROPERTY_SHORTMESSAGEISREAD = new BoolProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGEISREAD));		
		public static readonly StringProperty PROPERTY_SHORTMESSAGETYPE = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGETYPE));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "ShortMessageID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "ShortMessageID":
                    return typeof (int);
                case "ShortMessageTitle":
                    return typeof (string);
                case "ShortMessageCategory":
                    return typeof (string);
                case "ShortMessageContent":
                    return typeof (string);
                case "ShortMessageSenderName":
                    return typeof (string);
                case "ShortMessageToName":
                    return typeof (string);
                case "ShortMessageSendDate":
                    return typeof (DateTime);
                case "ShortMessageSendUserID":
                    return typeof (int);
                case "ShortMessageReceiverUserID":
                    return typeof (int);
                case "ShortMessageIsRead":
                    return typeof (bool);
                case "ShortMessageType":
                    return typeof (string);
          }
			return typeof(string);
        }
		

		
		
    }
}