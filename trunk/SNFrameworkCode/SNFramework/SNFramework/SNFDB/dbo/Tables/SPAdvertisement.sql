CREATE TABLE [dbo].[SPAdvertisement] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50)   NULL,
    [Code]              NVARCHAR (50)   NULL,
    [ImageUrl]          NVARCHAR (200)  NULL,
    [AdPrice]           NVARCHAR (50)   NULL,
    [AccountType]       NVARCHAR (50)   NULL,
    [ApplyStatus]       NVARCHAR (50)   NULL,
    [AdType]            NVARCHAR (50)   NULL,
    [AdText]            NVARCHAR (2000) NULL,
    [Description]       NVARCHAR (2000) NULL,
    [IsDisable]         BIT             NULL,
    [AssignedClient]    INT             NULL,
    [UpperID]           INT             NULL,
    [CreateBy]          INT             NOT NULL,
    [CreateAt]          DATETIME        NOT NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NOT NULL,
    CONSTRAINT [PK_SPAdvertisement] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPAdvertisement_SPUpper] FOREIGN KEY ([UpperID]) REFERENCES [dbo].[SPUpper] ([ID]) ON DELETE CASCADE
);

