ALTER TABLE [dbo].[SystemMoudleField]
    ADD CONSTRAINT [FK_SystemMoudleField_SystemMoudle] FOREIGN KEY ([SystemMoudle_ID]) REFERENCES [dbo].[SystemMoudle] ([Moudle_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

