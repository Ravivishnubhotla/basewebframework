CREATE TABLE [dbo].[SystemUserGroupRoleRelation] (
    [UserGroupRole_ID] INT IDENTITY (1, 1) NOT NULL,
    [Role_ID]          INT NOT NULL,
    [UserGroup_ID]     INT NOT NULL,
    CONSTRAINT [PK_SystemUserGroupRole] PRIMARY KEY CLUSTERED ([UserGroupRole_ID] ASC),
    CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemUserGroup] FOREIGN KEY ([UserGroup_ID]) REFERENCES [dbo].[SystemUserGroup] ([Group_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation', @level2type = N'COLUMN', @level2name = N'UserGroupRole_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupRoleRelation', @level2type = N'COLUMN', @level2name = N'UserGroup_ID';

