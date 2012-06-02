// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPMemoDataObject.Designer.cs">
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
    public partial class SPMemoDataObject : BaseNHibernateDataObject<SPMemoEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_TITLE = new StringProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_TITLE));		
		public static readonly StringProperty PROPERTY_TEXTCONTENT = new StringProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_TEXTCONTENT));		
		public static readonly DateTimeProperty PROPERTY_PUBLISHDATE = new DateTimeProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_PUBLISHDATE));		
		public static readonly DateTimeProperty PROPERTY_CREATEDATE = new DateTimeProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_CREATEDATE));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SPMemoEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      
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
                case "TextContent":
                    return typeof (string);
                case "PublishDate":
                    return typeof (DateTime);
                case "CreateDate":
                    return typeof (DateTime);
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
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPMemoEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
