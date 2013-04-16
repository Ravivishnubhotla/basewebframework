CREATE TABLE [dbo].[SystemUserRoleRelation] (
    [UserRole_ID] INT IDENTITY (1, 1) NOT NULL,
    [User_ID]     INT NOT NULL,
    [Role_ID]     INT NOT NULL,
    CONSTRAINT [PK_SystemUserRoleRelation] PRIMARY KEY CLUSTERED ([UserRole_ID] ASC),
    CONSTRAINT [FK_SystemUserRoleRelation_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemUserRoleRelation_SystemUser] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation', @level2type = N'COLUMN', @level2name = N'UserRole_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation', @level2type = N'COLUMN', @level2name = N'User_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserRoleRelation', @level2type = N'COLUMN', @level2name = N'Role_ID';

