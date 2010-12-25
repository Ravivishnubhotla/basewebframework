create table SystemApplication (SystemApplication_ID INTEGER NOT NULL AUTO_INCREMENT, SystemApplication_Name TEXT not null, SystemApplication_Description TEXT, SystemApplication_Url TEXT, SystemApplication_IsSystemApplication TINYINT(1), primary key (SystemApplication_ID));

create table SystemSetting (ID INTEGER NOT NULL AUTO_INCREMENT, SystemName TEXT not null, SystemDescription TEXT, SystemUrl TEXT, SystemVersion TEXT not null, SystemLisence TEXT not null, primary key (ID));

create table SystemRole (Role_ID INTEGER NOT NULL AUTO_INCREMENT, Role_Name VARCHAR(100), Role_Description TEXT, Role_IsSystemRole TINYINT(1), Role_Type VARCHAR(100), CreateBy INTEGER, CreateDate DATETIME, LastUpdateBy INTEGER, LastUpdateDate DATETIME, primary key (Role_ID));

create table SystemUser (User_ID INTEGER NOT NULL AUTO_INCREMENT, User_LoginID VARCHAR(100) not null, User_Name VARCHAR(100) not null, User_Email VARCHAR(100) not null, User_Password VARCHAR(100) not null, User_Status VARCHAR(100) not null, User_Create_Date DATETIME not null, User_Type VARCHAR(100) not null, Department_ID INTEGER, MobilePIN VARCHAR(100), PasswordFormat INTEGER not null, PasswordQuestion TEXT, PasswordAnswer TEXT, Comments TEXT, IsApproved TINYINT(1) not null, IsLockedOut TINYINT(1) not null, LastActivityDate DATETIME not null, LastLoginDate DATETIME not null, LastLockedOutDate DATETIME not null, LastPasswordChangeDate DATETIME not null, FailedPwdAttemptCnt INTEGER not null, FailedPwdAttemptWndStart DATETIME not null, FailedPwdAnsAttemptCnt INTEGER not null, FailedPwdAnsAttemptWndStart DATETIME not null, IsNeedChgPwd TINYINT(1) not null, PasswordSalt TEXT, LoweredEmail TEXT, primary key (User_ID));

create table SystemMenu (Menu_ID INTEGER NOT NULL AUTO_INCREMENT, Menu_Name TEXT not null, Menu_Description TEXT, Menu_Url TEXT, Menu_UrlTarget TEXT, Menu_IconUrl TEXT, Menu_IsCategory TINYINT(1) not null, ParentMenu_ID INTEGER, Menu_Order INTEGER, Menu_Type TEXT not null, Menu_IsSystemMenu TINYINT(1), Menu_IsEnable TINYINT(1), ApplicationID INTEGER, primary key (Menu_ID));

create table SystemEmailTemplate (EmailTemplateID INTEGER NOT NULL AUTO_INCREMENT, Name TEXT, Code TEXT, Description TEXT, TemplateType VARCHAR(100), TitleTemplate TEXT, BodyTemplate VARCHAR(255), IsHtmlEmail TINYINT(1), IsEnable TINYINT(1), CreateDate DATETIME, CreateBy INTEGER, primary key (EmailTemplateID));

create table SystemEmailSettings (EmailSettingID INTEGER NOT NULL AUTO_INCREMENT, Name TEXT, Descriprsion TEXT, Host TEXT, Port TEXT, SSL TINYINT(1), FromEmail TEXT, FromName TEXT, LoginEmail TEXT, LoginPassword TEXT, IsEnable TINYINT(1), IsDefault TINYINT(1), CreateDate DATETIME, CreateBy INTEGER, primary key (EmailSettingID));

create table SystemEmailQueue (QueueID INTEGER NOT NULL AUTO_INCREMENT, Title TEXT, Body VARCHAR(255), FromAddress TEXT, FromName TEXT, ToAddresss VARCHAR(255), ToNames VARCHAR(255), CCAddresss VARCHAR(255), CCNames VARCHAR(255), BCCAddresss VARCHAR(255), BCCNames VARCHAR(255), EmailTemplateID INTEGER, Statues TEXT, SendRetry INTEGER, MaxRetryTime INTEGER, MailLog VARCHAR(255), CreateDate DATETIME, CreateBy INTEGER, SendDate DATETIME, primary key (QueueID));

