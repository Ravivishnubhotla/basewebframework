
--|--------------------------------------------------------------------------------
--| [SystemApplication] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemApplication] ON

	INSERT INTO [SystemApplication]
	([SystemApplication_ID], [SystemApplication_Name], [SystemApplication_Code], [SystemApplication_Description], [SystemApplication_Url], [SystemApplication_IsSystemApplication], [OrderIndex])
	VALUES
	(36, '[L]Application.BaseSystemModule', 'Base System Module', 'Base System Module', '#', 1, NULL);

	INSERT INTO [SystemApplication]
	([SystemApplication_ID], [SystemApplication_Name], [SystemApplication_Code], [SystemApplication_Description], [SystemApplication_Url], [SystemApplication_IsSystemApplication], [OrderIndex])
	VALUES
	(38, '��������ģ��', 'ECommence Moudle', '��������ģ��', '#', 1, NULL);

	INSERT INTO [SystemApplication]
	([SystemApplication_ID], [SystemApplication_Name], [SystemApplication_Code], [SystemApplication_Description], [SystemApplication_Url], [SystemApplication_IsSystemApplication], [OrderIndex])
	VALUES
	(39, '��������ģ��', 'SP Moudle', '��������ģ��', '#', 1, NULL);

	INSERT INTO [SystemApplication]
	([SystemApplication_ID], [SystemApplication_Name], [SystemApplication_Code], [SystemApplication_Description], [SystemApplication_Url], [SystemApplication_IsSystemApplication], [OrderIndex])
	VALUES
	(40, '���ݹ���ģ��', 'Content Moudle', '���ݹ���ģ��', '#', 1, NULL);

	INSERT INTO [SystemApplication]
	([SystemApplication_ID], [SystemApplication_Name], [SystemApplication_Code], [SystemApplication_Description], [SystemApplication_Url], [SystemApplication_IsSystemApplication], [OrderIndex])
	VALUES
	(48, '�ĵ�����ģ��', 'Document Module', '�ĵ�����ģ��', '#', 1, NULL);
	SET IDENTITY_INSERT [SystemApplication] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------

--|--------------------------------------------------------------------------------
--| [SystemRole] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemRole] ON

	INSERT INTO [SystemRole]
	([Role_ID], [Role_Name], [Role_Code], [Role_Description], [Role_IsSystemRole], [Role_Type], [CreateBy], [CreateDate], [LastUpdateBy], [LastUpdateDate])
	VALUES
	(3, 'df', 'dsf', 'sdfsdf', 0, NULL, NULL, NULL, NULL, NULL);
	SET IDENTITY_INSERT [SystemRole] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------

--|--------------------------------------------------------------------------------
--| [SystemSetting] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemSetting] ON

	INSERT INTO [SystemSetting]
	([ID], [SystemName], [SystemDescription], [SystemUrl], [SystemVersion], [SystemLisence])
	VALUES
	(1, '[L]Setting.SystemName', '', '#', '1.0.0', '[L]Setting.SystemLisence');
	SET IDENTITY_INSERT [SystemSetting] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------

