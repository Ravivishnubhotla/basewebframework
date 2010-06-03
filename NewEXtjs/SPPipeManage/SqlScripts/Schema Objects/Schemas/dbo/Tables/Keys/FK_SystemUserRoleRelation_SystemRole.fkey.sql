ALTER TABLE [dbo].[SystemUserRoleRelation]
    ADD CONSTRAINT [FK_SystemUserRoleRelation_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

