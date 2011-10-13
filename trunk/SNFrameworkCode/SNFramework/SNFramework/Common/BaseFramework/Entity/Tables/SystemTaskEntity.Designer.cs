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
	public partial class SystemTaskEntity  : BaseTableEntity,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemTaskEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_TASKCONTENT = "TaskContent";
		public static readonly string PROPERTY_NAME_ASSIGNEDUSERID = "AssignedUserID";
		public static readonly string PROPERTY_NAME_STATUS = "Status";
		public static readonly string PROPERTY_NAME_DATEDUE = "DateDue";
		public static readonly string PROPERTY_NAME_ISDATEDUE = "IsDateDue";
		public static readonly string PROPERTY_NAME_DATESTART = "DateStart";
		public static readonly string PROPERTY_NAME_ISDATESTART = "IsDateStart";
		public static readonly string PROPERTY_NAME_PRIORITY = "Priority";
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
		public static readonly string PROPERTY_NAME_ISFINISHED = "IsFinished";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private string _title;
		private string _taskContent;
		private int? _assignedUserID;
		private string _status;
		private DateTime? _dateDue;
		private bool? _isDateDue;
		private DateTime? _dateStart;
		private bool? _isDateStart;
		private string _priority;
		private int? _parentDataID;
		private string _parentDataType;
		private bool? _isFinished;
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
		public SystemTaskEntity()
		{
			_id = 0;
			_title = null;
			_taskContent = null;
			_assignedUserID = null;
			_status = null;
			_dateDue = null;
			_isDateDue = null;
			_dateStart = null;
			_isDateStart = null;
			_priority = null;
			_parentDataID = null;
			_parentDataType = null;
			_isFinished = null;
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
		public SystemTaskEntity( int id, string title, string taskContent, int? assignedUserID, string status, DateTime? dateDue, bool? isDateDue, DateTime? dateStart, bool? isDateStart, string priority, int? parentDataID, string parentDataType, bool? isFinished, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_title = title;
			_taskContent = taskContent;
			_assignedUserID = assignedUserID;
			_status = status;
			_dateDue = dateDue;
			_isDateDue = isDateDue;
			_dateStart = dateStart;
			_isDateStart = isDateStart;
			_priority = priority;
			_parentDataID = parentDataID;
			_parentDataType = parentDataType;
			_isFinished = isFinished;
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
		public virtual string Title
		{
			get { return _title; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				_isChanged |= (_title != value); _title = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string TaskContent
		{
			get { return _taskContent; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for TaskContent", value, value.ToString());
				_isChanged |= (_taskContent != value); _taskContent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? AssignedUserID
		{
			get { return _assignedUserID; }

			set	
			{
				_isChanged |= (_assignedUserID != value); _assignedUserID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Status
		{
			get { return _status; }

			set	
			{

				if( value != null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				_isChanged |= (_status != value); _status = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? DateDue
		{
			get { return _dateDue; }

			set	
			{
				_isChanged |= (_dateDue != value); _dateDue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsDateDue
		{
			get { return _isDateDue; }

			set	
			{
				_isChanged |= (_isDateDue != value); _isDateDue = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? DateStart
		{
			get { return _dateStart; }

			set	
			{
				_isChanged |= (_dateStart != value); _dateStart = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsDateStart
		{
			get { return _isDateStart; }

			set	
			{
				_isChanged |= (_isDateStart != value); _isDateStart = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Priority
		{
			get { return _priority; }

			set	
			{

				if( value != null && value.Length > 20)
					throw new ArgumentOutOfRangeException("Invalid value for Priority", value, value.ToString());
				_isChanged |= (_priority != value); _priority = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ParentDataID
		{
			get { return _parentDataID; }

			set	
			{
				_isChanged |= (_parentDataID != value); _parentDataID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ParentDataType
		{
			get { return _parentDataType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ParentDataType", value, value.ToString());
				_isChanged |= (_parentDataType != value); _parentDataType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsFinished
		{
			get { return _isFinished; }

			set	
			{
				_isChanged |= (_isFinished != value); _isFinished = value;
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
			 return this.CheckEquals(obj as SystemTaskEntity);
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
