CREATE TABLE [dbo].[SystemSetting] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [SystemName]        NVARCHAR (200)  NOT NULL,
    [SystemDescription] NVARCHAR (2000) NULL,
    [SystemUrl]         NVARCHAR (200)  NULL,
    [SystemVersion]     NVARCHAR (200)  NOT NULL,
    [SystemLisence]     NVARCHAR (2000) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统设置', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting', @level2type = N'COLUMN', @level2name = N'SystemName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting', @level2type = N'COLUMN', @level2name = N'SystemDescription';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统URL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting', @level2type = N'COLUMN', @level2name = N'SystemUrl';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统版本', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting', @level2type = N'COLUMN', @level2name = N'SystemVersion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统版权声明', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemSetting', @level2type = N'COLUMN', @level2name = N'SystemLisence';

