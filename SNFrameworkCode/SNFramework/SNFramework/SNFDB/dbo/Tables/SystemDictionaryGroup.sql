CREATE TABLE [dbo].[SystemDictionaryGroup] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50)  NULL,
    [Code]              NVARCHAR (50)  NULL,
    [Description]       NVARCHAR (500) NULL,
    [IsEnable]          BIT            NULL,
    [IsSystem]          BIT            NULL,
    [CreateBy]          INT            NULL,
    [CreateAt]          DATETIME       NULL,
    [LastModifyBy]      INT            NULL,
    [LastModifyAt]      DATETIME       NULL,
    [LastModifyComment] NVARCHAR (300) NULL,
    CONSTRAINT [PK_SystemDictionaryGroup] PRIMARY KEY CLUSTERED ([ID] ASC)
);

