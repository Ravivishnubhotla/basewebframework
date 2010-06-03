CREATE TABLE [dbo].[SystemOperation] (
    [Operation_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Operation_NameCn]      NVARCHAR (200)  NULL,
    [Operation_NameEn]      NVARCHAR (200)  NULL,
    [Operation_Description] NVARCHAR (2000) NOT NULL,
    [IsSystemOperation]     BIT             NOT NULL,
    [IsCanSingleOperation]  BIT             NOT NULL,
    [IsCanMutilOperation]   BIT             NOT NULL,
    [IsEnable]              BIT             NOT NULL,
    [IsInListPage]          BIT             NOT NULL,
    [IsInSinglePage]        BIT             NOT NULL,
    [Operation_Order]       INT             NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统操作', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'操作中文名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'操作代号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'操作描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否为系统操作', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsSystemOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否可以单条数据操作', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsCanSingleOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否可以多条数据操作', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsCanMutilOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否生效', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsEnable';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否出现在列表页面', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsInListPage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否出现在详细页面', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsInSinglePage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'操作排序号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_Order';

