CREATE TABLE [dbo].[SystemLog] (
    [Log_ID]                 INT             IDENTITY (1, 1) NOT NULL,
    [Log_Level]              NVARCHAR (200)  NOT NULL,
    [Log_Type]               NVARCHAR (200)  NULL,
    [Log_Date]               DATETIME        NOT NULL,
    [Log_Source]             NVARCHAR (200)  NOT NULL,
    [Log_User]               NVARCHAR (200)  NOT NULL,
    [Log_Descrption]         NVARCHAR (2000) NOT NULL,
    [Log_RequestInfo]        NVARCHAR (200)  NULL,
    [Log_RelateMoudleID]     INT             NULL,
    [Log_RelateMoudleDataID] INT             NULL,
    [Log_RelateUserID]       INT             NULL,
    [Log_RelateDateTime]     DATETIME        NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统事件日志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志级别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Level';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志来源', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Source';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志用户', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_User';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志内容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_Descrption';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志请求信息', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RequestInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志相关模块', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RelateMoudleID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志相关模块数据ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RelateMoudleDataID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志相关用户ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RelateUserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志相关时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemLog', @level2type = N'COLUMN', @level2name = N'Log_RelateDateTime';

