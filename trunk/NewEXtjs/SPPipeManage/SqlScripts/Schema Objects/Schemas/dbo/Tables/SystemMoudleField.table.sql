CREATE TABLE [dbo].[SystemMoudleField] (
    [SystemMoudleField_ID]           INT             IDENTITY (1, 1) NOT NULL,
    [SystemMoudleField_NameEn]       NVARCHAR (200)  NULL,
    [SystemMoudleField_NameCn]       NVARCHAR (200)  NULL,
    [SystemMoudleField_NameDb]       NVARCHAR (200)  NULL,
    [SystemMoudleField_Type]         NVARCHAR (200)  NULL,
    [SystemMoudleField_IsRequired]   BIT             NULL,
    [SystemMoudleField_DefaultValue] NVARCHAR (200)  NULL,
    [SystemMoudleField_IsKeyField]   BIT             NULL,
    [SystemMoudleField_Size]         INT             NULL,
    [SystemMoudleField_Description]  NVARCHAR (2000) NULL,
    [SystemMoudle_ID]                INT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统数据模块字段', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段数据表名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_NameDb';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段是否必填', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_IsRequired';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段默认值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_DefaultValue';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段是否为主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_IsKeyField';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段大小', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_Size';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段对应模块ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudle_ID';

