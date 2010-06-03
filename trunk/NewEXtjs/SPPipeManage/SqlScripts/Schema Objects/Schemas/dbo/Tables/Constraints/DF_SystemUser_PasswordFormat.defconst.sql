ALTER TABLE [dbo].[SystemUser]
    ADD CONSTRAINT [DF_SystemUser_PasswordFormat] DEFAULT ((0)) FOR [PasswordFormat];

