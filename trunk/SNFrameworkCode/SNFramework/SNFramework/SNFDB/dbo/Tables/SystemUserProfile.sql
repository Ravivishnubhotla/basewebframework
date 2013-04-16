CREATE TABLE [dbo].[SystemUserProfile] (
    [Profile_ID]           INT            IDENTITY (1, 1) NOT NULL,
    [UserID]               INT            NOT NULL,
    [Property_ID]          INT            NOT NULL,
    [PropertyValuesString] NTEXT          NULL,
    [PropertyValuesBinary] IMAGE          NULL,
    [LastUpdatedDate]      DATETIME       NOT NULL,
    [CreateBy]             INT            NULL,
    [CreateAt]             DATETIME       NULL,
    [LastModifyBy]         INT            NULL,
    [LastModifyAt]         DATETIME       NULL,
    [LastModifyComment]    NVARCHAR (300) NULL,
    CONSTRAINT [PK_SystemUserProfile] PRIMARY KEY CLUSTERED ([Profile_ID] ASC),
    CONSTRAINT [FK_SystemUserProfile_SystemUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemUserProfile_SystemUserProfilePropertys] FOREIGN KEY ([Property_ID]) REFERENCES [dbo].[SystemUserProfilePropertys] ([Property_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'Profile_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'UserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'Property_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'???', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'PropertyValuesString';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'PropertyValuesBinary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'LastUpdatedDate';

