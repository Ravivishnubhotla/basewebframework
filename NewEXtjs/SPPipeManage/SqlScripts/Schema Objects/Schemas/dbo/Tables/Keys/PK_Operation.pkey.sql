﻿ALTER TABLE [dbo].[SystemOperation]
    ADD CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED ([Operation_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
