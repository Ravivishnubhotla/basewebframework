CREATE TABLE [dbo].[SPClientCodeSycnParams] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (200)  NOT NULL,
    [Description]       NVARCHAR (2000) NOT NULL,
    [IsEnable]          BIT             NOT NULL,
    [IsRequired]        BIT             NOT NULL,
    [CodeID]            INT             NOT NULL,
    [MappingParams]     NVARCHAR (200)  NOT NULL,
    [Title]             NVARCHAR (200)  NOT NULL,
    [ParamsValue]       NVARCHAR (200)  NOT NULL,
    [ParamsType]        NVARCHAR (20)   NOT NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SPClientCodeSycnParams] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SPClientCodeSycnParams_SPCode] FOREIGN KEY ([CodeID]) REFERENCES [dbo].[SPCode] ([ID]) ON DELETE CASCADE
);

