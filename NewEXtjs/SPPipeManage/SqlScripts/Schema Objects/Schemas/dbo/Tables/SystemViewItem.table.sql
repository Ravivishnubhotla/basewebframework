CREATE TABLE [dbo].[SystemViewItem] (
    [SystemViewItem_ID]            INT             IDENTITY (1, 1) NOT NULL,
    [SystemViewItem_NameEn]        NVARCHAR (200)  NULL,
    [SystemViewItem_NameCn]        NVARCHAR (200)  NULL,
    [SystemViewItem_Description]   NVARCHAR (2000) NULL,
    [SystemViewItem_DisplayFormat] NVARCHAR (2000) NULL,
    [SystemView_ID]                INT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统视图字段', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'字段显示格式', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_DisplayFormat';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'所属视图ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemView_ID';

