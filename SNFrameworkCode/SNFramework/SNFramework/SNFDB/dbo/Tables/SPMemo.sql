CREATE TABLE [dbo].[SPMemo] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (200) NULL,
    [TextContent]       NTEXT          NULL,
    [PublishDate]       DATETIME       NULL,
    [CreateDate]        DATETIME       NULL,
    [CreateBy]          INT            NULL,
    [CreateAt]          DATETIME       NULL,
    [LastModifyBy]      INT            NULL,
    [LastModifyAt]      DATETIME       NULL,
    [LastModifyComment] NVARCHAR (300) NULL,
    CONSTRAINT [PK_SPMEMO] PRIMARY KEY CLUSTERED ([ID] ASC)
);

