// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using LD.SPPipeManage.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace LD.SPPipeManage.Data.Tables
{
    public partial class SPFailedRequestDataObject : BaseNHibernateDataObject<SPFailedRequestEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_RECIEVEDCONTENT = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_RECIEVEDCONTENT);
		public static readonly Property PROPERTY_RECIEVEDDATE = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_RECIEVEDDATE);
		public static readonly Property PROPERTY_RECIEVEDIP = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_RECIEVEDIP);
		public static readonly Property PROPERTY_RECIEVEDSENDURL = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_RECIEVEDSENDURL);
		public static readonly Property PROPERTY_CHANNELID = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_CHANNELID);
		public static readonly Property PROPERTY_CLIENTID = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_CLIENTID);
		public static readonly Property PROPERTY_FAILEDMESSAGE = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_FAILEDMESSAGE);
		public static readonly Property PROPERTY_ISPROCESSED = Property.ForName(SPFailedRequestEntity.PROPERTY_NAME_ISPROCESSED);
      
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
                case "RecievedContent":
                    return typeof (string);
                case "RecievedDate":
                    return typeof (DateTime);
                case "RecievedIP":
                    return typeof (string);
                case "RecievedSendUrl":
                    return typeof (string);
                case "ChannelID":
                    return typeof (int);
                case "ClientID":
                    return typeof (int);
                case "FailedMessage":
                    return typeof (string);
                case "IsProcessed":
                    return typeof (bool);
          }
			return typeof(string);
        }
		
		
		
		
		
    }
}
