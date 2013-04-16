CREATE TABLE [dbo].[SystemAttachment] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NULL,
    [Type]              NVARCHAR (30)   NULL,
    [Description]       NVARCHAR (2000) NULL,
    [FileName]          NVARCHAR (200)  NULL,
    [MD5]               NVARCHAR (30)   NULL,
    [Size]              INT             NULL,
    [FileExt]           NVARCHAR (10)   NULL,
    [Pages]             INT             NULL,
    [FilePath]          NVARCHAR (200)  NULL,
    [ParentType]        NVARCHAR (50)   NULL,
    [ParentID]          INT             NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemAttachment] PRIMARY KEY CLUSTERED ([ID] ASC)
);

