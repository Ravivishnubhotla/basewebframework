// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables.Container;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace SPS.Bussiness.Wrappers
{
    public partial class SPCodeFilterWrapper   
    {
        #region Member

		internal static readonly ISPCodeFilterServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPCodeFilterServiceProxyInstance;
		
		
		internal SPCodeFilterEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPCodeFilterWrapper() : base(new SPCodeFilterEntity())
        {
            
        }

        internal SPCodeFilterWrapper(SPCodeFilterEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
		        case "CodeID_Id":
					return PROPERTY_CODEID_ID;
		        case "CodeID_Name":
					return PROPERTY_CODEID_NAME;
		        case "CodeID_Description":
					return PROPERTY_CODEID_DESCRIPTION;
		        case "CodeID_Code":
					return PROPERTY_CODEID_CODE;
		        case "CodeID_CodeType":
					return PROPERTY_CODEID_CODETYPE;
		        case "CodeID_ChannelID":
					return PROPERTY_CODEID_CHANNELID;
		        case "CodeID_Mo":
					return PROPERTY_CODEID_MO;
		        case "CodeID_MOType":
					return PROPERTY_CODEID_MOTYPE;
		        case "CodeID_MOLength":
					return PROPERTY_CODEID_MOLENGTH;
		        case "CodeID_OrderIndex":
					return PROPERTY_CODEID_ORDERINDEX;
		        case "CodeID_SPCode":
					return PROPERTY_CODEID_SPCODE;
		        case "CodeID_SPCodeType":
					return PROPERTY_CODEID_SPCODETYPE;
		        case "CodeID_SPCodeLength":
					return PROPERTY_CODEID_SPCODELENGTH;
		        case "CodeID_HasFilters":
					return PROPERTY_CODEID_HASFILTERS;
		        case "CodeID_HasParamsConvert":
					return PROPERTY_CODEID_HASPARAMSCONVERT;
		        case "CodeID_Province":
					return PROPERTY_CODEID_PROVINCE;
		        case "CodeID_DisableCity":
					return PROPERTY_CODEID_DISABLECITY;
		        case "CodeID_IsDiable":
					return PROPERTY_CODEID_ISDIABLE;
		        case "CodeID_DayLimit":
					return PROPERTY_CODEID_DAYLIMIT;
		        case "CodeID_MonthLimit":
					return PROPERTY_CODEID_MONTHLIMIT;
		        case "CodeID_Price":
					return PROPERTY_CODEID_PRICE;
		        case "CodeID_SendText":
					return PROPERTY_CODEID_SENDTEXT;
		        case "CodeID_CreateBy":
					return PROPERTY_CODEID_CREATEBY;
		        case "CodeID_CreateAt":
					return PROPERTY_CODEID_CREATEAT;
		        case "CodeID_LastModifyBy":
					return PROPERTY_CODEID_LASTMODIFYBY;
		        case "CodeID_LastModifyAt":
					return PROPERTY_CODEID_LASTMODIFYAT;
		        case "CodeID_LastModifyComment":
					return PROPERTY_CODEID_LASTMODIFYCOMMENT;
              default:
                    return columnName;
            }
        }

        private static void ProcessQueryFilters(List<QueryFilter> filters)
        {
            foreach (QueryFilter queryFilter in filters)
            {
                queryFilter.FilterFieldName = ProcessColumnName(queryFilter.FilterFieldName);
            }
        }
		#endregion
		
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPCodeFilterEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_PARAMSNAME = "ParamsName";
		public static readonly string PROPERTY_NAME_FILTERTYPE = "FilterType";
		public static readonly string PROPERTY_NAME_FILTERVALUE = "FilterValue";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPCodeFilterEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPCodeFilterEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPCodeFilterEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPCodeFilterEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPCodeFilterEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPCodeFilterEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPCodeFilterEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPCodeFilterEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPCodeFilterEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPCodeFilterEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPCodeFilterEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPCodeFilterEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPCodeFilterEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPCodeFilterEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPCodeFilterEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPCodeFilterEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_PROVINCE = "CodeID_SPCodeFilterEntity_Alias.Province";
		public const string PROPERTY_CODEID_DISABLECITY = "CodeID_SPCodeFilterEntity_Alias.DisableCity";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPCodeFilterEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_DAYLIMIT = "CodeID_SPCodeFilterEntity_Alias.DayLimit";
		public const string PROPERTY_CODEID_MONTHLIMIT = "CodeID_SPCodeFilterEntity_Alias.MonthLimit";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPCodeFilterEntity_Alias.Price";
		public const string PROPERTY_CODEID_SENDTEXT = "CodeID_SPCodeFilterEntity_Alias.SendText";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPCodeFilterEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPCodeFilterEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPCodeFilterEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPCodeFilterEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPCodeFilterEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// 
		/// </summary>		
		public int Id
		{
			get
			{
				return entity.Id;
			}
			set
			{
				entity.Id = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public SPCodeWrapper CodeID
		{
			get
			{
				return SPCodeWrapper.ConvertEntityToWrapper(entity.CodeID) ;
			}
			set
			{
				entity.CodeID = ((value == null) ? null : value.Entity);
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ParamsName
		{
			get
			{
				return entity.ParamsName;
			}
			set
			{
				entity.ParamsName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FilterType
		{
			get
			{
				return entity.FilterType;
			}
			set
			{
				entity.FilterType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FilterValue
		{
			get
			{
				return entity.FilterValue;
			}
			set
			{
				entity.FilterValue = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int CreateBy
		{
			get
			{
				return entity.CreateBy;
			}
			set
			{
				entity.CreateBy = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime CreateAt
		{
			get
			{
				return entity.CreateAt;
			}
			set
			{
				entity.CreateAt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? LastModifyBy
		{
			get
			{
				return entity.LastModifyBy;
			}
			set
			{
				entity.LastModifyBy = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? LastModifyAt
		{
			get
			{
				return entity.LastModifyAt;
			}
			set
			{
				entity.LastModifyAt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string LastModifyComment
		{
			get
			{
				return entity.LastModifyComment;
			}
			set
			{
				entity.LastModifyComment = value;
			}
		}
		#endregion 


		#region Query Property
		
		
		#region codeID字段外键查询字段
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_ID)]
        public int? CodeID_Id
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Id;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_NAME)]
        public string CodeID_Name
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Name;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_DESCRIPTION)]
        public string CodeID_Description
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Description;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_CODE)]
        public string CodeID_Code
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Code;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_CODETYPE)]
        public string CodeID_CodeType
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.CodeType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_CHANNELID)]
        public SPChannelWrapper CodeID_ChannelID
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.ChannelID;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_MO)]
        public string CodeID_Mo
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Mo;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_MOTYPE)]
        public string CodeID_MOType
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.MOType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_MOLENGTH)]
        public int? CodeID_MOLength
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.MOLength;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_ORDERINDEX)]
        public int? CodeID_OrderIndex
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.OrderIndex;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_SPCODE)]
        public string CodeID_SPCode
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.SPCode;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_SPCODETYPE)]
        public string CodeID_SPCodeType
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.SPCodeType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_SPCODELENGTH)]
        public int? CodeID_SPCodeLength
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.SPCodeLength;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_HASFILTERS)]
        public bool? CodeID_HasFilters
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.HasFilters;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_HASPARAMSCONVERT)]
        public bool? CodeID_HasParamsConvert
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.HasParamsConvert;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_PROVINCE)]
        public string CodeID_Province
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Province;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_DISABLECITY)]
        public string CodeID_DisableCity
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.DisableCity;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_ISDIABLE)]
        public bool? CodeID_IsDiable
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.IsDiable;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_DAYLIMIT)]
        public string CodeID_DayLimit
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.DayLimit;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_MONTHLIMIT)]
        public string CodeID_MonthLimit
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.MonthLimit;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_PRICE)]
        public decimal? CodeID_Price
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.Price;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_SENDTEXT)]
        public string CodeID_SendText
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.SendText;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_CREATEBY)]
        public int? CodeID_CreateBy
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.CreateBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_CREATEAT)]
        public DateTime? CodeID_CreateAt
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.CreateAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_LASTMODIFYBY)]
        public int? CodeID_LastModifyBy
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.LastModifyBy;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_LASTMODIFYAT)]
        public DateTime? CodeID_LastModifyAt
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.LastModifyAt;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_LASTMODIFYCOMMENT)]
        public string CodeID_LastModifyComment
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.LastModifyComment;
            }
        }
		#endregion
      	
   
		#endregion


        #region "FKQuery"
		
        public static List<SPCodeFilterWrapper> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,   SPCodeWrapper codeID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndCodeID(orderByColumnName, isDesc,   codeID.Entity, pageQueryParams));
        }

        public static List<SPCodeFilterWrapper> FindAllByCodeID(SPCodeWrapper codeID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByCodeID(codeID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPCodeFilterWrapper> ConvertToWrapperList(List<SPCodeFilterEntity> entitylist)
        {
            List<SPCodeFilterWrapper> list = new List<SPCodeFilterWrapper>();
            foreach (SPCodeFilterEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPCodeFilterWrapper> ConvertToWrapperList(IList<SPCodeFilterEntity> entitylist)
        {
            List<SPCodeFilterWrapper> list = new List<SPCodeFilterWrapper>();
            foreach (SPCodeFilterEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPCodeFilterEntity> ConvertToEntityList(List<SPCodeFilterWrapper> wrapperlist)
        {
            List<SPCodeFilterEntity> list = new List<SPCodeFilterEntity>();
            foreach (SPCodeFilterWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPCodeFilterWrapper ConvertEntityToWrapper(SPCodeFilterEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPCodeFilterWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

