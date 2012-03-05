using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Aop
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RecordAuditorClassAttribute : Attribute
    {
        public bool EnableVersion { get; set; }
    }
}
