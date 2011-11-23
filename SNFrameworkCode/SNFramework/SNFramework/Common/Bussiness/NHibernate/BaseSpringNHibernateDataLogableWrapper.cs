using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Entity;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public abstract class BaseSpringNHibernateDataLogableWrapper<DomainType, ServiceProxyType, WrapperType> : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>, IDataLogableWrapper
        where DomainType : BaseTableEntity
        where ServiceProxyType : IBaseSpringNHibernateEntityServiceProxy<DomainType>
        where WrapperType : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>, IDataLogableWrapper
    {
        protected BaseSpringNHibernateDataLogableWrapper(DomainType entityObj) : base(entityObj)
        {
        }


        new protected static void Save(WrapperType obj, ServiceProxyType serviceProxy)
        {
            BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>.Save(obj, serviceProxy);
            LogNewRecord(obj, obj.CreateBy.Value, obj.CreateAt.Value, obj.LastModifyComment, obj.entity.GetDataEntityKey());
        }

        private static void LogNewRecord(WrapperType wrapperType, int userID, DateTime dateTime,string opComment,object id)
        {
            try
            {
                if(userID==0)
                {
                    SystemLogWrapper.LogUserOperationAction(opComment, HttpUtil.GetIP(HttpContext.Current.Request), dateTime, typeof(WrapperType).Name, (int)id);
                }
                else
                {
                    SystemLogWrapper.LogUserOperationAction(SystemUserWrapper.FindById(userID), opComment, HttpUtil.GetIP(HttpContext.Current.Request), dateTime, typeof(WrapperType).Name, (int)id);          
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }


        public abstract int? CreateBy { get; set; }

        public abstract DateTime? CreateAt { get; set; }

        public abstract int? LastModifyBy { get; set; }

        public abstract DateTime? LastModifyAt { get; set; }

        public abstract string LastModifyComment { get; set; }

        public void SetCreatByInfo(int createBy, DateTime createAt, string createComment)
        {
            CreateBy = createBy;
            CreateAt = createAt;
            LastModifyComment = createComment;
        }

        public void SetModifyByInfo(int lastModifyBy, DateTime lastModifyAt, string modifyComment)
        {
            LastModifyBy = lastModifyBy;
            LastModifyAt = lastModifyAt;
            LastModifyComment = modifyComment;
        }
    }
}
