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
	public class SPPhoneAreaDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPPhoneAreaDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_PROVINCE = "Province";
		public static readonly string PROPERTY_NAME_CITY = "City";
		public static readonly string PROPERTY_NAME_PHONEPREFIX = "PhonePrefix";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _province;
		private string _city;
		private string _phonePrefix;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPPhoneAreaDataContract()
		{
			_id = 0;
			_province = null;
			_city = null;
			_phonePrefix = null;
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
		public string Province
		{
			get { return _province; }

			set	
			{

				if( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for Province", value, value.ToString());
				_province = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string City
		{
			get { return _city; }

			set	
			{

				if( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				_city = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public string PhonePrefix
		{
			get { return _phonePrefix; }

			set	
			{

				if( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for PhonePrefix", value, value.ToString());
				_phonePrefix = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPPhoneAreaWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Province = wrapper.Province;
			this.City = wrapper.City;
			this.PhonePrefix = wrapper.PhonePrefix;
		}
		
		
		public SPPhoneAreaWrapper ToWrapper()
        {
			SPPhoneAreaWrapper wrapper = new SPPhoneAreaWrapper();
			wrapper.Id = this.Id;
			wrapper.Province = this.Province;
			wrapper.City = this.City;
			wrapper.PhonePrefix = this.PhonePrefix;
		
		return wrapper;
        }



   }
}
