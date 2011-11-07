
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
using Legendigital.Framework.Common.Utility;


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



	    public string DisplayName
	    {
            get
            {
                if (string.IsNullOrEmpty(this.Alias))
                {
                    return this.UserLoginID;
                }
                return this.Alias;
            }      
	    }

	    private SPClientChannelSettingWrapper defaultClientChannelSetting = null;

	    public SPClientChannelSettingWrapper DefaultClientChannelSetting
	    {
	        get
	        {
	            if(defaultClientChannelSetting==null)
	                defaultClientChannelSetting = FindDefaultSetting();
	            return defaultClientChannelSetting;
	        }
	    }

	    public int DefaultChannelID
	    {
            get
            {
                if (DefaultClientChannelSetting != null)
                    return DefaultClientChannelSetting.ChannelID.Id;
                return 0;
            }
	    }




        public string SyncDataUrl
        {            
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";
                return DefaultClientChannelSetting.SyncDataUrl;
            }
        }

        public string SPCode
        {
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";

                return DefaultClientChannelSetting.ChannelClientCode;
            }
        }

        public string AllowAndDisableArea
        {
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";

                return DefaultClientChannelSetting.AllowAndDisableArea;
            }
        }

        public string SendText
        {
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";

                return DefaultClientChannelSetting.SendText;
            }
        }

        public string Getway
        {
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";

                return DefaultClientChannelSetting.Getway;
            }
        }

        public string DayLimitAndMonthLimit
        {
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";

                return DefaultClientChannelSetting.DayLimitAndMonthLimit;
            }
        }

        


        public string InterfaceList
        {
            get
            {
                if (DefaultClientChannelSetting == null)
                    return "";

                StringBuilder sbInterfaceList = new StringBuilder();

                List<SPClientChannelSycnParamsWrapper> clientFieldMappings = DefaultClientChannelSetting.GetFieldMappings();

                if (clientFieldMappings.Count > 0)
                {
                    foreach (SPClientChannelSycnParamsWrapper clientFieldMapping in clientFieldMappings)
                    {
                        sbInterfaceList.AppendLine(string.Format("{0}:{1}<br/>", clientFieldMapping.Name, clientFieldMapping.Description));
                    }
                }
                else
                {
                    List<SPChannelDefaultClientSycnParamsWrapper> channelFieldMappings = DefaultClientChannelSetting.ChannelID.GetAllEnableDefaultSendParams();

                    foreach (SPChannelDefaultClientSycnParamsWrapper channelDefaultClientSycnParam in channelFieldMappings)
                    {
                        sbInterfaceList.AppendLine(string.Format("{0}:{1}<br/>", channelDefaultClientSycnParam.Name, channelDefaultClientSycnParam.Description));
                    }
                }

                return sbInterfaceList.ToString();
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

	    public static List<SPClientWrapper> GetAllDefaultClient()
	    {
            return ConvertToWrapperList(businessProxy.GetAllDefaultClient());       

	    }

        public static List<SPClientWrapper> FindAllNotInClientGroup(int clientGroupId)
        {
            return ConvertToWrapperList(businessProxy.FindAllNotInClientGroup(clientGroupId));   
        }

        //public static void QuickAdd(string loginId, string code, SPChannelWrapper channelWrapper, int mainloginuserId, List<CodeUserID> codeUserIds, string channelCode, int orderIndex, bool hasSubCode, string codeType)
        //{
        //    businessProxy.QuickAdd(loginId, code, channelWrapper.entity, mainloginuserId, codeUserIds, channelCode, orderIndex, hasSubCode, codeType);
        //}

        public static void QuickAdd(string loginId, string code, SPChannelWrapper channelWrapper, int mainloginuserId, List<CodeUserID> codeUserIds, string channelCode, int orderIndex, bool hasSubCode, string codeType, string allowAndDisableArea, string getway, string dayLimit, string monthLimit, string sendText)
        {
            businessProxy.QuickAdd(loginId, code, channelWrapper.entity, mainloginuserId, codeUserIds, channelCode, orderIndex, hasSubCode, codeType, allowAndDisableArea,   getway,   dayLimit,   monthLimit,   sendText);

        }


        public DayliyReport GetDayReport(DateTime dateTime)
	    {
	        return SPDayReportWrapper.GetDayReport(dateTime.Date,this);
	    }

        public decimal Price
        {
            get
            {
                if(SPClientGroupID==null)
                {
                    return SPClientPriceWrapper.GetClientPrice(this.Id);
                }
                else
                {
                    return SPClientPriceWrapper.GetClientGroupPrice(this.Id, SPClientGroupID.Id);                
                }
            }
        }






	    public void SetClientPrice(decimal price)
	    {
            if (SPClientGroupID == null)
            {
                SPClientPriceWrapper.SetClientPrice(this.Id, price);
            }
            else
            {
                SPClientPriceWrapper.SetClientGroupPrice(this.Id, SPClientGroupID.Id, price);
            }
	    }

        public DateTime GetDT()
        {
            int dayCount = 7;


            try
            {
                dayCount = ConfigurationUtil.ReadIntAppSetting("ClientViewRecordDay", dayCount);
            }
            catch (Exception e)
            {
                
            }

            switch (System.DateTime.Now.Date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return System.DateTime.Now.Date.AddDays(-1 * dayCount);
                case DayOfWeek.Tuesday:
                    return System.DateTime.Now.Date.AddDays(-1 * (dayCount + 1));
                case DayOfWeek.Wednesday:
                    return System.DateTime.Now.Date.AddDays(-1 * (dayCount + 2));
                case DayOfWeek.Thursday:
                    return System.DateTime.Now.Date.AddDays(-1 * (dayCount + 3));
                case DayOfWeek.Friday:
                    return System.DateTime.Now.Date.AddDays(-1 * (dayCount + 4));
                case DayOfWeek.Saturday:
                    return System.DateTime.Now.Date.AddDays(-1 * (dayCount + 5));
                case DayOfWeek.Sunday:
                    return System.DateTime.Now.Date.AddDays(-1 * (dayCount + 6));
            }

            return DateTime.Now.Date;
        }


	    public void UpdateSyncDataSetting()
	    {
            SPClientChannelSettingWrapper channelSetting = this.DefaultClientChannelSetting;

            if (channelSetting != null)
            {
                if (this.SPClientGroupID!=null && !string.IsNullOrEmpty(this.SPClientGroupID.DefaultSycnMoUrl))
                {
                    channelSetting.SyncData = true;
                    channelSetting.SyncDataUrl = this.SPClientGroupID.DefaultSycnMoUrl;
                    channelSetting.OkMessage = "ok";
                    channelSetting.SyncType = "1";
                }
                else
                {
                    channelSetting.SyncData = false;
                    channelSetting.SyncDataUrl = "";
                    channelSetting.OkMessage = "";
                    channelSetting.FailedMessage = "";
                    channelSetting.SyncType = "";
                }

                SPClientChannelSettingWrapper.Update(channelSetting);
            }
	    }
    }
}
