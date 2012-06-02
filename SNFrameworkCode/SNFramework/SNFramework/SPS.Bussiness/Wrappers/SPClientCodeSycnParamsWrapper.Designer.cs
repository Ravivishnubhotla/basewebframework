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
    public partial class SPClientCodeSycnParamsWrapper   
    {
        #region Member

		internal static readonly ISPClientCodeSycnParamsServiceProxy businessProxy = ((SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(SPS.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPClientCodeSycnParamsServiceProxyInstance;
		
		
		internal SPClientCodeSycnParamsEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SPClientCodeSycnParamsWrapper() : base(new SPClientCodeSycnParamsEntity())
        {
            
        }

        internal SPClientCodeSycnParamsWrapper(SPClientCodeSycnParamsEntity entityObj)
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
		        case "CodeID_IsDiable":
					return PROPERTY_CODEID_ISDIABLE;
		        case "CodeID_Price":
					return PROPERTY_CODEID_PRICE;
		        case "CodeID_OperationType":
					return PROPERTY_CODEID_OPERATIONTYPE;
		        case "CodeID_HasDayTotalLimit":
					return PROPERTY_CODEID_HASDAYTOTALLIMIT;
		        case "CodeID_DayTotalLimitCount":
					return PROPERTY_CODEID_DAYTOTALLIMITCOUNT;
		        case "CodeID_HasPhoneLimit":
					return PROPERTY_CODEID_HASPHONELIMIT;
		        case "CodeID_PhoneLimitDayCount":
					return PROPERTY_CODEID_PHONELIMITDAYCOUNT;
		        case "CodeID_PhoneLimitMonthCount":
					return PROPERTY_CODEID_PHONELIMITMONTHCOUNT;
		        case "CodeID_PhoneLimitType":
					return PROPERTY_CODEID_PHONELIMITTYPE;
		        case "CodeID_LimitProvince":
					return PROPERTY_CODEID_LIMITPROVINCE;
		        case "CodeID_LimitProvinceArea":
					return PROPERTY_CODEID_LIMITPROVINCEAREA;
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

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPClientCodeSycnParamsEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISREQUIRED = "IsRequired";
		public static readonly string PROPERTY_NAME_CODEID = "CodeID";
		public static readonly string PROPERTY_NAME_MAPPINGPARAMS = "MappingParams";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_PARAMSVALUE = "ParamsValue";
		public static readonly string PROPERTY_NAME_PARAMSTYPE = "ParamsType";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region codeID字段外键查询字段
        public const string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPClientCodeSycnParamsEntity_Alias";
		public const string PROPERTY_CODEID_ID = "CodeID_SPClientCodeSycnParamsEntity_Alias.Id";
		public const string PROPERTY_CODEID_NAME = "CodeID_SPClientCodeSycnParamsEntity_Alias.Name";
		public const string PROPERTY_CODEID_DESCRIPTION = "CodeID_SPClientCodeSycnParamsEntity_Alias.Description";
		public const string PROPERTY_CODEID_CODE = "CodeID_SPClientCodeSycnParamsEntity_Alias.Code";
		public const string PROPERTY_CODEID_CODETYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.CodeType";
		public const string PROPERTY_CODEID_CHANNELID = "CodeID_SPClientCodeSycnParamsEntity_Alias.ChannelID";
		public const string PROPERTY_CODEID_MO = "CodeID_SPClientCodeSycnParamsEntity_Alias.Mo";
		public const string PROPERTY_CODEID_MOTYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.MOType";
		public const string PROPERTY_CODEID_MOLENGTH = "CodeID_SPClientCodeSycnParamsEntity_Alias.MOLength";
		public const string PROPERTY_CODEID_ORDERINDEX = "CodeID_SPClientCodeSycnParamsEntity_Alias.OrderIndex";
		public const string PROPERTY_CODEID_SPCODE = "CodeID_SPClientCodeSycnParamsEntity_Alias.SPCode";
		public const string PROPERTY_CODEID_SPCODETYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.SPCodeType";
		public const string PROPERTY_CODEID_SPCODELENGTH = "CodeID_SPClientCodeSycnParamsEntity_Alias.SPCodeLength";
		public const string PROPERTY_CODEID_HASFILTERS = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasFilters";
		public const string PROPERTY_CODEID_HASPARAMSCONVERT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasParamsConvert";
		public const string PROPERTY_CODEID_ISDIABLE = "CodeID_SPClientCodeSycnParamsEntity_Alias.IsDiable";
		public const string PROPERTY_CODEID_PRICE = "CodeID_SPClientCodeSycnParamsEntity_Alias.Price";
		public const string PROPERTY_CODEID_OPERATIONTYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.OperationType";
		public const string PROPERTY_CODEID_HASDAYTOTALLIMIT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasDayTotalLimit";
		public const string PROPERTY_CODEID_DAYTOTALLIMITCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.DayTotalLimitCount";
		public const string PROPERTY_CODEID_HASPHONELIMIT = "CodeID_SPClientCodeSycnParamsEntity_Alias.HasPhoneLimit";
		public const string PROPERTY_CODEID_PHONELIMITDAYCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.PhoneLimitDayCount";
		public const string PROPERTY_CODEID_PHONELIMITMONTHCOUNT = "CodeID_SPClientCodeSycnParamsEntity_Alias.PhoneLimitMonthCount";
		public const string PROPERTY_CODEID_PHONELIMITTYPE = "CodeID_SPClientCodeSycnParamsEntity_Alias.PhoneLimitType";
		public const string PROPERTY_CODEID_LIMITPROVINCE = "CodeID_SPClientCodeSycnParamsEntity_Alias.LimitProvince";
		public const string PROPERTY_CODEID_LIMITPROVINCEAREA = "CodeID_SPClientCodeSycnParamsEntity_Alias.LimitProvinceArea";
		public const string PROPERTY_CODEID_CREATEBY = "CodeID_SPClientCodeSycnParamsEntity_Alias.CreateBy";
		public const string PROPERTY_CODEID_CREATEAT = "CodeID_SPClientCodeSycnParamsEntity_Alias.CreateAt";
		public const string PROPERTY_CODEID_LASTMODIFYBY = "CodeID_SPClientCodeSycnParamsEntity_Alias.LastModifyBy";
		public const string PROPERTY_CODEID_LASTMODIFYAT = "CodeID_SPClientCodeSycnParamsEntity_Alias.LastModifyAt";
		public const string PROPERTY_CODEID_LASTMODIFYCOMMENT = "CodeID_SPClientCodeSycnParamsEntity_Alias.LastModifyComment";
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
		public string Name
		{
			get
			{
				return entity.Name;
			}
			set
			{
				entity.Name = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Description
		{
			get
			{
				return entity.Description;
			}
			set
			{
				entity.Description = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool IsEnable
		{
			get
			{
				return entity.IsEnable;
			}
			set
			{
				entity.IsEnable = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool IsRequired
		{
			get
			{
				return entity.IsRequired;
			}
			set
			{
				entity.IsRequired = value;
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
		public string MappingParams
		{
			get
			{
				return entity.MappingParams;
			}
			set
			{
				entity.MappingParams = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string Title
		{
			get
			{
				return entity.Title;
			}
			set
			{
				entity.Title = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ParamsValue
		{
			get
			{
				return entity.ParamsValue;
			}
			set
			{
				entity.ParamsValue = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ParamsType
		{
			get
			{
				return entity.ParamsType;
			}
			set
			{
				entity.ParamsType = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? CreateBy
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
		public DateTime? CreateAt
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
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_OPERATIONTYPE)]
        public string CodeID_OperationType
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.OperationType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_HASDAYTOTALLIMIT)]
        public bool? CodeID_HasDayTotalLimit
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.HasDayTotalLimit;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_DAYTOTALLIMITCOUNT)]
        public int? CodeID_DayTotalLimitCount
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.DayTotalLimitCount;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_HASPHONELIMIT)]
        public bool? CodeID_HasPhoneLimit
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.HasPhoneLimit;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_PHONELIMITDAYCOUNT)]
        public int? CodeID_PhoneLimitDayCount
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.PhoneLimitDayCount;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_PHONELIMITMONTHCOUNT)]
        public int? CodeID_PhoneLimitMonthCount
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.PhoneLimitMonthCount;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_PHONELIMITTYPE)]
        public int? CodeID_PhoneLimitType
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.PhoneLimitType;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_LIMITPROVINCE)]
        public bool? CodeID_LimitProvince
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.LimitProvince;
            }
        }
		[NhibernateQueryPropertyAttribute(MappingColumnName = PROPERTY_CODEID_LIMITPROVINCEAREA)]
        public string CodeID_LimitProvinceArea
        {
            get
            {
                if (this. CodeID == null)
                    return null;
                return  CodeID.LimitProvinceArea;
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
		
        public static List<SPClientCodeSycnParamsWrapper> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,   SPCodeWrapper codeID,  PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndCodeID(orderByColumnName, isDesc,   codeID.Entity, pageQueryParams));
        }

        public static List<SPClientCodeSycnParamsWrapper> FindAllByCodeID(SPCodeWrapper codeID)
        {
            return ConvertToWrapperList(businessProxy.FindAllByCodeID(codeID.Entity));
        }
		



        #endregion








        #region Static Common Data Operation
		
		internal static List<SPClientCodeSycnParamsWrapper> ConvertToWrapperList(List<SPClientCodeSycnParamsEntity> entitylist)
        {
            List<SPClientCodeSycnParamsWrapper> list = new List<SPClientCodeSycnParamsWrapper>();
            foreach (SPClientCodeSycnParamsEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPClientCodeSycnParamsWrapper> ConvertToWrapperList(IList<SPClientCodeSycnParamsEntity> entitylist)
        {
            List<SPClientCodeSycnParamsWrapper> list = new List<SPClientCodeSycnParamsWrapper>();
            foreach (SPClientCodeSycnParamsEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPClientCodeSycnParamsEntity> ConvertToEntityList(List<SPClientCodeSycnParamsWrapper> wrapperlist)
        {
            List<SPClientCodeSycnParamsEntity> list = new List<SPClientCodeSycnParamsEntity>();
            foreach (SPClientCodeSycnParamsWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPClientCodeSycnParamsWrapper ConvertEntityToWrapper(SPClientCodeSycnParamsEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPClientCodeSycnParamsWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

