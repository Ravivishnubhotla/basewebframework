CREATE TABLE [dbo].[SystemView] (
    [SystemView_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [SystemView_NameCn]      NVARCHAR (200)  NULL,
    [SystemView_NameEn]      NVARCHAR (200)  NULL,
    [Application_ID]         INT             NULL,
    [SystemView_Description] NVARCHAR (2000) NULL,
    [OrderIndex]             INT             NULL,
    [CreateBy]               INT             NULL,
    [CreateAt]               DATETIME        NULL,
    [LastModifyBy]           INT             NULL,
    [LastModifyAt]           DATETIME        NULL,
    [LastModifyComment]      NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemView] PRIMARY KEY CLUSTERED ([SystemView_ID] ASC),
    CONSTRAINT [FK_SystemView_SystemApplication1] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'Application_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemView', @level2type = N'COLUMN', @level2name = N'SystemView_Description';

