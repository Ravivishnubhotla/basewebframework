CREATE TABLE [dbo].[SystemCountry] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [CodeNumber] NVARCHAR (10) NULL,
    [Code2]      NVARCHAR (2)  NULL,
    [Code3]      NVARCHAR (3)  NULL,
    [AbbrNameCN] NVARCHAR (30) NULL,
    [AbbrNameEN] NVARCHAR (50) NULL,
    [FullNameCn] NVARCHAR (80) NULL,
    [FullNameEn] NVARCHAR (80) NULL,
    CONSTRAINT [PK_SystemCountry] PRIMARY KEY CLUSTERED ([ID] ASC)
);

