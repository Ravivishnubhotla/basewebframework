ALTER TABLE [dbo].[SystemUserGroupUserRelation]
    ADD CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

