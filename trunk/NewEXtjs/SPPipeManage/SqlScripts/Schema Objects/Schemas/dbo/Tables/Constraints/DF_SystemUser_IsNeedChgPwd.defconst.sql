ALTER TABLE [dbo].[SystemUser]
    ADD CONSTRAINT [DF_SystemUser_IsNeedChgPwd] DEFAULT ((0)) FOR [IsNeedChgPwd];

