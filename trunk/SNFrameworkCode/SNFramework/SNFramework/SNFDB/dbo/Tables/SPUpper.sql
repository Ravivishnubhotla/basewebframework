CREATE TABLE [dbo].[SPUpper] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NOT NULL,
    [Code]              NVARCHAR (200)  NOT NULL,
    [Description]       NVARCHAR (2000) NOT NULL,
    [CreateBy]          INT             NOT NULL,
    [CreateAt]          DATETIME        NOT NULL,
    [LastModifyBy]      INT             NOT NULL,
    [LastModifyAt]      DATETIME        NOT NULL,
    [LastModifyComment] NVARCHAR (300)  NOT NULL,
    CONSTRAINT [PK_SPUPPER] PRIMARY KEY CLUSTERED ([ID] ASC)
);

