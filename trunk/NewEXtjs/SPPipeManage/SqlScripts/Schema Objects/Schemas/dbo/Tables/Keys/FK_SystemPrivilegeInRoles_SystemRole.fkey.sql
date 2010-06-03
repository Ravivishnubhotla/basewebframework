ALTER TABLE [dbo].[SystemPrivilegeInRoles]
    ADD CONSTRAINT [FK_SystemPrivilegeInRoles_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

