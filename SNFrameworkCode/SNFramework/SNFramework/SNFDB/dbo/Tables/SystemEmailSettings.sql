CREATE TABLE [dbo].[SystemEmailSettings] (
    [EmailSettingID]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NULL,
    [Code]              NVARCHAR (200)  NULL,
    [Descriprsion]      NVARCHAR (2000) NULL,
    [Host]              NVARCHAR (200)  NULL,
    [Port]              NVARCHAR (200)  NULL,
    [SSL]               BIT             NULL,
    [FromEmail]         NVARCHAR (200)  NULL,
    [FromName]          NVARCHAR (200)  NULL,
    [LoginEmail]        NVARCHAR (200)  NULL,
    [LoginPassword]     NVARCHAR (200)  NULL,
    [IsEnable]          BIT             NULL,
    [IsDefault]         BIT             NULL,
    [OrderIndex]        INT             NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemEmailSettings] PRIMARY KEY CLUSTERED ([EmailSettingID] ASC)
);

