ALTER TABLE [dbo].[SystemRoleMenuRelation]
    ADD CONSTRAINT [FK_SystemRoleMenuRelation_SystemMenu] FOREIGN KEY ([Menu_ID]) REFERENCES [dbo].[SystemMenu] ([Menu_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

