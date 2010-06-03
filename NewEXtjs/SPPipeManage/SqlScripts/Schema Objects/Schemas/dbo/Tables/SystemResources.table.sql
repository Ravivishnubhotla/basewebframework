CREATE TABLE [dbo].[SystemResources] (
    [Resources_ID]              INT             NOT NULL,
    [Resources_NameCn]          NVARCHAR (200)  NOT NULL,
    [Resources_NameEn]          NVARCHAR (200)  NOT NULL,
    [Resources_Description]     NVARCHAR (2000) NULL,
    [Resources_Type]            NVARCHAR (200)  NULL,
    [Resources_Category]        NVARCHAR (200)  NULL,
    [Resources_LimitExpression] NVARCHAR (2000) NULL,
    [Resources_IsRelateUser]    BIT             NOT NULL,
    [MoudleID]                  INT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统资源', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'资源中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'资源英文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'资源描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'资源类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'资源限制条件', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_LimitExpression';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'资源是否于用户相关', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'Resources_IsRelateUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'所属模块', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemResources', @level2type = N'COLUMN', @level2name = N'MoudleID';

