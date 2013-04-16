CREATE TABLE [dbo].[SystemDictionary] (
    [SystemDictionary_ID]         INT             IDENTITY (1, 1) NOT NULL,
    [SystemDictionary_GroupID]    INT             NULL,
    [SystemDictionary_Key]        NVARCHAR (50)   NULL,
    [SystemDictionary_Code]       NVARCHAR (50)   NULL,
    [SystemDictionary_Value]      NVARCHAR (200)  NULL,
    [SystemDictionary_Desciption] NVARCHAR (2000) NULL,
    [SystemDictionary_Order]      INT             NULL,
    [SystemDictionary_IsEnable]   BIT             NULL,
    [SystemDictionary_IsSystem]   BIT             NULL,
    [CreateBy]                    INT             NULL,
    [CreateAt]                    DATETIME        NULL,
    [LastModifyBy]                INT             NULL,
    [LastModifyAt]                DATETIME        NULL,
    [LastModifyComment]           NVARCHAR (300)  NULL,
    CONSTRAINT [PK_SystemDictionary] PRIMARY KEY CLUSTERED ([SystemDictionary_ID] ASC),
    CONSTRAINT [FK_SystemDictionary_SystemDictionaryGroup] FOREIGN KEY ([SystemDictionary_GroupID]) REFERENCES [dbo].[SystemDictionaryGroup] ([ID]) ON DELETE CASCADE
);

