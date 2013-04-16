CREATE TABLE [dbo].[SPRecord] (
    [ID]                   INT           IDENTITY (1, 1) NOT NULL,
    [LinkID]               NVARCHAR (50) NOT NULL,
    [MO]                   NVARCHAR (50) NULL,
    [Mobile]               NVARCHAR (15) NOT NULL,
    [SpNumber]             NVARCHAR (20) NULL,
    [Province]             NVARCHAR (6)  NOT NULL,
    [City]                 NVARCHAR (8)  NOT NULL,
    [OperatorType]         NVARCHAR (2)  NOT NULL,
    [CreateDate]           DATETIME      NOT NULL,
    [IsReport]             BIT           NOT NULL,
    [IsIntercept]          BIT           NOT NULL,
    [IsSycnToClient]       BIT           NOT NULL,
    [IsSycnSuccessed]      BIT           NOT NULL,
    [IsStatOK]             BIT           NOT NULL,
    [SycnRetryTimes]       INT           NOT NULL,
    [ChannelID]            INT           NOT NULL,
    [ClientID]             INT           NOT NULL,
    [CodeID]               INT           NOT NULL,
    [ClientCodeRelationID] INT           NULL,
    [Price]                DECIMAL (18)  NULL,
    [Count]                INT           NOT NULL,
    CONSTRAINT [PK_SPRECORD] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPRecord_SPChannel] FOREIGN KEY ([ChannelID]) REFERENCES [dbo].[SPChannel] ([ID]),
    CONSTRAINT [FK_SPRecord_SPClientCodeRelation] FOREIGN KEY ([ClientCodeRelationID]) REFERENCES [dbo].[SPClientCodeRelation] ([ID]),
    CONSTRAINT [FK_SPRecord_SPCode] FOREIGN KEY ([CodeID]) REFERENCES [dbo].[SPCode] ([ID]),
    CONSTRAINT [FK_SPRecord_SPSClient] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[SPSClient] ([ID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SPRecordChannelIDLinkID]
    ON [dbo].[SPRecord]([ChannelID] ASC, [LinkID] ASC);

