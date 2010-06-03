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
    [PrivilegeRoleValue]     IMAGE          NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色权限分配', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'PrivilegeRoleID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'权限ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'Privilege_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'授权类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'EnableType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'CreateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后更新时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'UpdateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'过期时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'ExpiryTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许参数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'EnableParameter';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'权限分配值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeInRoles', @level2type = N'COLUMN', @level2name = N'PrivilegeRoleValue';

