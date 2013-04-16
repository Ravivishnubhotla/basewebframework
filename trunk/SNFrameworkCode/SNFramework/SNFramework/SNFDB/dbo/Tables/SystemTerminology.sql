CREATE TABLE [dbo].[SystemTerminology] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NULL,
    [Code]              NVARCHAR (200)  NULL,
    [Description]       NVARCHAR (2000) NULL,
    [Text]              NVARCHAR (2000) NULL,
    [LanguageType]      NVARCHAR (10)   NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemTerminology] PRIMARY KEY CLUSTERED ([ID] ASC)
);

