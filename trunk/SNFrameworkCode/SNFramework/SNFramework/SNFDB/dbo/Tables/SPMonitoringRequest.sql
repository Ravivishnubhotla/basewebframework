CREATE TABLE [dbo].[SPMonitoringRequest] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [RecievedContent] NTEXT          NULL,
    [RecievedDate]    DATETIME       NULL,
    [RecievedIP]      NVARCHAR (50)  NULL,
    [RecievedSendUrl] NVARCHAR (500) NULL,
    [ChannelID]       INT            NULL,
    CONSTRAINT [PK_SPMonitoringRequest] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPMonitoringRequest_SPChannel] FOREIGN KEY ([ChannelID]) REFERENCES [dbo].[SPChannel] ([ID])
);

