ALTER TABLE [dbo].[SystemUserProfile]
    ADD CONSTRAINT [FK_SystemUserProfile_SystemUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

