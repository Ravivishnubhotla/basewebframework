CREATE TABLE [dbo].[SystemTimeZone] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (200) NOT NULL,
    [NameCn]         NVARCHAR (200) NULL,
    [DisplayName]    NVARCHAR (200) NOT NULL,
    [DisplayNameCn]  NVARCHAR (200) NULL,
    [StandardName]   NVARCHAR (200) NOT NULL,
    [StandardNameCn] NVARCHAR (200) NULL,
    [DaylightName]   NVARCHAR (200) NOT NULL,
    [UTCOffset]      INT            CONSTRAINT [DF_TimeZones_Offset] DEFAULT ((0)) NOT NULL,
    [SupportDST]     BIT            NOT NULL,
    [DaylightDelta]  INT            NOT NULL,
    CONSTRAINT [PK_TimeZone] PRIMARY KEY CLUSTERED ([ID] ASC)
);

