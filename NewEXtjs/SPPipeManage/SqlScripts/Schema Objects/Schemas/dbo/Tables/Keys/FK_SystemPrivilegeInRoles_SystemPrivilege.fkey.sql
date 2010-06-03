ALTER TABLE [dbo].[SystemPrivilegeInRoles]
    ADD CONSTRAINT [FK_SystemPrivilegeInRoles_SystemPrivilege] FOREIGN KEY ([Privilege_ID]) REFERENCES [dbo].[SystemPrivilege] ([Privilege_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

