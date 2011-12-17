<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSClientEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPSClientEdit" %>
<ext:Window ID="winSPSClientEdit" runat="server" Icon="ApplicationEdit" Title="编辑客户信息"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPSClientEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
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
                <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="是否同步数据" Checked="false"
                    AnchorHorizontal="95%">
                    <Listeners>
                        <Check Handler="ShowSycn(#{chkSyncData},#{txtRecieveDataUrl},#{txtOkMessage},#{txtFailedMessage});">
                        </Check>
                    </Listeners>
                </ext:Checkbox>
                                                        <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="默认重发次数" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />	      
                <ext:TextField ID="txtRecieveDataUrl" runat="server" FieldLabel="同步地址" Hidden="true"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtOkMessage" runat="server" FieldLabel="同步成功返回参数" Text="ok" Hidden="true"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="同步失败返回参数" Text="failed"
                    Hidden="true" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPSClient" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPSClientEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPSClient_Click" Success="Ext.MessageBox.alert('操作成功', '更新客户信息成功！',callback);function callback(id) {#{formPanelSPSClientEdit}.getForm().reset();#{storeSPSClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="保存中,请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPSClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPSClientEdit}.getForm().reset();#{winSPSClientEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