--|--------------------------------------------------------------------------------
--| [SystemUser] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemUser] ON

	INSERT INTO [SystemUser]
	([User_ID], [User_LoginID], [User_Name], [User_Email], [User_Password], [User_Status], [User_Create_Date], [User_Type], [Department_ID], [MobilePIN], [PasswordFormat], [PasswordQuestion], [PasswordAnswer], [Comments], [IsApproved], [IsLockedOut], [LastActivityDate], [LastLoginDate], [LastLockedOutDate], [LastPasswordChangeDate], [FailedPwdAttemptCnt], [FailedPwdAttemptWndStart], [FailedPwdAnsAttemptCnt], [FailedPwdAnsAttemptWndStart], [IsNeedChgPwd], [PasswordSalt], [LoweredEmail])
	VALUES
	(25, 'DeveloperAdministrator', 'Developer Administrator', '111@163.com', 'QY5SzM2HG5Gf9j6OY9Gt9X/FgEg=', '', '01/01/2009 00:00:00', '1', NULL, '', 1, NULL, NULL, ' ', 1, 0, '03/22/2010 18:04:20', '08/21/2011 11:35:26', '01/01/2009 00:00:00', '03/22/2010 18:04:20', 1, '04/05/2011 14:01:36', 0, '01/01/2009 00:00:00', 0, 'B2F3DD3DA842C720CDB21835359D593EA6DBF0E748289FD33D4495F0B6A19E400779AF066FC7AC2D02FB5E6846D4B212C1F5FDA6AD292E10B60BFA124656B570', '');

	INSERT INTO [SystemUser]
	([User_ID], [User_LoginID], [User_Name], [User_Email], [User_Password], [User_Status], [User_Create_Date], [User_Type], [Department_ID], [MobilePIN], [PasswordFormat], [PasswordQuestion], [PasswordAnswer], [Comments], [IsApproved], [IsLockedOut], [LastActivityDate], [LastLoginDate], [LastLockedOutDate], [LastPasswordChangeDate], [FailedPwdAttemptCnt], [FailedPwdAttemptWndStart], [FailedPwdAnsAttemptCnt], [FailedPwdAnsAttemptWndStart], [IsNeedChgPwd], [PasswordSalt], [LoweredEmail])
	VALUES
	(28, 'TestUser', 'TestUser', 'TestUser@163.com', '225DSeUS1HgOem4XfhxueZW66IM=', '', '05/16/2011 02:14:17', '', NULL, NULL, 1, NULL, NULL, NULL, 1, 0, '01/01/1753 00:00:00', '01/01/1753 00:00:00', '01/01/1753 00:00:00', '01/01/1753 00:00:00', 0, '01/01/1753 00:00:00', 0, '01/01/1753 00:00:00', 0, '45CD6463ECF872DFEB844660544965C25A9712866C71B38411AFAC63FDFB56D912492D4C11099EDC8B05691DC20B63BD6B9468A7AD428AC1C62C91F72423A52A', NULL);
	SET IDENTITY_INSERT [SystemUser] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------











