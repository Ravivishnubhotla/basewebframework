CREATE TABLE [dbo].[SystemUserGroupRoleRelation] (
    [UserGroupRole_ID] INT IDENTITY (1, 1) NOT NULL,
    [Role_ID]          INT NOT NULL,
    [UserGroup_ID]     INT NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门角色关系', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation', @level2type = N'COLUMN', @level2name = N'UserGroupRole_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation', @level2type = N'COLUMN', @level2name = N'UserGroup_ID';

