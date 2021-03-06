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
    public partial class SPChannelFiltersDataObject : BaseNHibernateDataObject<SPChannelFiltersEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_CHANNELID = Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_CHANNELID);
		public static readonly Property PROPERTY_PARAMSNAME = Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_PARAMSNAME);
		public static readonly Property PROPERTY_FILTERTYPE = Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_FILTERTYPE);
		public static readonly Property PROPERTY_FILTERVALUE = Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_FILTERVALUE);
      
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
                case "ParamsName":
                    return typeof (string);
                case "FilterType":
                    return typeof (string);
                case "FilterValue":
                    return typeof (string);
          }
			return typeof(string);
        }
		
		
		
		
		
    }
}
