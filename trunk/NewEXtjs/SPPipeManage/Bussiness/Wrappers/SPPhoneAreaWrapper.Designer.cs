// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public partial class SPPhoneAreaWrapper
    {
        #region Member

		internal static readonly ISPPhoneAreaServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPPhoneAreaServiceProxyInstance;
		//internal static readonly ISPPhoneAreaServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPPhoneAreaServiceProxyInstance;

        internal SPPhoneAreaEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPPhoneAreaWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPPhoneAreaWrapper() : this(new SPPhoneAreaEntity())
        {
            
        }

        internal SPPhoneAreaWrapper(SPPhoneAreaEntity entityObj)
        {
            entity = entityObj;
        }
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		public override bool Equals(object obj)
        {
            if (obj == null && entity!=null)
            {
                if (entity.Id == 0)
                    return true;

                return false;
            }
            return entity.Equals(obj);
        }

        public override int GetHashCode()
        {
            return entity.GetHashCode();
        }
		#endregion
		
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPPhoneAreaEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_PHONEPREFIX = "PhonePrefix";
		
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
		public string Province
		{
			get
			{
				return entity.Province;
			}
			set
			{
				entity.Province = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string City
		{
			get
			{
				return entity.City;
			}
			set
			{
				entity.City = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string PhonePrefix
		{
			get
			{
				return entity.PhonePrefix;
			}
			set
			{
				entity.PhonePrefix = value;
			}
		}
		#endregion 





        #region "FKQuery"



        #endregion

        #region Static Common Data Operation
		
		internal static List<SPPhoneAreaWrapper> ConvertToWrapperList(List<SPPhoneAreaEntity> entitylist)
        {
            List<SPPhoneAreaWrapper> list = new List<SPPhoneAreaWrapper>();
            foreach (SPPhoneAreaEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPPhoneAreaWrapper> ConvertToWrapperList(IList<SPPhoneAreaEntity> entitylist)
        {
            List<SPPhoneAreaWrapper> list = new List<SPPhoneAreaWrapper>();
            foreach (SPPhoneAreaEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPPhoneAreaEntity> ConvertToEntityList(List<SPPhoneAreaWrapper> wrapperlist)
        {
            List<SPPhoneAreaEntity> list = new List<SPPhoneAreaEntity>();
            foreach (SPPhoneAreaWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPPhoneAreaWrapper ConvertEntityToWrapper(SPPhoneAreaEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPPhoneAreaWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

