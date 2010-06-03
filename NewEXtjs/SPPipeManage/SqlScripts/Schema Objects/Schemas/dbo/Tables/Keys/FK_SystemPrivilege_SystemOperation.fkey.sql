ALTER TABLE [dbo].[SystemPrivilege]
    ADD CONSTRAINT [FK_SystemPrivilege_SystemOperation] FOREIGN KEY ([Operation_ID]) REFERENCES [dbo].[SystemOperation] ([Operation_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

