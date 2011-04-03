
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemEmailQueueWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemEmailQueueWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemEmailQueueWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemEmailQueueWrapper obj)
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

        public static void Delete(SystemEmailQueueWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemEmailQueueWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemEmailQueueWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemEmailQueueWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemEmailQueueWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemEmailQueueEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemEmailQueueWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemEmailQueueWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemEmailQueueWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   pageQueryParams));

            return results;
        }
		

        public static List<SystemEmailQueueWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public static void SaveSuccessMail(MailMessage mailMessage)
	    {
	        SystemEmailQueueWrapper systemEmailQueueWrapper = new SystemEmailQueueWrapper();

	        systemEmailQueueWrapper.FromAddress = mailMessage.From.Address;
            systemEmailQueueWrapper.FromName = mailMessage.From.DisplayName;

	        string toNames = string.Empty;
	        string toMails = string.Empty;

            List<string> toNamesA = new List<string>();
	        List<string> toMailsA = new List<string>();

	        foreach (MailAddress mailAddress in mailMessage.To)
	        {
	            toNamesA.Add(mailAddress.DisplayName);
 	            toMailsA.Add(mailAddress.Address);
	        }

            toNames = string.Join(",",toNamesA.ToArray());
            toMails = string.Join(",",toMailsA.ToArray());

	        systemEmailQueueWrapper.ToAddresss = toMails;
            systemEmailQueueWrapper.ToNames = toNames;

	        systemEmailQueueWrapper.Title = mailMessage.Subject;
	        systemEmailQueueWrapper.Body = mailMessage.Body;

	        systemEmailQueueWrapper.MaxRetryTime = 5;
	        systemEmailQueueWrapper.SendRetry = 0;

	        systemEmailQueueWrapper.SendDate = System.DateTime.Now;

	        systemEmailQueueWrapper.MailLog = string.Format(" [{0}] Send Success \n",
	                                                        systemEmailQueueWrapper.SendDate.Value.ToShortTimeString());

	        systemEmailQueueWrapper.Statues = "success";

            Save(systemEmailQueueWrapper);
	    }

	    public static void SaveErrorMail(MailMessage mailMessage, Exception exception)
	    {
            SystemEmailQueueWrapper systemEmailQueueWrapper = new SystemEmailQueueWrapper();

            systemEmailQueueWrapper.FromAddress = mailMessage.From.Address;
            systemEmailQueueWrapper.FromName = mailMessage.From.DisplayName;

            string toNames = string.Empty;
            string toMails = string.Empty;

            List<string> toNamesA = new List<string>();
            List<string> toMailsA = new List<string>();

            foreach (MailAddress mailAddress in mailMessage.To)
            {
                toNamesA.Add(mailAddress.DisplayName);
                toMailsA.Add(mailAddress.Address);
            }

            toNames = string.Join(",", toNamesA.ToArray());
            toMails = string.Join(",", toMailsA.ToArray());

            systemEmailQueueWrapper.ToAddresss = toMails;
            systemEmailQueueWrapper.ToNames = toNames;

            systemEmailQueueWrapper.Title = mailMessage.Subject;
            systemEmailQueueWrapper.Body = mailMessage.Body;

            systemEmailQueueWrapper.MaxRetryTime = 5;
            systemEmailQueueWrapper.SendRetry = 1;

            systemEmailQueueWrapper.MailLog = string.Format(" [{0}] Send failed Error Message : {1} \n",
                                                            System.DateTime.Now.ToShortTimeString(), exception.Message);
            systemEmailQueueWrapper.Statues = "failed";

            Save(systemEmailQueueWrapper);
	    }
    }
}
