ALTER TABLE [dbo].[SystemUserGroupRoleRelation]
    ADD CONSTRAINT [FK_SystemUserGroupRoleRelation_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

