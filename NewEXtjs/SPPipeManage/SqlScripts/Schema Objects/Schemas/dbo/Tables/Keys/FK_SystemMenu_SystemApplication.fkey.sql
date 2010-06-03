ALTER TABLE [dbo].[SystemMenu]
    ADD CONSTRAINT [FK_SystemMenu_SystemApplication] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

