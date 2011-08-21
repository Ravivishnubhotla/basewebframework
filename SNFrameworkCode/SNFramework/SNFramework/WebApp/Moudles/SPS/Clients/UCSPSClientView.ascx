<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSClientView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPSClientView" %>
<ext:Window ID="winSPSClientView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPSClient"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPSClientView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPSClientID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblRecieveDataUrl" runat="server" FieldLabel="RecieveDataUrl" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblUserID" runat="server" FieldLabel="UserID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSyncData" runat="server" FieldLabel="SyncData" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblOkMessage" runat="server" FieldLabel="OkMessage" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblFailedMessage" runat="server" FieldLabel="FailedMessage" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSyncType" runat="server" FieldLabel="SyncType" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblAlias" runat="server" FieldLabel="Alias" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblInterceptRate" runat="server" FieldLabel="InterceptRate" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDefaultPrice" runat="server" FieldLabel="DefaultPrice" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>