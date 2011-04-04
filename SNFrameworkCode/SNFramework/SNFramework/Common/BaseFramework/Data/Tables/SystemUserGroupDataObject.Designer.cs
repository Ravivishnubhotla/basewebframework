// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemUserGroupDataObject : BaseNHibernateDataObject<SystemUserGroupEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_GROUPID = new IntProperty(Property.ForName(SystemUserGroupEntity.PROPERTY_NAME_GROUPID));		
		public static readonly StringProperty PROPERTY_GROUPNAMECN = new StringProperty(Property.ForName(SystemUserGroupEntity.PROPERTY_NAME_GROUPNAMECN));		
		public static readonly StringProperty PROPERTY_GROUPNAMEEN = new StringProperty(Property.ForName(SystemUserGroupEntity.PROPERTY_NAME_GROUPNAMEEN));		
		public static readonly StringProperty PROPERTY_GROUPDESCRIPTION = new StringProperty(Property.ForName(SystemUserGroupEntity.PROPERTY_NAME_GROUPDESCRIPTION));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "GroupID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "GroupID":
                    return typeof (int);
                case "GroupNameCn":
                    return typeof (string);
                case "GroupNameEn":
                    return typeof (string);
                case "GroupDescription":
                    return typeof (string);
          }
			return typeof(string);
        }
		

		
		
    }
}