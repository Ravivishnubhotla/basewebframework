CREATE TABLE [dbo].[SystemLog] (
    [Log_ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Log_Level]          NVARCHAR (30)  NOT NULL,
    [Log_Type]           NVARCHAR (30)  NULL,
    [Log_Date]           DATETIME       NOT NULL,
    [Log_Source]         NVARCHAR (30)  NOT NULL,
    [Log_User]           NVARCHAR (30)  NOT NULL,
    [Log_Descrption]     NVARCHAR (800) NOT NULL,
    [Log_RequestInfo]    NVARCHAR (300) NULL,
    [Parent_DataID]      INT            NULL,
    [Parent_DataType]    NVARCHAR (50)  NULL,
    [Log_RelateUserID]   INT            NULL,
    [Log_RelateUserName] NVARCHAR (30)  NULL,
    [Log_RelateDateTime] DATETIME       NULL,
    [DataNumber]         NVARCHAR (50)  NULL,
    CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED ([Log_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SystemLog', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_Level', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Level';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_Type', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_Source', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Source';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_User', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_User';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_Descrption', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Descrption';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_RequestInfo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RequestInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_RelateMoudleID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Parent_DataID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_RelateMoudleDataID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Parent_DataType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_RelateUserID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RelateUserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Log_RelateDateTime', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RelateDateTime';

