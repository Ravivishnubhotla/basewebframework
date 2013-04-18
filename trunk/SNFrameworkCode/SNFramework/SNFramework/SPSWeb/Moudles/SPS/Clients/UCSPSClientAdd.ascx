<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSClientAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Clients.UCSPSClientAdd" %>
 
<ext:Window ID="winSPSClientAdd" runat="server" Icon="ApplicationAdd" Title="添加客户"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPSClientAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="true"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtInterceptRate" runat="server" FieldLabel="默认扣率" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtNotInterceptCount" runat="server" FieldLabel="默认指令免扣数" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="numShowDayRecord" runat="server" FieldLabel="默认数据保留天数" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:NumberField ID="txtDefaultPrice" runat="server" FieldLabel="默认价格" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserID" runat="server" FieldLabel="登陆用户ID" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserPasword" runat="server" FieldLabel="登陆用户密码" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="是否同步数据" Checked="false" Hidden="True"
                    AnchorHorizontal="95%">
 
                </ext:Checkbox>
                <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="默认重发次数" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />
                <ext:FieldSet ID="fsSyncMO" runat="server" CheckboxToggle="true" Title="同步MO" AutoHeight="true"
                    Collapsed="true" LabelWidth="75" Layout="Form" Hidden="True">
                    <Items>
                        <ext:TextField ID="txtSycnMOUrl" runat="server" FieldLabel="同步地址" AllowBlank="True"
                            AnchorHorizontal="95%" />
                        <ext:TextField ID="txtSycnMOOkMessage" runat="server" FieldLabel="同步成功返回参数" Text="ok"
                            AllowBlank="True" AnchorHorizontal="95%" />
                        <ext:TextField ID="txtSycnMOFailedMessage" runat="server" FieldLabel="同步失败返回参数" Text="failed"
                            AllowBlank="True" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsSyncMR" runat="server" CheckboxToggle="true" Title="同步MR" AutoHeight="true"
                    Collapsed="true" LabelWidth="75" Layout="Form" Hidden="True">
                    <Items>
                        <ext:TextField ID="txtSycnMRUrl" runat="server" FieldLabel="同步地址" AllowBlank="True"
                            AnchorHorizontal="95%" />
                        <ext:TextField ID="txtSycnMROkMessage" runat="server" FieldLabel="同步成功返回参数" Text="ok"
                            AllowBlank="True" AnchorHorizontal="95%" />
                        <ext:TextField ID="txtSycnMRFailedMessage" runat="server" FieldLabel="同步失败返回参数" Text="failed"
                            AllowBlank="True" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsSyncState" runat="server" CheckboxToggle="true" Title="同步状态"
                    AutoHeight="true" Collapsed="true" LabelWidth="75" Layout="Form" Hidden="True">
                    <Items>
                        <ext:TextField ID="txtSycnStateUrl" runat="server" FieldLabel="同步地址" AllowBlank="True"
                            AnchorHorizontal="95%" />
                        <ext:TextField ID="txtSycnStateOkMessage" runat="server" FieldLabel="同步成功返回参数" Text="ok"
                            AllowBlank="True" AnchorHorizontal="95%" />
                        <ext:TextField ID="txtSycnStateFailedMessage" runat="server" FieldLabel="同步失败返回参数" Text="failed"
                            AllowBlank="True" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPSClient" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPSClientAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPSClient_Click"
                    Success="#{formPanelSPSClientAdd}.getForm().reset();ShowMessage('操作成功','添加客户成功！',1);#{storeSPSClient}.reload();"
                    Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPSClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPSClientAdd}.getForm().reset();#{winSPSClientAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Close Handler="#{formPanelSPSClientAdd}.getForm().reset();"></Close>
    </Listeners>
</ext:Window>
