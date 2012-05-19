using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Code.MyGenAddin.NHibernateFramework
{
    public class ADOFrameworkCodeGenerateForm : BaseDatabaseGenerateForm<ADOFrameworkCodeGenerateConfig>
    {
        public override ADOFrameworkCodeGenerateConfig DefaultConfig
        {
            get { return new ADOFrameworkCodeGenerateConfig(); }
        }

        public override string ConfigKey
        {
            get { return "ADOFramework.DB.DBCodeGenerateConfig"; }
        }

        protected override List<string> GetDefaultSelectTables()
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetDefaultSelectViews()
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetDefaultSelectProceduces()
        {
            throw new NotImplementedException();
        }

        protected override string GetDefaultDataBaseName()
        {
            throw new NotImplementedException();
        }
    }
}
