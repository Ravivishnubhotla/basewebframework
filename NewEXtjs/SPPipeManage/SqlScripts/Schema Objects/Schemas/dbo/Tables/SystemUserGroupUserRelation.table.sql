CREATE TABLE [dbo].[SystemUserGroupUserRelation] (
    [UserGroupUserID] INT IDENTITY (1, 1) NOT NULL,
    [UserID]          INT NULL,
    [UserGroupID]     INT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户用户组对应关系', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation', @level2type = N'COLUMN', @level2name = N'UserGroupUserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation', @level2type = N'COLUMN', @level2name = N'UserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户组', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation', @level2type = N'COLUMN', @level2name = N'UserGroupID';

