CREATE TABLE [dbo].[SystemRoleApplication] (
    [SystemRoleApplication_ID] INT IDENTITY (1, 1) NOT NULL,
    [Role_ID]                  INT NULL,
    [Application_ID]           INT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色应用分配表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication', @level2type = N'COLUMN', @level2name = N'SystemRoleApplication_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication', @level2type = N'COLUMN', @level2name = N'Role_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'应用ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleApplication', @level2type = N'COLUMN', @level2name = N'Application_ID';

