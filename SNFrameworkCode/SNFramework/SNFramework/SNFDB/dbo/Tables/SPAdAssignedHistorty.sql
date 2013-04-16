CREATE TABLE [dbo].[SPAdAssignedHistorty] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [SPAdID]            INT             NULL,
    [SPAdPackID]        INT             NULL,
    [SPClientID]        INT             NULL,
    [ClientPrice]       DECIMAL (18, 2) NULL,
    [StartDate]         DATETIME        NULL,
    [EndDate]           DATETIME        NULL,
    [CreateBy]          INT             NOT NULL,
    [CreateAt]          DATETIME        NOT NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NOT NULL,
    CONSTRAINT [PK_SPAdAssignedHistorty] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPAdAssignedHistorty_SPAdPack] FOREIGN KEY ([SPAdPackID]) REFERENCES [dbo].[SPAdPack] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SPAdAssignedHistorty_SPSClient] FOREIGN KEY ([SPClientID]) REFERENCES [dbo].[SPSClient] ([ID]) ON DELETE SET NULL
);

