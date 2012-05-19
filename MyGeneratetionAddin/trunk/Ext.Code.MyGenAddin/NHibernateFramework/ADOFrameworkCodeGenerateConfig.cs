using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using Legendigital.Code.MyGenAddin.Win;

namespace Legendigital.Code.MyGenAddin.NHibernateFramework
{
    [Serializable]
    public class ADOFrameworkCodeGenerateConfig
    {
        #region [业务实体层代码设置]--[代码命名设置]

        private string _EntityAssembleName;
        private string _EntityTablesNameSpace;
        private string _EntityViewsNameSpace;
        private string _EntityTableClassNameFormat;
        private string _EntityViewClassNameFormat;

        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类应用程序集"), Browsable(true)]
        public string EntityAssembleName
        {
            get { return _EntityAssembleName; }
            set { _EntityAssembleName = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务表实体类名称空间"), Browsable(true)]
        public string EntityTablesNameSpace
        {
            get { return _EntityTablesNameSpace; }
            set { _EntityTablesNameSpace = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务视图实体类名称空间"), Browsable(true)]
        public string EntityViewsNameSpace
        {
            get { return _EntityViewsNameSpace; }
            set { _EntityViewsNameSpace = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务表实体类命名规则"), Browsable(true)]
        public string EntityTableClassNameFormat
        {
            get { return _EntityTableClassNameFormat; }
            set { _EntityTableClassNameFormat = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务视图实体类命名规则"), Browsable(true)]
        public string EntityViewClassNameFormat
        {
            get { return _EntityViewClassNameFormat; }
            set { _EntityViewClassNameFormat = value; }
        }


        #endregion

        #region [业务实体层代码设置]--[代码生成开关]

        private bool _IsCreateEntityClassFile;

        [Category("[业务实体层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否创建业务实体类件"), Browsable(true)]
        public bool IsCreateEntityClassFile
        {
            get { return _IsCreateEntityClassFile; }
            set { _IsCreateEntityClassFile = value; }
        }


        #endregion

        #region [业务实体层代码设置]--[代码生成配置]

        private string _SpecifiedPrimaryKeyIndex;
        private string _DbPrefix;
        private string _MemberPrefix;

        [Category("[业务实体层代码设置]--[代码生成配置]"), ReadOnly(false), Description("手动指定主键索引（仅对没有主键的表有效）"), Browsable(true)]
        public string SpecifiedPrimaryKeyIndex
        {
            get { return _SpecifiedPrimaryKeyIndex; }
            set { _SpecifiedPrimaryKeyIndex = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成配置]"), ReadOnly(false), Description("数据命名对象前缀"), Browsable(true)]
        public string DbPrefix
        {
            get { return _DbPrefix; }
            set { _DbPrefix = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成配置]"), ReadOnly(false), Description("实体类成员变量前缀"), Browsable(true)]
        public string MemberPrefix
        {
            get { return _MemberPrefix; }
            set { _MemberPrefix = value; }
        }

        #endregion

        #region [业务实体层代码设置]--[代码功能选项]

        private bool _IsGenerateSerializeCode;
        private bool _IsimplementICloneable;
        private bool _IsUseNullAbleType;
        private bool _IsCreateFKeyClassrefence;
        private bool _IsCreateSubClassListrefence;
        private bool _IsParentClassMaintainSubClass;
        private bool _IsReadOnlyClass;
        private bool _IsCreateEqualsAndGetHashCodeFunction;
        private bool _IsCreateSerializeFunction;

        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("业务实体类是否支持序列化"), Browsable(true)]
        public bool IsGenerateSerializeCode
        {
            get { return _IsGenerateSerializeCode; }
            set { _IsGenerateSerializeCode = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("业务实体类是否实现ICloneable接口"), Browsable(true)]
        public bool IsimplementICloneable
        {
            get { return _IsimplementICloneable; }
            set { _IsimplementICloneable = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("业务实体类是否使用可空类型"), Browsable(true)]
        public bool IsUseNullAbleType
        {
            get { return _IsUseNullAbleType; }
            set { _IsUseNullAbleType = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否创建外键引用类"), Browsable(true)]
        public bool IsCreateFKeyClassrefence
        {
            get { return _IsCreateFKeyClassrefence; }
            set { _IsCreateFKeyClassrefence = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否创建子对象引用集合类"), Browsable(true)]
        public bool IsCreateSubClassListrefence
        {
            get { return _IsCreateSubClassListrefence; }
            set { _IsCreateSubClassListrefence = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否父类维护子对象集合"), Browsable(true)]
        public bool IsParentClassMaintainSubClass
        {
            get { return _IsParentClassMaintainSubClass; }
            set { _IsParentClassMaintainSubClass = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否为只读类"), Browsable(true)]
        public bool IsReadOnlyClass
        {
            get { return _IsReadOnlyClass; }
            set { _IsReadOnlyClass = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否生成Equals GetHashCode方法"), Browsable(true)]
        public bool IsCreateEqualsAndGetHashCodeFunction
        {
            get { return _IsCreateEqualsAndGetHashCodeFunction; }
            set { _IsCreateEqualsAndGetHashCodeFunction = value; }
        }
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否生成序列化代码"), Browsable(true)]
        public bool IsCreateSerializeFunction
        {
            get { return _IsCreateSerializeFunction; }
            set { _IsCreateSerializeFunction = value; }
        }


        #endregion

        #region [业务实体层代码设置]--[代码生成路径]

        private string _SelectEntityTablesClassFilePath;
        private string _SelectEntityViewsClassFilePath;

        [Category("[业务实体层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务表实体类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectEntityTablesClassFilePath
        {
            get { return _SelectEntityTablesClassFilePath; }
            set { _SelectEntityTablesClassFilePath = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务视图实体类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectEntityViewsClassFilePath
        {
            get { return _SelectEntityViewsClassFilePath; }
            set { _SelectEntityViewsClassFilePath = value; }
        }
       
        #endregion


        #region DataObjectGenerationCofig

        #region [数据访问层代码设置]--[代码命名设置]

        private string _DataObjectAssembleName;
        private string _DataObjectTablesNameSpace;
        private string _DataObjectViewsNameSpace;
        private string _DataObjectProcsNameSpace;
        private string _DataObjectTableClassNameFormat;
        private string _DataObjectViewClassNameFormat;
        private string _DataObjectProcClassNameFormat;
        private string _DataObjectContainerIoCClassName;
        private string _DataObjectContainerIoCClassNameSpace;
        private string _DataObjectIocXmlFileName;


        [Category("[数据访问层代码设置]--[代码命名设置]"), ReadOnly(false), Description("数据访问层容器类名称空间"), Browsable(true)]
        public string DataObjectContainerIoCClassNameSpace
        {
            get { return _DataObjectContainerIoCClassNameSpace; }
            set { _DataObjectContainerIoCClassNameSpace = value; }
        }
        [Category("[数据访问层代码设置]--[代码命名设置]"), ReadOnly(false), Description("数据访问层应用程序集"), Browsable(true)]
        public string DataObjectAssembleName
        {
            get { return _DataObjectAssembleName; }
            set { _DataObjectAssembleName = value; }
        }
     
        [Category("[数据访问层代码设置]--[代码命名设置]"), ReadOnly(false), Description("数据访问层容器类名"), Browsable(true)]
        public string DataObjectContainerIoCClassName
        {
            get { return _DataObjectContainerIoCClassName; }
            set { _DataObjectContainerIoCClassName = value; }
        }
        [Category("[数据访问层代码设置]--[代码命名设置]"), ReadOnly(false), Description("数据访问层容器类配置文件名"), Browsable(true)]
        public string DataObjectIocXmlFileName
        {
            get { return _DataObjectIocXmlFileName; }
            set { _DataObjectIocXmlFileName = value; }
        }

        #endregion

        #region [数据访问层代码设置]--[代码生成开关]

        private bool _IsCreateDataObjectClassFile;
        private bool _IsCreateDataObjectContainerIoCClass;
        private bool _IsCreateDataObjectIocXmlFileName;

        [Category("[数据访问层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否生成数据访问类"), Browsable(true)]
        public bool IsCreateDataObjectClassFile
        {
            get { return _IsCreateDataObjectClassFile; }
            set { _IsCreateDataObjectClassFile = value; }
        }
        [Category("[数据访问层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否生成数据层容器类"), Browsable(true)]
        public bool IsCreateDataObjectContainerIoCClass
        {
            get { return _IsCreateDataObjectContainerIoCClass; }
            set { _IsCreateDataObjectContainerIoCClass = value; }
        }
        [Category("[数据访问层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否生成数据层容器配置文件"), Browsable(true)]
        public bool IsCreateDataObjectIocXmlFileName
        {
            get { return _IsCreateDataObjectIocXmlFileName; }
            set { _IsCreateDataObjectIocXmlFileName = value; }
        }

        #endregion

        #region [数据访问层代码设置]--[代码生成路径]

        private string _SelectDataObjectClassFilePath;
        private string _DataObjectIocXmlFilePath;
        private string _DataObjectContainerIocClassFilePath;

        [Category("[数据访问层代码设置]--[代码生成路径]"), ReadOnly(false), Description("数据访问类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectDataObjectClassFilePath
        {
            get { return _SelectDataObjectClassFilePath; }
            set { _SelectDataObjectClassFilePath = value; }
        }
        [Category("[数据访问层代码设置]--[代码生成路径]"), ReadOnly(false), Description("数据层容器类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataObjectIocXmlFilePath
        {
            get { return _DataObjectIocXmlFilePath; }
            set { _DataObjectIocXmlFilePath = value; }
        }
        [Category("[数据访问层代码设置]--[代码生成路径]"), ReadOnly(false), Description("数据层容器配置文件生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataObjectContainerIocClassFilePath
        {
            get { return _DataObjectContainerIocClassFilePath; }
            set { _DataObjectContainerIocClassFilePath = value; }
        }

        #endregion

        #region [数据访问层代码设置]--[代码生成配置]

        private string _RootDataObjectName;
        private string _RootDataObjectNameSpace;
        private string _ImportNameSpace;
        private bool _DataObjectIsInternal;

        [Category("[数据访问层代码设置]--[代码生成配置]"), ReadOnly(false), Description("数据访问类是否为内部类"), Browsable(true)]
        public bool DataObjectIsInternal
        {
            get { return _DataObjectIsInternal; }
            set { _DataObjectIsInternal = value; }
        }

        [Category("[数据访问层代码设置]--[代码生成配置]"), ReadOnly(false), Description("数据访问类基类名"), Browsable(true)]
        public string RootDataObjectName
        {
            get { return _RootDataObjectName; }
            set { _RootDataObjectName = value; }
        }
        [Category("[数据访问层代码设置]--[代码生成配置]"), ReadOnly(false), Description("数据访问类基类名称空间"), Browsable(true)]
        public string RootDataObjectNameSpace
        {
            get { return _RootDataObjectNameSpace; }
            set { _RootDataObjectNameSpace = value; }
        }
        [Category("[数据访问层代码设置]--[代码生成配置]"), ReadOnly(false), Description("数据访问类预加载名称空间"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ImportNameSpace
        {
            get { return _ImportNameSpace; }
            set { _ImportNameSpace = value; }
        }

        #endregion

        #endregion
    }
}
