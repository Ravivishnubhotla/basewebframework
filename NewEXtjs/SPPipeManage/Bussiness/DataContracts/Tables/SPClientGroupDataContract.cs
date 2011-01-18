using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace LD.SPPipeManage.Bussiness.DataContracts.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public class SPClientGroupDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPClientGroupDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_DEFAULTSYCNMOURL = "DefaultSycnMoUrl";
		public static readonly string PROPERTY_NAME_DEFAULTSYCNMRURL = "DefaultSycnMRUrl";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _name;
		private string _description;
		private int? _userID;
		private string _defaultSycnMoUrl;
		private string _defaultSycnMRUrl;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPClientGroupDataContract()
		{
			_id = 0;
			_name = null;
			_description = null;
			_userID = null;
			_defaultSycnMoUrl = null;
			_defaultSycnMRUrl = null;
		}
		#endregion

	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int Id
		{
			get { return _id; }

			set	
			{
				_id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Name
		{
			get { return _name; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string Description
		{
			get { return _description; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_description = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public int? UserID
		{
			get { return _userID; }

			set	
			{
				_userID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string DefaultSycnMoUrl
		{
			get { return _defaultSycnMoUrl; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for DefaultSycnMoUrl", value, value.ToString());
				_defaultSycnMoUrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string DefaultSycnMRUrl
		{
			get { return _defaultSycnMRUrl; }

			set	
			{

				if( value != null && value.Length > 1000)
					throw new ArgumentOutOfRangeException("Invalid value for DefaultSycnMRUrl", value, value.ToString());
				_defaultSycnMRUrl = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPClientGroupWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Name = wrapper.Name;
			this.Description = wrapper.Description;
			this.UserID = wrapper.UserID;
			this.DefaultSycnMoUrl = wrapper.DefaultSycnMoUrl;
			this.DefaultSycnMRUrl = wrapper.DefaultSycnMRUrl;
		}
		
		
		public SPClientGroupWrapper ToWrapper()
        {
			SPClientGroupWrapper wrapper = new SPClientGroupWrapper();
			wrapper.Id = this.Id;
			wrapper.Name = this.Name;
			wrapper.Description = this.Description;
			wrapper.UserID = this.UserID;
			wrapper.DefaultSycnMoUrl = this.DefaultSycnMoUrl;
			wrapper.DefaultSycnMRUrl = this.DefaultSycnMRUrl;
		
		return wrapper;
        }



   }
}
