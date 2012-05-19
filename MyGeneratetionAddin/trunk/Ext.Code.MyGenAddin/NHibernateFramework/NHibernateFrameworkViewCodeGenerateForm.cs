using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin.NHibernateFramework
{
    public class NHibernateFrameworkViewCodeGenerateForm : BaseViewsSelectorForm<NHibernateFrameworkViewCodeGenerateConfig>
    {
        public NHibernateFrameworkViewCodeGenerateForm(dbRoot myMeta, IZeusInput input)
        {
            InitForm(myMeta, input);
            this.propertyGridSetting.CollapseAllGridItems();
        }

        public override NHibernateFrameworkViewCodeGenerateConfig DefaultConfig
        {
            get
            {
                return new NHibernateFrameworkViewCodeGenerateConfig();
            }
        }

        public override string ConfigKey
        {
            get { return "NHibernateFramework.View.ViewCodeGenerateConfig"; }
        }

        protected override List<string> GetDefaultSelectObject()
        {
            if(string.IsNullOrEmpty(this.config.SelectObjectNames))
                return new List<string>();

            string[] objectNames = this.config.SelectObjectNames.Split(("\n").ToCharArray());

            for (int i = 0; i < objectNames.Length; i++)
            {
                if (objectNames[i].Trim().Replace("\r", "").Replace("\n", "").Trim() != "")
                    objectNames[i] = objectNames[i].Trim().Replace("\r", "").Replace("\n", "").Trim().ToUpper();
            }
            return new List<string>(objectNames);
        }

        protected override string GetDefaultDataBaseName()
        {
            return this.config.DefaultDatabaseName;
        }
    }
}
