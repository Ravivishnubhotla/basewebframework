CREATE TABLE [dbo].[SPChannel] (
    [ID]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (200)  NULL,
    [Description]     NVARCHAR (2000) NULL,
    [Area]            NVARCHAR (2000) NULL,
    [Operator]        NVARCHAR (200)  NULL,
    [ChannelCode]     NVARCHAR (200)  NULL,
    [FuzzyCommand]    NVARCHAR (200)  NULL,
    [AccurateCommand] NVARCHAR (200)  NULL,
    [Port]            NVARCHAR (200)  NULL,
    [ChannelType]     NVARCHAR (200)  NULL,
    [Price]           DECIMAL (18)    NULL,
    [Rate]            INT             NULL,
    [Status]          INT             NULL,
    [CreateTime]      DATETIME        NULL,
    [CreateBy]        INT             NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'短行通道', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'描述', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'支持区域', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Area';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'运营商', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Operator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'通道编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'ChannelCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模糊指令', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'FuzzyCommand';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'精准指令', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'AccurateCommand';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'端口号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Port';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'通道类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'ChannelType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'价格', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Price';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'分成比例', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Rate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'CreateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SPChannel', @level2type = N'COLUMN', @level2name = N'CreateBy';

