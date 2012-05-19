using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public abstract class EntityGenerateConfig
    {

        private string _EntityClassNameFormat;

        private string _EntityAssembleName;
        private string _EntityNameSpace;

        private string _MemberPrefix;

        private bool _IsCreateEntityClassFile;
        private bool _IsCreateEntityDesignerClassFile;

        private string _SelectEntityClassFilePath;
        private string _SelectAbstractDesignerEntityClassFilePath;

        private bool _IsGenerateSerializeCode;
        private bool _IsimplementICloneable;
        private bool _IsUseNullAbleType;




        [Category("代码命名选项"), ReadOnlyAttribute(false), Description("实体类命名模板"), Browsable(true)]
        public string EntityClassNameFormat
        {
            get { return _EntityClassNameFormat; }
            set { _EntityClassNameFormat = value; }
        }
        [Category("代码命名选项"), ReadOnlyAttribute(false), Description("实体类成员变量前缀"), Browsable(true)]
        public string MemberPrefix
        {
            get { return _MemberPrefix; }
            set { _MemberPrefix = value; }
        }
        [Category("代码实体类选项"), ReadOnlyAttribute(false), Description("实体类应用程序集名称"), Browsable(true)]
        public string EntityAssembleName
        {
            get { return _EntityAssembleName; }
            set { _EntityAssembleName = value; }
        }
        [Category("代码实体类选项"), ReadOnlyAttribute(false), Description("实体类命名空间"), Browsable(true)]
        public string EntityNameSpace
        {
            get { return _EntityNameSpace; }
            set { _EntityNameSpace = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("是否生成实体类"), Browsable(true)]
        public bool IsCreateEntityClassFile
        {
            get { return _IsCreateEntityClassFile; }
            set { _IsCreateEntityClassFile = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("是否生成实体设计类"), Browsable(true)]
        public bool IsCreateEntityDesignerClassFile
        {
            get { return _IsCreateEntityDesignerClassFile; }
            set { _IsCreateEntityDesignerClassFile = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("实体类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectEntityClassFilePath
        {
            get { return _SelectEntityClassFilePath; }
            set { _SelectEntityClassFilePath = value; }
        }
        [Category("代码生成选项"), ReadOnlyAttribute(false), Description("实体设计类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectAbstractDesignerEntityClassFilePath
        {
            get { return _SelectAbstractDesignerEntityClassFilePath; }
            set { _SelectAbstractDesignerEntityClassFilePath = value; }
        }
        [Category("代码功能选项"), ReadOnlyAttribute(false), Description("是否生成序列化代码"), Browsable(true)]
        public bool IsGenerateSerializeCode
        {
            get { return _IsGenerateSerializeCode; }
            set { _IsGenerateSerializeCode = value; }
        }
        [Category("代码功能选项"), ReadOnlyAttribute(false), Description("是否实现ICloneable接口"), Browsable(true)]
        public bool IsimplementICloneable
        {
            get { return _IsimplementICloneable; }
            set { _IsimplementICloneable = value; }
        }
        [Category("代码功能选项"), ReadOnlyAttribute(false), Description("是否使用可空类型"), Browsable(true)]
        public bool IsUseNullAbleType
        {
            get { return _IsUseNullAbleType; }
            set { _IsUseNullAbleType = value; }
        }




    }
}
