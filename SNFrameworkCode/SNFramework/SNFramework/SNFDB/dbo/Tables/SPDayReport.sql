CREATE TABLE [dbo].[SPDayReport] (
    [ID]                INT      IDENTITY (1, 1) NOT NULL,
    [ReportDate]        DATETIME NOT NULL,
    [TotalCount]        INT      NOT NULL,
    [TotalSuccessCount] INT      NOT NULL,
    [InterceptCount]    INT      NOT NULL,
    [DownTotalCount]    INT      NOT NULL,
    [DownSycnSuccess]   INT      NOT NULL,
    [DownSycnFailed]    INT      NOT NULL,
    [DownNotSycn]       INT      NOT NULL,
    [ClientID]          INT      NOT NULL,
    [ChannelID]         INT      NOT NULL,
    [CodeID]            INT      NOT NULL,
    [UperID]            INT      NULL,
    CONSTRAINT [PK_SPDayReport] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPDayReport_SPChannel] FOREIGN KEY ([ChannelID]) REFERENCES [dbo].[SPChannel] ([ID]),
    CONSTRAINT [FK_SPDayReport_SPCode] FOREIGN KEY ([CodeID]) REFERENCES [dbo].[SPCode] ([ID]),
    CONSTRAINT [FK_SPDayReport_SPDayReport] FOREIGN KEY ([ID]) REFERENCES [dbo].[SPDayReport] ([ID]),
    CONSTRAINT [FK_SPDayReport_SPSClient] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[SPSClient] ([ID]),
    CONSTRAINT [FK_SPDayReport_SPUpper] FOREIGN KEY ([UperID]) REFERENCES [dbo].[SPUpper] ([ID])
);

