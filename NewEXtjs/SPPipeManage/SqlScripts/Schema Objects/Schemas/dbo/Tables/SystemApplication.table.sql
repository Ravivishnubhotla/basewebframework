CREATE TABLE [dbo].[SystemApplication] (
    [SystemApplication_ID]                  INT             IDENTITY (1, 1) NOT NULL,
    [SystemApplication_Name]                NVARCHAR (200)  NOT NULL,
    [SystemApplication_Description]         NVARCHAR (2000) NULL,
    [SystemApplication_Url]                 NVARCHAR (200)  NULL,
    [SystemApplication_IsSystemApplication] BIT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System Application', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemApplication';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemApplication', @level2type = N'COLUMN', @level2name = N'SystemApplication_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Application Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemApplication', @level2type = N'COLUMN', @level2name = N'SystemApplication_Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Application Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemApplication', @level2type = N'COLUMN', @level2name = N'SystemApplication_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Appilcation Url', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemApplication', @level2type = N'COLUMN', @level2name = N'SystemApplication_Url';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{$DisplayName:"Is System Application"} Test description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemApplication', @level2type = N'COLUMN', @level2name = N'SystemApplication_IsSystemApplication';

