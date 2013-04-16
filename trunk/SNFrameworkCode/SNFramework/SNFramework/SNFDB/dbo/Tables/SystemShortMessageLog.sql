CREATE TABLE [dbo].[SystemShortMessageLog] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [RecID]     INT           NULL,
    [MessageID] INT           NULL,
    [Statue]    NVARCHAR (50) NULL,
    CONSTRAINT [PK_SystemShortMessageLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);

