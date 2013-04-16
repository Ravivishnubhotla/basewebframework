CREATE TABLE [dbo].[SPFilterRule] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [ParentDataID]   INT             NULL,
    [ParentDataType] NVARCHAR (50)   NULL,
    [RuleCode]       NVARCHAR (2000) NULL,
    [FilterType]     NVARCHAR (50)   NULL,
    CONSTRAINT [PK_SPFilterRule] PRIMARY KEY CLUSTERED ([ID] ASC)
);

