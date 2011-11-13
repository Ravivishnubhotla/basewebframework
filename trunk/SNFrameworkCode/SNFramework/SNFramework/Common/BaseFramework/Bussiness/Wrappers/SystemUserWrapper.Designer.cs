// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context.Support;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public partial class SystemUserWrapper   
    {
        #region Member

		internal static readonly ISystemUserServiceProxy businessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserServiceProxyInstance;
		
		
		internal SystemUserEntity Entity
        {
            get { return this.entity; }
        }
		
        #endregion

        #region Construtor
		public SystemUserWrapper() : base(new SystemUserEntity())
        {
            
        }

        internal SystemUserWrapper(SystemUserEntity entityObj)
            : base(entityObj)
        {
        }
		#endregion

        #region Process Column Name
        private static string ProcessColumnName(string columnName)
        {
            switch (columnName)
            {
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

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemUserEntity";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERLOGINID = "UserLoginID";
		public static readonly string PROPERTY_NAME_USERNAME = "UserName";
		public static readonly string PROPERTY_NAME_USEREMAIL = "UserEmail";
		public static readonly string PROPERTY_NAME_USERPASSWORD = "UserPassword";
		public static readonly string PROPERTY_NAME_USERSTATUS = "UserStatus";
		public static readonly string PROPERTY_NAME_USERCREATEDATE = "UserCreateDate";
		public static readonly string PROPERTY_NAME_USERTYPE = "UserType";
		public static readonly string PROPERTY_NAME_MOBILEPIN = "MobilePIN";
		public static readonly string PROPERTY_NAME_PASSWORDFORMAT = "PasswordFormat";
		public static readonly string PROPERTY_NAME_PASSWORDQUESTION = "PasswordQuestion";
		public static readonly string PROPERTY_NAME_PASSWORDANSWER = "PasswordAnswer";
		public static readonly string PROPERTY_NAME_COMMENTS = "Comments";
		public static readonly string PROPERTY_NAME_ISAPPROVED = "IsApproved";
		public static readonly string PROPERTY_NAME_ISLOCKEDOUT = "IsLockedOut";
		public static readonly string PROPERTY_NAME_LASTACTIVITYDATE = "LastActivityDate";
		public static readonly string PROPERTY_NAME_LASTLOGINDATE = "LastLoginDate";
		public static readonly string PROPERTY_NAME_LASTLOCKEDOUTDATE = "LastLockedOutDate";
		public static readonly string PROPERTY_NAME_LASTPASSWORDCHANGEDATE = "LastPasswordChangeDate";
		public static readonly string PROPERTY_NAME_FAILEDPWDATTEMPTCNT = "FailedPwdAttemptCnt";
		public static readonly string PROPERTY_NAME_FAILEDPWDATTEMPTWNDSTART = "FailedPwdAttemptWndStart";
		public static readonly string PROPERTY_NAME_FAILEDPWDANSATTEMPTCNT = "FailedPwdAnsAttemptCnt";
		public static readonly string PROPERTY_NAME_FAILEDPWDANSATTEMPTWNDSTART = "FailedPwdAnsAttemptWndStart";
		public static readonly string PROPERTY_NAME_ISNEEDCHGPWD = "IsNeedChgPwd";
		public static readonly string PROPERTY_NAME_PASSWORDSALT = "PasswordSalt";
		public static readonly string PROPERTY_NAME_LOWEREDEMAIL = "LoweredEmail";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		


		#region Public Property
		/// <summary>
		/// Primary Key
		/// </summary>		
		public int UserID
		{
			get
			{
				return entity.UserID;
			}
			set
			{
				entity.UserID = value;
			}
		}
		/// <summary>
		/// Login ID
		/// </summary>		
		public string UserLoginID
		{
			get
			{
				return entity.UserLoginID;
			}
			set
			{
				entity.UserLoginID = value;
			}
		}
		/// <summary>
		/// User Name
		/// </summary>		
		public string UserName
		{
			get
			{
				return entity.UserName;
			}
			set
			{
				entity.UserName = value;
			}
		}
		/// <summary>
		/// Email
		/// </summary>		
		public string UserEmail
		{
			get
			{
				return entity.UserEmail;
			}
			set
			{
				entity.UserEmail = value;
			}
		}
		/// <summary>
		/// Password
		/// </summary>		
		public string UserPassword
		{
			get
			{
				return entity.UserPassword;
			}
			set
			{
				entity.UserPassword = value;
			}
		}
		/// <summary>
		/// Status
		/// </summary>		
		public string UserStatus
		{
			get
			{
				return entity.UserStatus;
			}
			set
			{
				entity.UserStatus = value;
			}
		}
		/// <summary>
		/// Create Date
		/// </summary>		
		public DateTime UserCreateDate
		{
			get
			{
				return entity.UserCreateDate;
			}
			set
			{
				entity.UserCreateDate = value;
			}
		}
		/// <summary>
		/// User Type
		/// </summary>		
		public string UserType
		{
			get
			{
				return entity.UserType;
			}
			set
			{
				entity.UserType = value;
			}
		}
		/// <summary>
		/// MobilePIN
		/// </summary>		
		public string MobilePIN
		{
			get
			{
				return entity.MobilePIN;
			}
			set
			{
				entity.MobilePIN = value;
			}
		}
		/// <summary>
		/// PasswordF ormat
		/// </summary>		
		public int PasswordFormat
		{
			get
			{
				return entity.PasswordFormat;
			}
			set
			{
				entity.PasswordFormat = value;
			}
		}
		/// <summary>
		/// Password Question
		/// </summary>		
		public string PasswordQuestion
		{
			get
			{
				return entity.PasswordQuestion;
			}
			set
			{
				entity.PasswordQuestion = value;
			}
		}
		/// <summary>
		/// Password Answer
		/// </summary>		
		public string PasswordAnswer
		{
			get
			{
				return entity.PasswordAnswer;
			}
			set
			{
				entity.PasswordAnswer = value;
			}
		}
		/// <summary>
		/// Comments
		/// </summary>		
		public string Comments
		{
			get
			{
				return entity.Comments;
			}
			set
			{
				entity.Comments = value;
			}
		}
		/// <summary>
		/// Is Approved
		/// </summary>		
		public bool IsApproved
		{
			get
			{
				return entity.IsApproved;
			}
			set
			{
				entity.IsApproved = value;
			}
		}
		/// <summary>
		/// Is Locked Out
		/// </summary>		
		public bool IsLockedOut
		{
			get
			{
				return entity.IsLockedOut;
			}
			set
			{
				entity.IsLockedOut = value;
			}
		}
		/// <summary>
		/// Last Activity Date
		/// </summary>		
		public DateTime LastActivityDate
		{
			get
			{
				return entity.LastActivityDate;
			}
			set
			{
				entity.LastActivityDate = value;
			}
		}
		/// <summary>
		/// Last Login Date
		/// </summary>		
		public DateTime LastLoginDate
		{
			get
			{
				return entity.LastLoginDate;
			}
			set
			{
				entity.LastLoginDate = value;
			}
		}
		/// <summary>
		/// Last Locked Out Date
		/// </summary>		
		public DateTime LastLockedOutDate
		{
			get
			{
				return entity.LastLockedOutDate;
			}
			set
			{
				entity.LastLockedOutDate = value;
			}
		}
		/// <summary>
		/// Last Password Change Date
		/// </summary>		
		public DateTime LastPasswordChangeDate
		{
			get
			{
				return entity.LastPasswordChangeDate;
			}
			set
			{
				entity.LastPasswordChangeDate = value;
			}
		}
		/// <summary>
		/// Failed Password Attempt Count
		/// </summary>		
		public int FailedPwdAttemptCnt
		{
			get
			{
				return entity.FailedPwdAttemptCnt;
			}
			set
			{
				entity.FailedPwdAttemptCnt = value;
			}
		}
		/// <summary>
		/// Failed Password Attempt DateTime
		/// </summary>		
		public DateTime FailedPwdAttemptWndStart
		{
			get
			{
				return entity.FailedPwdAttemptWndStart;
			}
			set
			{
				entity.FailedPwdAttemptWndStart = value;
			}
		}
		/// <summary>
		/// Failed Password Answer Attempt Count
		/// </summary>		
		public int FailedPwdAnsAttemptCnt
		{
			get
			{
				return entity.FailedPwdAnsAttemptCnt;
			}
			set
			{
				entity.FailedPwdAnsAttemptCnt = value;
			}
		}
		/// <summary>
		/// Failed Password Answer Attempt DateTime
		/// </summary>		
		public DateTime FailedPwdAnsAttemptWndStart
		{
			get
			{
				return entity.FailedPwdAnsAttemptWndStart;
			}
			set
			{
				entity.FailedPwdAnsAttemptWndStart = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public bool IsNeedChgPwd
		{
			get
			{
				return entity.IsNeedChgPwd;
			}
			set
			{
				entity.IsNeedChgPwd = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string PasswordSalt
		{
			get
			{
				return entity.PasswordSalt;
			}
			set
			{
				entity.PasswordSalt = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>		
		public string LoweredEmail
		{
			get
			{
				return entity.LoweredEmail;
			}
			set
			{
				entity.LoweredEmail = value;
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
		
		
      	
   
		#endregion


        #region "FKQuery"



        #endregion








        #region Static Common Data Operation
		
		internal static List<SystemUserWrapper> ConvertToWrapperList(List<SystemUserEntity> entitylist)
        {
            List<SystemUserWrapper> list = new List<SystemUserWrapper>();
            foreach (SystemUserEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }

		internal static List<SystemUserWrapper> ConvertToWrapperList(IList<SystemUserEntity> entitylist)
        {
            List<SystemUserWrapper> list = new List<SystemUserWrapper>();
            foreach (SystemUserEntity lentity in entitylist)
            {
                list.Add(ConvertEntityToWrapper(lentity));
            }
            return list;
        }
		
		internal static List<SystemUserEntity> ConvertToEntityList(List<SystemUserWrapper> wrapperlist)
        {
            List<SystemUserEntity> list = new List<SystemUserEntity>();
            foreach (SystemUserWrapper wrapper in wrapperlist)
            {
                list.Add(wrapper.entity);
            }
            return list;
        }

        internal static SystemUserWrapper ConvertEntityToWrapper(SystemUserEntity entity)
        {
            if (entity == null)
                return null;
				
            if (entity.UserID == 0)
                return null;

            return new SystemUserWrapper(entity);
        }
		
		#endregion

    }//End Class
}// End Namespace

