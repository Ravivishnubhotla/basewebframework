ALTER TABLE [dbo].[SystemRoleApplication]
    ADD CONSTRAINT [FK_SystemRoleApplication_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

