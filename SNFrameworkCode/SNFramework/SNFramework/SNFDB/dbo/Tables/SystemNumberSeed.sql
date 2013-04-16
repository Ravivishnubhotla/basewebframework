CREATE TABLE [dbo].[SystemNumberSeed] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50)  NULL,
    [Code]              NVARCHAR (50)  NULL,
    [Description]       NVARCHAR (50)  NULL,
    [IsActive]          BIT            NULL,
    [Format]            NVARCHAR (100) NULL,
    [CurrentNumber]     INT            NULL,
    [CreateBy]          INT            NULL,
    [CreateAt]          DATETIME       NULL,
    [LastModifyBy]      INT            NULL,
    [LastModifyAt]      DATETIME       NULL,
    [LastModifyComment] NVARCHAR (300) NULL,
    CONSTRAINT [PK_SystemNumberSeed] PRIMARY KEY CLUSTERED ([ID] ASC)
);

