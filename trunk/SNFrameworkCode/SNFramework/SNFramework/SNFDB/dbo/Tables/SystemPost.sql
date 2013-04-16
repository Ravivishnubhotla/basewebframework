CREATE TABLE [dbo].[SystemPost] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50)   NULL,
    [Code]              NVARCHAR (50)   NULL,
    [Description]       NVARCHAR (2000) NULL,
    [OrganizationID]    INT             NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemPost] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SystemPost_SystemOrganization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[SystemOrganization] ([ID]) ON DELETE CASCADE
);

