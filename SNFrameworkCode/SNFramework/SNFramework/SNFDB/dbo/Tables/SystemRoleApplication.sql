CREATE TABLE [dbo].[SystemRoleApplication] (
    [SystemRoleApplication_ID] INT IDENTITY (1, 1) NOT NULL,
    [Role_ID]                  INT NULL,
    [Application_ID]           INT NULL,
    CONSTRAINT [PK_SystemRoleApplication] PRIMARY KEY CLUSTERED ([SystemRoleApplication_ID] ASC),
    CONSTRAINT [FK_SystemRoleApplication_SystemApplication] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemRoleApplication_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'???????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication', @level2type = N'COLUMN', @level2name = N'SystemRoleApplication_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication', @level2type = N'COLUMN', @level2name = N'Application_ID';

