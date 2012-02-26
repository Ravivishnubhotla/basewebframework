 IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[view_ReportedPayment]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[view_ReportedPayment]
AS
SELECT   ChannelID, ClientID
FROM      (SELECT   ChannelID, ClinetID AS ClientID
                 FROM      dbo.SPClientChannelSetting
                 GROUP BY ChannelID, ClinetID
                 UNION
                 SELECT   ChannelID, ClientID
                 FROM      view_PaymentReport
                 GROUP BY ChannelID, ClientID) AS tb
GROUP BY ChannelID, ClientID
' 