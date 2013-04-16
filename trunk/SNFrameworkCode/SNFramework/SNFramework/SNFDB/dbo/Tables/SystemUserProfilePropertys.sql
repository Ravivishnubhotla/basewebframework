CREATE TABLE [dbo].[SystemUserProfilePropertys] (
    [Property_ID]          INT             NOT NULL,
    [Property_Name]        NVARCHAR (500)  NOT NULL,
    [Property_Description] NVARCHAR (2000) NULL,
    CONSTRAINT [PK_SystemProfile] PRIMARY KEY CLUSTERED ([Property_ID] ASC)
);

