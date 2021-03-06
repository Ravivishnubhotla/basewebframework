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
    public partial class SPMemoDataObject : BaseNHibernateDataObject<SPMemoEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPMemoEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_TITLE = Property.ForName(SPMemoEntity.PROPERTY_NAME_TITLE);
		public static readonly Property PROPERTY_MEMOCONTENT = Property.ForName(SPMemoEntity.PROPERTY_NAME_MEMOCONTENT);
		public static readonly Property PROPERTY_CREATEDATE = Property.ForName(SPMemoEntity.PROPERTY_NAME_CREATEDATE);
      
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
                case "MemoContent":
                    return typeof (string);
                case "CreateDate":
                    return typeof (DateTime);
          }
			return typeof(string);
        }
		
		
		
		
		
    }
}
