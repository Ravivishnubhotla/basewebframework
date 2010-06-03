ALTER TABLE [dbo].[SystemMenu]
    ADD CONSTRAINT [FK_SystemMenu_SystemMenu] FOREIGN KEY ([ParentMenu_ID]) REFERENCES [dbo].[SystemMenu] ([Menu_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

