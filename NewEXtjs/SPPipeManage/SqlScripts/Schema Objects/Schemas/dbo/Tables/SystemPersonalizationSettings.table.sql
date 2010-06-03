CREATE TABLE [dbo].[SystemPersonalizationSettings] (
    [PersonalizationID] INT            IDENTITY (1, 1) NOT NULL,
    [ApplicationID]     INT            NULL,
    [UserId]            INT            NULL,
    [Path]              NVARCHAR (500) NOT NULL,
    [PageSettings]      IMAGE          NOT NULL,
    [LastUpdatedDate]   DATETIME       NULL
);

