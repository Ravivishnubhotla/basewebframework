using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace LD.SPPipeManage.Bussiness.DataContracts.Tables
{
	/// <summary>
	///	公告
	/// </summary>
	[DataContract]
	public class SPMemoDataContract
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "LD.SPPipeManage.Bussiness.DataContracts.Tables.SPMemoDataContract";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_TITLE = "Title";
		public static readonly string PROPERTY_NAME_MEMOCONTENT = "MemoContent";
		public static readonly string PROPERTY_NAME_CREATEDATE = "CreateDate";
		
        #endregion
	
        #region 私有成员变量
		
		private int _id;
		private string _title;
		private string _memoContent;
		private DateTime? _createDate;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SPMemoDataContract()
		{
			_id = 0;
			_title = String.Empty;
			_memoContent = null;
			_createDate = null;
		}
		#endregion

	    #region 公共属性

		/// <summary>
		/// 主键
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
		/// 标题
		/// </summary>
		[DataMember]
		public string Title
		{
			get { return _title; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				_title = value;
			}
		}

		/// <summary>
		/// 内容
		/// </summary>
		[DataMember]
		public string MemoContent
		{
			get { return _memoContent; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for MemoContent", value, value.ToString());
				_memoContent = value;
			}
		}

		/// <summary>
		/// 创建时间
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


        public void FromWrapper(SPMemoWrapper wrapper)
		{
			this.Id = wrapper.Id;
			this.Title = wrapper.Title;
			this.MemoContent = wrapper.MemoContent;
			this.CreateDate = wrapper.CreateDate;
		}
		
		
		public SPMemoWrapper ToWrapper()
        {
			SPMemoWrapper wrapper = new SPMemoWrapper();
			wrapper.Id = this.Id;
			wrapper.Title = this.Title;
			wrapper.MemoContent = this.MemoContent;
			wrapper.CreateDate = this.CreateDate;
		
		return wrapper;
        }



   }
}
