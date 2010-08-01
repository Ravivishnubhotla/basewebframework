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
	public class SPUperDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPUperDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_NAME = "Name";
		public static readonly string PROPERTY_NAME_DESCRIPTION = "Description";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _name;
		private string _description;
		private DateTime? _createDate;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPUperDataContract()
		{
			_id = 0;
			_name = null;
			_description = null;
			_createDate = null;
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
		public DateTime? CreateDate
		{
			get { return _createDate; }

			set	
			{
				_createDate = value;
			}
		}

		
		#endregion 


        public void FromWrapper(SPUperWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Name = wrapper.Name;
			this.Description = wrapper.Description;
			this.CreateDate = wrapper.CreateDate;
		}
		
		
		public SPUperWrapper ToWrapper()
        {
			SPUperWrapper wrapper = new SPUperWrapper();
			wrapper.Id = this.Id;
			wrapper.Name = this.Name;
			wrapper.Description = this.Description;
			wrapper.CreateDate = this.CreateDate;
		
		return wrapper;
        }



   }
}
