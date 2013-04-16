CREATE TABLE [dbo].[SystemRoleMenuRelation] (
    [MenuRole_ID] INT IDENTITY (1, 1) NOT NULL,
    [Menu_ID]     INT NOT NULL,
    [Role_ID]     INT NOT NULL,
    CONSTRAINT [PK_SystemRoleMenuRelation] PRIMARY KEY CLUSTERED ([MenuRole_ID] ASC),
    CONSTRAINT [FK_SystemRoleMenuRelation_SystemMenu] FOREIGN KEY ([Menu_ID]) REFERENCES [dbo].[SystemMenu] ([Menu_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemRoleMenuRelation_SystemRole] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[SystemRole] ([Role_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation', @level2type = N'COLUMN', @level2name = N'MenuRole_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation', @level2type = N'COLUMN', @level2name = N'Menu_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemRoleMenuRelation', @level2type = N'COLUMN', @level2name = N'Role_ID';