create table SystemConfig (SystemConfig_ID INTEGER NOT NULL AUTO_INCREMENT, Config_Key TEXT, Config_Value TEXT, Config_Description TEXT, SortIndex INTEGER, primary key (SystemConfig_ID));

create table SystemShortMessage (ShortMessage_ID INTEGER NOT NULL AUTO_INCREMENT, ShortMessage_Title TEXT not null, ShortMessage_Category TEXT, ShortMessage_Content TEXT, ShortMessage_Sender TEXT, ShortMessage_Send_Date DATETIME not null, ShortMessage_Receiver_ID INTEGER not null, ShortMessage_IsRead TINYINT(1) not null, primary key (ShortMessage_ID));

create table SystemLog (Log_ID INTEGER NOT NULL AUTO_INCREMENT, Log_Level TEXT not null, Log_Type TEXT, Log_Date DATETIME not null, Log_Source TEXT not null, Log_User TEXT not null, Log_Descrption TEXT not null, Log_RequestInfo TEXT, Log_RelateMoudleID INTEGER, Log_RelateMoudleDataID INTEGER, Log_RelateUserID INTEGER, Log_RelateDateTime DATETIME, primary key (Log_ID));

create table SystemDepartment (Department_ID INTEGER NOT NULL AUTO_INCREMENT, Parent_Department_ID INTEGER, Department_NameCn TEXT not null, Department_NameEn TEXT not null, Department_Decription TEXT, DepartmentSortIndex INTEGER, primary key (Department_ID));

create table SystemMoudle (Moudle_ID INTEGER NOT NULL AUTO_INCREMENT, Moudle_NameCn TEXT not null, Moudle_NameEn TEXT not null, Moudle_NameDb TEXT not null, Moudle_Description TEXT not null, Application_ID INTEGER, Moudle_IsSystemMoudle TINYINT(1) not null, primary key (Moudle_ID));

create table SystemMoudleField (SystemMoudleField_ID INTEGER NOT NULL AUTO_INCREMENT, SystemMoudleField_NameEn TEXT, SystemMoudleField_NameCn TEXT, SystemMoudleField_NameDb TEXT, SystemMoudleField_Type TEXT, SystemMoudleField_IsRequired TINYINT(1), SystemMoudleField_DefaultValue TEXT, SystemMoudleField_IsKeyField TINYINT(1), SystemMoudleField_Size INTEGER, SystemMoudleField_Description TEXT, SystemMoudle_ID INTEGER, primary key (SystemMoudleField_ID));

create table SystemView (SystemView_ID INTEGER NOT NULL AUTO_INCREMENT, SystemView_NameCn TEXT, SystemView_NameEn TEXT, Application_ID INTEGER, SystemView_Description TEXT, primary key (SystemView_ID));

create table SystemViewItem (SystemViewItem_ID INTEGER NOT NULL AUTO_INCREMENT, SystemViewItem_NameEn TEXT, SystemViewItem_NameCn TEXT, SystemViewItem_Description TEXT, SystemViewItem_DisplayFormat TEXT, SystemView_ID INTEGER, primary key (SystemViewItem_ID));


create table SystemDictionary (SystemDictionary_ID INTEGER NOT NULL AUTO_INCREMENT, SystemDictionary_CategoryID TEXT, SystemDictionary_Key TEXT, SystemDictionary_Value TEXT, SystemDictionary_Desciption TEXT, SystemDictionary_Order INTEGER, SystemDictionary_IsEnable TINYINT(1), primary key (SystemDictionary_ID));

create table SystemResources (Resources_ID INTEGER not null, Resources_NameCn TEXT not null, Resources_NameEn TEXT not null, Resources_Description TEXT, Resources_Type TEXT, Resources_Category TEXT, Resources_LimitExpression TEXT, Resources_IsRelateUser TINYINT(1) not null, MoudleID INTEGER, primary key (Resources_ID));

create table SystemOperation (Operation_ID INTEGER NOT NULL AUTO_INCREMENT, Operation_NameCn TEXT, Operation_NameEn TEXT, Operation_Description TEXT not null, IsSystemOperation TINYINT(1) not null, IsCanSingleOperation TINYINT(1) not null, IsCanMutilOperation TINYINT(1) not null, IsEnable TINYINT(1) not null, IsInListPage TINYINT(1) not null, IsInSinglePage TINYINT(1) not null, Operation_Order INTEGER not null, primary key (Operation_ID));

