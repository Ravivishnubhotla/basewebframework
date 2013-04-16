CREATE TABLE [dbo].[SPCodeInfo] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [SPCodeID]    INT             NULL,
    [Province]    NVARCHAR (200)  NULL,
    [DisableCity] NVARCHAR (200)  NULL,
    [DayLimit]    NVARCHAR (200)  NULL,
    [MonthLimit]  NVARCHAR (200)  NULL,
    [SendText]    NVARCHAR (4000) NULL,
    CONSTRAINT [PK_SPCodeInfo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPCodeInfo_SPCode] FOREIGN KEY ([SPCodeID]) REFERENCES [dbo].[SPCode] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

