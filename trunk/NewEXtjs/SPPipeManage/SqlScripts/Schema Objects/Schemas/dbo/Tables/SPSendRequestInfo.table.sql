CREATE TABLE [dbo].[SPSendRequestInfo] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [ToUrl]        INT             NULL,
    [DataID]       INT             NULL,
    [IsSuccess]    BIT             NULL,
    [ErrorCode]    NVARCHAR (50)   NULL,
    [ErrorMessage] NVARCHAR (2000) NULL,
    [SendParans]   NVARCHAR (2000) NULL
);

