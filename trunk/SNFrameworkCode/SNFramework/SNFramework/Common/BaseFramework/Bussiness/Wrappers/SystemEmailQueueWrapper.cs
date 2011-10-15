
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
    public partial class SystemEmailQueueWrapper : BaseSpringNHibernateWrapper<SystemEmailQueueEntity, ISystemEmailQueueServiceProxy, SystemEmailQueueWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemEmailQueueWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemEmailQueueWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemEmailQueueWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemEmailQueueWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemEmailQueueWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemEmailQueueWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemEmailQueueWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemEmailQueueWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemEmailQueueWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemEmailQueueWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemEmailQueueWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemEmailQueueWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
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
