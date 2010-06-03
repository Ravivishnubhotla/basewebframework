ALTER TABLE [dbo].[SystemUserGroupRoleRelation]
    ADD CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemUserGroup] FOREIGN KEY ([UserGroup_ID]) REFERENCES [dbo].[SystemUserGroup] ([Group_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

