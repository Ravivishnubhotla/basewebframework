ALTER TABLE [dbo].[SystemApplication]
    ADD CONSTRAINT [DF_SystemApplication_SystemApplication_IsSystemApplication] DEFAULT ((0)) FOR [SystemApplication_IsSystemApplication];

