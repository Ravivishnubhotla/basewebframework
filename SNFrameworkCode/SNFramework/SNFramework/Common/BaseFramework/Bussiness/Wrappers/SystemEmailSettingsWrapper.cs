
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Net.Mail;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    public enum MailType { SendAsync, SendSync, SendAsyncSysDb, SendSqlMail }

    [Serializable]
    public partial class SystemEmailSettingsWrapper : BaseSpringNHibernateWrapper<SystemEmailSettingsEntity, ISystemEmailSettingsServiceProxy, SystemEmailSettingsWrapper>
    {


        #region Static Common Data Operation

        public static void Save(SystemEmailSettingsWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemEmailSettingsWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemEmailSettingsWrapper obj)
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

        public static void Delete(SystemEmailSettingsWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemEmailSettingsWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemEmailSettingsWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemEmailSettingsWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemEmailSettingsWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemEmailSettingsWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemEmailSettingsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemEmailSettingsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion


        private static SystemEmailSettingsWrapper GetDefaultSetting()
        {
            return ConvertEntityToWrapper(businessProxy.GetDefaultSetting());
        }

        private static SystemEmailSettingsWrapper GetSettingByName(string mailSettingName)
        {
            return ConvertEntityToWrapper(businessProxy.GetSettingByName(mailSettingName));
        }

        public static void SendMail(List<string> toMails, string subject, string body, bool isHtmlFormat, MailType mailType)
        {
            SystemEmailSettingsWrapper systemEmailSettingsWrapper = GetDefaultSetting();
            if (systemEmailSettingsWrapper != null)
            {
                SendMail(toMails, subject, body, isHtmlFormat, systemEmailSettingsWrapper.Name, mailType);

            }

        }

        private static void SendMail(List<string> toMails, string subject, string body, bool isHtmlFormat, string mailSettingName, MailType mailType)
        {
            SystemEmailSettingsWrapper mailSetting = null;

            if (string.IsNullOrEmpty(mailSettingName))
                mailSetting = GetDefaultSetting();
            else
                mailSetting = GetSettingByName(mailSettingName);

            SmtpClient objSmtpClient = mailSetting.GetSmtpClientByMailSetting(mailSetting);

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(mailSetting.FromEmail, mailSetting.FromName);

            foreach (string toMail in toMails)
            {
                if (!string.IsNullOrEmpty(toMail))
                {
                    mailMessage.To.Add(new MailAddress(toMail));
                }
            }

            mailMessage.Subject = subject;
            mailMessage.Body = body;


            mailMessage.IsBodyHtml = isHtmlFormat;
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            switch (mailType)
            {
                case MailType.SendSync:
                    try
                    {
                        objSmtpClient.Send(mailMessage);
                        SystemEmailQueueWrapper.SaveSuccessMail(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        SystemEmailQueueWrapper.SaveErrorMail(mailMessage, ex);
                        throw;
                    }
                    break;
                case MailType.SendAsync:
                    objSmtpClient.SendCompleted += new SendCompletedEventHandler(objSmtpClient_SendCompleted);
                    objSmtpClient.SendAsync(mailMessage, mailMessage);
                    break;
                case MailType.SendAsyncSysDb:
                    break;
                case MailType.SendSqlMail:
                    break;
                default:
                    objSmtpClient.Send(mailMessage);
                    break;
            }


        }

        private static void objSmtpClient_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MailMessage mailMessage = e.UserState as MailMessage;

            if (mailMessage != null)
            {
                if (e.Error != null)
                {
                    SystemEmailQueueWrapper.SaveErrorMail(mailMessage, e.Error);
                }
                else
                {
                    SystemEmailQueueWrapper.SaveSuccessMail(mailMessage);
                }
            }
        }

        private SmtpClient GetSmtpClientByMailSetting(SystemEmailSettingsWrapper mailSetting)
        {

            SmtpClient objSmtpClient = new SmtpClient(mailSetting.Host);

            if (!string.IsNullOrEmpty(mailSetting.Port))
            {
                objSmtpClient.Port = Convert.ToInt32(mailSetting.Port);
            }
            if (!string.IsNullOrEmpty(mailSetting.LoginEmail) && !string.IsNullOrEmpty(mailSetting.LoginPassword))
            {
                objSmtpClient.UseDefaultCredentials = true;
                objSmtpClient.Credentials = new System.Net.NetworkCredential(mailSetting.LoginEmail, mailSetting.LoginPassword);
            }

            if (mailSetting.Ssl.HasValue)
            {
                objSmtpClient.EnableSsl = mailSetting.Ssl.Value;
            }

            objSmtpClient.Timeout = 10000;

            return objSmtpClient;
        }
    }
}
