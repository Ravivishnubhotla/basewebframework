CREATE TABLE [dbo].[SystemConfig] (
    [SystemConfig_ID]    INT             IDENTITY (1, 1) NOT NULL,
    [Config_Key]         NVARCHAR (200)  NULL,
    [Config_Value]       NVARCHAR (200)  NULL,
    [Config_DataType]    NVARCHAR (10)   NULL,
    [Config_Description] NVARCHAR (2000) NULL,
    [SortIndex]          INT             NULL,
    [Config_GroupID]     INT             NULL,
    [CreateBy]           INT             NULL,
    [CreateAt]           DATETIME        NULL,
    [LastModifyBy]       INT             NULL,
    [LastModifyAt]       DATETIME        NULL,
    [LastModifyComment]  NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SYSTEMCONFIG] PRIMARY KEY CLUSTERED ([SystemConfig_ID] ASC),
    CONSTRAINT [FK_SystemConfig_SystemConfigGroup] FOREIGN KEY ([Config_GroupID]) REFERENCES [dbo].[SystemConfigGroup] ([ID]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'SystemConfig', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemConfig';

