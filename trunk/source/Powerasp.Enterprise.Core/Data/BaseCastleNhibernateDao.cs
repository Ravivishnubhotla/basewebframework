using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Components;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;

namespace Powerasp.Enterprise.Core.Data
{
    public class BaseCastleNhibernateDao<T> : NHibernateGenericDao<T>
    {
        public BaseCastleNhibernateDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }

        public BaseCastleNhibernateDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }


    }
}
