<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientCodeRelationEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPClientCodeRelationEdit" %>
<ext:Window ID="winSPClientCodeRelationEdit" runat="server" Icon="ApplicationEdit"
    Title="Edit SPClientCodeRelation" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPClientCodeRelationEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtCodeID" runat="server" FieldLabel="CodeID" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtClientID" runat="server" FieldLabel="ClientID" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrice" runat="server" FieldLabel="Price" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtInterceptRate" runat="server" FieldLabel="InterceptRate" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkUseClientDefaultSycnSetting" runat="server" FieldLabel="UseClientDefaultSycnSetting"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="SyncData" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSycnResendFailedData" runat="server" FieldLabel="SycnResendFailedData"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="SycnRetryTimes"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSyncType" runat="server" FieldLabel="SyncType" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnDataUrl" runat="server" FieldLabel="SycnDataUrl" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnOkMessage" runat="server" FieldLabel="SycnOkMessage" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnFailedMessage" runat="server" FieldLabel="SycnFailedMessage"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtStartDate" runat="server" FieldLabel="StartDate" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtEndDate" runat="server" FieldLabel="EndDate" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnNotInterceptCount" runat="server" FieldLabel="SycnNotInterceptCount"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCreateBy" runat="server" FieldLabel="CreateBy" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtCreateAt" runat="server" FieldLabel="CreateAt" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtLastModifyBy" runat="server" FieldLabel="LastModifyBy" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtLastModifyAt" runat="server" FieldLabel="LastModifyAt" AllowBlank="True"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPClientCodeRelation" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPClientCodeRelationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientCodeRelation_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPClientCodeRelationEdit}.getForm().reset();#{storeSPClientCodeRelation}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientCodeRelation" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPClientCodeRelationEdit}.getForm().reset();#{winSPClientCodeRelationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
