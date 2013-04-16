CREATE TABLE [dbo].[SystemCity] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [AbbrName]   NVARCHAR (50) NULL,
    [Code]       NVARCHAR (50) NULL,
    [ProvinceID] INT           NULL,
    [Capital]    BIT           NULL,
    CONSTRAINT [PK_SystemCity] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SystemCity_SystemProvince] FOREIGN KEY ([ProvinceID]) REFERENCES [dbo].[SystemProvince] ([ID]) ON DELETE CASCADE
);

