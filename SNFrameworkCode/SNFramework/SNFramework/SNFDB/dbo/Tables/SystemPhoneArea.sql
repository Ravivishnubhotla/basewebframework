CREATE TABLE [dbo].[SystemPhoneArea] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [PhonePrefix]  CHAR (7)      NOT NULL,
    [Province]     NVARCHAR (12) NOT NULL,
    [City]         NVARCHAR (12) NULL,
    [OperatorType] NVARCHAR (2)  NOT NULL,
    [CardType]     NVARCHAR (15) NULL,
    [AreaCode]     NVARCHAR (6)  NULL,
    [ZipCode]      NVARCHAR (8)  NULL,
    CONSTRAINT [PK_SystemPhoneArea] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemPhoneArea_OperatorType]
    ON [dbo].[SystemPhoneArea]([OperatorType] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemPhoneArea_PhonePrefix]
    ON [dbo].[SystemPhoneArea]([PhonePrefix] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemPhoneArea_Province]
    ON [dbo].[SystemPhoneArea]([Province] ASC);

