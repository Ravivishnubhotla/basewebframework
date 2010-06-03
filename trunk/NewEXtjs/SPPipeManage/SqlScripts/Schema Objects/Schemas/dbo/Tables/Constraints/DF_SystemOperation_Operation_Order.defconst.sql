ALTER TABLE [dbo].[SystemOperation]
    ADD CONSTRAINT [DF_SystemOperation_Operation_Order] DEFAULT ((9999)) FOR [Operation_Order];

