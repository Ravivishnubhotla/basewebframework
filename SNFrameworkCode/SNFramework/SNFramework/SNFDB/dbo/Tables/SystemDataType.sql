CREATE TABLE [dbo].[SystemDataType] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50)   NULL,
    [Code]              NVARCHAR (50)   NULL,
    [Description]       NVARCHAR (2000) NULL,
    [TableName]         NVARCHAR (20)   NULL,
    [IDFieldName]       NVARCHAR (20)   NULL,
    [ClassFullName]     NVARCHAR (50)   NULL,
    [AssemblyName]      NVARCHAR (20)   NULL,
    [LoadMethodName]    NVARCHAR (50)   NULL,
    [SaveMethodName]    NVARCHAR (50)   NULL,
    [UpdateMethodName]  NVARCHAR (50)   NULL,
    [DeleteMethodName]  NVARCHAR (50)   NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemDataType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

