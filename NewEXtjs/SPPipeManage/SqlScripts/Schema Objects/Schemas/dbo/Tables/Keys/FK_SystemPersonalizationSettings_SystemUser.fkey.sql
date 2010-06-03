ALTER TABLE [dbo].[SystemPersonalizationSettings]
    ADD CONSTRAINT [FK_SystemPersonalizationSettings_SystemUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

