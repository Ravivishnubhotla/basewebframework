CREATE TABLE [dbo].[SPSClient] (
    [ID]                    INT             IDENTITY (1, 1) NOT NULL,
    [Name]                  NVARCHAR (200)  NOT NULL,
    [Description]           NVARCHAR (2000) NOT NULL,
    [UserID]                INT             NOT NULL,
    [IsDefaultClient]       BIT             NULL,
    [SyncData]              BIT             NOT NULL,
    [SycnNotInterceptCount] INT             NULL,
    [SyncDataSetting]       INT             NULL,
    [Alias]                 NVARCHAR (200)  NULL,
    [IsEnable]              BIT             NULL,
    [InterceptRate]         DECIMAL (18, 2) NOT NULL,
    [DefaultPrice]          DECIMAL (18, 2) NOT NULL,
    [DefaultShowRecordDays] INT             NOT NULL,
    [ChannelStatus]         NVARCHAR (20)   NULL,
    [CreateBy]              INT             NULL,
    [CreateAt]              DATETIME        NULL,
    [LastModifyBy]          INT             NULL,
    [LastModifyAt]          DATETIME        NULL,
    [LastModifyComment]     NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SPSClient] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPSClient_SPSDataSycnSetting] FOREIGN KEY ([SyncDataSetting]) REFERENCES [dbo].[SPSDataSycnSetting] ([ID]) ON DELETE SET NULL
);

