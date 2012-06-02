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
    public partial class SystemShortMessageDataObject : BaseNHibernateDataObject<SystemShortMessageEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_TITLE = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_TITLE));		
		public static readonly StringProperty PROPERTY_MESSAGETYPE = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_MESSAGETYPE));		
		public static readonly StringProperty PROPERTY_CATEGORY = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_CATEGORY));		
		public static readonly StringProperty PROPERTY_MSGCONTENT = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_MSGCONTENT));		
		public static readonly IntProperty PROPERTY_SENDID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SENDID));		
		public static readonly IntProperty PROPERTY_GROUPID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_GROUPID));		
		public static readonly DateTimeProperty PROPERTY_SENDDATE = new DateTimeProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SENDDATE));		
		public static readonly StringProperty PROPERTY_STATUS = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_STATUS));		
		public static readonly IntProperty PROPERTY_REPLYID = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_REPLYID));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      
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
                case "Title":
                    return typeof (string);
                case "MessageType":
                    return typeof (string);
                case "Category":
                    return typeof (string);
                case "MsgContent":
                    return typeof (string);
                case "SendID":
                    return typeof (int);
                case "GroupID":
                    return typeof (int);
                case "SendDate":
                    return typeof (DateTime);
                case "Status":
                    return typeof (string);
                case "ReplyID":
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
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemShortMessageEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
