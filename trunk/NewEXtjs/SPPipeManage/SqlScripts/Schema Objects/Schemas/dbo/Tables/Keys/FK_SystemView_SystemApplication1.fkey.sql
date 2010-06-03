ALTER TABLE [dbo].[SystemView]
    ADD CONSTRAINT [FK_SystemView_SystemApplication1] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

