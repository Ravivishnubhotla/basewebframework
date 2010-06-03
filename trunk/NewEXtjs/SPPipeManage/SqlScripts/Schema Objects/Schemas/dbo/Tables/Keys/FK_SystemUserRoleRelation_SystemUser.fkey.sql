ALTER TABLE [dbo].[SystemUserRoleRelation]
    ADD CONSTRAINT [FK_SystemUserRoleRelation_SystemUser] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

