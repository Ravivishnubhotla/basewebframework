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
    public partial class SystemApplicationDataObject : BaseNHibernateDataObject<SystemApplicationEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONID = Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONID);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONNAME = Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONNAME);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONURL = Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONURL);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = Property.ForName(SystemApplicationEntity.PROPERTY_NAME_SYSTEMAPPLICATIONISSYSTEMAPPLICATION);
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "SystemApplicationID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "SystemApplicationID":
                    return typeof (int);
                    break;
                case "SystemApplicationName":
                    return typeof (string);
                    break;
                case "SystemApplicationDescription":
                    return typeof (string);
                    break;
                case "SystemApplicationUrl":
                    return typeof (string);
                    break;
                case "SystemApplicationIsSystemApplication":
                    return typeof (bool);
                    break;
          }
			return typeof(string);
        }
    }
}
