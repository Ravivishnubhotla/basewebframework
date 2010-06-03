CREATE TABLE [dbo].[SystemShortMessage] (
    [ShortMessage_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [ShortMessage_Title]       NVARCHAR (200)  NOT NULL,
    [ShortMessage_Category]    NVARCHAR (200)  NULL,
    [ShortMessage_Content]     NVARCHAR (4000) NULL,
    [ShortMessage_Sender]      NVARCHAR (200)  NULL,
    [ShortMessage_Send_Date]   DATETIME        NOT NULL,
    [ShortMessage_Receiver_ID] INT             NOT NULL,
    [ShortMessage_IsRead]      BIT             NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统短消息', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'标题', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'内容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_Content';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'发送者ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_Sender';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'发送日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_Send_Date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接受者ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_Receiver_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否已读', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemShortMessage', @level2type = N'COLUMN', @level2name = N'ShortMessage_IsRead';

