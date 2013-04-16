CREATE TABLE [dbo].[SystemPersonalizationSettings] (
    [PersonalizationID] INT            IDENTITY (1, 1) NOT NULL,
    [ApplicationID]     INT            NULL,
    [UserId]            INT            NULL,
    [Path]              NVARCHAR (500) NOT NULL,
    [PageSettings]      IMAGE          NOT NULL,
    [LastUpdatedDate]   DATETIME       NULL,
    [CreateBy]          INT            NULL,
    [CreateAt]          DATETIME       NULL,
    [LastModifyBy]      INT            NULL,
    [LastModifyAt]      DATETIME       NULL,
    [LastModifyComment] NVARCHAR (300) NULL,
    CONSTRAINT [PK_SystemPersonalizationSettings] PRIMARY KEY CLUSTERED ([PersonalizationID] ASC),
    CONSTRAINT [FK_SystemPersonalizationSettings_SystemApplication] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[SystemApplication] ([SystemApplication_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SystemPersonalizationSettings_SystemUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[SystemUser] ([User_ID]) ON DELETE CASCADE
);

