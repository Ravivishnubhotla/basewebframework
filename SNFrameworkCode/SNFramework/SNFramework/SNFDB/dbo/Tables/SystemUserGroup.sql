CREATE TABLE [dbo].[SystemUserGroup] (
    [Group_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Group_NameCn]      NVARCHAR (200)  NOT NULL,
    [Group_NameEn]      NVARCHAR (200)  NOT NULL,
    [Group_Description] NVARCHAR (2000) NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemUserGroup] PRIMARY KEY CLUSTERED ([Group_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'User Group', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'User Group Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'User Group Code', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'User Group Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUserGroup', @level2type = N'COLUMN', @level2name = N'Group_Description';

