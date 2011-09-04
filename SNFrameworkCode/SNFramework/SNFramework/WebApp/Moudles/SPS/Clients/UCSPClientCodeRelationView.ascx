<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientCodeRelationView.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPClientCodeRelationView" %>
<ext:Window ID="winSPClientCodeRelationView" runat="server" Icon="ApplicationViewDetail"
    Title="ShowSPClientCodeRelation" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPClientCodeRelationView" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
                <ext:Hidden ID="hidSPClientCodeRelationID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblCodeID" runat="server" FieldLabel="CodeID" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblClientID" runat="server" FieldLabel="ClientID" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblPrice" runat="server" FieldLabel="Price" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblInterceptRate" runat="server" FieldLabel="InterceptRate"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblUseClientDefaultSycnSetting" runat="server" FieldLabel="UseClientDefaultSycnSetting"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSyncData" runat="server" FieldLabel="SyncData" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSycnResendFailedData" runat="server" FieldLabel="SycnResendFailedData"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSycnRetryTimes" runat="server" FieldLabel="SycnRetryTimes"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSyncType" runat="server" FieldLabel="SyncType" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSycnDataUrl" runat="server" FieldLabel="SycnDataUrl" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSycnOkMessage" runat="server" FieldLabel="SycnOkMessage"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSycnFailedMessage" runat="server" FieldLabel="SycnFailedMessage"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblStartDate" runat="server" FieldLabel="StartDate" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblEndDate" runat="server" FieldLabel="EndDate" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblIsEnable" runat="server" FieldLabel="IsEnable" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblSycnNotInterceptCount" runat="server" FieldLabel="SycnNotInterceptCount"
                    AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblCreateAt" runat="server" FieldLabel="CreateAt" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblLastModifyBy" runat="server" FieldLabel="LastModifyBy" AnchorHorizontal="95%" />
                <ext:DisplayField ID="lblLastModifyAt" runat="server" FieldLabel="LastModifyAt" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
