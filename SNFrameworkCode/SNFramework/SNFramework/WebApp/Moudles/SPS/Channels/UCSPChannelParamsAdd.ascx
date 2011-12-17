<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsAdd" %>
<ext:Window ID="winSPChannelParamsAdd" runat="server" Icon="ApplicationAdd" Title="通道参数添加"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtTitle" runat="server" FieldLabel="显示名" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="是否可用" Checked="true" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsRequired" runat="server" FieldLabel="是否必须" Checked="true"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkShowInClientGrid" runat="server" FieldLabel="显示给下家" Checked="true"
                    AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbChannelParamsType" Editable="false" runat="server" FieldLabel="参数类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryChannelParamsType"
                    AllowBlank="false" SelectedIndex="0"  AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:ComboBox ID="cmbParamsMappingName" Editable="false" runat="server" FieldLabel="映射字段"
                    DisplayField="Code" ValueField="Code" StoreID="storeDictionarySPField" AllowBlank="false"
                    SelectedIndex="0"  AnchorHorizontal="95%">
                </ext:ComboBox>
                <ext:TextField ID="txtParamsValue" runat="server" FieldLabel="参数值" AllowBlank="True"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannelParams" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelParamsAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelParams_Click" Success="Ext.MessageBox.alert('操作成功', '添加通道参数成功' ,callback);function callback(id) {#{formPanelSPChannelParamsAdd}.getForm().reset();#{storeSPChannelParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="保存中,请稍后....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParams" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelParamsAdd}.getForm().reset();#{winSPChannelParamsAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeDictionaryChannelParamsType}.reload();#{storeDictionarySPField}.reload();">
        </BeforeShow>
    </Listeners>
</ext:Window>
