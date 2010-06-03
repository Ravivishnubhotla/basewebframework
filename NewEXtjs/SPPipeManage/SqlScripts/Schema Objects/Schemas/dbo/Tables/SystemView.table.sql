CREATE TABLE [dbo].[SystemView] (
    [SystemView_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [SystemView_NameCn]      NVARCHAR (200)  NULL,
    [SystemView_NameEn]      NVARCHAR (200)  NULL,
    [Application_ID]         INT             NULL,
    [SystemView_Description] NVARCHAR (2000) NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统视图', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'视图中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'视图英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'应用ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'Application_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'视图描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_Description';

