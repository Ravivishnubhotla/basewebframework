ALTER TABLE [dbo].[SystemUserGroupUserRelation]
    ADD CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUserGroup] FOREIGN KEY ([UserGroupID]) REFERENCES [dbo].[SystemUserGroup] ([Group_ID]) ON DELETE NO ACTION ON UPDATE CASCADE;

