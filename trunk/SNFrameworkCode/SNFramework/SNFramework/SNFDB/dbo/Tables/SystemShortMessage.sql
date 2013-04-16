CREATE TABLE [dbo].[SystemShortMessage] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (200)  NOT NULL,
    [MessageType]       NVARCHAR (50)   NULL,
    [Category]          NVARCHAR (200)  NULL,
    [MsgContent]        NVARCHAR (4000) NULL,
    [SendID]            INT             NULL,
    [GroupID]           INT             NULL,
    [SendDate]          DATETIME        NOT NULL,
    [Status]            NVARCHAR (50)   NULL,
    [ReplyID]           INT             NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemShortMessage] PRIMARY KEY CLUSTERED ([ID] ASC)
);

