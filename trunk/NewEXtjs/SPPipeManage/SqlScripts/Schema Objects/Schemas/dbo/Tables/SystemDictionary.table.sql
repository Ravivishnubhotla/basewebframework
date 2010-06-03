CREATE TABLE [dbo].[SystemDictionary] (
    [SystemDictionary_ID]         INT             IDENTITY (1, 1) NOT NULL,
    [SystemDictionary_CategoryID] NVARCHAR (200)  NULL,
    [SystemDictionary_Key]        NVARCHAR (200)  NULL,
    [SystemDictionary_Value]      NVARCHAR (2000) NULL,
    [SystemDictionary_Desciption] NVARCHAR (2000) NULL,
    [SystemDictionary_Order]      INT             NULL,
    [SystemDictionary_IsEnable]   BIT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System Dictionary', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Category Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_CategoryID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_Key';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Value', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_Value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_Desciption';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Order Index', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_Order';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is Enable', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemDictionary', @level2type = N'COLUMN', @level2name = N'SystemDictionary_IsEnable';

