<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsConvertAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsConvertAdd" %>
<ext:Window ID="winSPChannelParamsConvertAdd" runat="server" Icon="ApplicationAdd"
    Title="SPChannelParamsConvert Add " Width="400" Height="270" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true"
    Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsConvertAdd" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
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
        <ext:Button ID="btnSavelSPChannelParamsConvert" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelParamsConvertAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelParamsConvert_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPChannelParamsConvertAdd}.getForm().reset();#{storeSPChannelParamsConvert}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParamsConvert" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelParamsConvertAdd}.getForm().reset();#{winSPChannelParamsConvertAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
