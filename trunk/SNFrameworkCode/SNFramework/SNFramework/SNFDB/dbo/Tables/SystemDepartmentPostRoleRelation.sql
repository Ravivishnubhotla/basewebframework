CREATE TABLE [dbo].[SystemDepartmentPostRoleRelation] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [DepartmentID] INT             NULL,
    [PostID]       INT             NULL,
    [RoleID]       INT             NULL,
    [Description]  NVARCHAR (2000) NULL,
    CONSTRAINT [PK_SystemDepartmentPostRoleRelation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SystemDepartmentPostRoleRelation_SystemDepartment] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[SystemDepartment] ([Department_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemDepartmentPostRoleRelation_SystemPost] FOREIGN KEY ([PostID]) REFERENCES [dbo].[SystemPost] ([ID]),
    CONSTRAINT [FK_SystemDepartmentPostRoleRelation_SystemRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE
);

