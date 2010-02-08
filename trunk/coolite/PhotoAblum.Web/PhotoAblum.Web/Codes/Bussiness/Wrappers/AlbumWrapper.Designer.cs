// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using PhotoAblum.Web.Codes.Entity.Tables;
using PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables.Container;
using PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables;

namespace PhotoAblum.Web.Codes.Bussiness.Wrappers
{
    public partial class AlbumWrapper
    {
        #region Member

		internal static readonly IAlbumServiceProxy businessProxy = ((PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID", typeof(PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables.Container.ServiceProxyContainer)))).AlbumServiceProxyInstance;
		//internal static readonly IAlbumServiceProxy businessProxy = ((ServiceProxyContainer)(ContextRegistry.GetContext().GetObject("ServiceProxyContainerIocID"))).AlbumServiceProxyInstance;

        internal AlbumEntity entity;
		
		private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(typeof(AlbumWrapper));
                return logger;
            }
        }

        #endregion

        #region Construtor
        public AlbumWrapper() : this(new AlbumEntity())
        {
            
        }

        internal AlbumWrapper(AlbumEntity entityObj)
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

		public static readonly string CLASS_FULL_NAME = "PhotoAblum.Web.Codes.Entity.Tables.AlbumEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_SHORTDESCRIPTION = "ShortDescription";
		public static readonly string PROPERTY_NAME_FILEPATH = "FilePath";
		public static readonly string PROPERTY_NAME_FULLIMAGE = "FullImage";
		public static readonly string PROPERTY_NAME_MIDDLEIMAGE = "MiddleImage";
		public static readonly string PROPERTY_NAME_THUMBIMAGE = "ThumbImage";
		public static readonly string PROPERTY_NAME_DIRNAME = "DirName";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		public static readonly string PROPERTY_NAME_VIEWPASSWORD = "ViewPassword";
		public static readonly string PROPERTY_NAME_ISSHOW = "IsShow";
		
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
		public string ShortDescription
		{
			get
			{
				return entity.ShortDescription;
			}
			set
			{
				entity.ShortDescription = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FilePath
		{
			get
			{
				return entity.FilePath;
			}
			set
			{
				entity.FilePath = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string FullImage
		{
			get
			{
				return entity.FullImage;
			}
			set
			{
				entity.FullImage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string MiddleImage
		{
			get
			{
				return entity.MiddleImage;
			}
			set
			{
				entity.MiddleImage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ThumbImage
		{
			get
			{
				return entity.ThumbImage;
			}
			set
			{
				entity.ThumbImage = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string DirName
		{
			get
			{
				return entity.DirName;
			}
			set
			{
				entity.DirName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public int? OrderIndex
		{
			get
			{
				return entity.OrderIndex;
			}
			set
			{
				entity.OrderIndex = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string ViewPassword
		{
			get
			{
				return entity.ViewPassword;
			}
			set
			{
				entity.ViewPassword = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool? IsShow
		{
			get
			{
				return entity.IsShow;
			}
			set
			{
				entity.IsShow = value;
			}
		}
		#endregion 







        #region Static Common Data Operation
		
		internal static List<AlbumWrapper> ConvertToWrapperList(List<AlbumEntity> entitylist)
        {
            List<AlbumWrapper> list = new List<AlbumWrapper>();
            foreach (AlbumEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<AlbumWrapper> ConvertToWrapperList(IList<AlbumEntity> entitylist)
        {
            List<AlbumWrapper> list = new List<AlbumWrapper>();
            foreach (AlbumEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<AlbumEntity> ConvertToEntityList(List<AlbumWrapper> wrapperlist)
        {
            List<AlbumEntity> list = new List<AlbumEntity>();
            foreach (AlbumWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static AlbumWrapper ConvertEntityToWrapper(AlbumEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.Id == 0)
                return null;

            return new AlbumWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

