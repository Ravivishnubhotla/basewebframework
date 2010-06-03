CREATE TABLE [dbo].[SystemPrivilege] (
    [Privilege_ID]      INT             IDENTITY (1, 1) NOT NULL,
    [Operation_ID]      INT             NULL,
    [Resources_ID]      INT             NULL,
    [PrivilegeCnName]   NVARCHAR (200)  NOT NULL,
    [PrivilegeEnName]   NVARCHAR (200)  NOT NULL,
    [DefaultValue]      NVARCHAR (2000) NULL,
    [Description]       NVARCHAR (2000) NULL,
    [PrivilegeOrder]    INT             NOT NULL,
    [PrivilegeCategory] NVARCHAR (200)  NULL,
    [PrivilegeType]     NVARCHAR (200)  NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System Permission', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'Privilege_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Operation ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'Operation_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Resources ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'Resources_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permission Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'PrivilegeCnName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permission Code', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'PrivilegeEnName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Default Value', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'DefaultValue';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permission Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permission Order', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'PrivilegeOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'permission Category', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilege', @level2type = N'COLUMN', @level2name = N'PrivilegeCategory';

