CREATE TABLE [dbo].[SPAdReport] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [SPAdID]            INT             NULL,
    [SPPackID]          INT             NULL,
    [SPClientID]        INT             NULL,
    [ReportDate]        DATETIME        NULL,
    [ClientCount]       INT             NULL,
    [AdCount]           INT             NULL,
    [AdUseCount]        INT             NULL,
    [AdClientUseCount]  INT             NULL,
    [AdDownCount]       INT             NULL,
    [AdClientDownCount] INT             NULL,
    [AdAmount]          DECIMAL (18, 2) NULL,
    [ClientAmount]      DECIMAL (18, 2) NULL,
    [CreateBy]          INT             NOT NULL,
    [CreateAt]          DATETIME        NOT NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NOT NULL,
    CONSTRAINT [PK_SPAdAmount] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPAdReport_SPAdPack] FOREIGN KEY ([SPPackID]) REFERENCES [dbo].[SPAdPack] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SPAdReport_SPSClient] FOREIGN KEY ([SPClientID]) REFERENCES [dbo].[SPSClient] ([ID]) ON DELETE CASCADE
);

