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
	public partial class SPClientChannelSettingEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Entity.Tables.SPClientChannelSettingEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_CHANNELID = "ChannelID";
		public static readonly string PROPERTY_NAME_CLINETID = "ClinetID";
		public static readonly string PROPERTY_NAME_INTERCEPTRATE = "InterceptRate";
		public static readonly string PROPERTY_NAME_UPRATE = "UpRate";
		public static readonly string PROPERTY_NAME_DOWNRATE = "DownRate";
		public static readonly string PROPERTY_NAME_COMMANDTYPE = "CommandType";
		public static readonly string PROPERTY_NAME_COMMANDCODE = "CommandCode";
		public static readonly string PROPERTY_NAME_DISABLE = "Disable";
		public static readonly string PROPERTY_NAME_COMMANDCOLUMN = "CommandColumn";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private SPChannelEntity _channelID;
		private SPClientEntity _clinetID;
		private int? _interceptRate;
		private int? _upRate;
		private int? _downRate;
		private string _commandType;
		private string _commandCode;
		private bool? _disable;
		private string _commandColumn;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPClientChannelSettingEntity()
		{
			_id = 0;
			_channelID = null;
			_clinetID = null;
			_interceptRate = null;
			_upRate = null;
			_downRate = null;
			_commandType = null;
			_commandCode = null;
			_disable = false;
			_commandColumn = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPClientChannelSettingEntity( int id, SPChannelEntity channelID, SPClientEntity clinetID, int? interceptRate, int? upRate, int? downRate, string commandType, string commandCode, bool? disable, string commandColumn)
		{
			_id = id;
			_channelID = channelID;
			_clinetID = clinetID;
			_interceptRate = interceptRate;
			_upRate = upRate;
			_downRate = downRate;
			_commandType = commandType;
			_commandCode = commandCode;
			_disable = disable;
			_commandColumn = commandColumn;
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
		public virtual SPChannelEntity ChannelID
		{
			get { return _channelID; }

			set	
			{
				_isChanged |= (_channelID != value); _channelID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SPClientEntity ClinetID
		{
			get { return _clinetID; }

			set	
			{
				_isChanged |= (_clinetID != value); _clinetID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? InterceptRate
		{
			get { return _interceptRate; }

			set	
			{
				_isChanged |= (_interceptRate != value); _interceptRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? UpRate
		{
			get { return _upRate; }

			set	
			{
				_isChanged |= (_upRate != value); _upRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? DownRate
		{
			get { return _downRate; }

			set	
			{
				_isChanged |= (_downRate != value); _downRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CommandType
		{
			get { return _commandType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for CommandType", value, value.ToString());
				_isChanged |= (_commandType != value); _commandType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CommandCode
		{
			get { return _commandCode; }

			set	
			{

				if( value != null && value.Length > 1600)
					throw new ArgumentOutOfRangeException("Invalid value for CommandCode", value, value.ToString());
				_isChanged |= (_commandCode != value); _commandCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? Disable
		{
			get { return _disable; }

			set	
			{
				_isChanged |= (_disable != value); _disable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string CommandColumn
		{
			get { return _commandColumn; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for CommandColumn", value, value.ToString());
				_isChanged |= (_commandColumn != value); _commandColumn = value;
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
			
			SPClientChannelSettingEntity castObj = (SPClientChannelSettingEntity)obj;
			
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