create table SystemPrivilege (Privilege_ID INTEGER NOT NULL AUTO_INCREMENT, Operation_ID INTEGER, Resources_ID INTEGER, PrivilegeCnName TEXT not null, PrivilegeEnName TEXT not null, DefaultValue TEXT, Description TEXT, PrivilegeOrder INTEGER not null, PrivilegeCategory TEXT, PrivilegeType TEXT, primary key (Privilege_ID));

create table SystemPrivilegeInRoles (PrivilegeRoleID INTEGER NOT NULL AUTO_INCREMENT, Role_ID INTEGER, Privilege_ID INTEGER, PrivilegeRoleValueType TEXT, EnableType TEXT not null, CreateTime DATETIME not null, UpdateTime DATETIME not null, ExpiryTime DATETIME not null, EnableParameter TINYINT(1) not null, PrivilegeRoleValue LONGBLOB, primary key (PrivilegeRoleID));

create table SystemPrivilegeParameter (PrivilegeParameterID INTEGER NOT NULL AUTO_INCREMENT, RoleID INTEGER, PrivilegeID INTEGER, BizParameter TEXT not null, primary key (PrivilegeParameterID));

create table SystemUserRoleRelation (UserRole_ID INTEGER NOT NULL AUTO_INCREMENT, User_ID INTEGER, Role_ID INTEGER, primary key (UserRole_ID));

create table SystemPersonalizationSettings (PersonalizationID INTEGER NOT NULL AUTO_INCREMENT, ApplicationID INTEGER, UserId INTEGER, Path TEXT not null, PageSettings LONGBLOB not null, LastUpdatedDate DATETIME, primary key (PersonalizationID));

create table SystemUserProfile (Profile_ID INTEGER NOT NULL AUTO_INCREMENT, UserID INTEGER, Property_ID INTEGER, PropertyValuesString VARCHAR(255), PropertyValuesBinary LONGBLOB, LastUpdatedDate DATETIME not null, primary key (Profile_ID));

create table SystemUserProfilePropertys (Property_ID INTEGER not null, Property_Name TEXT not null, Property_Description TEXT, primary key (Property_ID));


create table SystemRoleMenuRelation (MenuRole_ID INTEGER NOT NULL AUTO_INCREMENT, Menu_ID INTEGER, Role_ID INTEGER, primary key (MenuRole_ID));
create table SystemRoleApplication (SystemRoleApplication_ID INTEGER NOT NULL AUTO_INCREMENT, Role_ID INTEGER, Application_ID INTEGER, primary key (SystemRoleApplication_ID));
create table SystemUserGroupRoleRelation (UserGroupRole_ID INTEGER NOT NULL AUTO_INCREMENT, Role_ID INTEGER, UserGroup_ID INTEGER, primary key (UserGroupRole_ID));
create table SystemUserGroup (Group_ID INTEGER NOT NULL AUTO_INCREMENT, Group_NameCn TEXT not null, Group_NameEn TEXT not null, Group_Description TEXT, primary key (Group_ID));
create table SystemUserGroupUserRelation (UserGroupUserID INTEGER NOT NULL AUTO_INCREMENT, UserID INTEGER, UserGroupID INTEGER, primary key (UserGroupUserID));
create table SystemWorkFlow (WorkFlowID INTEGER not null, Name VARCHAR(20), Code VARCHAR(20), Description VARCHAR(20), IsSystemFlow VARCHAR(20), IsDelete VARCHAR(20), IsEnable VARCHAR(20), primary key (WorkFlowID));

create table SystemWorkFlowStep (WorkFlowStepID INTEGER not null, Name TEXT, Code TEXT, Description TEXT, primary key (WorkFlowStepID));





