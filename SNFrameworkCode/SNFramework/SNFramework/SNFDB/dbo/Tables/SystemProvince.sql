CREATE TABLE [dbo].[SystemProvince] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NULL,
    [AbbrName]       NVARCHAR (50) NULL,
    [SingleAbbrName] NCHAR (10)    NULL,
    [Code]           NVARCHAR (50) NULL,
    [CountryID]      INT           NULL,
    CONSTRAINT [PK_SystemProvince] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SystemProvince_SystemCountry] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[SystemCountry] ([ID]) ON DELETE CASCADE
);

