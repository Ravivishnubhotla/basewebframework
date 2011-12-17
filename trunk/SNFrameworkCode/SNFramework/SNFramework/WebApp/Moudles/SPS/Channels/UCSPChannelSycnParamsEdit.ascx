<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelSycnParamsEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelSycnParamsEdit" %>
<ext:Window ID="winSPChannelSycnParamsEdit" runat="server" Icon="ApplicationEdit"
    Title="编辑同步参数" Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true"
    Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelSycnParamsEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtName" runat="server" FieldLabel="参数名" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="启用" Checked="false" AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbChannelParamsType" Editable="false" runat="server" FieldLabel="参数类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryChannelParamsType"
                    AllowBlank="false" AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:ComboBox ID="cmbParamsMappingName" Editable="false" runat="server" FieldLabel="映射字段"
                    DisplayField="Code" ValueField="Code" StoreID="storeDictionarySPField" AllowBlank="false"
                    AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:TextField ID="txtParamsValue" runat="server" FieldLabel="参数值" AllowBlank="True"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPChannelSycnParams" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelSycnParamsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelSycnParams_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPChannelSycnParamsEdit}.getForm().reset();#{storeSPChannelSycnParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelSycnParams" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelSycnParamsEdit}.getForm().reset();#{winSPChannelSycnParamsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeDictionaryChannelParamsType}.reload();#{storeDictionarySPField}.reload();">
        </BeforeShow>
    </Listeners>
</ext:Window>
