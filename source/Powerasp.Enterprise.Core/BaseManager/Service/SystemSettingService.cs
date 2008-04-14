using System;
using System.Collections.Generic;
using System.Text;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.BaseService;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemSettingService : SystemSettingBaseService
    {
        public SystemSettingService(SystemSettingDao selfDao) : base(selfDao)
        {
        }

        /// <summary>
        /// 获取系统基本设置信息
        /// </summary>
        /// <returns></returns>
        [Transaction(TransactionMode.Requires)]
        public virtual SystemSetting GetCurrentSystemSetting()
        {
            List<SystemSetting> listSystemSetting = this.SelfDao.FindAll();
            if (listSystemSetting.Count <= 0)
            {
                SystemSetting systemSetting = new SystemSetting();
                systemSetting.SystemName = "基础管理平台";
                systemSetting.SystemUrl = "#";
                systemSetting.SystemDescription = "";
                systemSetting.SystemVersion = "1.0.0";
                systemSetting.SystemLisence =
                    "Powered By <a href='#' target='_blank'><font color='#ffffff'>Supesoft.com</font></a> Information Technology Logistics Inc.";
                this.Create(systemSetting);
                return systemSetting;
            }
            else if (listSystemSetting.Count == 1)
            {
                return listSystemSetting[0];
            }
            else if (listSystemSetting.Count > 1)
            {
                for (int i = 0; i < listSystemSetting.Count - 1; i++)
                {
                    this.Delete(listSystemSetting[i + 1]);
                }
                return listSystemSetting[0];
            }
            else
            {
                SystemSetting systemSetting = new SystemSetting();
                systemSetting.SystemName = "基础管理平台";
                systemSetting.SystemUrl = "#";
                systemSetting.SystemDescription = "";
                systemSetting.SystemVersion = "1.0.0";
                systemSetting.SystemLisence =
                    "Powered By <a href='#' target='_blank'><font color='#ffffff'>Supesoft.com</font></a> Information Technology Logistics Inc.";
                this.Create(systemSetting);
                return systemSetting;
            }
        }
    }
}