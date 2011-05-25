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
    public partial class SPClientGroupDataObject : BaseNHibernateDataObject<SPClientGroupEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPClientGroupEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SPClientGroupEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SPClientGroupEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_USERID = Property.ForName(SPClientGroupEntity.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_DEFAULTSYCNMOURL = Property.ForName(SPClientGroupEntity.PROPERTY_NAME_DEFAULTSYCNMOURL);
		public static readonly Property PROPERTY_DEFAULTSYCNMRURL = Property.ForName(SPClientGroupEntity.PROPERTY_NAME_DEFAULTSYCNMRURL);
      
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
                case "UserID":
                    return typeof (int);
                case "DefaultSycnMoUrl":
                    return typeof (string);
                case "DefaultSycnMRUrl":
                    return typeof (string);
          }
			return typeof(string);
        }
		
		
		
		
		
    }
}
