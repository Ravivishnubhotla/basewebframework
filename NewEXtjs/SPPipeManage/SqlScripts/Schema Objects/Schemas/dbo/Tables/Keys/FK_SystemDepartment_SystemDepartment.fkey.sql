ALTER TABLE [dbo].[SystemDepartment]
    ADD CONSTRAINT [FK_SystemDepartment_SystemDepartment] FOREIGN KEY ([Parent_Department_ID]) REFERENCES [dbo].[SystemDepartment] ([Department_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

