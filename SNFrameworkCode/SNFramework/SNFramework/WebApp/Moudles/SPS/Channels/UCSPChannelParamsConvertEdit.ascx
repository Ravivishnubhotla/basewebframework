<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsConvertEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsConvertEdit" %>
<ext:Window ID="winSPChannelParamsConvertEdit" runat="server" Icon="ApplicationEdit"
    Title="Edit SPChannelParamsConvert" Width="400" Height="270" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsConvertEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtParamsValue" runat="server" FieldLabel="ParamsValue" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtParamsConvertTo" runat="server" FieldLabel="ParamsConvertTo"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtParamsConvertType" runat="server" FieldLabel="ParamsConvertType"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtParamsConvertCondition" runat="server" FieldLabel="ParamsConvertCondition"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtChannelID" runat="server" FieldLabel="ChannelID" AllowBlank="False"
                    AnchorHorizontal="95%" />
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
        <ext:Button ID="btnSaveSPChannelParamsConvert" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelParamsConvertEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelParamsConvert_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPChannelParamsConvertEdit}.getForm().reset();#{storeSPChannelParamsConvert}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParamsConvert" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelParamsConvertEdit}.getForm().reset();#{winSPChannelParamsConvertEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
