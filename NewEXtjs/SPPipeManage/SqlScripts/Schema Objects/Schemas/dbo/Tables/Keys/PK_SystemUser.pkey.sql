﻿ALTER TABLE [dbo].[SystemUser]
    ADD CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED ([User_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

