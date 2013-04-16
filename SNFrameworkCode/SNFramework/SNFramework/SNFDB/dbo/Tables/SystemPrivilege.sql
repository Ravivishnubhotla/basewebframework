CREATE TABLE [dbo].[SystemPrivilege] (
    [Privilege_ID]      INT             IDENTITY (1, 1) NOT NULL,
    [Operation_ID]      INT             NULL,
    [Resources_ID]      INT             NULL,
    [PrivilegeCnName]   NVARCHAR (200)  NOT NULL,
    [PrivilegeEnName]   NVARCHAR (200)  NOT NULL,
    [DefaultValue]      NVARCHAR (2000) NULL,
    [Description]       NVARCHAR (2000) NULL,
    [PrivilegeOrder]    INT             NOT NULL,
    [PrivilegeType]     NVARCHAR (200)  NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemPrivilege] PRIMARY KEY CLUSTERED ([Privilege_ID] ASC),
    CONSTRAINT [FK_SystemPrivilege_SystemOperation] FOREIGN KEY ([Operation_ID]) REFERENCES [dbo].[SystemOperation] ([Operation_ID]),
    CONSTRAINT [FK_SystemPrivilege_SystemResources] FOREIGN KEY ([Resources_ID]) REFERENCES [dbo].[SystemResources] ([Resources_ID]) ON UPDATE CASCADE
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

