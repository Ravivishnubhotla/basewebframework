CREATE TABLE [dbo].[SystemIPLocation] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [StartIPNum]  DECIMAL (18, 2) NOT NULL,
    [StartIPText] NVARCHAR (15)   NULL,
    [EndIPNum]    DECIMAL (18, 2) NOT NULL,
    [EndIPText]   NVARCHAR (15)   NULL,
    [Country]     NVARCHAR (255)  NULL,
    [Local]       NVARCHAR (255)  NULL,
    CONSTRAINT [PK_SystemIPLocation] PRIMARY KEY CLUSTERED ([ID] ASC)
);

