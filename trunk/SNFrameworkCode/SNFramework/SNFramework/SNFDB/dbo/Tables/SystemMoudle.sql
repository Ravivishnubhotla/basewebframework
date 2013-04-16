CREATE TABLE [dbo].[SystemMoudle] (
    [Moudle_ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Moudle_NameCn]         NVARCHAR (200)  NOT NULL,
    [Moudle_NameEn]         NVARCHAR (200)  NOT NULL,
    [Moudle_NameDb]         NVARCHAR (200)  NOT NULL,
    [Moudle_Description]    NVARCHAR (2000) NOT NULL,
    [Application_ID]        INT             NULL,
    [Moudle_IsSystemMoudle] BIT             NOT NULL,
    [OrderIndex]            INT             NULL,
    [CreateBy]              INT             NULL,
    [CreateAt]              DATETIME        NULL,
    [LastModifyBy]          INT             NULL,
    [LastModifyAt]          DATETIME        NULL,
    [LastModifyComment]     NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemMoudle] PRIMARY KEY CLUSTERED ([Moudle_ID] ASC),
    CONSTRAINT [FK_SystemMoudle_SystemApplication] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System Moudle', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Moudle Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Moudle Code', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'moudle of Table', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_NameDb';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Moudle Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Application ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Application_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is System Moudle', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudle', @level2type = N'COLUMN', @level2name = N'Moudle_IsSystemMoudle';

