ALTER TABLE [dbo].[SystemRoleApplication]
    ADD CONSTRAINT [FK_SystemRoleApplication_SystemApplication] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

