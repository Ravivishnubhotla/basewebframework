CREATE TABLE [dbo].[SPClient] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (200)  NULL,
    [Description]    NVARCHAR (2000) NULL,
    [RecieveDataUrl] NVARCHAR (200)  NULL,
    [UserID]         INT             NULL
);

