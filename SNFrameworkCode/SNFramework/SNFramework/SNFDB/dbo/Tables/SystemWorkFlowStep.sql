CREATE TABLE [dbo].[SystemWorkFlowStep] (
    [WorkFlowStepID]    INT             NOT NULL,
    [Name]              NVARCHAR (200)  NULL,
    [Code]              NVARCHAR (200)  NULL,
    [Description]       NVARCHAR (2000) NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemWorkFlowStep] PRIMARY KEY CLUSTERED ([WorkFlowStepID] ASC)
);

