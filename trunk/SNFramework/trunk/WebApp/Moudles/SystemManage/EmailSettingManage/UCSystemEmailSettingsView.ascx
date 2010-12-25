<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemEmailSettingsView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.EmailSettingManage.UCSystemEmailSettingsView" %>
<ext:Window ID="winSystemEmailSettingsView" runat="server" Icon="ApplicationViewDetail" Title="ShowSystemEmailSettings"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemEmailSettingsView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSystemEmailSettingsID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescriprsion" runat="server" FieldLabel="Descriprsion" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblHost" runat="server" FieldLabel="Host" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblPort" runat="server" FieldLabel="Port" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSSL" runat="server" FieldLabel="SSL" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblFromEmail" runat="server" FieldLabel="FromEmail" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblFromName" runat="server" FieldLabel="FromName" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLoginEmail" runat="server" FieldLabel="LoginEmail" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLoginPassword" runat="server" FieldLabel="LoginPassword" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsEnable" runat="server" FieldLabel="IsEnable" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsDefault" runat="server" FieldLabel="IsDefault" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateDate" runat="server" FieldLabel="CreateDate" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>