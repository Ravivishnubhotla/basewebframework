﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportProvinceChart.aspx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ReportProvinceChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="rptvContainer" runat="server" Width="100%" Height="100%" 
        AsyncRendering="False" SizeToReportContent="True" OnReportRefresh="rptvContainer_ReportRefresh">
    </rsweb:ReportViewer>
    </form>
</body>
</html>
