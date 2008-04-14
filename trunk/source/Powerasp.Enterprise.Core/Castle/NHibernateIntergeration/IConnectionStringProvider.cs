using System;
using System.Collections.Generic;
using System.Text;

namespace Powerasp.Enterprise.Core.Castle.NHibernateIntergeration
{
    public interface IConnectionStringProvider
    {
        string GetConnString{get;}
    }
}