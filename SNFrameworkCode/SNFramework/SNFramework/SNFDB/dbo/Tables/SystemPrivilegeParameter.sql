CREATE TABLE [dbo].[SystemPrivilegeParameter] (
    [PrivilegeParameterID] INT             IDENTITY (1, 1) NOT NULL,
    [RoleID]               INT             NOT NULL,
    [PrivilegeID]          INT             NOT NULL,
    [BizParameter]         NVARCHAR (2000) NOT NULL,
    [CreateBy]             INT             NULL,
    [CreateAt]             DATETIME        NULL,
    [LastModifyBy]         INT             NULL,
    [LastModifyAt]         DATETIME        NULL,
    [LastModifyComment]    NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemPrivilegeParameter] PRIMARY KEY CLUSTERED ([PrivilegeParameterID] ASC),
    CONSTRAINT [FK_SystemPrivilegeParameter_SystemPrivilege] FOREIGN KEY ([PrivilegeID]) REFERENCES [dbo].[SystemPrivilege] ([Privilege_ID]),
    CONSTRAINT [FK_SystemPrivilegeParameter_SystemRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[SystemRole] ([Role_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'PrivilegeParameterID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'RoleID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'PrivilegeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'BizParameter';

