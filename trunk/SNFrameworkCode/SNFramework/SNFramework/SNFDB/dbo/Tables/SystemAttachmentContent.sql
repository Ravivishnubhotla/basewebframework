CREATE TABLE [dbo].[SystemAttachmentContent] (
    [ID]          INT   IDENTITY (1, 1) NOT NULL,
    [AttacmentID] INT   NULL,
    [FileContent] IMAGE NOT NULL,
    CONSTRAINT [PK_SystemAttachmentContent] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SystemAttachmentContent_SystemAttachment] FOREIGN KEY ([AttacmentID]) REFERENCES [dbo].[SystemAttachment] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

