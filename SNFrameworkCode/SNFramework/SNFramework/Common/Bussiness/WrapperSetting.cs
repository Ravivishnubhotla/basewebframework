using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Framework.Common.Bussiness
{
    public class WrapperSetting
    {
        protected HashSet<string> allowWrapperAutoRecordLog = new HashSet<string>();
        protected HashSet<string> allowWrapperAutoVersion = new HashSet<string>();

        private WrapperSetting()
        {
        }

        private static WrapperSetting wrapperSetting;

        public static WrapperSetting GetCurrent()
        {
            if (wrapperSetting==null)
            {
                wrapperSetting = new WrapperSetting();

                wrapperSetting.allowWrapperAutoRecordLog.Add(typeof(SystemOrganizationWrapper).FullName);
                wrapperSetting.allowWrapperAutoRecordLog.Add(typeof(SystemUserWrapper).FullName);

                

                wrapperSetting.allowWrapperAutoVersion.Add(typeof(SystemOrganizationWrapper).FullName);
            }

            return wrapperSetting;
        }

        public bool CheckTypeIsAutoRecordLog(Type checkType)
        {
            return allowWrapperAutoRecordLog.Contains(checkType.FullName);
        }

        public bool CheckTypeIsAutoVersion(Type checkType)
        {
            return allowWrapperAutoVersion.Contains(checkType.FullName);
        }

    }
}
