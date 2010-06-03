ALTER TABLE [dbo].[SystemViewItem]
    ADD CONSTRAINT [FK_SystemViewItem_SystemView] FOREIGN KEY ([SystemView_ID]) REFERENCES [dbo].[SystemView] ([SystemView_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

