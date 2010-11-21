
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPClientGroupWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPClientGroupWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPClientGroupWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPClientGroupWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SPClientGroupWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPClientGroupWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPClientGroupWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPClientGroupWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientGroupWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPClientGroupEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPClientGroupWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPClientGroupWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPClientGroupWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPClientGroupWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

        public bool UserIsLocked
        {
            get
            {
                if (this.UserID != null && this.UserID > 0)
                {
                    SystemUserWrapper user = SystemUserWrapper.FindById(this.UserID);

                    if (user != null)
                        return user.IsLockedOut;
                }
                return false;
            }
        }

        public string ClientList
	    {
	        get
	        {
	            StringBuilder sb = new StringBuilder();

	            List<SPClientWrapper> clientWrappers = SPClientWrapper.FindAllBySPClientGroupID(this);

	            foreach (SPClientWrapper spClientWrapper in clientWrappers)
	            {
	                SPClientChannelSettingWrapper channelSettingWrapper = spClientWrapper.FindDefaultSetting();

	                string codeChannel = "";

                    if(channelSettingWrapper!=null)
                    {
                        codeChannel = string.Format("指令 ‘{0}’ 通道 ‘{1}’", channelSettingWrapper.ChannelClientRuleMatch, channelSettingWrapper.ChannelID.Name);
                    }

	                sb.AppendFormat(" 下家 ‘{0}’{1}  <br/>", spClientWrapper.Name, codeChannel);
	            }

	            return sb.ToString();
	        }

	    }

        public string UserName
        {
            get
            {
                if (this.UserID != null && this.UserID > 0)
                {
                    SystemUserWrapper user = SystemUserWrapper.FindById(this.UserID);

                    if (user != null)
                        return user.UserLoginID;
                }
                return "";
            }
        }

        public static SPClientGroupWrapper GetByUserID(int userId)
	    {
            SystemUserWrapper user = SystemUserWrapper.FindById(userId);

            return ConvertEntityToWrapper(businessProxy.GetIDByUserID(userId));
	    }

 
    }
}
