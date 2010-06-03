ALTER TABLE [dbo].[SystemPrivilegeParameter]
    ADD CONSTRAINT [FK_SystemPrivilegeParameter_SystemRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

