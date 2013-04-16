CREATE TABLE [dbo].[SystemDepartment] (
    [Department_ID]         INT             IDENTITY (1, 1) NOT NULL,
    [Parent_Department_ID]  INT             NULL,
    [Department_NameCn]     NVARCHAR (200)  NOT NULL,
    [Department_NameEn]     NVARCHAR (200)  NOT NULL,
    [Department_Decription] NVARCHAR (2000) NULL,
    [DepartmentSortIndex]   INT             NULL,
    [OrganizationID]        INT             NULL,
    [CreateBy]              INT             NULL,
    [CreateAt]              DATETIME        NULL,
    [LastModifyBy]          INT             NULL,
    [LastModifyAt]          DATETIME        NULL,
    [LastModifyComment]     NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemDepartment] PRIMARY KEY CLUSTERED ([Department_ID] ASC),
    CONSTRAINT [FK_SystemDepartment_SystemDepartment] FOREIGN KEY ([Parent_Department_ID]) REFERENCES [dbo].[SystemDepartment] ([Department_ID]),
    CONSTRAINT [FK_SystemDepartment_SystemOrganization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[SystemOrganization] ([ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'???', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Parent_Department_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDepartment', @level2type = N'COLUMN', @level2name = N'Department_Decription';

