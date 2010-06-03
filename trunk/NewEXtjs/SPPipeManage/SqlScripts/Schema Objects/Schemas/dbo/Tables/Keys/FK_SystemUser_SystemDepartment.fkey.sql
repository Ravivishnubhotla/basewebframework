ALTER TABLE [dbo].[SystemUser]
    ADD CONSTRAINT [FK_SystemUser_SystemDepartment] FOREIGN KEY ([Department_ID]) REFERENCES [dbo].[SystemDepartment] ([Department_ID]) ON DELETE SET NULL ON UPDATE NO ACTION;

