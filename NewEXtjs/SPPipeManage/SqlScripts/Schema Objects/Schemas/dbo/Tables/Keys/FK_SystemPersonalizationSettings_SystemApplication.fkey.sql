ALTER TABLE [dbo].[SystemPersonalizationSettings]
    ADD CONSTRAINT [FK_SystemPersonalizationSettings_SystemApplication] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE CASCADE ON UPDATE NO ACTION;

