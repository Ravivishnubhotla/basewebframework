CREATE TABLE [dbo].[SystemRichText] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Type]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (200) NULL,
    [TextContent] NTEXT          NULL,
    [ParentType]  NVARCHAR (50)  NULL,
    [ParentID]    INT            NULL,
    CONSTRAINT [PK_SystemRichText] PRIMARY KEY CLUSTERED ([ID] ASC)
);

