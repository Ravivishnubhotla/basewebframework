using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin.NHibernateFramework
{
    public class NHibernateFrameworkWebUIGenerateForm : BaseSingleObjectSelectorForm<NHibernateFrameworkWebUIGenerateConfig>
    {

        public NHibernateFrameworkWebUIGenerateForm(dbRoot myMeta, IZeusInput input)
        {
            InitForm(myMeta, input);
        }

        public override NHibernateFrameworkWebUIGenerateConfig DefaultConfig
        {
            get {
                NHibernateFrameworkWebUIGenerateConfig config = new NHibernateFrameworkWebUIGenerateConfig();
                config.TableCss = "tabForm";
                config.TableRowLableCss = "dataLabel";
                config.TableRowInputCss = "tabEditViewDF";
                config.AjaxControlPrex = "AspAjax";
                config.IdKeyName = "ID";
                config.AddPageNameFormat = "{0}AddPage";
                config.EditPageNameFormat = "{0}EditPage";
                config.ViewPageNameFormat = "{0}ViewPage";
                config.ListPageNameFormat = "{0}ListPage";
                config.ValidGroup = "vg{0}";
                return config;
                 }
        }

        public override string ConfigKey
        {
            get { return "NHibernateFramework.WebUI.Generate"; }
        }

        protected override string GetDefaultDataBaseName()
        {
            return this.config.DefaultDatabaseName;
        }

        public override SortedList<string, string> GetDropDownList()
        {
            SortedList<string, string> hb = new SortedList<string, string>();
            hb.Add("GenerateAddPageHtmlAndPageCode", "生成添加界面HTML和后台代码");
            hb.Add("GenerateEditPageHtmlAndPageCode", "生成编辑界面HTML和后台代码");
            hb.Add("GenerateViewPageHtmlAndPageCode", "生成显示界面HTML和后台代码");
            hb.Add("GenerateListPageHtmlAndPageCode", "生成列表界面HTML和后台代码");
            hb.Add("GenerateSingleManageListPageHtmlAndPageCode", "生成单列表管理界面HTML和后台代码");
            return hb;
        }
    }
}
