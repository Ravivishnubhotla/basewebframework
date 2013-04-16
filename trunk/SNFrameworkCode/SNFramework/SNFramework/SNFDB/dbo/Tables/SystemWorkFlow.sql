CREATE TABLE [dbo].[SystemWorkFlow] (
    [WorkFlowID]        INT            NOT NULL,
    [Name]              NCHAR (10)     NULL,
    [Code]              NCHAR (10)     NULL,
    [Description]       NCHAR (10)     NULL,
    [IsSystemFlow]      NCHAR (10)     NULL,
    [IsDelete]          NCHAR (10)     NULL,
    [IsEnable]          NCHAR (10)     NULL,
    [CreateBy]          INT            NULL,
    [CreateAt]          DATETIME       NULL,
    [LastModifyBy]      INT            NULL,
    [LastModifyAt]      DATETIME       NULL,
    [LastModifyComment] NVARCHAR (300) NULL,
    CONSTRAINT [PK_SystemWorkFlow] PRIMARY KEY CLUSTERED ([WorkFlowID] ASC)
);

