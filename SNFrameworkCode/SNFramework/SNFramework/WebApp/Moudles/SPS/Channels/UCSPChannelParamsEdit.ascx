<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelParamsEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelParamsEdit" %>
<ext:Window ID="winSPChannelParamsEdit" runat="server" Icon="ApplicationEdit" Title="编辑通道参数"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelParamsEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtName" runat="server" FieldLabel="参数名" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="启用" Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsRequired" runat="server" FieldLabel="必须" Checked="false" AnchorHorizontal="95%" />
                <ext:TextField ID="txtTitle" runat="server" FieldLabel="标题" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkShowInClientGrid" runat="server" FieldLabel="显示给下家" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:ComboBox ID="cmbChannelParamsType" Editable="false" runat="server" FieldLabel="参数类型"
                    DisplayField="Value" ValueField="Key" StoreID="storeDictionaryChannelParamsType"
                    AllowBlank="false"   AnchorHorizontal="95%">
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
        <ext:Button ID="btnSaveSPChannelParams" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelParamsEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelParams_Click" Success="Ext.MessageBox.alert('操作成功', '更新参数成功！',callback);function callback(id) {#{formPanelSPChannelParamsEdit}.getForm().reset();#{storeSPChannelParams}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="保存中,请等待....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelParams" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelParamsEdit}.getForm().reset();#{winSPChannelParamsEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeDictionaryChannelParamsType}.reload();#{storeDictionarySPField}.reload();">
        </BeforeShow>
    </Listeners>
</ext:Window>
