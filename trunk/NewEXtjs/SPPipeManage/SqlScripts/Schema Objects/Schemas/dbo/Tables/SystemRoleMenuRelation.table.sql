CREATE TABLE [dbo].[SystemRoleMenuRelation] (
    [MenuRole_ID] INT IDENTITY (1, 1) NOT NULL,
    [Menu_ID]     INT NOT NULL,
    [Role_ID]     INT NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统角色菜单分配', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation', @level2type = N'COLUMN', @level2name = N'MenuRole_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'菜单ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation', @level2type = N'COLUMN', @level2name = N'Menu_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation', @level2type = N'COLUMN', @level2name = N'Role_ID';

