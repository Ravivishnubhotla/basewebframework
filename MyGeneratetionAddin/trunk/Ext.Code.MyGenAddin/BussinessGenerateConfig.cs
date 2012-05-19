using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public class BussinessGenerateConfig
    {
        private string _ServiceProxyClassNameFormat;

        private string _ServiceProxyAssembleName;
        private string _ServiceProxyNameSpace;
        private string _ServiceProxyDesignerClassNameSpace;

        private bool _IsCreateServiceProxyClassFile;
        private bool _IsCreateServiceProxyDesignerClassFile;

        private string _SelectServiceProxyClassFilePath;



        private string _SelectAbstractDesignerServiceProxyClassFilePath;

        private string _RootServiceProxyName;
        private string _RootServiceProxyNameSpace;
        private string _DataObjectNameSpace;
        private string _DataObjectClassNameFormat;
        private string _EntityNameSpace;
        private string _EntityClassNameFormat;

        [Category("代码命名选项"), ReadOnlyAttribute(false), Description("实体类命名模板"), Browsable(true)]
        public string EntityClassNameFormat
        {
            get { return _EntityClassNameFormat; }
            set { _EntityClassNameFormat = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("业务实体类名称空间"), Browsable(true)]
        public string EntityNameSpace
        {
            get { return _EntityNameSpace; }
            set { _EntityNameSpace = value; }
        }

        [Category("代码命名选项"), ReadOnlyAttribute(false), Description("数据层类命名模板"), Browsable(true)]
        public string DataObjectClassNameFormat
        {
            get { return _DataObjectClassNameFormat; }
            set { _DataObjectClassNameFormat = value; }
        }
        [Category("代码命名选项"), ReadOnlyAttribute(false), Description("业务操作类命名模板"), Browsable(true)]
        public string ServiceProxyClassNameFormat
        {
            get { return _ServiceProxyClassNameFormat; }
            set { _ServiceProxyClassNameFormat = value; }
        }
        [Category("代码业务操作类选项"), ReadOnlyAttribute(false), Description("业务操作类应用程序集名称"), Browsable(true)]
        public string ServiceProxyAssembleName
        {
            get { return _ServiceProxyAssembleName; }
            set { _ServiceProxyAssembleName = value; }
        }
        [Category("代码业务操作类选项"), ReadOnlyAttribute(false), Description("业务操作类命名空间"), Browsable(true)]
        public string ServiceProxyNameSpace
        {
            get { return _ServiceProxyNameSpace; }
            set { _ServiceProxyNameSpace = value; }
        }
        [Category("代码业务操作类选项"), ReadOnlyAttribute(false), Description("业务操作设计类命名空间"), Browsable(true)]
        public string ServiceProxyDesignerClassNameSpace
        {
            get { return _ServiceProxyDesignerClassNameSpace; }
            set { _ServiceProxyDesignerClassNameSpace = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("是否生成业务操作类"), Browsable(true)]
        public bool IsCreateServiceProxyClassFile
        {
            get { return _IsCreateServiceProxyClassFile; }
            set { _IsCreateServiceProxyClassFile = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("是否生成业务操作设计类"), Browsable(true)]
        public bool IsCreateServiceProxyDesignerClassFile
        {
            get { return _IsCreateServiceProxyDesignerClassFile; }
            set { _IsCreateServiceProxyDesignerClassFile = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("业务操作类生成路径"), Browsable(true)]
        public string SelectServiceProxyClassFilePath
        {
            get { return _SelectServiceProxyClassFilePath; }
            set { _SelectServiceProxyClassFilePath = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("业务操作设计类生成路径"), Browsable(true)]
        public string SelectAbstractDesignerServiceProxyClassFilePath
        {
            get { return _SelectAbstractDesignerServiceProxyClassFilePath; }
            set { _SelectAbstractDesignerServiceProxyClassFilePath = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("业务操作基类名"), Browsable(true)]
        public string RootServiceProxyName
        {
            get { return _RootServiceProxyName; }
            set { _RootServiceProxyName = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("业务操作基类名称空间"), Browsable(true)]
        public string RootServiceProxyNameSpace
        {
            get { return _RootServiceProxyNameSpace; }
            set { _RootServiceProxyNameSpace = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("业务实体类名称空间"), Browsable(true)]
        public string DataObjectNameSpace
        {
            get { return _DataObjectNameSpace; }
            set { _DataObjectNameSpace = value; }
        }

    }
}
