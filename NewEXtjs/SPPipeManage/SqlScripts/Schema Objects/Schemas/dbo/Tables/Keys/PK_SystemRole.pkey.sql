﻿ALTER TABLE [dbo].[SystemRole]
    ADD CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED ([Role_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
