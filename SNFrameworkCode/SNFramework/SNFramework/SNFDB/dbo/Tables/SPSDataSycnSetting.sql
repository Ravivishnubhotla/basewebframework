CREATE TABLE [dbo].[SPSDataSycnSetting] (
    [ID]                    INT            NOT NULL,
    [SycnRetryTimes]        INT            NULL,
    [SyncType]              NVARCHAR (50)  NULL,
    [SycnMO]                BIT            NULL,
    [SycnMOUrl]             NVARCHAR (200) NULL,
    [SycnMOOkMessage]       NVARCHAR (50)  NULL,
    [SycnMOFailedMessage]   NVARCHAR (50)  NULL,
    [SycnMR]                BIT            NULL,
    [SycnMRUrl]             NVARCHAR (200) NULL,
    [SycnMROkMessage]       NVARCHAR (50)  NULL,
    [SycnMRFailedMessage]   NVARCHAR (50)  NULL,
    [SycnSate]              BIT            NULL,
    [SycnSateUrl]           NVARCHAR (200) NULL,
    [SycnSateOkMessage]     NVARCHAR (50)  NULL,
    [SycnSateFailedMessage] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_SPSDataSycnSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);

