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
    public partial class SPMemoWrapper
    {
        #region Member

		internal static readonly ISPMemoServiceProxy businessProxy = ((LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).SPMemoServiceProxyInstance;
		//internal static readonly ISPMemoServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).SPMemoServiceProxyInstance;

        internal SPMemoEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(SPMemoWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public SPMemoWrapper() : this(new SPMemoEntity())
        {
            
        }

        internal SPMemoWrapper(SPMemoEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPMemoEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_MEMOCONTENT = "MemoContent";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		
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
		public string MemoContent
		{
			get
			{
				return entity.MemoContent;
			}
			set
			{
				entity.MemoContent = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public DateTime? CreateDate
		{
			get
			{
				return entity.CreateDate;
			}
			set
			{
				entity.CreateDate = value;
			}
		}
		#endregion 







        #region Static Common Data Operation
		
		internal static List<SPMemoWrapper> ConvertToWrapperList(List<SPMemoEntity> entitylist)
        {
            List<SPMemoWrapper> list = new List<SPMemoWrapper>();
            foreach (SPMemoEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SPMemoWrapper> ConvertToWrapperList(IList<SPMemoEntity> entitylist)
        {
            List<SPMemoWrapper> list = new List<SPMemoWrapper>();
            foreach (SPMemoEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SPMemoEntity> ConvertToEntityList(List<SPMemoWrapper> wrapperlist)
        {
            List<SPMemoEntity> list = new List<SPMemoEntity>();
            foreach (SPMemoWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SPMemoWrapper ConvertEntityToWrapper(SPMemoEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new SPMemoWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

