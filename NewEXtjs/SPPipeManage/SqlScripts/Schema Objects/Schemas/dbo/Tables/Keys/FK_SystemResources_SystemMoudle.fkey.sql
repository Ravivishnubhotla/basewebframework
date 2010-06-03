ALTER TABLE [dbo].[SystemResources]
    ADD CONSTRAINT [FK_SystemResources_SystemMoudle] FOREIGN KEY ([MoudleID]) REFERENCES [dbo].[SystemMoudle] ([Moudle_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

