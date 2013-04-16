CREATE TABLE [dbo].[SystemAddress] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)   NULL,
    [Type]        NVARCHAR (50)   NULL,
    [Description] NVARCHAR (500)  NULL,
    [Country]     NVARCHAR (20)   NULL,
    [Province]    NVARCHAR (20)   NULL,
    [City]        NVARCHAR (50)   NULL,
    [Address1]    NVARCHAR (200)  NULL,
    [Address2]    NVARCHAR (200)  NULL,
    [Address3]    NVARCHAR (200)  NULL,
    [ZipCode]     NVARCHAR (20)   NULL,
    [ParentType]  NVARCHAR (50)   NULL,
    [ParentID]    INT             NULL,
    [Longitude]   DECIMAL (18, 6) NULL,
    [Latitude]    DECIMAL (18, 6) NULL,
    [TimeZoneID]  INT             NULL,
    CONSTRAINT [PK_SystemAddress] PRIMARY KEY CLUSTERED ([ID] ASC)
);

