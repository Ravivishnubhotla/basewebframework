CREATE TABLE [dbo].[SystemPrivilegeInRoles] (
    [PrivilegeRoleID]        INT            IDENTITY (1, 1) NOT NULL,
    [Role_ID]                INT            NOT NULL,
    [Privilege_ID]           INT            NOT NULL,
    [PrivilegeRoleValueType] NVARCHAR (200) NULL,
    [EnableType]             NVARCHAR (200) NOT NULL,
    [CreateTime]             DATETIME       NOT NULL,
    [UpdateTime]             DATETIME       NOT NULL,
    [ExpiryTime]             DATETIME       NOT NULL,
    [EnableParameter]        BIT            NOT NULL,
    [PrivilegeRoleValue]     IMAGE          NULL,
    CONSTRAINT [PK_SystemPrivilegeInRoles] PRIMARY KEY CLUSTERED ([PrivilegeRoleID] ASC),
    CONSTRAINT [FK_SystemPrivilegeInRoles_SystemPrivilege] FOREIGN KEY ([Privilege_ID]) REFERENCES [dbo].[SystemPrivilege] ([Privilege_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemPrivilegeInRoles_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'PrivilegeRoleID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'Privilege_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'EnableType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'CreateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'UpdateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'ExpiryTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'EnableParameter';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'PrivilegeRoleValue';

