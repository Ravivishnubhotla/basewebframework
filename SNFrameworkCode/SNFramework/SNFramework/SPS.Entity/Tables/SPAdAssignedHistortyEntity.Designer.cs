// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPAdAssignedHistortyEntity.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace SPS.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SPAdAssignedHistortyEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "SPS.Entity.Tables.SPAdAssignedHistortyEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_SPADID = "SPAdID";
		public static readonly string PROPERTY_NAME_SPADPACKID = "SPAdPackID";
		public static readonly string PROPERTY_NAME_SPCLIENTID = "SPClientID";
		public static readonly string PROPERTY_NAME_CLIENTPRICE = "ClientPrice";
		public static readonly string PROPERTY_NAME_STARTDATE = "StartDate";
		public static readonly string PROPERTY_NAME_ENDDATE = "EndDate";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region sPAdPackID字段外键查询字段
        public const string PROPERTY_SPADPACKID_ALIAS_NAME = "SPAdPackID_SPAdAssignedHistortyEntity_Alias";
		public const string PROPERTY_SPADPACKID_ID = "SPAdPackID_SPAdAssignedHistortyEntity_Alias.Id";
		public const string PROPERTY_SPADPACKID_SPADID = "SPAdPackID_SPAdAssignedHistortyEntity_Alias.SPAdID";
		public const string PROPERTY_SPADPACKID_NAME = "SPAdPackID_SPAdAssignedHistortyEntity_Alias.Name";
		public const string PROPERTY_SPADPACKID_CODE = "SPAdPackID_SPAdAssignedHistortyEntity_Alias.Code";
		public const string PROPERTY_SPADPACKID_DESCRIPTION = "SPAdPackID_SPAdAssignedHistortyEntity_Alias.Description";
		public const string PROPERTY_SPADPACKID_ADPRICE = "SPAdPackID_SPAdAssignedHistortyEntity_Alias.AdPrice";
		#endregion
		#region sPClientID字段外键查询字段
        public const string PROPERTY_SPCLIENTID_ALIAS_NAME = "SPClientID_SPAdAssignedHistortyEntity_Alias";
		public const string PROPERTY_SPCLIENTID_ID = "SPClientID_SPAdAssignedHistortyEntity_Alias.Id";
		public const string PROPERTY_SPCLIENTID_NAME = "SPClientID_SPAdAssignedHistortyEntity_Alias.Name";
		public const string PROPERTY_SPCLIENTID_DESCRIPTION = "SPClientID_SPAdAssignedHistortyEntity_Alias.Description";
		public const string PROPERTY_SPCLIENTID_USERID = "SPClientID_SPAdAssignedHistortyEntity_Alias.UserID";
		public const string PROPERTY_SPCLIENTID_ISDEFAULTCLIENT = "SPClientID_SPAdAssignedHistortyEntity_Alias.IsDefaultClient";
		public const string PROPERTY_SPCLIENTID_SYNCDATA = "SPClientID_SPAdAssignedHistortyEntity_Alias.SyncData";
		public const string PROPERTY_SPCLIENTID_SYCNNOTINTERCEPTCOUNT = "SPClientID_SPAdAssignedHistortyEntity_Alias.SycnNotInterceptCount";
		public const string PROPERTY_SPCLIENTID_SYNCDATASETTING = "SPClientID_SPAdAssignedHistortyEntity_Alias.SyncDataSetting";
		public const string PROPERTY_SPCLIENTID_ALIAS = "SPClientID_SPAdAssignedHistortyEntity_Alias.Alias";
		public const string PROPERTY_SPCLIENTID_ISENABLE = "SPClientID_SPAdAssignedHistortyEntity_Alias.IsEnable";
		public const string PROPERTY_SPCLIENTID_INTERCEPTRATE = "SPClientID_SPAdAssignedHistortyEntity_Alias.InterceptRate";
		public const string PROPERTY_SPCLIENTID_DEFAULTPRICE = "SPClientID_SPAdAssignedHistortyEntity_Alias.DefaultPrice";
		public const string PROPERTY_SPCLIENTID_DEFAULTSHOWRECORDDAYS = "SPClientID_SPAdAssignedHistortyEntity_Alias.DefaultShowRecordDays";
		public const string PROPERTY_SPCLIENTID_CHANNELSTATUS = "SPClientID_SPAdAssignedHistortyEntity_Alias.ChannelStatus";
		public const string PROPERTY_SPCLIENTID_CREATEBY = "SPClientID_SPAdAssignedHistortyEntity_Alias.CreateBy";
		public const string PROPERTY_SPCLIENTID_CREATEAT = "SPClientID_SPAdAssignedHistortyEntity_Alias.CreateAt";
		public const string PROPERTY_SPCLIENTID_LASTMODIFYBY = "SPClientID_SPAdAssignedHistortyEntity_Alias.LastModifyBy";
		public const string PROPERTY_SPCLIENTID_LASTMODIFYAT = "SPClientID_SPAdAssignedHistortyEntity_Alias.LastModifyAt";
		public const string PROPERTY_SPCLIENTID_LASTMODIFYCOMMENT = "SPClientID_SPAdAssignedHistortyEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private int? _sPAdID;
		private SPAdPackEntity _sPAdPackID;
		private SPSClientEntity _sPClientID;
		private decimal? _clientPrice;
		private DateTime? _startDate;
		private DateTime? _endDate;
		private int _createBy;
		private DateTime _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPAdAssignedHistortyEntity()
		{
			_id = 0;
			_sPAdID = null;
			_sPAdPackID = null;
			_sPClientID = null;
			_clientPrice = null;
			_startDate = null;
			_endDate = null;
			_createBy = 0;
			_createAt = DateTime.MinValue;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = String.Empty;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SPAdAssignedHistortyEntity( int id, int? sPAdID, SPAdPackEntity sPAdPackID, SPSClientEntity sPClientID, decimal? clientPrice, DateTime? startDate, DateTime? endDate, int createBy, DateTime createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_sPAdID = sPAdID;
			_sPAdPackID = sPAdPackID;
			_sPClientID = sPClientID;
			_clientPrice = clientPrice;
			_startDate = startDate;
			_endDate = endDate;
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
		public virtual int? SPAdID
		{
			get { return _sPAdID; }

			set	
			{
				_isChanged |= (_sPAdID != value); _sPAdID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SPAdPackEntity SPAdPackID
		{
			get { return _sPAdPackID; }

			set	
			{
				_isChanged |= (_sPAdPackID != value); _sPAdPackID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SPSClientEntity SPClientID
		{
			get { return _sPClientID; }

			set	
			{
				_isChanged |= (_sPClientID != value); _sPClientID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual decimal? ClientPrice
		{
			get { return _clientPrice; }

			set	
			{
				_isChanged |= (_clientPrice != value); _clientPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? StartDate
		{
			get { return _startDate; }

			set	
			{
				_isChanged |= (_startDate != value); _startDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? EndDate
		{
			get { return _endDate; }

			set	
			{
				_isChanged |= (_endDate != value); _endDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int CreateBy
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
		public virtual DateTime CreateAt
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
			 return this.CheckEquals(obj as SPAdAssignedHistortyEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override int GetDataEntityKey()
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
