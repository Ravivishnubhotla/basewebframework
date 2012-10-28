<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientCodeRelationEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Clients.UCSPClientCodeRelationEdit" %>
<script type="text/javascript">
    function SetEditSyncUI(showSync) {
        if(showSync) {
            //alert('111');
 
            <%= this.txtSycnRetryTimes.ClientID %>.show();    
            <%= this.txtSycnDataUrl.ClientID %>.show();   
            <%= this.txtSycnOkMessage.ClientID %>.show();   
            <%= this.txtSycnFailedMessage.ClientID %>.show();           
        }
        else {
 
            <%= this.txtSycnRetryTimes.ClientID %>.hide();      
            <%= this.txtSycnDataUrl.ClientID %>.hide();   
            <%= this.txtSycnOkMessage.ClientID %>.hide();   
            <%= this.txtSycnFailedMessage.ClientID %>.hide();                
        }

    }
    
</script>
<ext:Window ID="winSPClientCodeRelationEdit" runat="server" Icon="ApplicationEdit"
    Title="编辑分配代码设置" Width="520" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPClientCodeRelationEdit" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="txtChannelID" runat="server" FieldLabel="所属通道" AnchorHorizontal="95%" />
                <ext:DisplayField ID="txtCodeID" runat="server" FieldLabel="分配代码" AnchorHorizontal="95%" />
                <ext:TextField ID="txtPrice" runat="server" FieldLabel="价格" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtInterceptRate" runat="server" FieldLabel="扣率" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnNotInterceptCount" runat="server" FieldLabel="免扣量" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="同步数据" Checked="false" AnchorHorizontal="95%" />
 
                <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="重发数据次数" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnDataUrl" runat="server" FieldLabel="同步地址" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnOkMessage" runat="server" FieldLabel="同步成功标识" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnFailedMessage" runat="server" FieldLabel="同步失败标识" AllowBlank="True"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPClientCodeRelation" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPClientCodeRelationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientCodeRelation_Click" Success="Ext.MessageBox.alert('操作成功', '成功更新代码！',callback);function callback(id) {#{formPanelSPClientCodeRelationEdit}.getForm().reset();#{storeSPClientCodeRelation}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中,请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientCodeRelation" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPClientCodeRelationEdit}.getForm().reset();#{winSPClientCodeRelationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="SetEditSyncUI(#{chkSyncData}.getValue());">
        </BeforeShow>
    </Listeners>
</ext:Window>
