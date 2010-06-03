ALTER TABLE [dbo].[SystemPrivilege]
    ADD CONSTRAINT [FK_SystemPrivilege_SystemResources] FOREIGN KEY ([Resources_ID]) REFERENCES [dbo].[SystemResources] ([Resources_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

