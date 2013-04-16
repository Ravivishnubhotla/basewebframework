CREATE TABLE [dbo].[SystemMenu] (
    [Menu_ID]           INT             IDENTITY (1, 1) NOT NULL,
    [Menu_Name]         NVARCHAR (200)  NOT NULL,
    [Menu_Code]         NVARCHAR (200)  NULL,
    [Menu_Description]  NVARCHAR (2000) NULL,
    [Menu_Url]          NVARCHAR (200)  NULL,
    [Menu_UrlTarget]    NVARCHAR (200)  NULL,
    [Menu_IconUrl]      NVARCHAR (200)  NULL,
    [Menu_IsCategory]   BIT             NOT NULL,
    [ParentMenu_ID]     INT             NULL,
    [Menu_Order]        INT             NULL,
    [Menu_Type]         NVARCHAR (200)  NOT NULL,
    [Menu_IsSystemMenu] BIT             NULL,
    [Menu_IsEnable]     BIT             NULL,
    [ApplicationID]     INT             NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemMenu] PRIMARY KEY CLUSTERED ([Menu_ID] ASC),
    CONSTRAINT [FK_SystemMenu_SystemApplication] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]),
    CONSTRAINT [FK_SystemMenu_SystemMenu] FOREIGN KEY ([ParentMenu_ID]) REFERENCES [dbo].[SystemMenu] ([Menu_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System Navigation Menu', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Url', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_Url';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Url Target Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_UrlTarget';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Is Category', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_IsCategory';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parent Menu', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'ParentMenu_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_Order';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Menu Type', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is System Menu', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_IsSystemMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is Enable', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'Menu_IsEnable';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Application', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMenu', @level2type = N'COLUMN', @level2name = N'ApplicationID';

