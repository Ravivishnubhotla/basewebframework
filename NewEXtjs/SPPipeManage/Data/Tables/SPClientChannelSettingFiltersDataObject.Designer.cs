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
    public partial class SPClientChannelSettingFiltersDataObject : BaseNHibernateDataObject<SPClientChannelSettingFiltersEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPClientChannelSettingFiltersEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_PARAMSNAME = Property.ForName(SPClientChannelSettingFiltersEntity.PROPERTY_NAME_PARAMSNAME);
		public static readonly Property PROPERTY_FILTERTYPE = Property.ForName(SPClientChannelSettingFiltersEntity.PROPERTY_NAME_FILTERTYPE);
		public static readonly Property PROPERTY_FILTERVALUE = Property.ForName(SPClientChannelSettingFiltersEntity.PROPERTY_NAME_FILTERVALUE);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SPClientChannelSettingFiltersEntity.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID = Property.ForName(SPClientChannelSettingFiltersEntity.PROPERTY_NAME_CLIENTCHANNELSETTINGID);
      
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
                case "ParamsName":
                    return typeof (string);
                case "FilterType":
                    return typeof (string);
                case "FilterValue":
                    return typeof (string);
                case "IsEnable":
                    return typeof (bool);
                case "ClientChannelSettingID":
                    return typeof (int);
          }
			return typeof(string);
        }
		

		
		
    }
}
