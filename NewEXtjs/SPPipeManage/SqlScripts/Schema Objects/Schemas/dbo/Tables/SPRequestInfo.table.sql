CREATE TABLE [dbo].[SPRequestInfo] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [IP]          NVARCHAR (200)  NULL,
    [RequestInfo] NVARCHAR (2000) NULL,
    [RequestDate] DATETIME        NULL,
    [IsToPayment] BIT             NULL,
    [RequestUrl]  NVARCHAR (2000) NULL,
    [DataID]      INT             NULL
);

