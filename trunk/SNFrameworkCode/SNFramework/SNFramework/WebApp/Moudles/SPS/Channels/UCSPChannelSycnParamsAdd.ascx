<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelSycnParamsAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelSycnParamsAdd" %>
<ext:Window ID="winSPChannelSycnParamsAdd" runat="server" Icon="ApplicationAdd" Title="添加同步参数"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelSycnParamsAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="参数名" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="启用" Checked="true" AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbChannelParamsType" Editable="false" runat="server" FieldLabel="参数类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryChannelParamsType"
                    AllowBlank="false" SelectedIndex="0" AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:ComboBox ID="cmbParamsMappingName" Editable="false" runat="server" FieldLabel="映射字段"
                    DisplayField="Code" ValueField="Code" StoreID="storeDictionarySPField" AllowBlank="false"
                    SelectedIndex="0" AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:TextField ID="txtParamsValue" runat="server" FieldLabel="参数值" AllowBlank="True"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannelSycnParams" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelSycnParamsAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelSycnParams_Click" Success="Ext.MessageBox.alert('操作成功', '添加同步参数成功！' ,callback);function callback(id) {#{formPanelSPChannelSycnParamsAdd}.getForm().reset();#{storeSPChannelSycnParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="保存中,请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelSycnParams" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelSycnParamsAdd}.getForm().reset();#{winSPChannelSycnParamsAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeDictionaryChannelParamsType}.reload();#{storeDictionarySPField}.reload();">
        </BeforeShow>
    </Listeners>
</ext:Window>