--|--------------------------------------------------------------------------------
--| [SystemMenu] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemMenu] ON

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(43, '[L]Menu.SystemManage', NULL, 'System Manage', '', '1', '[S]CogEdit', 1, NULL, 1, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(63, '[L]Menu.SystemRole', NULL, 'System Role', '~/Moudles/SystemManage/RoleManage/SystemRoleListPage.aspx', '1', '[S]GroupKey', 0, 43, 8, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(68, '[L]Menu.SystemConfig', NULL, 'System Config', '~/Moudles/SystemManage/ConfigManage/SystemConfigListPage.aspx', '1', '[S]Cog', 0, 43, 2, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(106, '[L]Menu.SystemUser', NULL, 'System User', '~/Moudles/SystemManage/UserManage/SystemUserListPage.aspx', '1', '[S]User', 0, 43, 10, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(107, '[L]Menu.SystemPermission', '', 'System Permission', '~/Moudles/SystemManage/PermissionManage/SystemResourcesAndPriviliege.aspx', '1', '[S]GroupKey', 0, 43, 7, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(108, '[L]Menu.SystemDictionary', NULL, 'System Dictionary', '~/Moudles/SystemManage/DictionaryManage/SystemDictionaryListPage.aspx', '1', '[S]TableRow', 0, 43, 3, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(155, '[L]Menu.SystemDepartment', NULL, 'System Department', '~/Moudles/SystemManage/DepartmentManage/SystemDepartmentListPage.aspx', '1', '[S]UserHome', 0, 43, 9, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(156, '[L]Menu.SystemUserGroup', NULL, 'System User Group', '~/Moudles/SystemManage/UserGroupManage/SystemUserGroupListPage.aspx', '1', '[S]Group', 0, 43, 11, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(157, '[L]Menu.SystemSetting', NULL, 'System Setting', '~/Moudles/SystemManage/SettingManage/SystemSettingEditor.aspx', '1', '[S]ServerWrench', 0, 43, 1, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(158, '[L]Menu.SystemEmailTemplte', NULL, 'System Email Templte', '~/Moudles/SystemManage/EmailTemplates/SystemEmailTemplateListPage.aspx', '1', '[S]Email', 0, 43, 5, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(159, '[L]Menu.SystemEmailSetting', NULL, 'System Email Setting', '~/Moudles/SystemManage/EmailSettingManage/SystemEmailSettingsListPage.aspx', '1', '[S]EmailEdit', 0, 43, 4, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(162, '[L]Menu.ApplicationsAndMenus', NULL, 'Applications And Menus', '~/Moudles/SystemManage/SystemApplicationAndMenus\SystemApplicationAndMenusManage.aspx', '1', '[S]ApplicationOsxCascade', 0, 43, 6, '1', 1, 1, 36);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(163, '�����������', NULL, 'ECommence', '', '1', '[S]Money', 1, NULL, 1, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(164, '�������ع���', '', 'SP', '', '1', '[S]Email', 1, NULL, 1, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(165, '��Ʒ���', 'Category', '��Ʒ���', '', '1', '', 0, 163, 1, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(166, '��Ʒ����', NULL, '��Ʒ����', '', '1', '', 0, 163, 2, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(167, '��ƷĿ¼', NULL, '��ƷĿ¼', '', '1', '', 0, 163, 3, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(168, '������Ϣ', 'Area', '������Ϣ', '', '1', '', 0, 163, 4, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(169, '���䷽ʽ', 'ShipMethod', '���䷽ʽ', '', '1', '', 0, 163, 5, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(171, '�˷ѹ���', NULL, '�˷ѹ���', '', '1', '', 0, 163, 6, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(172, '֧����ʽ', NULL, '֧����ʽ', '', '1', '', 0, 163, 7, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(173, '�Ż�ȯ', NULL, '�Ż�ȯ', '', '1', '', 0, 163, 14, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(174, '����ȯ', NULL, '����ȯ', '', '1', '', 0, 163, 13, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(175, '��������', NULL, '��������', '', '1', '', 0, 163, 8, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(176, '��������', NULL, '��������', '', '1', '', 0, 163, 9, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(177, '�ͻ�����', NULL, '�ͻ�����', '', '1', '', 0, 163, 10, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(178, 'ҵ�񱨱�', '', 'ҵ�񱨱�', '', '1', '', 0, 163, 11, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(180, 'Ʒ�ƹ���', NULL, 'Ʒ�ƹ���', '', '1', '', 0, 163, 12, '1', 1, 1, 38);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(181, '���ݹ���', '', '���ݹ���', '', '1', '[S]Script', 1, NULL, 1, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(182, '�������', NULL, '�������', '', '1', '', 0, 181, 1, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(183, '����ר��', NULL, '����ר��', '', '1', '', 0, 181, 2, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(184, '����ר��', NULL, '����ר��', '', '1', '', 0, 181, 3, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(185, 'ģ�����', NULL, 'ģ�����', '', '1', '', 0, 181, 4, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(186, '��������', NULL, '��������', '', '1', '', 0, 181, 5, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(187, '���²ɼ�', NULL, '���²ɼ�', '', '1', '', 0, 181, 6, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(188, 'ע���û�', NULL, 'ע���û�', '', '1', '', 0, 181, 7, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(189, '���۹���', NULL, '���۹���', '', '1', '', 0, 181, 8, '1', 1, 1, 40);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(190, '�ĵ�����', '', '�ĵ�����', '', '1', '[S]Page', 1, NULL, 1, '1', 1, 1, 48);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(191, '�ϼҹ���', NULL, '�ϼҹ���', '', '1', '', 0, 164, 1, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(192, 'ͨ������', '', 'ͨ������', '~/Moudles/SPS/Channels/SPChannelListPage.aspx', '1', '', 0, 164, 2, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(193, '�ͻ�����', '', '�ͻ�����', '~/Moudles/SPS/Clients/SPSClientListPage.aspx', '1', '', 0, 164, 3, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(194, '�ձ���', NULL, '�ձ���', '', '1', '', 0, 164, 4, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(195, '���ܱ���', NULL, '���ܱ���', '', '1', '', 0, 164, 5, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(196, '��ʱ����', NULL, '��ʱ����', '', '1', '', 0, 164, 6, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(197, '���ݲ�ѯ', NULL, '���ݲ�ѯ', '', '1', '', 0, 164, 7, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(198, '���ݹ���', NULL, '���ݹ���', '', '1', '', 0, 164, 8, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(199, '�ĵ����͹���', NULL, '�ĵ����͹���', '', '1', '', 0, 190, 1, '1', 1, 1, 48);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(200, '�ĵ�ģ������', NULL, '�ĵ�ģ������', '', '1', '', 0, 190, 2, '1', 1, 1, 48);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(201, '�ĵ���ѯ', NULL, '�ĵ���ѯ', '', '1', '', 0, 190, 3, '1', 1, 1, 48);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(202, '�ϼұ���', NULL, '�ϼұ���', '', '1', '', 0, 164, 9, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(203, '�¼ұ���', NULL, '�¼ұ���', '', '1', '', 0, 164, 10, '1', 1, 1, 39);

	INSERT INTO [SystemMenu]
	([Menu_ID], [Menu_Name], [Menu_Code], [Menu_Description], [Menu_Url], [Menu_UrlTarget], [Menu_IconUrl], [Menu_IsCategory], [ParentMenu_ID], [Menu_Order], [Menu_Type], [Menu_IsSystemMenu], [Menu_IsEnable], [ApplicationID])
	VALUES
	(204, 'ͨ������', NULL, 'ͨ������', '', '1', '', 0, 164, 11, '1', 1, 1, 39);
	SET IDENTITY_INSERT [SystemMenu] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------

--|--------------------------------------------------------------------------------
--| [SystemRoleApplication] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemRoleApplication] ON

	INSERT INTO [SystemRoleApplication]
	([SystemRoleApplication_ID], [Role_ID], [Application_ID])
	VALUES
	(9, 3, 36);

	INSERT INTO [SystemRoleApplication]
	([SystemRoleApplication_ID], [Role_ID], [Application_ID])
	VALUES
	(12, 3, 40);

	INSERT INTO [SystemRoleApplication]
	([SystemRoleApplication_ID], [Role_ID], [Application_ID])
	VALUES
	(13, 3, 48);

	INSERT INTO [SystemRoleApplication]
	([SystemRoleApplication_ID], [Role_ID], [Application_ID])
	VALUES
	(14, 3, 39);
	SET IDENTITY_INSERT [SystemRoleApplication] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------



--|--------------------------------------------------------------------------------
--| [SystemRoleMenuRelation] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemRoleMenuRelation] ON

	INSERT INTO [SystemRoleMenuRelation]
	([MenuRole_ID], [Menu_ID], [Role_ID])
	VALUES
	(1, 43, 3);

	INSERT INTO [SystemRoleMenuRelation]
	([MenuRole_ID], [Menu_ID], [Role_ID])
	VALUES
	(2, 164, 3);

	INSERT INTO [SystemRoleMenuRelation]
	([MenuRole_ID], [Menu_ID], [Role_ID])
	VALUES
	(3, 181, 3);

	INSERT INTO [SystemRoleMenuRelation]
	([MenuRole_ID], [Menu_ID], [Role_ID])
	VALUES
	(4, 190, 3);
	SET IDENTITY_INSERT [SystemRoleMenuRelation] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------

--|--------------------------------------------------------------------------------
--| [SystemTerminology] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION
	SET IDENTITY_INSERT [SystemTerminology] ON

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(1, 'Setting.SystemName', 'Setting.SystemName', 'Setting.SystemName', '�������ƽ̨', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(2, 'Setting.SystemName', 'Setting.SystemName', 'Setting.SystemName', 'Base Framework', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(3, 'Menu.SystemManage', 'Menu.SystemManage', 'Menu.SystemManage', 'ϵͳ����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(4, 'Menu.SystemManage', 'Menu.SystemManage', 'Menu.SystemManage', 'System Manage', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(5, 'Menu.SystemApplication', 'Menu.SystemApplication', 'Menu.SystemApplication', 'Ӧ�ù���', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(6, 'Menu.SystemApplication', 'Menu.SystemApplication', 'Menu.SystemApplication', 'System Application', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(7, 'Menu.SystemRole', 'Menu.SystemRole', 'Menu.SystemRole', '��ɫ����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(8, 'Menu.SystemRole', 'Menu.SystemRole', 'Menu.SystemRole', 'System Role', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(9, 'Menu.SystemMenu', 'Menu.SystemMenu', 'Menu.SystemMenu', '�˵�����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(10, 'Menu.SystemMenu', 'Menu.SystemMenu', 'Menu.SystemMenu', 'System Menu', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(11, 'Menu.SystemUser', 'Menu.SystemUser', 'Menu.SystemUser', '�û�����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(12, 'Menu.SystemUser', 'Menu.SystemUser', 'Menu.SystemUser', 'System User', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(13, 'Menu.SystemDictionary', 'Menu.SystemDictionary', 'Menu.SystemDictionary', '�ֵ����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(14, 'Menu.SystemDictionary', 'Menu.SystemDictionary', 'Menu.SystemDictionary', 'System Dictionary', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(15, 'Menu.SystemPermission', 'Menu.SystemPermission', 'Menu.SystemPermission', '��ԴȨ�޹���', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(16, 'Menu.SystemPermission', 'Menu.SystemPermission', 'Menu.SystemPermission', 'Resource amd Permission', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(17, 'Menu.SystemDepartment', 'Menu.SystemDepartment', 'Menu.SystemDepartment', '���Ź���', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(18, 'Menu.SystemDepartment', 'Menu.SystemDepartment', 'Menu.SystemDepartment', 'System Department', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(19, 'Menu.SystemUserGroup', 'Menu.SystemUserGroup', 'Menu.SystemUserGroup', '�û������', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(20, 'Menu.SystemUserGroup', 'Menu.SystemUserGroup', 'Menu.SystemUserGroup', 'System User Group', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(21, 'Menu.SystemConfig', 'Menu.SystemConfig', 'Menu.SystemConfig', '���ù���', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(22, 'Menu.SystemConfig', 'Menu.SystemConfig', 'Menu.SystemConfig', 'System Config', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(23, 'Menu.SystemEmailTemplte', 'Menu.SystemEmailTemplte', 'Menu.SystemEmailTemplte', '�ʼ�ģ��', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(24, 'Menu.SystemEmailTemplte', 'Menu.SystemEmailTemplte', 'Menu.SystemEmailTemplte', 'System Email Templte', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(25, 'Menu.SystemEmailSetting', 'Menu.SystemEmailSetting', 'Menu.SystemEmailSetting', '�ʼ�����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(26, 'Menu.SystemEmailSetting', 'Menu.SystemEmailSetting', 'Menu.SystemEmailSetting', 'System Email Setting', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(27, 'Menu.SystemSetting', 'Menu.SystemSetting', 'Menu.SystemSetting', 'ϵͳ�趨', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(28, 'Menu.SystemSetting', 'Menu.SystemSetting', 'Menu.SystemSetting', 'System Setting', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(29, 'Menu.ApplicationsAndMenus', 'Menu.ApplicationsAndMenus', 'Menu.ApplicationsAndMenus', 'Ӧ�ò˵�����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(30, 'Menu.ApplicationsAndMenus', 'Menu.ApplicationsAndMenus', 'Menu.ApplicationsAndMenus', 'Applications And Menus', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(31, 'Application.BaseSystemModule', 'Application.BaseSystemModule', 'Application.BaseSystemModule', '����ϵͳģ��', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(32, 'Application.BaseSystemModule', 'Application.BaseSystemModule', 'Application.BaseSystemModule', 'Base System Module', 'en-US');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(33, 'Setting.SystemLisence', 'Setting.SystemLisence', 'Setting.SystemLisence', 'Copyright ?2003-2011 X soft All Rights Reserved ��Ȩ����', 'zh-chs');

	INSERT INTO [SystemTerminology]
	([ID], [Name], [Code], [Description], [Text], [LanguageType])
	VALUES
	(34, 'Setting.SystemLisence', 'Setting.SystemLisence', 'Setting.SystemLisence', 'Powered By X Soft Information Technology Logistics Inc.', 'en-US');
	SET IDENTITY_INSERT [SystemTerminology] OFF

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------




