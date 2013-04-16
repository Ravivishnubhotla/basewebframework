CREATE TABLE [dbo].[SystemSetting] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [SystemName]        NVARCHAR (200)  NOT NULL,
    [SystemDescription] NVARCHAR (2000) NULL,
    [SystemUrl]         NVARCHAR (200)  NULL,
    [SystemVersion]     NVARCHAR (200)  NOT NULL,
    [SystemLisence]     NVARCHAR (2000) NOT NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);

