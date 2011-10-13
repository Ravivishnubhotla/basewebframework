// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemDictionaryGroupEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemDictionaryGroupEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_CODE = "Code";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISSYSTEM = "IsSystem";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _name;
		private string _code;
		private string _description;
		private bool? _isEnable;
		private bool? _isSystem;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemDictionaryGroupEntity()
		{
			_id = 0;
			_name = null;
			_code = null;
			_description = null;
			_isEnable = null;
			_isSystem = null;
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemDictionaryGroupEntity( int id, string name, string code, string description, bool? isEnable, bool? isSystem, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_name = name;
			_code = code;
			_description = description;
			_isEnable = isEnable;
			_isSystem = isSystem;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
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

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_isChanged |= (_name != value); _name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Code
		{
			get { return _code; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Code", value, value.ToString());
				_isChanged |= (_code != value); _code = value;
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

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_isChanged |= (_description != value); _description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsEnable
		{
			get { return _isEnable; }

			set	
			{
				_isChanged |= (_isEnable != value); _isEnable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsSystem
		{
			get { return _isSystem; }

			set	
			{
				_isChanged |= (_isSystem != value); _isSystem = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_isChanged |= (_createBy != value); _createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateAt
		{
			get { return _createAt; }

			set	
			{
				_isChanged |= (_createAt != value); _createAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LastModifyBy
		{
			get { return _lastModifyBy; }

			set	
			{
				_isChanged |= (_lastModifyBy != value); _lastModifyBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastModifyAt
		{
			get { return _lastModifyAt; }

			set	
			{
				_isChanged |= (_lastModifyAt != value); _lastModifyAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastModifyComment
		{
			get { return _lastModifyComment; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LastModifyComment", value, value.ToString());
				_isChanged |= (_lastModifyComment != value); _lastModifyComment = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemDictionaryGroupEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override object GetDataEntityKey()
	    {
	        return this._id;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
