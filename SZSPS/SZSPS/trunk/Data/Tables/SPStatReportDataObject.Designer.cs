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
    public partial class SPStatReportDataObject : BaseNHibernateDataObject<SPStatReportEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPStatReportEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_CHANNELID = Property.ForName(SPStatReportEntity.PROPERTY_NAME_CHANNELID);
		public static readonly Property PROPERTY_STAT = Property.ForName(SPStatReportEntity.PROPERTY_NAME_STAT);
		public static readonly Property PROPERTY_LINKID = Property.ForName(SPStatReportEntity.PROPERTY_NAME_LINKID);
		public static readonly Property PROPERTY_QUERYSTRING = Property.ForName(SPStatReportEntity.PROPERTY_NAME_QUERYSTRING);
		public static readonly Property PROPERTY_REQUESTCONTENT = Property.ForName(SPStatReportEntity.PROPERTY_NAME_REQUESTCONTENT);
		public static readonly Property PROPERTY_CREATEDATE = Property.ForName(SPStatReportEntity.PROPERTY_NAME_CREATEDATE);
		public static readonly Property PROPERTY_ISPAYOK = Property.ForName(SPStatReportEntity.PROPERTY_NAME_ISPAYOK);
      
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
                case "ChannelID":
                    return typeof (int);
                case "Stat":
                    return typeof (string);
                case "LinkID":
                    return typeof (string);
                case "QueryString":
                    return typeof (string);
                case "RequestContent":
                    return typeof (string);
                case "CreateDate":
                    return typeof (DateTime);
                case "IsPayOk":
                    return typeof (bool);
          }
			return typeof(string);
        }
		
		
		
		
		
    }
}
