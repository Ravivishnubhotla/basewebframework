CREATE TABLE [dbo].[SystemTask] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (200)  NULL,
    [TaskContent]       NVARCHAR (2000) NULL,
    [AssignedUserID]    INT             NULL,
    [Status]            NVARCHAR (10)   NULL,
    [DateDue]           DATETIME        NULL,
    [DateStart]         DATETIME        NULL,
    [FinishedDate]      DATETIME        NULL,
    [IsAlertInHome]     BIT             NULL,
    [IsRead]            BIT             NULL,
    [Priority]          NVARCHAR (10)   NULL,
    [Parent_DataID]     INT             NULL,
    [Parent_DataType]   NVARCHAR (50)   NULL,
    [CreateBy]          INT             NULL,
    [CreateAt]          DATETIME        NULL,
    [LastModifyBy]      INT             NULL,
    [LastModifyAt]      DATETIME        NULL,
    [LastModifyComment] NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemTask] PRIMARY KEY CLUSTERED ([ID] ASC)
);

