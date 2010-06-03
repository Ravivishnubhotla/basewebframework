ALTER TABLE [dbo].[SystemPrivilegeParameter]
    ADD CONSTRAINT [FK_SystemPrivilegeParameter_SystemPrivilege] FOREIGN KEY ([PrivilegeID]) REFERENCES [dbo].[SystemPrivilege] ([Privilege_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

