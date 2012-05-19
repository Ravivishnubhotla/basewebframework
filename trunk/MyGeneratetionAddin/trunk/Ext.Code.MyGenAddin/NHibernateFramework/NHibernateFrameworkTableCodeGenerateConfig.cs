using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms.Design;
using Legendigital.Code.MyGenAddin.Win;
using MyMeta;

namespace Legendigital.Code.MyGenAddin.NHibernateFramework
{
    [Serializable]
    public class NHibernateFrameworkTableCodeGenerateConfig
    {
        #region Entity Layer Code

        #region [业务实体层代码设置]--[代码命名设置]

        private string _EntityAssembleName;
        private string _EntityNameSpace;
        private string _EntityClassNameFormat;
        private string _EntityMappingfileClassNameFormat;
        private string _EntityCollectionNameSpace;
        private string _EntityCollectionClassNameFormat;

        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类应用程序集"), Browsable(true)]
        public string EntityAssembleName
        {
            get { return _EntityAssembleName; }
            set { _EntityAssembleName = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类名称空间"), Browsable(true)]
        public string EntityNameSpace
        {
            get { return _EntityNameSpace; }
            set { _EntityNameSpace = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类命名规则"), Browsable(true)]
        public string EntityClassNameFormat
        {
            get { return _EntityClassNameFormat; }
            set { _EntityClassNameFormat = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类配置文件命名规则"), Browsable(true)]
        public string EntityMappingfileClassNameFormat
        {
            get { return _EntityMappingfileClassNameFormat; }
            set { _EntityMappingfileClassNameFormat = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类自定义集合类名称空间"), Browsable(false)]
        public string EntityCollectionNameSpace
        {
            get { return _EntityCollectionNameSpace; }
            set { _EntityCollectionNameSpace = value; }
        }
        [Category("[业务实体层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务实体类自定义集合类命名规则"), Browsable(false)]
        public string EntityCollectionClassNameFormat
        {
            get { return _EntityCollectionClassNameFormat; }
            set { _EntityCollectionClassNameFormat = value; }
        }

        #endregion

        #region [业务实体层代码设置]--[代码生成开关]

        private bool _IsCreateEntityClassFile;
        private bool _IsCreateMappingFile;
        private bool _IsCreateCollection;

        [Category("[业务实体层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否创建业务实体类配置文件"), Browsable(true)]
        public bool IsCreateMappingFile
        {
            get { return _IsCreateMappingFile; }
            set { _IsCreateMappingFile = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否创建业务实体类件"), Browsable(true)]
        public bool IsCreateEntityClassFile
        {
            get { return _IsCreateEntityClassFile; }
            set { _IsCreateEntityClassFile = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否创建业务实体自定义集合类"), Browsable(false)]
        public bool IsCreateCollection
        {
            get { return _IsCreateCollection; }
            set { _IsCreateCollection = value; }
        }

        #endregion

        #region [业务实体层代码设置]--[代码生成配置]

        private string _SpecifiedPrimaryKeyIndex;
        private string _DbPrefix;
        private string _MemberPrefix;
        private bool _IsUseSequenceKey;
        private string _SequenceIDNameFormat;
        private bool _EntityIsInternal;

        [Category("[业务实体层代码设置]--[代码生成配置]"), ReadOnly(false), Description("实体类是否为内部类"), Browsable(true)]
        public bool EntityIsInternal
        {
            get { return _EntityIsInternal; }
            set { _EntityIsInternal = value; }
        }

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
        [Category("[业务实体层代码设置]--[代码生成配置]"), ReadOnly(false), Description("是否使用Sequence(Oracle专用)"), Browsable(true)]
        public bool IsUseSequenceKey
        {
            get { return _IsUseSequenceKey; }
            set { _IsUseSequenceKey = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成配置]"), ReadOnly(false), Description("Sequence命名规则"), Browsable(true)]
        public string SequenceIDNameFormat
        {
            get { return _SequenceIDNameFormat; }
            set { _SequenceIDNameFormat = value; }
        }

        #endregion

        #region [业务实体层代码设置]--[代码功能选项]

        private bool _IsGenerateSerializeCode;
        private bool _IsimplementICloneable;
        private bool _IsUseNullAbleType;
        private bool _IsUseNHibernte2Config;
        private bool _IsCreateFKeyClassrefence;
        private bool _IsCreateSubClassListrefence;
        private bool _IsParentClassMaintainSubClass;
        private bool _IsReadOnlyClass;
        private bool _IsCreateEqualsAndGetHashCodeFunction;
        private bool _IsCreateSerializeFunction;
        private bool _IsLazyLoad;

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
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否使用NHibernte2.0配置"), Browsable(true)]
        public bool IsUseNHibernte2Config
        {
            get { return _IsUseNHibernte2Config; }
            set { _IsUseNHibernte2Config = value; }
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
        [Category("[业务实体层代码设置]--[代码功能选项]"), ReadOnly(false), Description("是否延迟加载"), Browsable(true)]
        public bool IsLazyLoad
        {
            get { return _IsLazyLoad; }
            set { _IsLazyLoad = value; }
        }


        #endregion

        #region [业务实体层代码设置]--[代码生成路径]

        private string _SelectEntityClassFilePath;
        private string _SelectMappingFileFilePath;
        private string _SelectEntityCollectionFilePath;

        [Category("[业务实体层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务实体类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectEntityClassFilePath
        {
            get { return _SelectEntityClassFilePath; }
            set { _SelectEntityClassFilePath = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务实体类配置文件生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectMappingFileFilePath
        {
            get { return _SelectMappingFileFilePath; }
            set { _SelectMappingFileFilePath = value; }
        }
        [Category("[业务实体层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务实体自定义集合类生成路径"), Browsable(false)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectEntityCollectionFilePath
        {
            get { return _SelectEntityCollectionFilePath; }
            set { _SelectEntityCollectionFilePath = value; }
        }

        #endregion

        #endregion

        #region DataObjectGenerationCofig

        #region [数据访问层代码设置]--[代码命名设置]

        private string _DataObjectAssembleName;
        private string _DataObjectNameSpace;
        private string _DataObjectClassNameFormat;
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
        [Category("[数据访问层代码设置]--[代码命名设置]"), ReadOnly(false), Description("数据访问类名称空间"), Browsable(true)]
        public string DataObjectNameSpace
        {
            get { return _DataObjectNameSpace; }
            set { _DataObjectNameSpace = value; }
        }
        [Category("[数据访问层代码设置]--[代码命名设置]"), ReadOnly(false), Description("数据访问类命名规则"), Browsable(true)]
        public string DataObjectClassNameFormat
        {
            get { return _DataObjectClassNameFormat; }
            set { _DataObjectClassNameFormat = value; }
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

        #region Bussiness Layer Code


        #region [业务层代码设置]--[代码命名设置]

        private bool _ServiceProxyClassIsInternal = true;

        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务代理类是否内部类"), Browsable(true)]
        public bool ServiceProxyClassIsInternal
        {
            get { return _ServiceProxyClassIsInternal; }
            set { _ServiceProxyClassIsInternal = value; }
        }

        private string _BussinessAssembleName;
        private string _ServiceProxyNameSpace;
        private string _GenerateBussinessEncapsulationClassNameSpace;
        private string _GenerateServiceProxyContainerClassNameSpace;
        private string _ServiceProxyClassNameFormat;
        private string _GenerateBussinessEncapsulationClassNameFormat;
        private string _ServiceProxyInterfaceNameFormat;
        private string _GenerateServiceProxyContainerClassName;
        private string _GenerateServiceProxyContainerXMLFileName;
        private string _RootServiceProxyClassName;
        private string _RootServiceProxyClassNameSpace;
        private string _ImportServiceProxyNameSpace;
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务代理类基类名"), Browsable(true)]
        public string RootServiceProxyClassName
        {
            get { return _RootServiceProxyClassName; }
            set { _RootServiceProxyClassName = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务代理类基类名称空间"), Browsable(true)]
        public string RootServiceProxyClassNameSpace
        {
            get { return _RootServiceProxyClassNameSpace; }
            set { _RootServiceProxyClassNameSpace = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务代理类基类名预加载名称空间"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ImportServiceProxyNameSpace
        {
            get { return _ImportServiceProxyNameSpace; }
            set { _ImportServiceProxyNameSpace = value; }
        }


        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层应用程序集名称"), Browsable(true)]
        public string BussinessAssembleName
        {
            get { return _BussinessAssembleName; }
            set { _BussinessAssembleName = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层代理类名称空间"), Browsable(true)]
        public string ServiceProxyNameSpace
        {
            get { return _ServiceProxyNameSpace; }
            set { _ServiceProxyNameSpace = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务包装类名称空间"), Browsable(true)]
        public string GenerateBussinessEncapsulationClassNameSpace
        {
            get { return _GenerateBussinessEncapsulationClassNameSpace; }
            set { _GenerateBussinessEncapsulationClassNameSpace = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务代理容器类名称空间"), Browsable(true)]
        public string GenerateServiceProxyContainerClassNameSpace
        {
            get { return _GenerateServiceProxyContainerClassNameSpace; }
            set { _GenerateServiceProxyContainerClassNameSpace = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务代理类命名规则"), Browsable(true)]
        public string ServiceProxyClassNameFormat
        {
            get { return _ServiceProxyClassNameFormat; }
            set { _ServiceProxyClassNameFormat = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务代理接口命名规则"), Browsable(true)]
        public string ServiceProxyInterfaceNameFormat
        {
            get { return _ServiceProxyInterfaceNameFormat; }
            set { _ServiceProxyInterfaceNameFormat = value; }
        }

        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务包装类命名规则"), Browsable(true)]
        public string GenerateBussinessEncapsulationClassNameFormat
        {
            get { return _GenerateBussinessEncapsulationClassNameFormat; }
            set { _GenerateBussinessEncapsulationClassNameFormat = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务代理容器类名称"), Browsable(true)]
        public string GenerateServiceProxyContainerClassName
        {
            get { return _GenerateServiceProxyContainerClassName; }
            set { _GenerateServiceProxyContainerClassName = value; }
        }
        [Category("[业务层代码设置]--[代码命名设置]"), ReadOnly(false), Description("业务层业务代理容器配置文件名称"), Browsable(true)]
        public string GenerateServiceProxyContainerXMLFileName
        {
            get { return _GenerateServiceProxyContainerXMLFileName; }
            set { _GenerateServiceProxyContainerXMLFileName = value; }
        }

        #endregion


        #region [业务层层代码设置]--[代码生成开关]

        private bool _IsCreateServiceProxyClassFile;
        private bool _IsGenerateBussinessEncapsulationClass;
        private bool _IsGenerateServiceProxyContainerClass;
        [Category("[业务层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否生成业务代理类"), Browsable(true)]
        public bool IsCreateServiceProxyClassFile
        {
            get { return _IsCreateServiceProxyClassFile; }
            set { _IsCreateServiceProxyClassFile = value; }
        }
        [Category("[业务层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否生成业务包装类"), Browsable(true)]
        public bool IsGenerateBussinessEncapsulationClass
        {
            get { return _IsGenerateBussinessEncapsulationClass; }
            set { _IsGenerateBussinessEncapsulationClass = value; }
        }
        [Category("[业务层代码设置]--[代码生成开关]"), ReadOnly(false), Description("是否生成业务代理容器类"), Browsable(true)]
        public bool IsGenerateServiceProxyContainerClass
        {
            get { return _IsGenerateServiceProxyContainerClass; }
            set { _IsGenerateServiceProxyContainerClass = value; }
        }

        #endregion


        #region [业务层层代码设置]--[代码生成路径]

        private string _SelectServiceProxyClassFilePath;
        private string _SelectGenerateBussinessEncapsulationClassFilePath;
        private string _SelectGenerateServiceProxyContainerClassFilePath;
        private string _SelectGenerateServiceProxyContainerClassXmlFilePath;

        [Category("[业务层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务代理类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectServiceProxyClassFilePath
        {
            get { return _SelectServiceProxyClassFilePath; }
            set { _SelectServiceProxyClassFilePath = value; }
        }
        [Category("[业务层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务包装类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectGenerateBussinessEncapsulationClassFilePath
        {
            get { return _SelectGenerateBussinessEncapsulationClassFilePath; }
            set { _SelectGenerateBussinessEncapsulationClassFilePath = value; }
        }
        [Category("[业务层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务代理容器类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectGenerateServiceProxyContainerClassFilePath
        {
            get { return _SelectGenerateServiceProxyContainerClassFilePath; }
            set { _SelectGenerateServiceProxyContainerClassFilePath = value; }
        }
        [Category("[业务层代码设置]--[代码生成路径]"), ReadOnly(false), Description("业务代理容器类配置文件生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectGenerateServiceProxyContainerClassXmlFilePath
        {
            get { return _SelectGenerateServiceProxyContainerClassXmlFilePath; }
            set { _SelectGenerateServiceProxyContainerClassXmlFilePath = value; }
        }

        #endregion






        #endregion

        #region Generate Setting

        private string _SelectObjectNames;
        private bool _IsEnbaleBussniessCode;
        private bool _IsEnbaleEntityCode;
        private bool _IsEnbaleDataCode;
        private bool _IsEnbaleGenerateBaseCode;
        private string _DefaultDatabaseName;

        [Category("[总体代码设置]"), ReadOnly(false), Description("是否生成基础框架继承类代码"), Browsable(true)]
        public bool IsEnbaleGenerateBaseCode
        {
            get { return _IsEnbaleGenerateBaseCode; }
            set { _IsEnbaleGenerateBaseCode = value; }
        }



        [Category("[总体代码设置]"), ReadOnly(false), Description("默认数据库名"), Browsable(true)]
        public string DefaultDatabaseName
        {
            get { return _DefaultDatabaseName; }
            set { _DefaultDatabaseName = value; }
        }

        [Category("[总体代码设置]"), ReadOnly(false), Description("是否生成业务层代码"), Browsable(true)]
        public bool IsEnbaleBussniessCode
        {
            get { return _IsEnbaleBussniessCode; }
            set { _IsEnbaleBussniessCode = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("预选择生成对象"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectObjectNames
        {
            get { return _SelectObjectNames; }
            set { _SelectObjectNames = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("是否生成业务实体层代码"), Browsable(true)]
        public bool IsEnbaleEntityCode
        {
            get { return _IsEnbaleEntityCode; }
            set { _IsEnbaleEntityCode = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("是否生成数据层代码"), Browsable(true)]
        public bool IsEnbaleDataCode
        {
            get { return _IsEnbaleDataCode; }
            set { _IsEnbaleDataCode = value; }
        }

        #endregion

        #region Base Code Config

        private string _BaseCodePrex;
        private string _BaseAssembleName;
        private string _BaseEntityObjectNameSpace;
        private string _BaseDataObjectNameSpace;
        private string _BaseServiceProxyNameSpace;
        private string _BaseBussinessEncapsulationClassNameSpace;
        private string _BaseTablePrex;




        
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架数据层继承类名称空间"), Browsable(true)]
        public string BaseAssembleName
        {
            get { return _BaseAssembleName; }
            set { _BaseAssembleName = value; }
        }
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架数据层继承类名称空间"), Browsable(true)]
        public string BaseEntityObjectNameSpace
        {
            get { return _BaseEntityObjectNameSpace; }
            set { _BaseEntityObjectNameSpace = value; }
        }
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架数据层继承类名称空间"), Browsable(true)]
        public string BaseTablePrex
        {
            get { return _BaseTablePrex; }
            set { _BaseTablePrex = value; }
        }
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架数据层继承类名称空间"), Browsable(true)]
        public string BaseDataObjectNameSpace
        {
            get { return _BaseDataObjectNameSpace; }
            set { _BaseDataObjectNameSpace = value; }
        }
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架继承类代码前缀"), Browsable(true)]
        public string BaseCodePrex
        {
            get { return _BaseCodePrex; }
            set { _BaseCodePrex = value; }
        }
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架业务层业务代理继承类名称空间"), Browsable(true)]
        public string BaseServiceProxyNameSpace
        {
            get { return _BaseServiceProxyNameSpace; }
            set { _BaseServiceProxyNameSpace = value; }
        }
        [Category("[基础框架继承代码设置]"), ReadOnly(false), Description("基础框架业务层业务包装继承类名称空间"), Browsable(true)]
        public string BaseBussinessEncapsulationClassNameSpace
        {
            get { return _BaseBussinessEncapsulationClassNameSpace; }
            set { _BaseBussinessEncapsulationClassNameSpace = value; }
        }

        #endregion

        #region Method

        public string GenerateEntityClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.EntityClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateMappingFileName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, _EntityMappingfileClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateCollectionClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.EntityCollectionClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateDataObjectClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.DataObjectClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateServiceProxyClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.ServiceProxyClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateBussinessEncapsulationClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.GenerateBussinessEncapsulationClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateServiceProxyInterfaceClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.ServiceProxyInterfaceNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }


        public string GenerateBaseDataObjectClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.BaseCodePrex+this.DataObjectClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateBaseServiceProxyClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.BaseCodePrex + this.ServiceProxyClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateBaseBussinessEncapsulationClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.BaseCodePrex + this.GenerateBussinessEncapsulationClassNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }
        public string GenerateBaseServiceProxyInterfaceClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.BaseCodePrex + this.ServiceProxyInterfaceNameFormat, StringCase.PascalCase,
                                                             this.DbPrefix);
        }




        












        public string GenerateEntityClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectEntityClassFilePath, GenerateEntityClassName(table) + ".cs");
        }
        public string GenerateEntityDesignerClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectEntityClassFilePath, GenerateEntityClassName(table) + ".Designer.cs");
        }
        public string GenerateEntityMappingFilePath(ITable table)
        {
            return Path.Combine(this.SelectMappingFileFilePath, GenerateMappingFileName(table) + ".hbm.xml");
        }
        public string GenerateEntityCollectioClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectEntityCollectionFilePath, GenerateCollectionClassName(table) + ".cs");
        }
        public string GenerateDataObjectClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectDataObjectClassFilePath, GenerateDataObjectClassName(table) + ".cs");
        }
        public string GenerateeDataObjectDesignerClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectDataObjectClassFilePath, GenerateDataObjectClassName(table) + ".Designer.cs");
        }
        public string GenerateServiceProxyClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectServiceProxyClassFilePath, GenerateServiceProxyClassName(table) + ".cs");
        }
        public string GenerateServiceProxyDesignerClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectServiceProxyClassFilePath, GenerateServiceProxyClassName(table) + ".Designer.cs");
        }

        public string GenerateBussinessEncapsulationClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectGenerateBussinessEncapsulationClassFilePath, GenerateBussinessEncapsulationClassName(table) + ".cs");
        }
        public string GenerateBussinessEncapsulationDesignerClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectGenerateBussinessEncapsulationClassFilePath, GenerateBussinessEncapsulationClassName(table) + ".Designer.cs");
        }
        public string GenerateServiceProxyClassFilePath()
        {
            return Path.Combine(this.SelectGenerateServiceProxyContainerClassFilePath, this.GenerateServiceProxyContainerClassName + ".cs");
        }


        public string GenerateBaseDataObjectClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectDataObjectClassFilePath, this.BaseCodePrex + GenerateDataObjectClassName(table) + ".cs");
        }
        public string GenerateBaseBussinessEncapsulationClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectGenerateBussinessEncapsulationClassFilePath, this.BaseCodePrex + GenerateBussinessEncapsulationClassName(table) + ".cs");
        }
        public string GenerateBaseBussinessEncapsulationDesignerClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectGenerateBussinessEncapsulationClassFilePath, this.BaseCodePrex + GenerateBussinessEncapsulationClassName(table) + ".Designer.cs");
        }
        public string GenerateBaseServiceProxyClassFilePath(ITable table)
        {
            return Path.Combine(this.SelectServiceProxyClassFilePath, this.BaseCodePrex + this.GenerateServiceProxyClassName(table) + ".cs");
        }

        public string GenerateServiceProxyDesignerClassFilePath()
        {
            return Path.Combine(this.SelectGenerateServiceProxyContainerClassFilePath, this.GenerateServiceProxyContainerClassName + ".Designer.cs");
        }   



        public string GenerateClassDescription(ITable table)
        {
            return table.Description;
        }

        public string GenerateEntityMemberName(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateNameByTableColumn(column, this.MemberPrefix + "{0}", StringCase.CamelCase);
        }

        public string GenerateEntityParamsName(IColumn column)
        {
            string entityParamsName = TableColumnGenerationHelper.GenerateNameByTableColumn(column, "{0}", StringCase.CamelCase);
            if (TableColumnGenerationHelper.Csharpkeyword.Contains(entityParamsName))
            {
                return entityParamsName+"p";
            }
            return entityParamsName;
        }

        public string GenerateEntityMemberType(IColumn column)
        {
            return TableColumnGenerationHelper.GeneratePrivateMembersTypeByTableColumn(column, this.IsUseNullAbleType, IsCreateFKeyClassrefence, this.EntityClassNameFormat, StringCase.PascalCase, this._DbPrefix);
        }

        public string GenerateEntityPorpertyType(IColumn column)
        {
            return TableColumnGenerationHelper.GeneratePorpertyTypeByTableColumn(column, this.IsUseNullAbleType, IsCreateFKeyClassrefence, this.EntityClassNameFormat, StringCase.PascalCase, this._DbPrefix);
        }

        public string GenerateEntityNHibernateType(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateNHibernateTypeByTableColumn(column, IsCreateFKeyClassrefence, this.EntityClassNameFormat, StringCase.PascalCase, this._DbPrefix);
        }

        public string GenerateEntityNHibernateType(IColumn column, bool isGenerateClassType)
        {
            return TableColumnGenerationHelper.GenerateNHibernateTypeByTableColumn(column, isGenerateClassType, this.EntityClassNameFormat, StringCase.CamelCase, this._DbPrefix);
        }

        public string GenerateEntityPorpertyType(IColumn column, bool isGenerateClassType)
        {
            return TableColumnGenerationHelper.GeneratePorpertyTypeByTableColumn(column, this.IsUseNullAbleType, isGenerateClassType, this.EntityClassNameFormat, StringCase.CamelCase, this._DbPrefix);
        }

        public string GenerateEntityPorpertyName(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateNameByTableColumn(column, "{0}", StringCase.PascalCase);
        }



        public string GenerateNhibernateMappingFileClassTag(ITable table)
        {
            const string classTagTemplate = "<class name=\"{0}.{1},{2}\" table=\"{3}\" lazy=\"{4}\"  {5}>";
            return string.Format(classTagTemplate, this.EntityNameSpace, GenerateEntityClassName(table),
                                 this.EntityAssembleName, table.Alias.Replace(" ", ""),
                                 this.IsLazyLoad.ToString().ToLower(), (this.IsReadOnlyClass ? "mutable=\"false\"" : ""));
        }

        public string GenerateNhibernateAllColumnParams(ITable table)
        {
            StringBuilder sbParams = new StringBuilder();
            foreach (IColumn column in table.Columns)
            {
                sbParams.AppendFormat(" {0} {1},", GenerateEntityMemberType(column), GenerateEntityParamsName(column));
            }
            string paramlist = sbParams.ToString();
            if (paramlist.EndsWith(","))
                paramlist = paramlist.Substring(0, paramlist.Length - 1);
            return paramlist;
        }

        public List<IColumn> GetAllPkColumn(ITable table)
        {
            int primaryKeysCount = table.PrimaryKeys.Count;

            List<IColumn> pks = new List<IColumn>();

            if (primaryKeysCount > 0)
            {
                foreach (IColumn column in table.PrimaryKeys)
                {
                    pks.Add(column);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.SpecifiedPrimaryKeyIndex.Trim()))
                    return pks;

                string[] keyIndexs = this.SpecifiedPrimaryKeyIndex.Split(',');

                foreach (string index in keyIndexs)
                {
                    pks.Add(table.Columns[int.Parse(index)]);
                }
            }

            return pks;
        }

        public List<IColumn> GetAllNotPkColumn(ITable table)
        {
            List<IColumn> pks = GetAllPkColumn(table);

            List<IColumn> npks = new List<IColumn>();

            foreach (IColumn column in table.Columns)
            {
                if (!pks.Contains(column))
                {
                    npks.Add(column);
                }
            }

            return npks;
        }


        public string GenerateEntityNHibernatePrimaryKeysTag(ITable table)
        {
            string idTemplate = "<id name=\"{0}\" column=\"{1}\" type=\"{2}\" {3} >\n" +
                                "   {4}\n" +
                                "</id>\n";

            List<IColumn> pks = GetAllPkColumn(table);

            if (pks.Count <= 0)
            {
                return
                    "<!-- could not find a primary key for this table/view. NHibernate requires an 'id' element, so you'll have to define one manually. -->";
            }
            else if (pks.Count == 1)
            {
                string idGenerateTemplate = "<generator class=\"{0}\">\n" +
                                            "{1}\n" +
                                            "</generator>\n";

                string generateTemplate = "";

                if (this.IsUseSequenceKey)
                {
                    generateTemplate = string.Format(idGenerateTemplate, "sequence", "<param name=\"sequence\">" + string.Format(this.SequenceIDNameFormat, pks[0].Table.Name) + "</param>");
                }
                else
                {
                    generateTemplate = string.Format(idGenerateTemplate, ((pks[0].IsAutoKey) ? "native" : "assigned"), "");
                }

                return string.Format(idTemplate, GenerateEntityPorpertyName(pks[0]), pks[0].Name, GenerateEntityNHibernateType(pks[0], false), GenerateEntityNHibernateUnsavedValue(pks[0]), generateTemplate);
            }
            else
            {
                return
                    "<!-- Composite primary key is experimental. View the documentation for syntax. -->";
            }

        }

        public string GenerateEntityDefaultValue(IColumn column)
        {
            return TableColumnGenerationHelper.GetContructInitalValueByTableColumn(column, this.IsUseNullAbleType, this.IsCreateFKeyClassrefence);
        }

        private string GenerateEntityNHibernateUnsavedValue(IColumn column)
        {
            switch (column.LanguageType)
            {
                case "decimal":
                case "float":
                case "short":
                case "int":
                case "long":
                case "double":
                    return "unsaved-value=\"0\"";
                    break;
                default:
                    return "";
                    break;
            }
        }

        public List<ITable> GetAllBaseTable(IDatabase db)
        {
            List<ITable> tables = new List<ITable>();
            foreach (ITable table in db.Tables)
            {
                if(table.Name.StartsWith(this.BaseTablePrex))
                {
                    tables.Add(table);
                }
            }
            return tables;
        }

        #endregion

    }
}
