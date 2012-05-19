using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public class DataObjectGenerateconfig
    {
        private string _DataObjectClassNameFormat;

        private string _DataObjectAssembleName;
        private string _DataObjectNameSpace;
        private string _DataObjectDesignerClassNameSpace;

        private bool _IsCreateDataObjectClassFile;
        private bool _IsCreateDataObjectDesignerClassFile;

        private string _SelectDataObjectClassFilePath;



        private string _SelectAbstractDesignerDataObjectClassFilePath;

        private string _RootDataObjectName;
        private string _RootDataObjectNameSpace;
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
        [Category("代码数据层类选项"), ReadOnlyAttribute(false), Description("数据层类应用程序集名称"), Browsable(true)]
        public string DataObjectAssembleName
        {
            get { return _DataObjectAssembleName; }
            set { _DataObjectAssembleName = value; }
        }
        [Category("代码数据层类选项"), ReadOnlyAttribute(false), Description("数据层类命名空间"), Browsable(true)]
        public string DataObjectNameSpace
        {
            get { return _DataObjectNameSpace; }
            set { _DataObjectNameSpace = value; }
        }
        [Category("代码数据层类选项"), ReadOnlyAttribute(false), Description("数据层设计类命名空间"), Browsable(true)]
        public string DataObjectDesignerClassNameSpace
        {
            get { return _DataObjectDesignerClassNameSpace; }
            set { _DataObjectDesignerClassNameSpace = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("是否生成数据层类"), Browsable(true)]
        public bool IsCreateDataObjectClassFile
        {
            get { return _IsCreateDataObjectClassFile; }
            set { _IsCreateDataObjectClassFile = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("是否生成数据层设计类"), Browsable(true)]
        public bool IsCreateDataObjectDesignerClassFile
        {
            get { return _IsCreateDataObjectDesignerClassFile; }
            set { _IsCreateDataObjectDesignerClassFile = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("数据层类生成路径"), Browsable(true)]
        public string SelectDataObjectClassFilePath
        {
            get { return _SelectDataObjectClassFilePath; }
            set { _SelectDataObjectClassFilePath = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("数据层设计类生成路径"), Browsable(true)]
        public string SelectAbstractDesignerDataObjectClassFilePath
        {
            get { return _SelectAbstractDesignerDataObjectClassFilePath; }
            set { _SelectAbstractDesignerDataObjectClassFilePath = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("数据层基类名"), Browsable(true)]
        public string RootDataObjectName
        {
            get { return _RootDataObjectName; }
            set { _RootDataObjectName = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("数据层基类名称空间"), Browsable(true)]
        public string RootDataObjectNameSpace
        {
            get { return _RootDataObjectNameSpace; }
            set { _RootDataObjectNameSpace = value; }
        }


    }
}
