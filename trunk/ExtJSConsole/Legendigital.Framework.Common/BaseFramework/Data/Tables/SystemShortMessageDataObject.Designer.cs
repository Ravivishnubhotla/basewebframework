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
    public partial class SystemShortMessageDataObject : BaseNHibernateDataObject<SystemShortMessageEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SHORTMESSAGEID = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGEID);
		public static readonly Property PROPERTY_SHORTMESSAGETITLE = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGETITLE);
		public static readonly Property PROPERTY_SHORTMESSAGECATEGORY = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGECATEGORY);
		public static readonly Property PROPERTY_SHORTMESSAGECONTENT = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGECONTENT);
		public static readonly Property PROPERTY_SHORTMESSAGESENDER = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGESENDER);
		public static readonly Property PROPERTY_SHORTMESSAGESENDDATE = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGESENDDATE);
		public static readonly Property PROPERTY_SHORTMESSAGERECEIVERID = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGERECEIVERID);
		public static readonly Property PROPERTY_SHORTMESSAGEISREAD = Property.ForName(SystemShortMessageEntity.PROPERTY_NAME_SHORTMESSAGEISREAD);
      
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
                    break;
                case "ShortMessageTitle":
                    return typeof (string);
                    break;
                case "ShortMessageCategory":
                    return typeof (string);
                    break;
                case "ShortMessageContent":
                    return typeof (string);
                    break;
                case "ShortMessageSender":
                    return typeof (string);
                    break;
                case "ShortMessageSendDate":
                    return typeof (DateTime);
                    break;
                case "ShortMessageReceiverID":
                    return typeof (int);
                    break;
                case "ShortMessageIsRead":
                    return typeof (bool);
                    break;
          }
			return typeof(string);
        }
    }
}
