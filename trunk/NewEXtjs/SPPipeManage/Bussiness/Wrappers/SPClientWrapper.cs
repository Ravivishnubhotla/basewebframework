
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
    [Serializable]
    public class CodeUserID
    {
        public string Code { get; set; }
        public int UserID { get; set; }
    }



	[Serializable]
    public partial class SPClientWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPClientWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPClientWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPClientWrapper obj)
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

        public static void Delete(SPClientWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPClientWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPClientWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPClientWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPClientEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPClientWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPClientWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion


        public string UserLoginID
        {
            get
            {
                if (this.UserID != null && this.UserID>0)
                {
                    SystemUserWrapper user = SystemUserWrapper.FindById(this.UserID);

                    if (user != null)
                        return user.UserLoginID;
                }
                return "";
            }
        }




        public string ClientGroupName
        {
            get
            {
                if (this.SPClientGroupID != null)
                {
                    return this.SPClientGroupID.Name;
                }
                return "";
            }
        }

        public static int GetClientIDByUserID(int userId)
        {
            SystemUserWrapper user = SystemUserWrapper.FindById(userId);

            return ConvertEntityToWrapper(businessProxy.GetClientByUserID(userId)).Id;
        }

        public static List<SPClientWrapper> FindByChannelID(int cid)
        {
            return ConvertToWrapperList(businessProxy.FindByChannelID(cid));
        }

        public SPClientChannelSettingWrapper FindDefaultSetting()
        {
            List<SPClientChannelSettingWrapper> clientChannelSettingWrappers =
                SPClientChannelSettingWrapper.FindAllByClinetID(this);

            if (clientChannelSettingWrappers != null && clientChannelSettingWrappers.Count > 0)
                return clientChannelSettingWrappers[0];
            else
                return null;
        }

        public static void QuickAdd(string loginID, string code, SPChannelWrapper channelWrapper, int mainloginuserID, List<CodeUserID> codeUserIds,string channelCode)
        {
            businessProxy.QuickAdd(loginID, code, channelWrapper.entity, mainloginuserID, codeUserIds, channelCode);
        }
    }
}
