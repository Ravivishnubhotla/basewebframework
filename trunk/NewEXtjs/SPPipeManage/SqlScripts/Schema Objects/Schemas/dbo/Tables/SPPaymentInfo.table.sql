CREATE TABLE [dbo].[SPPaymentInfo] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [MobileNumber] NVARCHAR (200)  NULL,
    [ChannelID]    INT             NULL,
    [ClientID]     INT             NULL,
    [Message]      NVARCHAR (2000) NULL,
    [IsIntercept]  BIT             NULL,
    [CreateDate]   DATETIME        NULL,
    [RequestID]    INT             NULL
);

