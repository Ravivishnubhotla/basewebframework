
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
    public partial class SystemEmailSettingsWrapper
    {


        #region Static Common Data Operation

        public static void Save(SystemEmailSettingsWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemEmailSettingsWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemEmailSettingsWrapper obj)
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

        public static void Delete(SystemEmailSettingsWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemEmailSettingsWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemEmailSettingsWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemEmailSettingsWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemEmailSettingsWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemEmailSettingsEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemEmailSettingsWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemEmailSettingsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemEmailSettingsWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   pageQueryParams));

            return results;
        }


        public static List<SystemEmailSettingsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
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
