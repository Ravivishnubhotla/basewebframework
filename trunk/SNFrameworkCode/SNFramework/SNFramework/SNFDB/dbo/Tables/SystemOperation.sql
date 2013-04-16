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
    [Operation_Order]       INT             CONSTRAINT [DF_SystemOperation_Operation_Order] DEFAULT ((9999)) NOT NULL,
    [IsCommonOperation]     BIT             NULL,
    [ResourceID]            INT             NULL,
    [CreateBy]              INT             NULL,
    [CreateAt]              DATETIME        NULL,
    [LastModifyBy]          INT             NULL,
    [LastModifyAt]          DATETIME        NULL,
    [LastModifyComment]     NVARCHAR (300)  NULL,
    CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED ([Operation_ID] ASC),
    CONSTRAINT [FK_SystemOperation_SystemResources] FOREIGN KEY ([ResourceID]) REFERENCES [dbo].[SystemResources] ([Resources_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'???????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsSystemOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsCanSingleOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsCanMutilOperation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsEnable';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsInListPage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'IsInSinglePage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemOperation', @level2type = N'COLUMN', @level2name = N'Operation_Order';

