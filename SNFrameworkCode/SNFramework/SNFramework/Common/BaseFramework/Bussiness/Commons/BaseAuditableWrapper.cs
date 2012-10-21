using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Entity;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Commons
{
    public abstract class BaseAuditableWrapper<DomainType, ServiceProxyType, WrapperType, EntityKeyType> : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType, EntityKeyType>, IAuditableWrapper
        where DomainType : BaseTableEntity<EntityKeyType>
        where ServiceProxyType : IBaseSpringNHibernateEntityServiceProxy<DomainType, EntityKeyType>
        where WrapperType : BaseAuditableWrapper<DomainType, ServiceProxyType, WrapperType, EntityKeyType>, IAuditableWrapper
    {


        #region Construtor

        protected BaseAuditableWrapper(DomainType entityObj)
            : base(entityObj)
        {
        }

        #endregion

        public static ILog logger = LogManager.GetLogger(typeof(SystemLogWrapper));



        public static SystemVersionWrapper SaveNewVersion(WrapperType objAuditable)
        {
            SystemVersionWrapper dataVersion = new SystemVersionWrapper();

            dataVersion.ParentDataType = objAuditable.GetType().FullName;
            dataVersion.ParentDataID = Convert.ToInt32(objAuditable.GetDataEntityKey());
            dataVersion.VersionNumber = 1;
            dataVersion.ChangeUserID = objAuditable.CreateBy;
            dataVersion.ChangeDate = objAuditable.CreateAt;
            dataVersion.VauleField = objAuditable.GetEntityPropertyDictionaryValues();
            dataVersion.NewChangeFileld = "";
            dataVersion.OldChangeFileld = "";

            SystemVersionWrapper.Save(dataVersion);

            return dataVersion;
        }

        public static SystemVersionWrapper UpdateNewVersion(WrapperType objAuditable)
        {
            SystemVersionWrapper dataVersion = new SystemVersionWrapper();

            dataVersion.ParentDataType = objAuditable.GetType().FullName;
            dataVersion.ParentDataID = Convert.ToInt32(objAuditable.GetDataEntityKey());

            SystemVersionWrapper curdataVersion =
                SystemVersionWrapper.GetCurrentVersionByDataTypeAndDataID(dataVersion.ParentDataType,
                                                                          dataVersion.ParentDataID.Value);

            if (curdataVersion == null)
            {
                return SaveNewVersion(objAuditable);
            }
            else
            {
                dataVersion.VersionNumber = curdataVersion.VersionNumber + 1;
                dataVersion.ChangeUserID = objAuditable.CreateBy;
                dataVersion.ChangeDate = objAuditable.CreateAt;
                dataVersion.VauleField = objAuditable.GetEntityPropertyDictionaryValues();
                dataVersion.GetChangeField(curdataVersion);

                SystemVersionWrapper.Save(dataVersion);

                return dataVersion;
            }
        }

        public static void LogOpCreate(WrapperType auditableData)
        {
            try
            {
                SystemLogWrapper log = new SystemLogWrapper();
                log.LogDate = ValueConvertUtil.ConvertNullableValue(auditableData.CreateAt, System.DateTime.Now);

                SystemUserWrapper opUser = null;

                if (auditableData.CreateBy.HasValue)
                {
                    opUser = SystemUserWrapper.FindById(auditableData.CreateBy.Value);
                }

                log.LogDescrption = auditableData.LastModifyComment;

                log.LogLevel = SystemLogWrapper.SysteLogLevel.Info;
                log.LogRelateDateTime = auditableData.CreateAt;
                log.LogRelateUserID = auditableData.CreateBy;

                if (opUser != null)
                    log.LogRelateUserName = opUser.UserLoginID;
                else
                    log.LogRelateUserName = "";



                log.ParentDataType = auditableData.GetType().Name.ToString();
                log.ParentDataID = auditableData.CreateBy;
                log.LogSource = "Operation";
                log.LogType = SystemLogWrapper.SysteLogType.OperationLog;

                SystemLogWrapper.Save(log);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }


        }

        public static void LogOpUpdate(WrapperType auditableData)
        {
            try
            {
                SystemLogWrapper log = new SystemLogWrapper();
                log.LogDate = ValueConvertUtil.ConvertNullableValue(auditableData.LastModifyAt, System.DateTime.Now);

                SystemUserWrapper opUser = null;

                if (auditableData.LastModifyBy.HasValue)
                {
                    opUser = SystemUserWrapper.FindById(auditableData.LastModifyBy.Value);
                }

                log.LogDescrption = auditableData.LastModifyComment;

                log.LogLevel = SystemLogWrapper.SysteLogLevel.Info;
                log.LogRelateDateTime = auditableData.LastModifyAt;
                log.LogRelateUserID = auditableData.LastModifyBy;

                if (opUser != null)
                    log.LogRelateUserName = opUser.UserLoginID;
                else
                    log.LogRelateUserName = "";

                log.ParentDataType = auditableData.GetType().ToString();
                log.ParentDataID = auditableData.LastModifyBy;
                log.LogSource = "Operation";
                log.LogType = SystemLogWrapper.SysteLogType.OperationLog;

                SystemLogWrapper.Save(log);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        public static void LogOpDelete(WrapperType auditableData)
        {
            LogOpOther(auditableData);
        }

        public static void LogOpOther(WrapperType auditableData)
        {
            try
            {
                SystemVersionWrapper systemVersion = null;

                if (systemVersion == null)
                {
                    systemVersion = SaveNewVersion(auditableData);
                }

                SystemLogWrapper log = new SystemLogWrapper();
                log.LogDate = ValueConvertUtil.ConvertNullableValue(auditableData.LastModifyAt, System.DateTime.Now);

                SystemUserWrapper opUser = null;

                if (auditableData.LastModifyBy.HasValue)
                {
                    opUser = SystemUserWrapper.FindById(auditableData.LastModifyBy.Value);
                }

                log.LogDescrption = auditableData.LastModifyComment;

                log.LogLevel = SystemLogWrapper.SysteLogLevel.Info;
                log.LogRelateDateTime = auditableData.LastModifyAt;
                log.LogRelateUserID = auditableData.LastModifyBy;

                if (opUser != null)
                    log.LogRelateUserName = opUser.UserLoginID;
                else
                    log.LogRelateUserName = "";

                log.ParentDataType = auditableData.GetType().ToString();
                log.ParentDataID = auditableData.LastModifyBy;
                log.LogSource = "Operation";
                log.LogType = SystemLogWrapper.SysteLogType.OperationLog;

                SystemLogWrapper.Save(log);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }


        public abstract int? CreateBy { get; set; }
        public abstract DateTime? CreateAt { get; set; }
        public abstract int? LastModifyBy { get; set; }
        public abstract DateTime? LastModifyAt { get; set; }
        public abstract string LastModifyComment { get; set; }
        public abstract string GetEntityTypeName();
        public abstract string GetEntityName();
        public abstract string GetEntityID();
    }
}
