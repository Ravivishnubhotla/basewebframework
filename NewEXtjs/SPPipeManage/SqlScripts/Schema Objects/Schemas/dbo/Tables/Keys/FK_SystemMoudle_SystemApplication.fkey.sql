ALTER TABLE [dbo].[SystemMoudle]
    ADD CONSTRAINT [FK_SystemMoudle_SystemApplication] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

