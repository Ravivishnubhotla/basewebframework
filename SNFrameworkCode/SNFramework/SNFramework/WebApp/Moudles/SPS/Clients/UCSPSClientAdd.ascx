<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSClientAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPSClientAdd" %>
<script type="text/javascript">
    function ShowSycn(chkSyncData, txtRecieveDataUrl, txtOkMessage, txtFailedMessage) {
        //alert(chkSyncData);
        //alert(chkSyncData.getValue());
        if (chkSyncData.getValue()) {
            txtRecieveDataUrl.show();
            txtOkMessage.show();
            txtFailedMessage.show();
            <%= txtSycnRetryTimes.ClientID %>.show();
        }
        else {
            txtRecieveDataUrl.hide();
            txtOkMessage.hide();
            txtFailedMessage.hide();
            <%= txtSycnRetryTimes.ClientID %>.hide();
        }
    }
</script>
<ext:window id="winSPSClientAdd" runat="server" icon="ApplicationAdd" title="添加客户"
    width="400" height="270" autoshow="false" maximizable="true" modal="true" hidden="true"
    autoscroll="true" constrainheader="true" resizable="true" layout="Fit">
    <content>
        <ext:FormPanel ID="formPanelSPSClientAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="false"  AnchorHorizontal="95%" />
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="true"  AnchorHorizontal="95%"/>
                        <ext:NumberField ID="txtInterceptRate" runat="server" FieldLabel="默认扣率" AllowBlank="false"  AnchorHorizontal="95%" />
                        <ext:NumberField ID="txtNotInterceptCount" runat="server" FieldLabel="默认指令免扣数" AllowBlank="false"  AnchorHorizontal="95%" />
                        <ext:NumberField ID="numShowDayRecord" runat="server" FieldLabel="默认数据保留天数" AllowBlank="false"  AnchorHorizontal="95%" />
                        <ext:NumberField ID="txtDefaultPrice" runat="server" FieldLabel="默认价格" AllowBlank="false"  AnchorHorizontal="95%" />
						<ext:TextField ID="txtUserID" runat="server" FieldLabel="登陆用户ID" AllowBlank="false"  AnchorHorizontal="95%" />
                        <ext:TextField ID="txtUserPasword" runat="server" FieldLabel="登陆用户密码" AllowBlank="false"  AnchorHorizontal="95%" />		 
                        <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="是否同步数据" Checked="false"  AnchorHorizontal="95%">
                        <Listeners>
                        <Check  Handler="ShowSycn(#{chkSyncData},#{txtRecieveDataUrl},#{txtOkMessage},#{txtFailedMessage});"></Check>
 
                        </Listeners>
                        </ext:Checkbox>
                                        <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="默认重发次数" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />	                                         
                        <ext:TextField ID="txtRecieveDataUrl" runat="server" FieldLabel="同步地址" Hidden="true" AllowBlank="True"  AnchorHorizontal="95%" />
						<ext:TextField ID="txtOkMessage" runat="server" FieldLabel="同步成功返回参数" Text="ok" Hidden="true" AllowBlank="True"  AnchorHorizontal="95%" />
						<ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="同步失败返回参数" Text="failed" Hidden="true" AllowBlank="True"  AnchorHorizontal="95%" />
 
            </Items>
        </ext:FormPanel>
    </content>
    <buttons>
        <ext:Button ID="btnSavelSPSClient" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPSClientAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPSClient_Click"
                    Success="Ext.MessageBox.alert('操作成功', '添加客户成功！' ,callback);function callback(id) {#{formPanelSPSClientAdd}.getForm().reset();#{storeSPSClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPSClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPSClientAdd}.getForm().reset();#{winSPSClientAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </buttons>
</ext:window>
