CREATE TABLE [dbo].[SystemRole] (
    [Role_ID]           INT             IDENTITY (1, 1) NOT NULL,
    [Role_Name]         NVARCHAR (50)   NULL,
    [Role_Description]  NVARCHAR (2000) NULL,
    [Role_IsSystemRole] BIT             NULL,
    [Role_Type]         NVARCHAR (50)   NULL,
    [CreateBy]          INT             NULL,
    [CreateDate]        DATETIME        NULL,
    [LastUpdateBy]      INT             NULL,
    [LastUpdateDate]    DATETIME        NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System Role', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRole';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRole', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Role Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRole', @level2type = N'COLUMN', @level2name = N'Role_Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Role Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRole', @level2type = N'COLUMN', @level2name = N'Role_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is System Role', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRole', @level2type = N'COLUMN', @level2name = N'Role_IsSystemRole';

