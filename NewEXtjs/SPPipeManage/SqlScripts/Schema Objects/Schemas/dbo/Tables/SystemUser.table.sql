CREATE TABLE [dbo].[SystemUser] (
    [User_ID]                     INT             IDENTITY (1, 1) NOT NULL,
    [User_LoginID]                NVARCHAR (50)   NOT NULL,
    [User_Name]                   NVARCHAR (50)   NOT NULL,
    [User_Email]                  NVARCHAR (50)   NOT NULL,
    [User_Password]               NVARCHAR (50)   NOT NULL,
    [User_Status]                 NVARCHAR (50)   NOT NULL,
    [User_Create_Date]            DATETIME        NOT NULL,
    [User_Type]                   NVARCHAR (50)   NOT NULL,
    [Department_ID]               INT             NULL,
    [MobilePIN]                   NVARCHAR (50)   NULL,
    [PasswordFormat]              INT             NOT NULL,
    [PasswordSalt]                NVARCHAR (128)  NOT NULL,
    [LoweredEmail]                NVARCHAR (128)  NULL,
    [PasswordQuestion]            NVARCHAR (255)  NULL,
    [PasswordAnswer]              NVARCHAR (255)  NULL,
    [Comments]                    NVARCHAR (3000) NULL,
    [IsApproved]                  BIT             NOT NULL,
    [IsLockedOut]                 BIT             NOT NULL,
    [LastActivityDate]            DATETIME        NOT NULL,
    [LastLoginDate]               DATETIME        NOT NULL,
    [LastLockedOutDate]           DATETIME        NOT NULL,
    [LastPasswordChangeDate]      DATETIME        NOT NULL,
    [FailedPwdAttemptCnt]         INT             NOT NULL,
    [FailedPwdAttemptWndStart]    DATETIME        NOT NULL,
    [FailedPwdAnsAttemptCnt]      INT             NOT NULL,
    [FailedPwdAnsAttemptWndStart] DATETIME        NOT NULL,
    [IsNeedChgPwd]                BIT             NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'System User', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primary Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Login ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_LoginID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'User Name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Email', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_Email';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Password', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_Password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Create Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_Create_Date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'User Type', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'User_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Department', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'Department_ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'MobilePIN', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'MobilePIN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'PasswordF ormat', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'PasswordFormat';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Password Salt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'PasswordSalt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Lowered Email', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'LoweredEmail';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Password Question', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'PasswordQuestion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Password Answer', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'PasswordAnswer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Comments', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'Comments';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is Approved', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'IsApproved';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Is Locked Out', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'IsLockedOut';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last Activity Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'LastActivityDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last Login Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'LastLoginDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last Locked Out Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'LastLockedOutDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Last Password Change Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'LastPasswordChangeDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Failed Password Attempt Count', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'FailedPwdAttemptCnt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Failed Password Attempt DateTime', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'FailedPwdAttemptWndStart';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Failed Password Answer Attempt Count', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'FailedPwdAnsAttemptCnt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Failed Password Answer Attempt DateTime', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SystemUser', @level2type = N'COLUMN', @level2name = N'FailedPwdAnsAttemptWndStart';

