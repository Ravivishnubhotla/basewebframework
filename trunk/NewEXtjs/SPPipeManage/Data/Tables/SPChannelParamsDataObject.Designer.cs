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
    public partial class SPChannelParamsDataObject : BaseNHibernateDataObject<SPChannelParamsEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_ISREQUIRED = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_ISREQUIRED);
		public static readonly Property PROPERTY_PARAMSTYPE = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_PARAMSTYPE);
		public static readonly Property PROPERTY_CHANNELID = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_CHANNELID);
		#region channelID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPChannelParamsEntity> InClude_ChannelID_Query(NHibernateDynamicQueryGenerator<SPChannelParamsEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPChannelParamsEntity.PROPERTY_NAME_CHANNELID, PROPERTY_CHANNELID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPChannelParamsEntity_Alias";
		public static readonly Property PROPERTY_CHANNELID_ID = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Id");
		public static readonly Property PROPERTY_CHANNELID_NAME = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Name");
		public static readonly Property PROPERTY_CHANNELID_DESCRIPTION = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Description");
		public static readonly Property PROPERTY_CHANNELID_AREA = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Area");
		public static readonly Property PROPERTY_CHANNELID_OPERATOR = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Operator");
		public static readonly Property PROPERTY_CHANNELID_CHANNELCODE = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ChannelCode");
		public static readonly Property PROPERTY_CHANNELID_FUZZYCOMMAND = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".FuzzyCommand");
		public static readonly Property PROPERTY_CHANNELID_ACCURATECOMMAND = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".AccurateCommand");
		public static readonly Property PROPERTY_CHANNELID_PORT = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Port");
		public static readonly Property PROPERTY_CHANNELID_CHANNELTYPE = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ChannelType");
		public static readonly Property PROPERTY_CHANNELID_PRICE = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Price");
		public static readonly Property PROPERTY_CHANNELID_RATE = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Rate");
		public static readonly Property PROPERTY_CHANNELID_STATUS = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Status");
		public static readonly Property PROPERTY_CHANNELID_CREATETIME = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".CreateTime");
		public static readonly Property PROPERTY_CHANNELID_CREATEBY = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".CreateBy");
		public static readonly Property PROPERTY_CHANNELID_OKMESSAGE = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".OkMessage");
		public static readonly Property PROPERTY_CHANNELID_FAILEDMESSAGE = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".FailedMessage");
		public static readonly Property PROPERTY_CHANNELID_UPERID = Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".UperID");
		#endregion
		public static readonly Property PROPERTY_PARAMSMAPPINGNAME = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_PARAMSMAPPINGNAME);
		public static readonly Property PROPERTY_TITLE = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_TITLE);
		public static readonly Property PROPERTY_SHOWINCLIENTGRID = Property.ForName(SPChannelParamsEntity.PROPERTY_NAME_SHOWINCLIENTGRID);
      
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
                case "IsEnable":
                    return typeof (bool);
                case "IsRequired":
                    return typeof (bool);
                case "ParamsType":
                    return typeof (string);
                case "ChannelID":
                    return typeof (int);
                case "ParamsMappingName":
                    return typeof (string);
                case "Title":
                    return typeof (string);
                case "ShowInClientGrid":
                    return typeof (bool);
          }
			return typeof(string);
        }
		
		public List<SPChannelParamsEntity> GetList_By_SPChannelEntity(SPChannelEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPChannelParamsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPChannelParamsEntity> GetPageList_By_SPChannelEntity(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPChannelEntity fkentity, out int recordCount)
        {
            NHibernateDynamicQueryGenerator<SPChannelParamsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            dynamicQueryGenerator.SetFirstResult((pageIndex - 1) * pageSize);

            dynamicQueryGenerator.SetMaxResults(pageSize);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, out recordCount);
        }		
		

		
		
    }
}
