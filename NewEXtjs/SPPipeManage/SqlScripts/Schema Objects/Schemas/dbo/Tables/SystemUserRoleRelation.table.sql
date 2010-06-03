CREATE TABLE [dbo].[SystemUserRoleRelation] (
    [UserRole_ID] INT IDENTITY (1, 1) NOT NULL,
    [User_ID]     INT NOT NULL,
    [Role_ID]     INT NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统用户角色分配', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation', @level2type = N'COLUMN', @level2name = N'UserRole_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation', @level2type = N'COLUMN', @level2name = N'User_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation', @level2type = N'COLUMN', @level2name = N'Role_ID';

