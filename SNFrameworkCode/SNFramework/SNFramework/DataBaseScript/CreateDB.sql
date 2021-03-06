USE [SNFrameworkDb]
GO
/****** Object:  Table [dbo].[SPUpper]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPUpper](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[LastModifyBy] [int] NOT NULL,
	[LastModifyAt] [datetime] NOT NULL,
	[LastModifyComment] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_SPUPPER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPSClient]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPSClient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[UserID] [int] NOT NULL,
	[IsDefaultClient] [bit] NULL,
	[SyncData] [bit] NOT NULL,
	[SycnRetryTimes] [int] NULL,
	[SyncType] [nvarchar](50) NULL,
	[SycnNotInterceptCount] [int] NULL,
	[SycnDataUrl] [nvarchar](200) NULL,
	[SycnOkMessage] [nvarchar](50) NULL,
	[SycnFailedMessage] [nvarchar](50) NULL,
	[Alias] [nvarchar](200) NULL,
	[InterceptRate] [decimal](18, 2) NOT NULL,
	[DefaultPrice] [decimal](18, 2) NOT NULL,
	[DefaultShowRecordDays] [int] NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPSClient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPMemo]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPMemo](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[TextContent] [ntext] NULL,
	[PublishDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPMEMO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemDepartment]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDepartment](
	[Department_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Department_ID] [int] NULL,
	[Department_NameCn] [nvarchar](200) NOT NULL,
	[Department_NameEn] [nvarchar](200) NOT NULL,
	[Department_Decription] [nvarchar](2000) NULL,
	[DepartmentSortIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemDepartment] PRIMARY KEY CLUSTERED 
(
	[Department_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemDepartment', @level2type=N'COLUMN',@level2name=N'Department_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemDepartment', @level2type=N'COLUMN',@level2name=N'Parent_Department_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemDepartment', @level2type=N'COLUMN',@level2name=N'Department_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemDepartment', @level2type=N'COLUMN',@level2name=N'Department_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemDepartment', @level2type=N'COLUMN',@level2name=N'Department_Decription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemDepartment'
GO
/****** Object:  Table [dbo].[SystemDataType]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDataType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [nvarchar](2000) NULL,
	[TableName] [nvarchar](20) NULL,
	[IDFieldName] [nvarchar](20) NULL,
	[ClassFullName] [nvarchar](50) NULL,
	[AssemblyName] [nvarchar](20) NULL,
	[LoadMethodName] [nvarchar](50) NULL,
	[SaveMethodName] [nvarchar](50) NULL,
	[UpdateMethodName] [nvarchar](50) NULL,
	[DeleteMethodName] [nvarchar](50) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemDataType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemCountry]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemCountry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeNumber] [nvarchar](10) NULL,
	[Code2] [nvarchar](2) NULL,
	[Code3] [nvarchar](3) NULL,
	[AbbrNameCN] [nvarchar](30) NULL,
	[AbbrNameEN] [nvarchar](50) NULL,
	[FullNameCn] [nvarchar](80) NULL,
	[FullNameEn] [nvarchar](80) NULL,
 CONSTRAINT [PK_SystemCountry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfigGroup]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfigGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[IsEnable] [bit] NULL,
	[IsSystem] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemConfigGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemAttachment]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemAttachment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[FileName] [nvarchar](200) NULL,
	[MD5] [nvarchar](30) NULL,
	[Size] [int] NULL,
	[FileExt] [nvarchar](10) NULL,
	[Pages] [int] NULL,
	[FilePath] [nvarchar](200) NULL,
	[ParentType] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemAttachment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemApplication]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemApplication](
	[SystemApplication_ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemApplication_Name] [nvarchar](200) NOT NULL,
	[SystemApplication_Code] [nvarchar](200) NULL,
	[SystemApplication_Description] [nvarchar](2000) NULL,
	[SystemApplication_Url] [nvarchar](200) NULL,
	[SystemApplication_IsSystemApplication] [bit] NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemApplication] PRIMARY KEY CLUSTERED 
(
	[SystemApplication_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemApplication', @level2type=N'COLUMN',@level2name=N'SystemApplication_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemApplication', @level2type=N'COLUMN',@level2name=N'SystemApplication_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemApplication', @level2type=N'COLUMN',@level2name=N'SystemApplication_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Appilcation Url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemApplication', @level2type=N'COLUMN',@level2name=N'SystemApplication_Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{$DisplayName:"Is System Application"} Test description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemApplication', @level2type=N'COLUMN',@level2name=N'SystemApplication_IsSystemApplication'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Application' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemApplication'
GO
/****** Object:  Table [dbo].[MasterCustomer]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterCustomer](
	[MasterCustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[CustomerCode] [nvarchar](50) NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[DayPhone] [nvarchar](50) NULL,
	[DayPhoneExt] [nvarchar](50) NULL,
	[FaxNumber] [nvarchar](50) NULL,
	[FaxNumberExt] [nvarchar](6) NULL,
	[Company] [nvarchar](200) NULL,
	[CompanyWeb] [nvarchar](255) NULL,
	[ShipFirstName] [nvarchar](30) NULL,
	[ShipLastName] [nvarchar](30) NULL,
	[ShipAddress1] [nvarchar](200) NULL,
	[ShipAddress2] [nvarchar](200) NULL,
	[ShipAddress3] [nvarchar](200) NULL,
	[ShipCity] [nvarchar](50) NULL,
	[ShipState] [nvarchar](50) NULL,
	[ShipZip] [nvarchar](15) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[Comment] [nvarchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[MasterCustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MainPageContent]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainPageContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContentKey] [nvarchar](80) NULL,
	[ContentValue] [nvarchar](255) NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ECMProduct]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ECMProduct](
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_ECMProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](200) NOT NULL,
	[Abbreviation] [nvarchar](6) NULL,
	[IsDefault] [bit] NOT NULL,
	[CanShipping] [bit] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommonSiteAccount]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommonSiteAccount](
	[ID] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[LoginID] [nchar](10) NULL,
	[Password] [nchar](10) NULL,
	[NickName] [nchar](10) NULL,
	[Sex] [nchar](10) NULL,
	[Created] [nchar](10) NULL,
	[LastVisit] [nchar](10) NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressBook]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](50) NULL,
	[Phone] [nvarchar](200) NULL,
	[Company] [nvarchar](200) NULL,
	[Address1] [nvarchar](60) NULL,
	[Address2] [nvarchar](60) NULL,
	[Address3] [nvarchar](60) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Zip] [nvarchar](50) NULL,
	[ShippingMethodID] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Extender] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingMethod]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingMethod](
	[ShippingMethodID] [int] IDENTITY(1,1) NOT NULL,
	[ShippingMethodName] [nvarchar](100) NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[RequiredMinOrderAmount] [bit] NOT NULL,
	[TrackUrl] [nvarchar](400) NULL,
	[LastUpdateTime] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](800) NULL,
	[CanTrack] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShippingMethodID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemWorkFlowStep]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemWorkFlowStep](
	[WorkFlowStepID] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemWorkFlowStep] PRIMARY KEY CLUSTERED 
(
	[WorkFlowStepID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemWorkFlow]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemWorkFlow](
	[WorkFlowID] [int] NOT NULL,
	[Name] [nchar](10) NULL,
	[Code] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
	[IsSystemFlow] [nchar](10) NULL,
	[IsDelete] [nchar](10) NULL,
	[IsEnable] [nchar](10) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemWorkFlow] PRIMARY KEY CLUSTERED 
(
	[WorkFlowID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemVersion]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemVersion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OldVersion] [nvarchar](2000) NULL,
	[NewVersion] [nvarchar](2000) NULL,
	[OldChangeFileld] [nvarchar](2000) NULL,
	[NewChangeFileld] [nvarchar](2000) NULL,
	[Parent_DataType] [nvarchar](50) NULL,
	[Parent_DataID] [int] NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeUserID] [int] NULL,
	[ChangeUserName] [int] NULL,
	[Comment] [nvarchar](200) NULL,
 CONSTRAINT [PK_SystemVersion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemTerminology]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemTerminology](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[Text] [nvarchar](2000) NULL,
	[LanguageType] [nvarchar](10) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemTerminology] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemTemplate]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[TemplateType] [nvarchar](50) NULL,
	[Template] [ntext] NULL,
	[Params] [nvarchar](3000) NULL,
	[IsEnable] [bit] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [int] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_Table_SystemTemplate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemTask]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemTask](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[TaskContent] [nvarchar](2000) NULL,
	[AssignedUserID] [int] NULL,
	[Status] [nvarchar](10) NULL,
	[DateDue] [datetime] NULL,
	[IsDateDue] [bit] NULL,
	[DateStart] [datetime] NULL,
	[IsDateStart] [bit] NULL,
	[Priority] [nvarchar](10) NULL,
	[Parent_DataID] [int] NULL,
	[Parent_DataType] [nvarchar](50) NULL,
	[IsFinished] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemTask] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemShortMessage]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemShortMessage](
	[ShortMessage_ID] [int] IDENTITY(1,1) NOT NULL,
	[ShortMessage_Title] [nvarchar](200) NOT NULL,
	[ShortMessage_Category] [nvarchar](200) NULL,
	[ShortMessage_Content] [nvarchar](4000) NULL,
	[ShortMessage_SenderName] [nvarchar](50) NULL,
	[ShortMessage_ToName] [nvarchar](500) NULL,
	[ShortMessage_Send_Date] [datetime] NOT NULL,
	[ShortMessage_Send_UserID] [int] NULL,
	[ShortMessage_Receiver_UserID] [int] NOT NULL,
	[ShortMessage_IsRead] [bit] NOT NULL,
	[ShortMessage_Type] [nvarchar](10) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemShortMessage] PRIMARY KEY CLUSTERED 
(
	[ShortMessage_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemSetting]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemSetting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemName] [nvarchar](200) NOT NULL,
	[SystemDescription] [nvarchar](2000) NULL,
	[SystemUrl] [nvarchar](200) NULL,
	[SystemVersion] [nvarchar](200) NOT NULL,
	[SystemLisence] [nvarchar](2000) NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUserProfilePropertys]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserProfilePropertys](
	[Property_ID] [int] NOT NULL,
	[Property_Name] [nvarchar](500) NOT NULL,
	[Property_Description] [nvarchar](2000) NULL,
 CONSTRAINT [PK_SystemProfile] PRIMARY KEY CLUSTERED 
(
	[Property_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUserGroup]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserGroup](
	[Group_ID] [int] IDENTITY(1,1) NOT NULL,
	[Group_NameCn] [nvarchar](200) NOT NULL,
	[Group_NameEn] [nvarchar](200) NOT NULL,
	[Group_Description] [nvarchar](2000) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemUserGroup] PRIMARY KEY CLUSTERED 
(
	[Group_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroup', @level2type=N'COLUMN',@level2name=N'Group_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'User Group Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroup', @level2type=N'COLUMN',@level2name=N'Group_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'User Group Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroup', @level2type=N'COLUMN',@level2name=N'Group_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'User Group Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroup', @level2type=N'COLUMN',@level2name=N'Group_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'User Group' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroup'
GO
/****** Object:  Table [dbo].[SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemRole](
	[Role_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [nvarchar](50) NULL,
	[Role_Code] [nvarchar](200) NULL,
	[Role_Description] [nvarchar](2000) NULL,
	[Role_IsSystemRole] [bit] NULL,
	[Role_Type] [nvarchar](50) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRole', @level2type=N'COLUMN',@level2name=N'Role_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Role Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRole', @level2type=N'COLUMN',@level2name=N'Role_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Role Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRole', @level2type=N'COLUMN',@level2name=N'Role_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is System Role' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRole', @level2type=N'COLUMN',@level2name=N'Role_IsSystemRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Role' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRole'
GO
/****** Object:  Table [dbo].[SPPhoneArea]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPPhoneArea](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Province] [nvarchar](12) NULL,
	[City] [nvarchar](12) NULL,
	[PhonePrefix] [nvarchar](12) NULL,
	[CodeType] [nvarchar](5) NULL,
 CONSTRAINT [PK_SPPhoneArea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Log_Level] [nvarchar](30) NOT NULL,
	[Log_Type] [nvarchar](30) NULL,
	[Log_Date] [datetime] NOT NULL,
	[Log_Source] [nvarchar](30) NOT NULL,
	[Log_User] [nvarchar](30) NOT NULL,
	[Log_Descrption] [nvarchar](800) NOT NULL,
	[Log_RequestInfo] [nvarchar](300) NULL,
	[Parent_DataID] [int] NULL,
	[Parent_DataType] [nvarchar](50) NULL,
	[Log_RelateUserID] [int] NULL,
	[Log_RelateUserName] [nvarchar](30) NULL,
	[Log_RelateDateTime] [datetime] NULL,
 CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_Level' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_Level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_Source' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_User' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_Descrption' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_Descrption'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_RequestInfo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_RequestInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_RelateMoudleID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Parent_DataID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_RelateMoudleDataID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Parent_DataType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_RelateUserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_RelateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log_RelateDateTime' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog', @level2type=N'COLUMN',@level2name=N'Log_RelateDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SystemLog' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemLog'
GO
/****** Object:  Table [dbo].[SystemEmailTemplate]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemEmailTemplate](
	[EmailTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[TemplateType] [nvarchar](50) NULL,
	[TitleTemplate] [nvarchar](200) NULL,
	[BodyTemplate] [ntext] NULL,
	[Params] [nvarchar](3000) NULL,
	[IsHtmlEmail] [bit] NULL,
	[IsEnable] [bit] NULL,
	[CreateAt] [datetime] NULL,
	[CreateBy] [int] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[EmailTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemEmailSettings]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemEmailSettings](
	[EmailSettingID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Code] [nvarchar](200) NULL,
	[Descriprsion] [nvarchar](2000) NULL,
	[Host] [nvarchar](200) NULL,
	[Port] [nvarchar](200) NULL,
	[SSL] [bit] NULL,
	[FromEmail] [nvarchar](200) NULL,
	[FromName] [nvarchar](200) NULL,
	[LoginEmail] [nvarchar](200) NULL,
	[LoginPassword] [nvarchar](200) NULL,
	[IsEnable] [bit] NULL,
	[IsDefault] [bit] NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemEmailSettings] PRIMARY KEY CLUSTERED 
(
	[EmailSettingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemEmailQueue]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemEmailQueue](
	[QueueID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Body] [ntext] NULL,
	[FromAddress] [nvarchar](200) NULL,
	[FromName] [nvarchar](200) NULL,
	[ToAddresss] [ntext] NULL,
	[ToNames] [ntext] NULL,
	[CCAddresss] [ntext] NULL,
	[CCNames] [ntext] NULL,
	[BCCAddresss] [ntext] NULL,
	[BCCNames] [ntext] NULL,
	[EmailTemplateID] [int] NOT NULL,
	[Statues] [nvarchar](200) NULL,
	[SendRetry] [int] NULL,
	[MaxRetryTime] [int] NULL,
	[MailLog] [ntext] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[SendConfig] [nchar](10) NULL,
	[SendDate] [datetime] NULL,
	[OrderIndex] [int] NULL,
 CONSTRAINT [PK_SystemEmailQueue] PRIMARY KEY CLUSTERED 
(
	[QueueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemDictionaryGroup]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDictionaryGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[IsEnable] [bit] NULL,
	[IsSystem] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemDictionaryGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemMoudle]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemMoudle](
	[Moudle_ID] [int] IDENTITY(1,1) NOT NULL,
	[Moudle_NameCn] [nvarchar](200) NOT NULL,
	[Moudle_NameEn] [nvarchar](200) NOT NULL,
	[Moudle_NameDb] [nvarchar](200) NOT NULL,
	[Moudle_Description] [nvarchar](2000) NOT NULL,
	[Application_ID] [int] NULL,
	[Moudle_IsSystemMoudle] [bit] NOT NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemMoudle] PRIMARY KEY CLUSTERED 
(
	[Moudle_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Moudle_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Moudle Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Moudle_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Moudle Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Moudle_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'moudle of Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Moudle_NameDb'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Moudle Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Moudle_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Application_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is System Moudle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle', @level2type=N'COLUMN',@level2name=N'Moudle_IsSystemMoudle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Moudle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudle'
GO
/****** Object:  Table [dbo].[SystemMenu]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemMenu](
	[Menu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Menu_Name] [nvarchar](200) NOT NULL,
	[Menu_Code] [nvarchar](200) NULL,
	[Menu_Description] [nvarchar](2000) NULL,
	[Menu_Url] [nvarchar](200) NULL,
	[Menu_UrlTarget] [nvarchar](200) NULL,
	[Menu_IconUrl] [nvarchar](200) NULL,
	[Menu_IsCategory] [bit] NOT NULL,
	[ParentMenu_ID] [int] NULL,
	[Menu_Order] [int] NULL,
	[Menu_Type] [nvarchar](200) NOT NULL,
	[Menu_IsSystemMenu] [bit] NULL,
	[Menu_IsEnable] [bit] NULL,
	[ApplicationID] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemMenu] PRIMARY KEY CLUSTERED 
(
	[Menu_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Url Target Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_UrlTarget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Is Category' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_IsCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent Menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'ParentMenu_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Order' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Menu Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is System Menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_IsSystemMenu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is Enable' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'Menu_IsEnable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu', @level2type=N'COLUMN',@level2name=N'ApplicationID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Navigation Menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMenu'
GO
/****** Object:  Table [dbo].[SystemAttachmentContent]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemAttachmentContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttacmentID] [int] NULL,
	[FileContent] [image] NOT NULL,
 CONSTRAINT [PK_SystemAttachmentContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemDictionary]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDictionary](
	[SystemDictionary_ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemDictionary_GroupID] [int] NULL,
	[SystemDictionary_Key] [nvarchar](50) NULL,
	[SystemDictionary_Code] [nvarchar](50) NULL,
	[SystemDictionary_Value] [nvarchar](200) NULL,
	[SystemDictionary_Desciption] [nvarchar](2000) NULL,
	[SystemDictionary_Order] [int] NULL,
	[SystemDictionary_IsEnable] [bit] NULL,
	[SystemDictionary_IsSystem] [bit] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemDictionary] PRIMARY KEY CLUSTERED 
(
	[SystemDictionary_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderForm]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderForm](
	[OrderFormID] [int] IDENTITY(1,1) NOT NULL,
	[MasterCustomerID] [int] NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderFormID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemProvince]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemProvince](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[AbbrName] [nvarchar](50) NULL,
	[SingleAbbrName] [nchar](10) NULL,
	[Code] [nvarchar](50) NULL,
	[CountryID] [int] NULL,
 CONSTRAINT [PK_SystemProvince] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_LoginID] [nvarchar](50) NOT NULL,
	[User_Name] [nvarchar](50) NOT NULL,
	[User_Email] [nvarchar](50) NOT NULL,
	[User_Password] [nvarchar](50) NOT NULL,
	[User_Status] [nvarchar](50) NOT NULL,
	[User_Create_Date] [datetime] NOT NULL,
	[User_Type] [nvarchar](50) NOT NULL,
	[Department_ID] [int] NULL,
	[MobilePIN] [nvarchar](50) NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordQuestion] [nvarchar](255) NULL,
	[PasswordAnswer] [nvarchar](255) NULL,
	[Comments] [nvarchar](3000) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastLockedOutDate] [datetime] NOT NULL,
	[LastPasswordChangeDate] [datetime] NOT NULL,
	[FailedPwdAttemptCnt] [int] NOT NULL,
	[FailedPwdAttemptWndStart] [datetime] NOT NULL,
	[FailedPwdAnsAttemptCnt] [int] NOT NULL,
	[FailedPwdAnsAttemptWndStart] [datetime] NOT NULL,
	[IsNeedChgPwd] [bit] NOT NULL,
	[PasswordSalt] [nvarchar](128) NULL,
	[LoweredEmail] [nvarchar](128) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Login ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_LoginID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'User Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Create Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_Create_Date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'User Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'User_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Department' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'Department_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MobilePIN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'MobilePIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PasswordF ormat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'PasswordFormat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password Question' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'PasswordQuestion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password Answer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'PasswordAnswer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'Comments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is Approved' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'IsApproved'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Is Locked Out' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'IsLockedOut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Activity Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'LastActivityDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Login Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Locked Out Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'LastLockedOutDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Password Change Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'LastPasswordChangeDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Failed Password Attempt Count' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'FailedPwdAttemptCnt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Failed Password Attempt DateTime' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'FailedPwdAttemptWndStart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Failed Password Answer Attempt Count' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'FailedPwdAnsAttemptCnt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Failed Password Answer Attempt DateTime' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'FailedPwdAnsAttemptWndStart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System User' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser'
GO
/****** Object:  Table [dbo].[SystemUserGroupRoleRelation]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserGroupRoleRelation](
	[UserGroupRole_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_ID] [int] NOT NULL,
	[UserGroup_ID] [int] NOT NULL,
 CONSTRAINT [PK_SystemUserGroupRole] PRIMARY KEY CLUSTERED 
(
	[UserGroupRole_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupRoleRelation', @level2type=N'COLUMN',@level2name=N'UserGroupRole_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupRoleRelation', @level2type=N'COLUMN',@level2name=N'Role_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupRoleRelation', @level2type=N'COLUMN',@level2name=N'UserGroup_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupRoleRelation'
GO
/****** Object:  Table [dbo].[SystemRoleApplication]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemRoleApplication](
	[SystemRoleApplication_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_ID] [int] NULL,
	[Application_ID] [int] NULL,
 CONSTRAINT [PK_SystemRoleApplication] PRIMARY KEY CLUSTERED 
(
	[SystemRoleApplication_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleApplication', @level2type=N'COLUMN',@level2name=N'SystemRoleApplication_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleApplication', @level2type=N'COLUMN',@level2name=N'Role_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleApplication', @level2type=N'COLUMN',@level2name=N'Application_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleApplication'
GO
/****** Object:  Table [dbo].[SystemView]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemView](
	[SystemView_ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemView_NameCn] [nvarchar](200) NULL,
	[SystemView_NameEn] [nvarchar](200) NULL,
	[Application_ID] [int] NULL,
	[SystemView_Description] [nvarchar](2000) NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemView] PRIMARY KEY CLUSTERED 
(
	[SystemView_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemView', @level2type=N'COLUMN',@level2name=N'SystemView_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemView', @level2type=N'COLUMN',@level2name=N'SystemView_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemView', @level2type=N'COLUMN',@level2name=N'SystemView_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemView', @level2type=N'COLUMN',@level2name=N'Application_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemView', @level2type=N'COLUMN',@level2name=N'SystemView_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemView'
GO
/****** Object:  Table [dbo].[SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPChannel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[DataOkMessage] [nvarchar](200) NOT NULL,
	[DataFailedMessage] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[DataAdapterType] [nvarchar](50) NOT NULL,
	[DataAdapterUrl] [nvarchar](200) NOT NULL,
	[ChannelType] [nvarchar](20) NOT NULL,
	[IVRFeeTimeType] [nvarchar](20) NULL,
	[IVRTimeFormat] [nvarchar](20) NULL,
	[IsStateReport] [bit] NOT NULL,
	[StateReportType] [nvarchar](20) NOT NULL,
	[ReportOkMessage] [nvarchar](200) NOT NULL,
	[ReportFailedMessage] [nvarchar](200) NOT NULL,
	[StateReportParamName] [nvarchar](20) NOT NULL,
	[StateReportParamValue] [nvarchar](20) NOT NULL,
	[RequestTypeParamName] [nvarchar](20) NOT NULL,
	[RequestTypeParamStateReportValue] [nvarchar](20) NOT NULL,
	[RequestTypeParamDataReportValue] [nvarchar](20) NOT NULL,
	[HasFilters] [bit] NOT NULL,
	[IsMonitorRequest] [bit] NOT NULL,
	[IsLogRequest] [bit] NOT NULL,
	[IsParamsConvert] [bit] NOT NULL,
	[IsAutoLinkID] [bit] NOT NULL,
	[AutoLinkIDFields] [nvarchar](300) NOT NULL,
	[LogRequestType] [nvarchar](20) NULL,
	[Price] [decimal](18, 0) NULL,
	[DefaultRate] [decimal](18, 0) NULL,
	[ChannelDetailInfo] [ntext] NULL,
	[UpperID] [int] NULL,
	[ChannelStatus] [nvarchar](20) NULL,
	[IsDisable] [bit] NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPCHANNEL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[MasterCustomerID] [int] NULL,
	[ItemID] [nvarchar](30) NULL,
	[ProductName] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[ProductImage] [nvarchar](200) NULL,
	[ProductThumb] [nvarchar](200) NULL,
	[Keyword] [nvarchar](1000) NULL,
	[Visible] [bit] NULL,
	[Discontinued] [bit] NULL,
	[Inventory] [int] NOT NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[Comments] [nvarchar](200) NULL,
	[OutOfInventoryNote] [nvarchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nvarchar](20) NULL,
	[TrackNo] [nvarchar](100) NULL,
	[MasterCustomerID] [int] NULL,
	[SubCustomerID] [int] NULL,
	[OrderTime] [datetime] NOT NULL,
	[Company] [nvarchar](200) NULL,
	[ShippingMethodID] [int] NULL,
	[ShipFirstName] [nvarchar](30) NOT NULL,
	[ShipLastName] [nvarchar](50) NULL,
	[ShipAddress1] [nvarchar](60) NULL,
	[ShipAddress2] [nvarchar](60) NULL,
	[ShipAddress3] [nvarchar](60) NULL,
	[ShipCity] [nvarchar](50) NULL,
	[ShipCountry] [nvarchar](50) NULL,
	[ShipState] [nvarchar](50) NULL,
	[ShipZip] [nvarchar](15) NULL,
	[ContactPhone] [nvarchar](200) NULL,
	[ContactEmail] [nvarchar](255) NULL,
	[ContactName] [nvarchar](200) NULL,
	[ShipInstructions] [nvarchar](800) NULL,
	[Status] [nvarchar](100) NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[ShipTime] [datetime] NULL,
	[RequestShipDate] [datetime] NULL,
	[ProcessedTime] [datetime] NULL,
	[CancelledTime] [datetime] NULL,
	[Comment] [nvarchar](400) NULL,
	[RushRequired] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCustomer]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCustomer](
	[SubCustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[MasterCustomerID] [int] NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[DayPhone] [nvarchar](50) NULL,
	[DayPhoneExt] [nvarchar](6) NULL,
	[FaxNumber] [nvarchar](50) NULL,
	[FaxNumberExt] [nvarchar](6) NULL,
	[Company] [nvarchar](200) NULL,
	[CompanyWeb] [nvarchar](255) NULL,
	[ShipFirstName] [nvarchar](30) NULL,
	[ShipLastName] [nvarchar](30) NULL,
	[ShipAddress1] [nvarchar](60) NULL,
	[ShipAddress2] [nvarchar](60) NULL,
	[ShipAddress3] [nvarchar](60) NULL,
	[ShipCity] [nvarchar](50) NOT NULL,
	[ShipState] [int] NOT NULL,
	[ShipZip] [nvarchar](15) NOT NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[Comment] [nvarchar](800) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubCustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NULL,
	[StateName] [nvarchar](200) NOT NULL,
	[Abbreviation] [nvarchar](6) NULL,
	[CanShipping] [bit] NOT NULL,
	[DefaultShippingMethodID] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[Comment] [nvarchar](800) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[SystemConfig_ID] [int] IDENTITY(1,1) NOT NULL,
	[Config_Key] [nvarchar](200) NULL,
	[Config_Value] [nvarchar](200) NULL,
	[Config_DataType] [nvarchar](10) NULL,
	[Config_Description] [nvarchar](2000) NULL,
	[SortIndex] [int] NULL,
	[Config_GroupID] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SYSTEMCONFIG] PRIMARY KEY CLUSTERED 
(
	[SystemConfig_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SystemConfig' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemConfig'
GO
/****** Object:  Table [dbo].[SystemCity]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemCity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[AbbrName] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[ProvinceID] [int] NULL,
	[Capital] [bit] NULL,
 CONSTRAINT [PK_SystemCity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPChannelSycnParams]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPChannelSycnParams](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[ChannelID] [int] NOT NULL,
	[MappingParams] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ParamsValue] [nvarchar](200) NULL,
	[ParamsType] [nvarchar](20) NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPChannelSycnParams] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPChannelParamsConvert]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPChannelParamsConvert](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ParamsValue] [nvarchar](200) NOT NULL,
	[ParamsConvertTo] [nvarchar](500) NOT NULL,
	[ParamsConvertType] [nvarchar](50) NOT NULL,
	[ParamsConvertCondition] [nvarchar](500) NOT NULL,
	[ChannelID] [int] NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPChannelParamsConvert] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPChannelParams]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPChannelParams](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[ParamsType] [nvarchar](20) NULL,
	[ChannelID] [int] NOT NULL,
	[ParamsMappingName] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ShowInClientGrid] [bit] NOT NULL,
	[ParamsValue] [nvarchar](200) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPChannelParams] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPChannelFilters]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPChannelFilters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChannelID] [int] NOT NULL,
	[ParamsName] [nvarchar](50) NOT NULL,
	[FilterType] [nvarchar](50) NOT NULL,
	[FilterValue] [nvarchar](50) NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPChannelFilters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NOT NULL,
	[ItemID] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](400) NULL,
	[Comment] [nvarchar](400) NULL,
	[Quantity] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderFormItem]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderFormItem](
	[OrderFormItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderFormID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Comment] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderFormItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPCode]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPCode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](200) NOT NULL,
	[CodeType] [nvarchar](50) NULL,
	[ChannelID] [int] NOT NULL,
	[MO] [nvarchar](50) NOT NULL,
	[MOType] [nvarchar](50) NOT NULL,
	[MOLength] [int] NULL,
	[OrderIndex] [int] NOT NULL,
	[SPCode] [nvarchar](50) NOT NULL,
	[SPCodeType] [nvarchar](50) NULL,
	[SPCodeLength] [int] NULL,
	[HasFilters] [bit] NOT NULL,
	[HasParamsConvert] [bit] NOT NULL,
	[Province] [nvarchar](50) NULL,
	[DisableCity] [nvarchar](50) NULL,
	[IsDiable] [bit] NOT NULL,
	[DayLimit] [nvarchar](20) NULL,
	[MonthLimit] [nvarchar](20) NULL,
	[Price] [decimal](18, 2) NULL,
	[SendText] [nvarchar](2000) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPCODE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemViewItem]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemViewItem](
	[SystemViewItem_ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemViewItem_NameEn] [nvarchar](200) NULL,
	[SystemViewItem_NameCn] [nvarchar](200) NULL,
	[SystemViewItem_Description] [nvarchar](2000) NULL,
	[SystemViewItem_DisplayFormat] [nvarchar](2000) NULL,
	[SystemView_ID] [int] NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemViewItem] PRIMARY KEY CLUSTERED 
(
	[SystemViewItem_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem', @level2type=N'COLUMN',@level2name=N'SystemViewItem_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem', @level2type=N'COLUMN',@level2name=N'SystemViewItem_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem', @level2type=N'COLUMN',@level2name=N'SystemViewItem_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem', @level2type=N'COLUMN',@level2name=N'SystemViewItem_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem', @level2type=N'COLUMN',@level2name=N'SystemViewItem_DisplayFormat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem', @level2type=N'COLUMN',@level2name=N'SystemView_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemViewItem'
GO
/****** Object:  Table [dbo].[SystemUserRoleRelation]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserRoleRelation](
	[UserRole_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
 CONSTRAINT [PK_SystemUserRoleRelation] PRIMARY KEY CLUSTERED 
(
	[UserRole_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserRoleRelation', @level2type=N'COLUMN',@level2name=N'UserRole_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserRoleRelation', @level2type=N'COLUMN',@level2name=N'User_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserRoleRelation', @level2type=N'COLUMN',@level2name=N'Role_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserRoleRelation'
GO
/****** Object:  Table [dbo].[SystemUserProfile]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserProfile](
	[Profile_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Property_ID] [int] NOT NULL,
	[PropertyValuesString] [ntext] NULL,
	[PropertyValuesBinary] [image] NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemUserProfile] PRIMARY KEY CLUSTERED 
(
	[Profile_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserProfile', @level2type=N'COLUMN',@level2name=N'Profile_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserProfile', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserProfile', @level2type=N'COLUMN',@level2name=N'Property_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserProfile', @level2type=N'COLUMN',@level2name=N'PropertyValuesString'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserProfile', @level2type=N'COLUMN',@level2name=N'PropertyValuesBinary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserProfile', @level2type=N'COLUMN',@level2name=N'LastUpdatedDate'
GO
/****** Object:  Table [dbo].[SystemUserGroupUserRelation]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUserGroupUserRelation](
	[UserGroupUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[UserGroupID] [int] NULL,
 CONSTRAINT [PK_UserGroupUserRelation] PRIMARY KEY CLUSTERED 
(
	[UserGroupUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupUserRelation', @level2type=N'COLUMN',@level2name=N'UserGroupUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupUserRelation', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupUserRelation', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUserGroupUserRelation'
GO
/****** Object:  Table [dbo].[SystemRoleMenuRelation]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemRoleMenuRelation](
	[MenuRole_ID] [int] IDENTITY(1,1) NOT NULL,
	[Menu_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
 CONSTRAINT [PK_SystemRoleMenuRelation] PRIMARY KEY CLUSTERED 
(
	[MenuRole_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleMenuRelation', @level2type=N'COLUMN',@level2name=N'MenuRole_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleMenuRelation', @level2type=N'COLUMN',@level2name=N'Menu_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleMenuRelation', @level2type=N'COLUMN',@level2name=N'Role_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemRoleMenuRelation'
GO
/****** Object:  Table [dbo].[SystemResources]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemResources](
	[Resources_ID] [int] IDENTITY(1,1) NOT NULL,
	[Resources_NameCn] [nvarchar](200) NOT NULL,
	[Resources_NameEn] [nvarchar](200) NOT NULL,
	[Resources_Description] [nvarchar](2000) NULL,
	[Resources_Type] [nvarchar](200) NULL,
	[Resources_LimitExpression] [nvarchar](2000) NULL,
	[Resources_IsRelateUser] [bit] NOT NULL,
	[MoudleID] [int] NULL,
	[ParentResources_ID] [int] NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemResources] PRIMARY KEY CLUSTERED 
(
	[Resources_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_LimitExpression'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'Resources_IsRelateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources', @level2type=N'COLUMN',@level2name=N'MoudleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemResources'
GO
/****** Object:  Table [dbo].[SystemPersonalizationSettings]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemPersonalizationSettings](
	[PersonalizationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NULL,
	[UserId] [int] NULL,
	[Path] [nvarchar](500) NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemPersonalizationSettings] PRIMARY KEY CLUSTERED 
(
	[PersonalizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPMonitoringRequest]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPMonitoringRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RecievedContent] [ntext] NULL,
	[RecievedDate] [datetime] NULL,
	[RecievedIP] [nvarchar](50) NULL,
	[RecievedSendUrl] [nvarchar](500) NULL,
	[ChannelID] [int] NULL,
 CONSTRAINT [PK_SPMonitoringRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemMoudleField]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemMoudleField](
	[SystemMoudleField_ID] [int] IDENTITY(1,1) NOT NULL,
	[SystemMoudleField_NameEn] [nvarchar](200) NULL,
	[SystemMoudleField_NameCn] [nvarchar](200) NULL,
	[SystemMoudleField_NameDb] [nvarchar](200) NULL,
	[SystemMoudleField_Type] [nvarchar](200) NULL,
	[SystemMoudleField_IsRequired] [bit] NULL,
	[SystemMoudleField_DefaultValue] [nvarchar](200) NULL,
	[SystemMoudleField_IsKeyField] [bit] NULL,
	[SystemMoudleField_Size] [int] NULL,
	[SystemMoudleField_Description] [nvarchar](2000) NULL,
	[SystemMoudle_ID] [int] NULL,
	[OrderIndex] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemMoudleField] PRIMARY KEY CLUSTERED 
(
	[SystemMoudleField_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_NameDb'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_IsRequired'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_DefaultValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_IsKeyField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_Size'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudleField_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField', @level2type=N'COLUMN',@level2name=N'SystemMoudle_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SystemMoudleField' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemMoudleField'
GO
/****** Object:  Table [dbo].[SPRecord]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPRecord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LinkID] [nvarchar](50) NOT NULL,
	[MO] [nvarchar](50) NULL,
	[Mobile] [nvarchar](15) NOT NULL,
	[SpNumber] [nvarchar](20) NULL,
	[Province] [nvarchar](6) NOT NULL,
	[City] [nvarchar](8) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsReport] [bit] NOT NULL,
	[IsIntercept] [bit] NOT NULL,
	[IsSycnToClient] [bit] NOT NULL,
	[IsSycnSuccessed] [bit] NOT NULL,
	[IsStatOK] [bit] NOT NULL,
	[SycnRetryTimes] [int] NOT NULL,
	[ChannelID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[CodeID] [int] NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_SPRECORD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemOperation]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemOperation](
	[Operation_ID] [int] IDENTITY(1,1) NOT NULL,
	[Operation_NameCn] [nvarchar](200) NULL,
	[Operation_NameEn] [nvarchar](200) NULL,
	[Operation_Description] [nvarchar](2000) NOT NULL,
	[IsSystemOperation] [bit] NOT NULL,
	[IsCanSingleOperation] [bit] NOT NULL,
	[IsCanMutilOperation] [bit] NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[IsInListPage] [bit] NOT NULL,
	[IsInSinglePage] [bit] NOT NULL,
	[Operation_Order] [int] NOT NULL,
	[IsCommonOperation] [bit] NULL,
	[ResourceID] [int] NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[Operation_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'Operation_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'Operation_NameCn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'Operation_NameEn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'Operation_Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'IsSystemOperation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'IsCanSingleOperation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'IsCanMutilOperation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'IsEnable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'IsInListPage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'IsInSinglePage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation', @level2type=N'COLUMN',@level2name=N'Operation_Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemOperation'
GO
/****** Object:  Table [dbo].[SPClientCodeSycnParams]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPClientCodeSycnParams](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[CodeID] [int] NOT NULL,
	[MappingParams] [nvarchar](200) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ParamsValue] [nvarchar](200) NOT NULL,
	[ParamsType] [nvarchar](20) NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPClientCodeSycnParams] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPClientCodeRelation]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPClientCodeRelation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[InterceptRate] [decimal](18, 2) NOT NULL,
	[UseClientDefaultSycnSetting] [bit] NOT NULL,
	[SyncData] [bit] NOT NULL,
	[SycnRetryTimes] [nchar](10) NOT NULL,
	[SyncType] [nvarchar](50) NOT NULL,
	[SycnDataUrl] [nvarchar](200) NOT NULL,
	[SycnOkMessage] [nvarchar](50) NOT NULL,
	[SycnFailedMessage] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsEnable] [bit] NOT NULL,
	[SycnNotInterceptCount] [int] NOT NULL,
	[DefaultShowRecordDays] [int] NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPClientCodeRelation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPDayReport]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPDayReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportDate] [datetime] NOT NULL,
	[TotalCount] [int] NOT NULL,
	[InterceptCount] [int] NOT NULL,
	[DownTotalCount] [int] NOT NULL,
	[DownSuccess] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[ChannelID] [int] NOT NULL,
	[CodeID] [int] NOT NULL,
	[UperID] [int] NOT NULL,
 CONSTRAINT [PK_SPDayReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPCodeParamsConvert]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPCodeParamsConvert](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ParamsValue] [nvarchar](200) NOT NULL,
	[ParamsConvertTo] [nvarchar](500) NOT NULL,
	[ParamsConvertType] [nvarchar](50) NOT NULL,
	[ParamsConvertCondition] [nvarchar](200) NOT NULL,
	[CodeID] [int] NOT NULL,
	[DirectionType] [nvarchar](50) NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPCodeParamsConvert] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPCodeFilter]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPCodeFilter](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeID] [int] NOT NULL,
	[ParamsName] [nvarchar](50) NOT NULL,
	[FilterType] [nvarchar](50) NOT NULL,
	[FilterValue] [nvarchar](50) NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SPCodeFilter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPRecordExtendInfo]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPRecordExtendInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RecordID] [int] NOT NULL,
	[IP] [nvarchar](20) NULL,
	[sSycnDataUrl] [nvarchar](300) NULL,
	[RequestContent] [ntext] NULL,
	[ExtendField1] [nvarchar](50) NULL,
	[ExtendField2] [nvarchar](50) NULL,
	[ExtendField3] [nvarchar](50) NULL,
	[ExtendField4] [nvarchar](50) NULL,
	[ExtendField5] [nvarchar](50) NULL,
	[ExtendField6] [nvarchar](50) NULL,
	[ExtendField8] [nvarchar](50) NULL,
	[ExtendField7] [nvarchar](50) NULL,
	[ExtendField9] [nvarchar](50) NULL,
	[ExtendField10] [nvarchar](50) NULL,
	[State] [nvarchar](20) NULL,
	[FeeTime] [nvarchar](3) NULL,
	[StartTime] [nvarchar](20) NULL,
	[EndTime] [nvarchar](20) NULL,
 CONSTRAINT [PK_SPRECORDEXTENDINFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemPrivilege]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemPrivilege](
	[Privilege_ID] [int] IDENTITY(1,1) NOT NULL,
	[Operation_ID] [int] NULL,
	[Resources_ID] [int] NULL,
	[PrivilegeCnName] [nvarchar](200) NOT NULL,
	[PrivilegeEnName] [nvarchar](200) NOT NULL,
	[DefaultValue] [nvarchar](2000) NULL,
	[Description] [nvarchar](2000) NULL,
	[PrivilegeOrder] [int] NOT NULL,
	[PrivilegeType] [nvarchar](200) NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemPrivilege] PRIMARY KEY CLUSTERED 
(
	[Privilege_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'Privilege_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Operation ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'Operation_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Resources ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'Resources_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'PrivilegeCnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'PrivilegeEnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Default Value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'DefaultValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Order' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege', @level2type=N'COLUMN',@level2name=N'PrivilegeOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Permission' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilege'
GO
/****** Object:  Table [dbo].[SystemPrivilegeParameter]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemPrivilegeParameter](
	[PrivilegeParameterID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[PrivilegeID] [int] NOT NULL,
	[BizParameter] [nvarchar](2000) NOT NULL,
	[CreateBy] [int] NULL,
	[CreateAt] [datetime] NULL,
	[LastModifyBy] [int] NULL,
	[LastModifyAt] [datetime] NULL,
	[LastModifyComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_SystemPrivilegeParameter] PRIMARY KEY CLUSTERED 
(
	[PrivilegeParameterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeParameter', @level2type=N'COLUMN',@level2name=N'PrivilegeParameterID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeParameter', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeParameter', @level2type=N'COLUMN',@level2name=N'PrivilegeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeParameter', @level2type=N'COLUMN',@level2name=N'BizParameter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeParameter'
GO
/****** Object:  Table [dbo].[SystemPrivilegeInRoles]    Script Date: 10/19/2011 07:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemPrivilegeInRoles](
	[PrivilegeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role_ID] [int] NOT NULL,
	[Privilege_ID] [int] NOT NULL,
	[PrivilegeRoleValueType] [nvarchar](200) NULL,
	[EnableType] [nvarchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[ExpiryTime] [datetime] NOT NULL,
	[EnableParameter] [bit] NOT NULL,
	[PrivilegeRoleValue] [image] NULL,
 CONSTRAINT [PK_SystemPrivilegeInRoles] PRIMARY KEY CLUSTERED 
(
	[PrivilegeRoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'PrivilegeRoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'Role_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'Privilege_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'EnableType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'ExpiryTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'EnableParameter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles', @level2type=N'COLUMN',@level2name=N'PrivilegeRoleValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemPrivilegeInRoles'
GO
/****** Object:  Default [DF_SPChannelParams_ShowInClientGrid_1]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPChannelParams] ADD  CONSTRAINT [DF_SPChannelParams_ShowInClientGrid_1]  DEFAULT ((1)) FOR [ShowInClientGrid]
GO
/****** Object:  Default [DF_SPCode_HasFilters]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPCode] ADD  CONSTRAINT [DF_SPCode_HasFilters]  DEFAULT ((0)) FOR [HasFilters]
GO
/****** Object:  Default [DF_SPCode_HasParamsConvert]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPCode] ADD  CONSTRAINT [DF_SPCode_HasParamsConvert]  DEFAULT ((0)) FOR [HasParamsConvert]
GO
/****** Object:  Default [DF_SPCode_IsDiable]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPCode] ADD  CONSTRAINT [DF_SPCode_IsDiable]  DEFAULT ((0)) FOR [IsDiable]
GO
/****** Object:  Default [DF_SystemApplication_SystemApplication_IsSystemApplication]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemApplication] ADD  CONSTRAINT [DF_SystemApplication_SystemApplication_IsSystemApplication]  DEFAULT ((0)) FOR [SystemApplication_IsSystemApplication]
GO
/****** Object:  Default [DF_SystemOperation_Operation_Order]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemOperation] ADD  CONSTRAINT [DF_SystemOperation_Operation_Order]  DEFAULT ((9999)) FOR [Operation_Order]
GO
/****** Object:  Default [DF_SystemUser_PasswordFormat]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUser] ADD  CONSTRAINT [DF_SystemUser_PasswordFormat]  DEFAULT ((0)) FOR [PasswordFormat]
GO
/****** Object:  Default [DF_SystemUser_IsNeedChgPwd]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUser] ADD  CONSTRAINT [DF_SystemUser_IsNeedChgPwd]  DEFAULT ((0)) FOR [IsNeedChgPwd]
GO
/****** Object:  ForeignKey [FK46056EE579E47696]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[OrderForm]  WITH CHECK ADD  CONSTRAINT [FK46056EE579E47696] FOREIGN KEY([MasterCustomerID])
REFERENCES [dbo].[MasterCustomer] ([MasterCustomerID])
GO
ALTER TABLE [dbo].[OrderForm] CHECK CONSTRAINT [FK46056EE579E47696]
GO
/****** Object:  ForeignKey [FKA0F3D6F89FD1CF7F]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[OrderFormItem]  WITH CHECK ADD  CONSTRAINT [FKA0F3D6F89FD1CF7F] FOREIGN KEY([OrderFormID])
REFERENCES [dbo].[OrderForm] ([OrderFormID])
GO
ALTER TABLE [dbo].[OrderFormItem] CHECK CONSTRAINT [FKA0F3D6F89FD1CF7F]
GO
/****** Object:  ForeignKey [FKA0F3D6F8C24E712C]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[OrderFormItem]  WITH CHECK ADD  CONSTRAINT [FKA0F3D6F8C24E712C] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderFormItem] CHECK CONSTRAINT [FKA0F3D6F8C24E712C]
GO
/****** Object:  ForeignKey [FK3EF88858A8AC1729]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK3EF88858A8AC1729] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK3EF88858A8AC1729]
GO
/****** Object:  ForeignKey [FK318A099B675C8FB]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK318A099B675C8FB] FOREIGN KEY([ShippingMethodID])
REFERENCES [dbo].[ShippingMethod] ([ShippingMethodID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK318A099B675C8FB]
GO
/****** Object:  ForeignKey [FK318A099B79E47696]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK318A099B79E47696] FOREIGN KEY([MasterCustomerID])
REFERENCES [dbo].[MasterCustomer] ([MasterCustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK318A099B79E47696]
GO
/****** Object:  ForeignKey [FK1F94D86A79E47696]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK1F94D86A79E47696] FOREIGN KEY([MasterCustomerID])
REFERENCES [dbo].[MasterCustomer] ([MasterCustomerID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK1F94D86A79E47696]
GO
/****** Object:  ForeignKey [FK_SPCHANNE_REFERENCE_SPUPPER]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPChannel]  WITH CHECK ADD  CONSTRAINT [FK_SPCHANNE_REFERENCE_SPUPPER] FOREIGN KEY([UpperID])
REFERENCES [dbo].[SPUpper] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SPChannel] CHECK CONSTRAINT [FK_SPCHANNE_REFERENCE_SPUPPER]
GO
/****** Object:  ForeignKey [FK_SPChannelFilters_SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPChannelFilters]  WITH CHECK ADD  CONSTRAINT [FK_SPChannelFilters_SPChannel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPChannelFilters] CHECK CONSTRAINT [FK_SPChannelFilters_SPChannel]
GO
/****** Object:  ForeignKey [FK_SPChannelParams_SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPChannelParams]  WITH CHECK ADD  CONSTRAINT [FK_SPChannelParams_SPChannel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPChannelParams] CHECK CONSTRAINT [FK_SPChannelParams_SPChannel]
GO
/****** Object:  ForeignKey [FK_SPChannelParamsConvert_SPChannel1]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPChannelParamsConvert]  WITH CHECK ADD  CONSTRAINT [FK_SPChannelParamsConvert_SPChannel1] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPChannelParamsConvert] CHECK CONSTRAINT [FK_SPChannelParamsConvert_SPChannel1]
GO
/****** Object:  ForeignKey [FK_SPChannelSycnParams_SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPChannelSycnParams]  WITH CHECK ADD  CONSTRAINT [FK_SPChannelSycnParams_SPChannel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPChannelSycnParams] CHECK CONSTRAINT [FK_SPChannelSycnParams_SPChannel]
GO
/****** Object:  ForeignKey [FK_SPClientCodeRelation_SPCode]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPClientCodeRelation]  WITH CHECK ADD  CONSTRAINT [FK_SPClientCodeRelation_SPCode] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPClientCodeRelation] CHECK CONSTRAINT [FK_SPClientCodeRelation_SPCode]
GO
/****** Object:  ForeignKey [FK_SPClientCodeRelation_SPSClient]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPClientCodeRelation]  WITH CHECK ADD  CONSTRAINT [FK_SPClientCodeRelation_SPSClient] FOREIGN KEY([ClientID])
REFERENCES [dbo].[SPSClient] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPClientCodeRelation] CHECK CONSTRAINT [FK_SPClientCodeRelation_SPSClient]
GO
/****** Object:  ForeignKey [FK_SPClientCodeSycnParams_SPCode]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPClientCodeSycnParams]  WITH CHECK ADD  CONSTRAINT [FK_SPClientCodeSycnParams_SPCode] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPClientCodeSycnParams] CHECK CONSTRAINT [FK_SPClientCodeSycnParams_SPCode]
GO
/****** Object:  ForeignKey [FK_SPCode_SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPCode]  WITH CHECK ADD  CONSTRAINT [FK_SPCode_SPChannel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPCode] CHECK CONSTRAINT [FK_SPCode_SPChannel]
GO
/****** Object:  ForeignKey [FK_SPCodeFilter_SPCode]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPCodeFilter]  WITH CHECK ADD  CONSTRAINT [FK_SPCodeFilter_SPCode] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPCodeFilter] CHECK CONSTRAINT [FK_SPCodeFilter_SPCode]
GO
/****** Object:  ForeignKey [FK_SPCodeParamsConvert_SPCode]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPCodeParamsConvert]  WITH CHECK ADD  CONSTRAINT [FK_SPCodeParamsConvert_SPCode] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPCodeParamsConvert] CHECK CONSTRAINT [FK_SPCodeParamsConvert_SPCode]
GO
/****** Object:  ForeignKey [FK_SPDayReport_SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPDayReport]  WITH CHECK ADD  CONSTRAINT [FK_SPDayReport_SPChannel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
GO
ALTER TABLE [dbo].[SPDayReport] CHECK CONSTRAINT [FK_SPDayReport_SPChannel]
GO
/****** Object:  ForeignKey [FK_SPDayReport_SPCode]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPDayReport]  WITH CHECK ADD  CONSTRAINT [FK_SPDayReport_SPCode] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
GO
ALTER TABLE [dbo].[SPDayReport] CHECK CONSTRAINT [FK_SPDayReport_SPCode]
GO
/****** Object:  ForeignKey [FK_SPDayReport_SPDayReport]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPDayReport]  WITH CHECK ADD  CONSTRAINT [FK_SPDayReport_SPDayReport] FOREIGN KEY([ID])
REFERENCES [dbo].[SPDayReport] ([ID])
GO
ALTER TABLE [dbo].[SPDayReport] CHECK CONSTRAINT [FK_SPDayReport_SPDayReport]
GO
/****** Object:  ForeignKey [FK_SPDayReport_SPSClient]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPDayReport]  WITH CHECK ADD  CONSTRAINT [FK_SPDayReport_SPSClient] FOREIGN KEY([ClientID])
REFERENCES [dbo].[SPSClient] ([ID])
GO
ALTER TABLE [dbo].[SPDayReport] CHECK CONSTRAINT [FK_SPDayReport_SPSClient]
GO
/****** Object:  ForeignKey [FK_SPDayReport_SPUpper]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPDayReport]  WITH CHECK ADD  CONSTRAINT [FK_SPDayReport_SPUpper] FOREIGN KEY([UperID])
REFERENCES [dbo].[SPUpper] ([ID])
GO
ALTER TABLE [dbo].[SPDayReport] CHECK CONSTRAINT [FK_SPDayReport_SPUpper]
GO
/****** Object:  ForeignKey [FK_SPMonitoringRequest_SPChannel]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPMonitoringRequest]  WITH CHECK ADD  CONSTRAINT [FK_SPMonitoringRequest_SPChannel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
GO
ALTER TABLE [dbo].[SPMonitoringRequest] CHECK CONSTRAINT [FK_SPMonitoringRequest_SPChannel]
GO
/****** Object:  ForeignKey [FK_SPRECORD_REFERENCE_SPCHANNE]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPRecord]  WITH CHECK ADD  CONSTRAINT [FK_SPRECORD_REFERENCE_SPCHANNE] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[SPChannel] ([ID])
GO
ALTER TABLE [dbo].[SPRecord] CHECK CONSTRAINT [FK_SPRECORD_REFERENCE_SPCHANNE]
GO
/****** Object:  ForeignKey [FK_SPRECORD_REFERENCE_SPCODE]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPRecord]  WITH CHECK ADD  CONSTRAINT [FK_SPRECORD_REFERENCE_SPCODE] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
GO
ALTER TABLE [dbo].[SPRecord] CHECK CONSTRAINT [FK_SPRECORD_REFERENCE_SPCODE]
GO
/****** Object:  ForeignKey [FK_SPRecord_SPCode]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPRecord]  WITH CHECK ADD  CONSTRAINT [FK_SPRecord_SPCode] FOREIGN KEY([CodeID])
REFERENCES [dbo].[SPCode] ([ID])
GO
ALTER TABLE [dbo].[SPRecord] CHECK CONSTRAINT [FK_SPRecord_SPCode]
GO
/****** Object:  ForeignKey [FK_SPRecord_SPSClient]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPRecord]  WITH CHECK ADD  CONSTRAINT [FK_SPRecord_SPSClient] FOREIGN KEY([ClientID])
REFERENCES [dbo].[SPSClient] ([ID])
GO
ALTER TABLE [dbo].[SPRecord] CHECK CONSTRAINT [FK_SPRecord_SPSClient]
GO
/****** Object:  ForeignKey [FK_SPRECORD_SPSRECORD_SPRECORD]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SPRecordExtendInfo]  WITH CHECK ADD  CONSTRAINT [FK_SPRECORD_SPSRECORD_SPRECORD] FOREIGN KEY([RecordID])
REFERENCES [dbo].[SPRecord] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SPRecordExtendInfo] CHECK CONSTRAINT [FK_SPRECORD_SPSRECORD_SPRECORD]
GO
/****** Object:  ForeignKey [FK8A93AD2D9793491A]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK8A93AD2D9793491A] FOREIGN KEY([DefaultShippingMethodID])
REFERENCES [dbo].[ShippingMethod] ([ShippingMethodID])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK8A93AD2D9793491A]
GO
/****** Object:  ForeignKey [FK8A93AD2DE78A7356]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK8A93AD2DE78A7356] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK8A93AD2DE78A7356]
GO
/****** Object:  ForeignKey [FK2B6CED2B79E47696]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SubCustomer]  WITH CHECK ADD  CONSTRAINT [FK2B6CED2B79E47696] FOREIGN KEY([MasterCustomerID])
REFERENCES [dbo].[MasterCustomer] ([MasterCustomerID])
GO
ALTER TABLE [dbo].[SubCustomer] CHECK CONSTRAINT [FK2B6CED2B79E47696]
GO
/****** Object:  ForeignKey [FK_SystemAttachmentContent_SystemAttachment]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemAttachmentContent]  WITH CHECK ADD  CONSTRAINT [FK_SystemAttachmentContent_SystemAttachment] FOREIGN KEY([AttacmentID])
REFERENCES [dbo].[SystemAttachment] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemAttachmentContent] CHECK CONSTRAINT [FK_SystemAttachmentContent_SystemAttachment]
GO
/****** Object:  ForeignKey [FK_SystemCity_SystemProvince]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemCity]  WITH CHECK ADD  CONSTRAINT [FK_SystemCity_SystemProvince] FOREIGN KEY([ProvinceID])
REFERENCES [dbo].[SystemProvince] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemCity] CHECK CONSTRAINT [FK_SystemCity_SystemProvince]
GO
/****** Object:  ForeignKey [FK_SystemConfig_SystemConfigGroup]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemConfig]  WITH CHECK ADD  CONSTRAINT [FK_SystemConfig_SystemConfigGroup] FOREIGN KEY([Config_GroupID])
REFERENCES [dbo].[SystemConfigGroup] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemConfig] CHECK CONSTRAINT [FK_SystemConfig_SystemConfigGroup]
GO
/****** Object:  ForeignKey [FK_SystemDepartment_SystemDepartment]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemDepartment]  WITH CHECK ADD  CONSTRAINT [FK_SystemDepartment_SystemDepartment] FOREIGN KEY([Parent_Department_ID])
REFERENCES [dbo].[SystemDepartment] ([Department_ID])
GO
ALTER TABLE [dbo].[SystemDepartment] CHECK CONSTRAINT [FK_SystemDepartment_SystemDepartment]
GO
/****** Object:  ForeignKey [FK_SystemDictionary_SystemDictionaryGroup]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemDictionary]  WITH CHECK ADD  CONSTRAINT [FK_SystemDictionary_SystemDictionaryGroup] FOREIGN KEY([SystemDictionary_GroupID])
REFERENCES [dbo].[SystemDictionaryGroup] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemDictionary] CHECK CONSTRAINT [FK_SystemDictionary_SystemDictionaryGroup]
GO
/****** Object:  ForeignKey [FK_SystemMenu_SystemApplication]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemMenu]  WITH CHECK ADD  CONSTRAINT [FK_SystemMenu_SystemApplication] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
GO
ALTER TABLE [dbo].[SystemMenu] CHECK CONSTRAINT [FK_SystemMenu_SystemApplication]
GO
/****** Object:  ForeignKey [FK_SystemMenu_SystemMenu]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemMenu]  WITH CHECK ADD  CONSTRAINT [FK_SystemMenu_SystemMenu] FOREIGN KEY([ParentMenu_ID])
REFERENCES [dbo].[SystemMenu] ([Menu_ID])
GO
ALTER TABLE [dbo].[SystemMenu] CHECK CONSTRAINT [FK_SystemMenu_SystemMenu]
GO
/****** Object:  ForeignKey [FK_SystemMoudle_SystemApplication]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemMoudle]  WITH CHECK ADD  CONSTRAINT [FK_SystemMoudle_SystemApplication] FOREIGN KEY([Application_ID])
REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
GO
ALTER TABLE [dbo].[SystemMoudle] CHECK CONSTRAINT [FK_SystemMoudle_SystemApplication]
GO
/****** Object:  ForeignKey [FK_SystemMoudleField_SystemMoudle]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemMoudleField]  WITH CHECK ADD  CONSTRAINT [FK_SystemMoudleField_SystemMoudle] FOREIGN KEY([SystemMoudle_ID])
REFERENCES [dbo].[SystemMoudle] ([Moudle_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemMoudleField] CHECK CONSTRAINT [FK_SystemMoudleField_SystemMoudle]
GO
/****** Object:  ForeignKey [FK_SystemOperation_SystemResources]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemOperation]  WITH CHECK ADD  CONSTRAINT [FK_SystemOperation_SystemResources] FOREIGN KEY([ResourceID])
REFERENCES [dbo].[SystemResources] ([Resources_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemOperation] CHECK CONSTRAINT [FK_SystemOperation_SystemResources]
GO
/****** Object:  ForeignKey [FK_SystemPersonalizationSettings_SystemApplication]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPersonalizationSettings]  WITH CHECK ADD  CONSTRAINT [FK_SystemPersonalizationSettings_SystemApplication] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemPersonalizationSettings] CHECK CONSTRAINT [FK_SystemPersonalizationSettings_SystemApplication]
GO
/****** Object:  ForeignKey [FK_SystemPersonalizationSettings_SystemUser]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPersonalizationSettings]  WITH CHECK ADD  CONSTRAINT [FK_SystemPersonalizationSettings_SystemUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[SystemUser] ([User_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemPersonalizationSettings] CHECK CONSTRAINT [FK_SystemPersonalizationSettings_SystemUser]
GO
/****** Object:  ForeignKey [FK_SystemPrivilege_SystemOperation]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_SystemPrivilege_SystemOperation] FOREIGN KEY([Operation_ID])
REFERENCES [dbo].[SystemOperation] ([Operation_ID])
GO
ALTER TABLE [dbo].[SystemPrivilege] CHECK CONSTRAINT [FK_SystemPrivilege_SystemOperation]
GO
/****** Object:  ForeignKey [FK_SystemPrivilege_SystemResources]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_SystemPrivilege_SystemResources] FOREIGN KEY([Resources_ID])
REFERENCES [dbo].[SystemResources] ([Resources_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SystemPrivilege] CHECK CONSTRAINT [FK_SystemPrivilege_SystemResources]
GO
/****** Object:  ForeignKey [FK_SystemPrivilegeInRoles_SystemPrivilege]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPrivilegeInRoles]  WITH CHECK ADD  CONSTRAINT [FK_SystemPrivilegeInRoles_SystemPrivilege] FOREIGN KEY([Privilege_ID])
REFERENCES [dbo].[SystemPrivilege] ([Privilege_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemPrivilegeInRoles] CHECK CONSTRAINT [FK_SystemPrivilegeInRoles_SystemPrivilege]
GO
/****** Object:  ForeignKey [FK_SystemPrivilegeInRoles_SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPrivilegeInRoles]  WITH CHECK ADD  CONSTRAINT [FK_SystemPrivilegeInRoles_SystemRole] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[SystemRole] ([Role_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemPrivilegeInRoles] CHECK CONSTRAINT [FK_SystemPrivilegeInRoles_SystemRole]
GO
/****** Object:  ForeignKey [FK_SystemPrivilegeParameter_SystemPrivilege]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPrivilegeParameter]  WITH CHECK ADD  CONSTRAINT [FK_SystemPrivilegeParameter_SystemPrivilege] FOREIGN KEY([PrivilegeID])
REFERENCES [dbo].[SystemPrivilege] ([Privilege_ID])
GO
ALTER TABLE [dbo].[SystemPrivilegeParameter] CHECK CONSTRAINT [FK_SystemPrivilegeParameter_SystemPrivilege]
GO
/****** Object:  ForeignKey [FK_SystemPrivilegeParameter_SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemPrivilegeParameter]  WITH CHECK ADD  CONSTRAINT [FK_SystemPrivilegeParameter_SystemRole] FOREIGN KEY([RoleID])
REFERENCES [dbo].[SystemRole] ([Role_ID])
GO
ALTER TABLE [dbo].[SystemPrivilegeParameter] CHECK CONSTRAINT [FK_SystemPrivilegeParameter_SystemRole]
GO
/****** Object:  ForeignKey [FK_SystemProvince_SystemCountry]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemProvince]  WITH CHECK ADD  CONSTRAINT [FK_SystemProvince_SystemCountry] FOREIGN KEY([CountryID])
REFERENCES [dbo].[SystemCountry] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemProvince] CHECK CONSTRAINT [FK_SystemProvince_SystemCountry]
GO
/****** Object:  ForeignKey [FK_SystemResources_SystemMoudle]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemResources]  WITH CHECK ADD  CONSTRAINT [FK_SystemResources_SystemMoudle] FOREIGN KEY([MoudleID])
REFERENCES [dbo].[SystemMoudle] ([Moudle_ID])
GO
ALTER TABLE [dbo].[SystemResources] CHECK CONSTRAINT [FK_SystemResources_SystemMoudle]
GO
/****** Object:  ForeignKey [FK_SystemResources_SystemResources]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemResources]  WITH CHECK ADD  CONSTRAINT [FK_SystemResources_SystemResources] FOREIGN KEY([ParentResources_ID])
REFERENCES [dbo].[SystemResources] ([Resources_ID])
GO
ALTER TABLE [dbo].[SystemResources] CHECK CONSTRAINT [FK_SystemResources_SystemResources]
GO
/****** Object:  ForeignKey [FK_SystemRoleApplication_SystemApplication]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemRoleApplication]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleApplication_SystemApplication] FOREIGN KEY([Application_ID])
REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemRoleApplication] CHECK CONSTRAINT [FK_SystemRoleApplication_SystemApplication]
GO
/****** Object:  ForeignKey [FK_SystemRoleApplication_SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemRoleApplication]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleApplication_SystemRole] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[SystemRole] ([Role_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemRoleApplication] CHECK CONSTRAINT [FK_SystemRoleApplication_SystemRole]
GO
/****** Object:  ForeignKey [FK_SystemRoleMenuRelation_SystemMenu]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemRoleMenuRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleMenuRelation_SystemMenu] FOREIGN KEY([Menu_ID])
REFERENCES [dbo].[SystemMenu] ([Menu_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemRoleMenuRelation] CHECK CONSTRAINT [FK_SystemRoleMenuRelation_SystemMenu]
GO
/****** Object:  ForeignKey [FK_SystemRoleMenuRelation_SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemRoleMenuRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleMenuRelation_SystemRole] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[SystemRole] ([Role_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemRoleMenuRelation] CHECK CONSTRAINT [FK_SystemRoleMenuRelation_SystemRole]
GO
/****** Object:  ForeignKey [FK_SystemUser_SystemDepartment]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUser]  WITH CHECK ADD  CONSTRAINT [FK_SystemUser_SystemDepartment] FOREIGN KEY([Department_ID])
REFERENCES [dbo].[SystemDepartment] ([Department_ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SystemUser] CHECK CONSTRAINT [FK_SystemUser_SystemDepartment]
GO
/****** Object:  ForeignKey [FK_SystemUserGroupRoleRelation_SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserGroupRoleRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemRole] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[SystemRole] ([Role_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserGroupRoleRelation] CHECK CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemRole]
GO
/****** Object:  ForeignKey [FK_SystemUserGroupRoleRelation_SystemUserGroup]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserGroupRoleRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemUserGroup] FOREIGN KEY([UserGroup_ID])
REFERENCES [dbo].[SystemUserGroup] ([Group_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserGroupRoleRelation] CHECK CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemUserGroup]
GO
/****** Object:  ForeignKey [FK_SystemUserGroupUserRelation_SystemUser]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserGroupUserRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[SystemUser] ([User_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserGroupUserRelation] CHECK CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUser]
GO
/****** Object:  ForeignKey [FK_SystemUserGroupUserRelation_SystemUserGroup]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserGroupUserRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[SystemUserGroup] ([Group_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SystemUserGroupUserRelation] CHECK CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUserGroup]
GO
/****** Object:  ForeignKey [FK_SystemUserProfile_SystemUser]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserProfile]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserProfile_SystemUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[SystemUser] ([User_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserProfile] CHECK CONSTRAINT [FK_SystemUserProfile_SystemUser]
GO
/****** Object:  ForeignKey [FK_SystemUserProfile_SystemUserProfilePropertys]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserProfile]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserProfile_SystemUserProfilePropertys] FOREIGN KEY([Property_ID])
REFERENCES [dbo].[SystemUserProfilePropertys] ([Property_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserProfile] CHECK CONSTRAINT [FK_SystemUserProfile_SystemUserProfilePropertys]
GO
/****** Object:  ForeignKey [FK_SystemUserRoleRelation_SystemRole]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserRoleRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserRoleRelation_SystemRole] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[SystemRole] ([Role_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserRoleRelation] CHECK CONSTRAINT [FK_SystemUserRoleRelation_SystemRole]
GO
/****** Object:  ForeignKey [FK_SystemUserRoleRelation_SystemUser]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemUserRoleRelation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUserRoleRelation_SystemUser] FOREIGN KEY([User_ID])
REFERENCES [dbo].[SystemUser] ([User_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemUserRoleRelation] CHECK CONSTRAINT [FK_SystemUserRoleRelation_SystemUser]
GO
/****** Object:  ForeignKey [FK_SystemView_SystemApplication1]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemView]  WITH CHECK ADD  CONSTRAINT [FK_SystemView_SystemApplication1] FOREIGN KEY([Application_ID])
REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
GO
ALTER TABLE [dbo].[SystemView] CHECK CONSTRAINT [FK_SystemView_SystemApplication1]
GO
/****** Object:  ForeignKey [FK_SystemViewItem_SystemView]    Script Date: 10/19/2011 07:42:02 ******/
ALTER TABLE [dbo].[SystemViewItem]  WITH CHECK ADD  CONSTRAINT [FK_SystemViewItem_SystemView] FOREIGN KEY([SystemView_ID])
REFERENCES [dbo].[SystemView] ([SystemView_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SystemViewItem] CHECK CONSTRAINT [FK_SystemViewItem_SystemView]
GO
