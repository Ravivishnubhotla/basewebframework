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
    public partial class SPClientDataObject : BaseNHibernateDataObject<SPClientEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPClientEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SPClientEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SPClientEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_RECIEVEDATAURL = Property.ForName(SPClientEntity.PROPERTY_NAME_RECIEVEDATAURL);
		public static readonly Property PROPERTY_USERID = Property.ForName(SPClientEntity.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_SYNCDATA = Property.ForName(SPClientEntity.PROPERTY_NAME_SYNCDATA);
		public static readonly Property PROPERTY_OKMESSAGE = Property.ForName(SPClientEntity.PROPERTY_NAME_OKMESSAGE);
		public static readonly Property PROPERTY_FAILEDMESSAGE = Property.ForName(SPClientEntity.PROPERTY_NAME_FAILEDMESSAGE);
		public static readonly Property PROPERTY_SYNCTYPE = Property.ForName(SPClientEntity.PROPERTY_NAME_SYNCTYPE);
      
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
                case "Name":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "RecieveDataUrl":
                    return typeof (string);
                case "UserID":
                    return typeof (int);
                case "SyncData":
                    return typeof (bool);
                case "OkMessage":
                    return typeof (string);
                case "FailedMessage":
                    return typeof (string);
                case "SyncType":
                    return typeof (string);
          }
			return typeof(string);
        }
		

		
		
    }
}