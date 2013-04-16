CREATE TABLE [dbo].[SPChannelParams] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NOT NULL,
    [Description]       NVARCHAR (2000) NOT NULL,
    [IsEnable]          BIT             NOT NULL,
    [IsRequired]        BIT             NOT NULL,
    [ParamsType]        NVARCHAR (20)   NULL,
    [ChannelID]         INT             NOT NULL,
    [ParamsMappingName] NVARCHAR (200)  NOT NULL,
    [Title]             NVARCHAR (200)  NOT NULL,
    [ShowInClientGrid]  BIT             CONSTRAINT [DF_SPChannelParams_ShowInClientGrid_1] DEFAULT ((1)) NOT NULL,
    [ParamsValue]       NVARCHAR (200)  NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SPChannelParams] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPChannelParams_SPChannel] FOREIGN KEY ([ChannelID]) REFERENCES [dbo].[SPChannel] ([ID]) ON DELETE CASCADE
);

