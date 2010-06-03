CREATE TABLE [dbo].[SystemUserGroup] (
    [Group_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Group_NameCn]      NVARCHAR (200)  NOT NULL,
    [Group_NameEn]      NVARCHAR (200)  NOT NULL,
    [Group_Description] NVARCHAR (2000) NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户组', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户组中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户组英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户组描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_Description';

