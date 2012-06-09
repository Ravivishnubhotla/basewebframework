// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPFilterRuleDataObject.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using SPS.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace SPS.Data.Tables
{
    public partial class SPFilterRuleDataObject : BaseNHibernateDataObject<SPFilterRuleEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPFilterRuleEntity.PROPERTY_NAME_ID));		
		public static readonly IntProperty PROPERTY_PARENTDATAID = new IntProperty(Property.ForName(SPFilterRuleEntity.PROPERTY_NAME_PARENTDATAID));		
		public static readonly StringProperty PROPERTY_PARENTDATATYPE = new StringProperty(Property.ForName(SPFilterRuleEntity.PROPERTY_NAME_PARENTDATATYPE));		
		public static readonly StringProperty PROPERTY_RULECODE = new StringProperty(Property.ForName(SPFilterRuleEntity.PROPERTY_NAME_RULECODE));		
		public static readonly StringProperty PROPERTY_FILTERTYPE = new StringProperty(Property.ForName(SPFilterRuleEntity.PROPERTY_NAME_FILTERTYPE));		
      
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
                case "ParentDataID":
                    return typeof (int);
                case "ParentDataType":
                    return typeof (string);
                case "RuleCode":
                    return typeof (string);
                case "FilterType":
                    return typeof (string);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPFilterRuleEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}