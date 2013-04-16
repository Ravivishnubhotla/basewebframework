CREATE TABLE [dbo].[SPParamsConvertRule] (
    [ID]             INT             NOT NULL,
    [ParentDataID]   INT             NULL,
    [ParentDataType] NVARCHAR (50)   NULL,
    [ConvertCode]    NVARCHAR (2000) NULL,
    [ConvertType]    NVARCHAR (50)   NULL,
    CONSTRAINT [PK_SPParamsConvertRule] PRIMARY KEY CLUSTERED ([ID] ASC)
);

