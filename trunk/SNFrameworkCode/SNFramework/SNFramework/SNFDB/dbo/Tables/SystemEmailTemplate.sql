CREATE TABLE [dbo].[SystemEmailTemplate] (
    [EmailTemplateID]   INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NULL,
    [Code]              NVARCHAR (200)  NULL,
    [Description]       NVARCHAR (2000) NULL,
    [TemplateType]      NVARCHAR (50)   NULL,
    [TitleTemplate]     NVARCHAR (200)  NULL,
    [BodyTemplate]      NTEXT           NULL,
    [Params]            NVARCHAR (3000) NULL,
    [IsHtmlEmail]       BIT             NULL,
    [IsEnable]          BIT             NULL,
    [CreateAt]          DATETIME        NULL,
    [CreateBy]          INT             NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([EmailTemplateID] ASC)
);

