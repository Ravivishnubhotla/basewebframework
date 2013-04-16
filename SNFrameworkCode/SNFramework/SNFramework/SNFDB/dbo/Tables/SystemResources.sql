CREATE TABLE [dbo].[SystemResources] (
    [Resources_ID]              INT             IDENTITY (1, 1) NOT NULL,
    [Resources_NameCn]          NVARCHAR (200)  NOT NULL,
    [Resources_NameEn]          NVARCHAR (200)  NOT NULL,
    [Resources_Description]     NVARCHAR (2000) NULL,
    [Resources_Type]            NVARCHAR (200)  NULL,
    [Resources_LimitExpression] NVARCHAR (2000) NULL,
    [Resources_IsRelateUser]    BIT             NOT NULL,
    [MoudleID]                  INT             NULL,
    [ParentResources_ID]        INT             NULL,
    [OrderIndex]                INT             NULL,
    [CreateBy]                  INT             NULL,
    [CreateAt]                  DATETIME        NULL,
    [LastModifyBy]              INT             NULL,
    [LastModifyAt]              DATETIME        NULL,
    [LastModifyComment]         NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemResources] PRIMARY KEY CLUSTERED ([Resources_ID] ASC),
    CONSTRAINT [FK_SystemResources_SystemMoudle] FOREIGN KEY ([MoudleID]) REFERENCES [dbo].[SystemMoudle] ([Moudle_ID]),
    CONSTRAINT [FK_SystemResources_SystemResources] FOREIGN KEY ([ParentResources_ID]) REFERENCES [dbo].[SystemResources] ([Resources_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_LimitExpression';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_IsRelateUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'MoudleID';

