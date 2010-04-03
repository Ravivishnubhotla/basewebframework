<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemLogView.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.LogManage.UCSystemLogView" %>
<ext:Window ID="winSystemLogView" runat="server" Icon="ApplicationViewDetail" Title="查看SystemLog"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemLogView" runat="server" Title="SystemLog" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>

                                <ext:Hidden ID="hidSystemLogID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>

					<ext:Label ID="lblLogLevel" runat="server" FieldLabel="LogLevel" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogType" runat="server" FieldLabel="LogType" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogDate" runat="server" FieldLabel="LogDate" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogSource" runat="server" FieldLabel="LogSource" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogUser" runat="server" FieldLabel="LogUser" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogDescrption" runat="server" FieldLabel="LogDescrption" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogRequestInfo" runat="server" FieldLabel="LogRequestInfo" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogRelateMoudleID" runat="server" FieldLabel="LogRelateMoudleID" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogRelateMoudleDataID" runat="server" FieldLabel="LogRelateMoudleDataID" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogRelateUserID" runat="server" FieldLabel="LogRelateUserID" AnchorHorizontal="95%" />
					
					<ext:Label ID="lblLogRelateDateTime" runat="server" FieldLabel="LogRelateDateTime" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>







