CREATE TABLE [dbo].[SystemPrivilegeParameter] (
    [PrivilegeParameterID] INT             IDENTITY (1, 1) NOT NULL,
    [RoleID]               INT             NOT NULL,
    [PrivilegeID]          INT             NOT NULL,
    [BizParameter]         NVARCHAR (2000) NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'权限参数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'PrivilegeParameterID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'RoleID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'权限ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'PrivilegeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'参数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemPrivilegeParameter', @level2type = N'COLUMN', @level2name = N'BizParameter';

