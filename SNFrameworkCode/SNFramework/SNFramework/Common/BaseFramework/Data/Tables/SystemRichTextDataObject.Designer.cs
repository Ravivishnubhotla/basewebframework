// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemRichTextDataObject : BaseNHibernateDataObject<SystemRichTextEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_TYPE = new StringProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_TYPE));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly StringProperty PROPERTY_TEXTCONTENT = new StringProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_TEXTCONTENT));		
		public static readonly StringProperty PROPERTY_PARENTTYPE = new StringProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_PARENTTYPE));		
		public static readonly IntProperty PROPERTY_PARENTID = new IntProperty(Property.ForName(SystemRichTextEntity.PROPERTY_NAME_PARENTID));		
      
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
                case "Type":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "TextContent":
                    return typeof (string);
                case "ParentType":
                    return typeof (string);
                case "ParentID":
                    return typeof (int);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemRichTextEntity> queryGenerator)
        {
            switch (parent_alias)
            {
                default:
                    break;
 
            }
        }
		
		
		

		
		
    }
}