alter table SystemUserRoleRelation add index (User_ID), add constraint FK44F6A13C2D6F8510 foreign key (User_ID) references SystemUser (User_ID);
alter table SystemUserRoleRelation add index (Role_ID), add constraint FK44F6A13C947F1AA8 foreign key (Role_ID) references SystemRole (Role_ID);
alter table SystemMoudleField add index (SystemMoudle_ID), add constraint FKD98252B0B9BD3013 foreign key (SystemMoudle_ID) references SystemMoudle (Moudle_ID);
alter table SystemMenu add index (ParentMenu_ID), add constraint FKBE86F556EE62B70A foreign key (ParentMenu_ID) references SystemMenu (Menu_ID);
alter table SystemMenu add index (ApplicationID), add constraint FKBE86F5564F1E6E86 foreign key (ApplicationID) references SystemApplication (SystemApplication_ID);
alter table SystemDepartment add index (Parent_Department_ID), add constraint FK9A9B576989B3D199 foreign key (Parent_Department_ID) references SystemDepartment (Department_ID);
alter table SystemRoleMenuRelation add index (Menu_ID), add constraint FK7408E67C3793F53 foreign key (Menu_ID) references SystemMenu (Menu_ID);
alter table SystemRoleMenuRelation add index (Role_ID), add constraint FK7408E67947F1AA8 foreign key (Role_ID) references SystemRole (Role_ID);
alter table SystemViewItem add index (SystemView_ID), add constraint FK4038A2775FD09096 foreign key (SystemView_ID) references SystemView (SystemView_ID);
alter table SystemRoleApplication add index (Role_ID), add constraint FKE2CC94BB947F1AA8 foreign key (Role_ID) references SystemRole (Role_ID);
alter table SystemRoleApplication add index (Application_ID), add constraint FKE2CC94BB82146E91 foreign key (Application_ID) references SystemApplication (SystemApplication_ID);
alter table SystemResources add index (MoudleID), add constraint FKD45C45A2BD9E453 foreign key (MoudleID) references SystemMoudle (Moudle_ID);
alter table SystemMoudle add index (Application_ID), add constraint FK113874E582146E91 foreign key (Application_ID) references SystemApplication (SystemApplication_ID);
alter table SystemPrivilegeParameter add index (RoleID), add constraint FK55983DFA7094B5DC foreign key (RoleID) references SystemRole (Role_ID);
alter table SystemPrivilegeParameter add index (PrivilegeID), add constraint FK55983DFAC9B67F49 foreign key (PrivilegeID) references SystemPrivilege (Privilege_ID);
alter table SystemView add index (Application_ID), add constraint FKDE0C64A482146E91 foreign key (Application_ID) references SystemApplication (SystemApplication_ID);
alter table SystemUserGroupRoleRelation add index (Role_ID), add constraint FKFF69C134947F1AA8 foreign key (Role_ID) references SystemRole (Role_ID);
alter table SystemUserGroupRoleRelation add index (UserGroup_ID), add constraint FKFF69C1341163488 foreign key (UserGroup_ID) references SystemUserGroup (Group_ID);
alter table SystemUserGroupUserRelation add index (UserID), add constraint FKB3A81D6F76229C18 foreign key (UserID) references SystemUser (User_ID);
alter table SystemUserGroupUserRelation add index (UserGroupID), add constraint FKB3A81D6F47520A33 foreign key (UserGroupID) references SystemUserGroup (Group_ID);
alter table SystemPrivilege add index (Operation_ID), add constraint FKD89D329E28855C26 foreign key (Operation_ID) references SystemOperation (Operation_ID);
alter table SystemPrivilege add index (Resources_ID), add constraint FKD89D329ED2C2AF0B foreign key (Resources_ID) references SystemResources (Resources_ID);
alter table SystemPrivilegeInRoles add index (Role_ID), add constraint FK1D1935FC947F1AA8 foreign key (Role_ID) references SystemRole (Role_ID);
alter table SystemPrivilegeInRoles add index (Privilege_ID), add constraint FK1D1935FC54FBB852 foreign key (Privilege_ID) references SystemPrivilege (Privilege_ID);
alter table SystemPersonalizationSettings add index (ApplicationID), add constraint FKA19AE80C4F1E6E86 foreign key (ApplicationID) references SystemApplication (SystemApplication_ID);
alter table SystemPersonalizationSettings add index (UserId), add constraint FKA19AE80C76229C18 foreign key (UserId) references SystemUser (User_ID);
alter table SystemUserProfile add index (UserID), add constraint FK7D3821F676229C18 foreign key (UserID) references SystemUser (User_ID);
alter table SystemUserProfile add index (Property_ID), add constraint FK7D3821F6FC9DFC35 foreign key (Property_ID) references SystemUserProfilePropertys (Property_ID);
alter table SystemUser add index (Department_ID), add constraint FKF0C706D3E02823A9 foreign key (Department_ID) references SystemDepartment (Department_ID)