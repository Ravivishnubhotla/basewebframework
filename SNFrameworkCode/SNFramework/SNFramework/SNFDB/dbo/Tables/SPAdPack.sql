CREATE TABLE [dbo].[SPAdPack] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [SPAdID]      INT             NULL,
    [Name]        NVARCHAR (50)   NULL,
    [Code]        NVARCHAR (50)   NULL,
    [Description] NVARCHAR (50)   NULL,
    [AdPrice]     DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_SPAdPack] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPAdPack_SPAdvertisement] FOREIGN KEY ([SPAdID]) REFERENCES [dbo].[SPAdvertisement] ([ID]) ON DELETE CASCADE
);

