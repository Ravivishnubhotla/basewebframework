CREATE TABLE [dbo].[SystemDepartment] (
    [Department_ID]         INT             IDENTITY (1, 1) NOT NULL,
    [Parent_Department_ID]  INT             NULL,
    [Department_NameCn]     NVARCHAR (200)  NOT NULL,
    [Department_NameEn]     NVARCHAR (200)  NOT NULL,
    [Department_Decription] NVARCHAR (2000) NULL,
    [DepartmentSortIndex]   INT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统用户部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'父部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Parent_Department_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_Decription';

