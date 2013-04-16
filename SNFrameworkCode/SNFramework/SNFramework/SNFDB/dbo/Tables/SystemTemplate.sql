CREATE TABLE [dbo].[SystemTemplate] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NULL,
    [Code]              NVARCHAR (200)  NULL,
    [Description]       NVARCHAR (2000) NULL,
    [TemplateType]      NVARCHAR (50)   NULL,
    [Template]          NTEXT           NULL,
    [Params]            NVARCHAR (3000) NULL,
    [IsEnable]          BIT             NULL,
    [CreateAt]          DATETIME        NULL,
    [CreateBy]          INT             NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_Table_SystemTemplate] PRIMARY KEY CLUSTERED ([ID] ASC)
);

