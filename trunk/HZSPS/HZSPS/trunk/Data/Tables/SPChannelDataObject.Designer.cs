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
    public partial class SPChannelDataObject : BaseNHibernateDataObject<SPChannelEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPChannelEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SPChannelEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SPChannelEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_AREA = Property.ForName(SPChannelEntity.PROPERTY_NAME_AREA);
		public static readonly Property PROPERTY_OPERATOR = Property.ForName(SPChannelEntity.PROPERTY_NAME_OPERATOR);
		public static readonly Property PROPERTY_CHANNELCODE = Property.ForName(SPChannelEntity.PROPERTY_NAME_CHANNELCODE);
		public static readonly Property PROPERTY_FUZZYCOMMAND = Property.ForName(SPChannelEntity.PROPERTY_NAME_FUZZYCOMMAND);
		public static readonly Property PROPERTY_ACCURATECOMMAND = Property.ForName(SPChannelEntity.PROPERTY_NAME_ACCURATECOMMAND);
		public static readonly Property PROPERTY_PORT = Property.ForName(SPChannelEntity.PROPERTY_NAME_PORT);
		public static readonly Property PROPERTY_CHANNELTYPE = Property.ForName(SPChannelEntity.PROPERTY_NAME_CHANNELTYPE);
		public static readonly Property PROPERTY_PRICE = Property.ForName(SPChannelEntity.PROPERTY_NAME_PRICE);
		public static readonly Property PROPERTY_RATE = Property.ForName(SPChannelEntity.PROPERTY_NAME_RATE);
		public static readonly Property PROPERTY_STATUS = Property.ForName(SPChannelEntity.PROPERTY_NAME_STATUS);
		public static readonly Property PROPERTY_CREATETIME = Property.ForName(SPChannelEntity.PROPERTY_NAME_CREATETIME);
		public static readonly Property PROPERTY_CREATEBY = Property.ForName(SPChannelEntity.PROPERTY_NAME_CREATEBY);
		public static readonly Property PROPERTY_OKMESSAGE = Property.ForName(SPChannelEntity.PROPERTY_NAME_OKMESSAGE);
		public static readonly Property PROPERTY_FAILEDMESSAGE = Property.ForName(SPChannelEntity.PROPERTY_NAME_FAILEDMESSAGE);
		public static readonly Property PROPERTY_UPERID = Property.ForName(SPChannelEntity.PROPERTY_NAME_UPERID);
		#region uperID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPChannelEntity> InClude_UperID_Query(NHibernateDynamicQueryGenerator<SPChannelEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPChannelEntity.PROPERTY_NAME_UPERID, PROPERTY_UPERID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_UPERID_ALIAS_NAME = "UperID_SPChannelEntity_Alias";
		public static readonly Property PROPERTY_UPERID_ID = Property.ForName(PROPERTY_UPERID_ALIAS_NAME + ".Id");
		public static readonly Property PROPERTY_UPERID_NAME = Property.ForName(PROPERTY_UPERID_ALIAS_NAME + ".Name");
		public static readonly Property PROPERTY_UPERID_DESCRIPTION = Property.ForName(PROPERTY_UPERID_ALIAS_NAME + ".Description");
		public static readonly Property PROPERTY_UPERID_CREATEDATE = Property.ForName(PROPERTY_UPERID_ALIAS_NAME + ".CreateDate");
		#endregion
		public static readonly Property PROPERTY_CHANNELCODEPARAMSNAME = Property.ForName(SPChannelEntity.PROPERTY_NAME_CHANNELCODEPARAMSNAME);
		public static readonly Property PROPERTY_ISALLOWNULLLINKID = Property.ForName(SPChannelEntity.PROPERTY_NAME_ISALLOWNULLLINKID);
		public static readonly Property PROPERTY_RECSTATREPORT = Property.ForName(SPChannelEntity.PROPERTY_NAME_RECSTATREPORT);
		public static readonly Property PROPERTY_STATPARAMSNAME = Property.ForName(SPChannelEntity.PROPERTY_NAME_STATPARAMSNAME);
		public static readonly Property PROPERTY_STATPARAMSVALUES = Property.ForName(SPChannelEntity.PROPERTY_NAME_STATPARAMSVALUES);
		public static readonly Property PROPERTY_HASREQUESTTYPEPARAMS = Property.ForName(SPChannelEntity.PROPERTY_NAME_HASREQUESTTYPEPARAMS);
		public static readonly Property PROPERTY_REQUESTTYPEPARAMNAME = Property.ForName(SPChannelEntity.PROPERTY_NAME_REQUESTTYPEPARAMNAME);
		public static readonly Property PROPERTY_REQUESTTYPEVALUES = Property.ForName(SPChannelEntity.PROPERTY_NAME_REQUESTTYPEVALUES);
		public static readonly Property PROPERTY_HASFILTERS = Property.ForName(SPChannelEntity.PROPERTY_NAME_HASFILTERS);
		public static readonly Property PROPERTY_CHANNELINFO = Property.ForName(SPChannelEntity.PROPERTY_NAME_CHANNELINFO);
		public static readonly Property PROPERTY_STATSENDONCE = Property.ForName(SPChannelEntity.PROPERTY_NAME_STATSENDONCE);
		public static readonly Property PROPERTY_ISMONITORINGREQUEST = Property.ForName(SPChannelEntity.PROPERTY_NAME_ISMONITORINGREQUEST);
		public static readonly Property PROPERTY_ISDISABLE = Property.ForName(SPChannelEntity.PROPERTY_NAME_ISDISABLE);
		public static readonly Property PROPERTY_REPORTIDPARAMS = Property.ForName(SPChannelEntity.PROPERTY_NAME_REPORTIDPARAMS);
		public static readonly Property PROPERTY_CHANNEDATA = Property.ForName(SPChannelEntity.PROPERTY_NAME_CHANNEDATA);
      
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
                case "Area":
                    return typeof (string);
                case "Operator":
                    return typeof (string);
                case "ChannelCode":
                    return typeof (string);
                case "FuzzyCommand":
                    return typeof (string);
                case "AccurateCommand":
                    return typeof (string);
                case "Port":
                    return typeof (string);
                case "ChannelType":
                    return typeof (string);
                case "Price":
                    return typeof (decimal);
                case "Rate":
                    return typeof (int);
                case "Status":
                    return typeof (int);
                case "CreateTime":
                    return typeof (DateTime);
                case "CreateBy":
                    return typeof (int);
                case "OkMessage":
                    return typeof (string);
                case "FailedMessage":
                    return typeof (string);
                case "UperID":
                    return typeof (int);
                case "ChannelCodeParamsName":
                    return typeof (string);
                case "IsAllowNullLinkID":
                    return typeof (bool);
                case "RecStatReport":
                    return typeof (bool);
                case "StatParamsName":
                    return typeof (string);
                case "StatParamsValues":
                    return typeof (string);
                case "HasRequestTypeParams":
                    return typeof (bool);
                case "RequestTypeParamName":
                    return typeof (string);
                case "RequestTypeValues":
                    return typeof (string);
                case "HasFilters":
                    return typeof (bool);
                case "ChannelInfo":
                    return typeof (string);
                case "StatSendOnce":
                    return typeof (bool);
                case "IsMonitoringRequest":
                    return typeof (bool);
                case "IsDisable":
                    return typeof (bool);
                case "ReportIDParams":
                    return typeof (string);
                case "ChanneData":
                    return typeof (string);
          }
			return typeof(string);
        }
		
				public List<SPChannelEntity> GetList_By_SPUperEntity(SPUperEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPChannelEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_UPERID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPChannelEntity> GetPageList_By_SPUperEntity(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPUperEntity fkentity, out int recordCount)
        {
            NHibernateDynamicQueryGenerator<SPChannelEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_UPERID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            dynamicQueryGenerator.SetFirstResult((pageIndex - 1) * pageSize);

            dynamicQueryGenerator.SetMaxResults(pageSize);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, out recordCount);
        }		
		

		
		
		
    }
}
