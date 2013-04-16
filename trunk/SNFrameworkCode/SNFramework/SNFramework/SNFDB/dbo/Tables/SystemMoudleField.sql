CREATE TABLE [dbo].[SystemMoudleField] (
    [SystemMoudleField_ID]           INT             IDENTITY (1, 1) NOT NULL,
    [SystemMoudleField_NameEn]       NVARCHAR (200)  NULL,
    [SystemMoudleField_NameCn]       NVARCHAR (200)  NULL,
    [SystemMoudleField_NameDb]       NVARCHAR (200)  NULL,
    [SystemMoudleField_Type]         NVARCHAR (200)  NULL,
    [SystemMoudleField_IsRequired]   BIT             NULL,
    [SystemMoudleField_DefaultValue] NVARCHAR (200)  NULL,
    [SystemMoudleField_IsKeyField]   BIT             NULL,
    [SystemMoudleField_Size]         INT             NULL,
    [SystemMoudleField_Description]  NVARCHAR (2000) NULL,
    [SystemMoudle_ID]                INT             NULL,
    [OrderIndex]                     INT             NULL,
    [CreateBy]                       INT             NULL,
    [CreateAt]                       DATETIME        NULL,
    [LastModifyBy]                   INT             NULL,
    [LastModifyAt]                   DATETIME        NULL,
    [LastModifyComment]              NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemMoudleField] PRIMARY KEY CLUSTERED ([SystemMoudleField_ID] ASC),
    CONSTRAINT [FK_SystemMoudleField_SystemMoudle] FOREIGN KEY ([SystemMoudle_ID]) REFERENCES [dbo].[SystemMoudle] ([Moudle_ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SystemMoudleField', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_NameCn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_NameDb';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_IsRequired';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'?????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_DefaultValue';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'???????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_IsKeyField';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_Size';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'????', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudleField_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'??????ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemMoudleField', @level2type = N'COLUMN', @level2name = N'SystemMoudle_ID';

