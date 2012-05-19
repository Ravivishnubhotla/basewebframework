using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin.NHibernateFramework
{
    public class NHibernateFrameworkTableCodeGenerateForm : BaseTablesSelectorForm<NHibernateFrameworkTableCodeGenerateConfig>
    {
        public NHibernateFrameworkTableCodeGenerateForm(dbRoot myMeta, IZeusInput input)
        {
            InitForm(myMeta, input);
            this.propertyGridSetting.CollapseAllGridItems();
        }

        public override NHibernateFrameworkTableCodeGenerateConfig DefaultConfig
        {
            get
            {
                return new NHibernateFrameworkTableCodeGenerateConfig();
            }
        }

        public override string ConfigKey
        {
            get { return "NHibernateFramework.Table.TableCodeGenerateConfig"; }
        }

        protected override List<string> GetDefaultSelectObject()
        {
            //MessageBox.Show(this.config.SelectObjectNames);

            if(string.IsNullOrEmpty(this.config.SelectObjectNames))
                return new List<string>();

            string[] objectNames = this.config.SelectObjectNames.Split(("\n").ToCharArray());
            //MessageBox.Show(objectNames.Length.ToString());
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
