// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemDepartmentDataObject : BaseNHibernateDataObject<SystemDepartmentEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_DEPARTMENTID = Property.ForName(SystemDepartmentEntity.PROPERTY_NAME_DEPARTMENTID);
		public static readonly Property PROPERTY_PARENTDEPARTMENTID = Property.ForName(SystemDepartmentEntity.PROPERTY_NAME_PARENTDEPARTMENTID);
		public static readonly Property PROPERTY_DEPARTMENTNAMECN = Property.ForName(SystemDepartmentEntity.PROPERTY_NAME_DEPARTMENTNAMECN);
		public static readonly Property PROPERTY_DEPARTMENTNAMEEN = Property.ForName(SystemDepartmentEntity.PROPERTY_NAME_DEPARTMENTNAMEEN);
		public static readonly Property PROPERTY_DEPARTMENTDECRIPTION = Property.ForName(SystemDepartmentEntity.PROPERTY_NAME_DEPARTMENTDECRIPTION);
		public static readonly Property PROPERTY_DEPARTMENTSORTINDEX = Property.ForName(SystemDepartmentEntity.PROPERTY_NAME_DEPARTMENTSORTINDEX);
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "DepartmentID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "DepartmentID":
                    return typeof (int);
                case "ParentDepartmentID":
                    return typeof (int);
                case "DepartmentNameCn":
                    return typeof (string);
                case "DepartmentNameEn":
                    return typeof (string);
                case "DepartmentDecription":
                    return typeof (string);
                case "DepartmentSortIndex":
                    return typeof (int);
          }
			return typeof(string);
        }
    }
}
