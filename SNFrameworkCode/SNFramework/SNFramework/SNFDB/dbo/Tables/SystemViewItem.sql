CREATE TABLE [dbo].[SystemViewItem] (
    [SystemViewItem_ID]            INT             IDENTITY (1, 1) NOT NULL,
    [SystemViewItem_NameEn]        NVARCHAR (200)  NULL,
    [SystemViewItem_NameCn]        NVARCHAR (200)  NULL,
    [SystemViewItem_Description]   NVARCHAR (2000) NULL,
    [SystemViewItem_DisplayFormat] NVARCHAR (2000) NULL,
    [SystemView_ID]                INT             NULL,
    [OrderIndex]                   INT             NULL,
    [CreateBy]                     INT             NULL,
    [CreateAt]                     DATETIME        NULL,
    [LastModifyBy]                 INT             NULL,
    [LastModifyAt]                 DATETIME        NULL,
    [LastModifyComment]            NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemViewItem] PRIMARY KEY CLUSTERED ([SystemViewItem_ID] ASC),
    CONSTRAINT [FK_SystemViewItem_SystemView] FOREIGN KEY ([SystemView_ID]) REFERENCES [dbo].[SystemView] ([SystemView_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemViewItem_DisplayFormat';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemViewItem', @level2type = N'COLUMN', @level2name = N'SystemView_ID';

