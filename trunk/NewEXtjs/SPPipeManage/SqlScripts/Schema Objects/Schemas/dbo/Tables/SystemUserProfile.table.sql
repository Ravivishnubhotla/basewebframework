CREATE TABLE [dbo].[SystemUserProfile] (
    [Profile_ID]           INT      IDENTITY (1, 1) NOT NULL,
    [UserID]               INT      NOT NULL,
    [Property_ID]          INT      NOT NULL,
    [PropertyValuesString] NTEXT    NULL,
    [PropertyValuesBinary] IMAGE    NULL,
    [LastUpdatedDate]      DATETIME NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'Profile_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'UserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'属性ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'Property_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'属性值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'PropertyValuesString';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'属性二进制值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'PropertyValuesBinary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'上次更新时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserProfile', @level2type = N'COLUMN', @level2name = N'LastUpdatedDate';

