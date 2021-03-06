// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LD.SPPipeManage.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPClientGroupEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPClientGroupEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_DEFAULTSYCNMOURL = "DefaultSycnMoUrl";
		public static readonly string PROPERTY_NAME_DEFAULTSYCNMRURL = "DefaultSycnMRUrl";
		public static readonly string PROPERTY_NAME_DEFAULTINTERCEPTRATE = "DefaultInterceptRate";
		public static readonly string PROPERTY_NAME_DEFAULTNOINTERCEPTCOUNT = "DefaultNoInterceptCount";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _name;
		private string _description;
		private int? _userID;
		private string _defaultSycnMoUrl;
		private string _defaultSycnMRUrl;
		private int _defaultInterceptRate;
		private int _defaultNoInterceptCount;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPClientGroupEntity()
		{
			_id = 0;
			_name = null;
			_description = null;
			_userID = null;
			_defaultSycnMoUrl = null;
			_defaultSycnMRUrl = null;
			_defaultInterceptRate = 5;
			_defaultNoInterceptCount = 100;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPClientGroupEntity( int id, string name, string description, int? userID, string defaultSycnMoUrl, string defaultSycnMRUrl, int defaultInterceptRate, int defaultNoInterceptCount)
		{
			_id = id;
			_name = name;
			_description = description;
			_userID = userID;
			_defaultSycnMoUrl = defaultSycnMoUrl;
			_defaultSycnMRUrl = defaultSycnMRUrl;
			_defaultInterceptRate = defaultInterceptRate;
			_defaultNoInterceptCount = defaultNoInterceptCount;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int Id
		{
			get { return _id; }

			set	
			{
				_isChanged |= (_id != value); _id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Name
		{
			get { return _name; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_isChanged |= (_name != value); _name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_isChanged |= (_description != value); _description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? UserID
		{
			get { return _userID; }

			set	
			{
				_isChanged |= (_userID != value); _userID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DefaultSycnMoUrl
		{
			get { return _defaultSycnMoUrl; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for DefaultSycnMoUrl", value, value.ToString());
				_isChanged |= (_defaultSycnMoUrl != value); _defaultSycnMoUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DefaultSycnMRUrl
		{
			get { return _defaultSycnMRUrl; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for DefaultSycnMRUrl", value, value.ToString());
				_isChanged |= (_defaultSycnMRUrl != value); _defaultSycnMRUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DefaultInterceptRate
		{
			get { return _defaultInterceptRate; }

			set	
			{
				_isChanged |= (_defaultInterceptRate != value); _defaultInterceptRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DefaultNoInterceptCount
		{
			get { return _defaultNoInterceptCount; }

			set	
			{
				_isChanged |= (_defaultNoInterceptCount != value); _defaultNoInterceptCount = value;
			}
		}
		/// <summary>
		/// 返回对象是否被改变。
		/// </summary>
		public virtual bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 

        #region 公共方法
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public virtual void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		#endregion

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			
			SPClientGroupEntity castObj = (SPClientGroupEntity)obj;
			
			return ( castObj != null ) && ( this._id == castObj.Id );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id.GetHashCode();

			return hash; 
		}
		#endregion
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
