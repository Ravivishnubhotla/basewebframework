CREATE TABLE [dbo].[SystemVersion] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [VauleField]      NTEXT          NULL,
    [OldChangeFileld] NTEXT          NULL,
    [NewChangeFileld] NTEXT          NULL,
    [Parent_DataType] NVARCHAR (50)  NULL,
    [Parent_DataID]   INT            NULL,
    [ChangeDate]      DATETIME       NULL,
    [ChangeUserID]    INT            NULL,
    [ChangeUserName]  INT            NULL,
    [VersionNumber]   INT            NULL,
    [DataNumber]      NVARCHAR (50)  NULL,
    [Comment]         NVARCHAR (200) NULL,
    CONSTRAINT [PK_SystemVersion] PRIMARY KEY CLUSTERED ([ID] ASC)
);

