ALTER TABLE [dbo].[SystemUserProfile]
    ADD CONSTRAINT [FK_SystemUserProfile_SystemUserProfilePropertys] FOREIGN KEY ([Property_ID]) REFERENCES [dbo].[SystemUserProfilePropertys] ([Property_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

