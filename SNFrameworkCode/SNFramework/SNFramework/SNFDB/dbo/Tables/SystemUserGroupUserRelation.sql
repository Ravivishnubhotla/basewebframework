CREATE TABLE [dbo].[SystemUserGroupUserRelation] (
    [UserGroupUserID] INT IDENTITY (1, 1) NOT NULL,
    [UserID]          INT NULL,
    [UserGroupID]     INT NULL,
    CONSTRAINT [PK_UserGroupUserRelation] PRIMARY KEY CLUSTERED ([UserGroupUserID] ASC),
    CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemUserGroupUserRelation_SystemUserGroup] FOREIGN KEY ([UserGroupID]) REFERENCES [dbo].[SystemUserGroup] ([Group_ID]) ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation', @level2type = N'COLUMN', @level2name = N'UserGroupUserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation', @level2type = N'COLUMN', @level2name = N'UserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'???', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroupUserRelation', @level2type = N'COLUMN', @level2name = N'UserGroupID';

