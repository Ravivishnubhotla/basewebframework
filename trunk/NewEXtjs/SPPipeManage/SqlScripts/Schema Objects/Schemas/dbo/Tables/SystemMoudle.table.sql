CREATE TABLE [dbo].[SystemMoudle] (
    [Moudle_ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Moudle_NameCn]         NVARCHAR (200)  NOT NULL,
    [Moudle_NameEn]         NVARCHAR (200)  NOT NULL,
    [Moudle_NameDb]         NVARCHAR (200)  NOT NULL,
    [Moudle_Description]    NVARCHAR (2000) NOT NULL,
    [Application_ID]        INT             NULL,
    [Moudle_IsSystemMoudle] BIT             NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统数据模块', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模块中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模块英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模块对应数据表名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_NameDb';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模块描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'应用ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Application_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否为系统模块', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_IsSystemMoudle';

