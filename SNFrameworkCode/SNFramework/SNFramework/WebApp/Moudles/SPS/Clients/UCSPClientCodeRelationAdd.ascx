<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientCodeRelationAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SPS.Clients.UCSPClientCodeRelationAdd" %>
<script type="text/javascript">
    function SetAddSyncUI(showSync) {
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
<ext:store id="storeSPChannel" runat="server" autoload="true" onrefreshdata="storeSPChannel_Refresh">
    <reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
  <ext:RecordField Name="MoCode" />
                </Fields>
            </ext:JsonReader>
        </reader>
    <directeventconfig>
            <EventMask ShowMask="true" />
        </directeventconfig>
 
</ext:store>
<ext:store id="storeSPCode" runat="server" autoload="false" onrefreshdata="storeSPCode_Refresh">
    <reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
 
                </Fields>
            </ext:JsonReader>
        </reader>
    <directeventconfig>
            <EventMask ShowMask="true" />
        </directeventconfig>
</ext:store>
<ext:window id="winSPClientCodeRelationAdd" runat="server" icon="ApplicationAdd"
    title="分配代码" width="400" height="270" autoshow="false" maximizable="true" modal="true"
    hidden="true" autoscroll="true" constrainheader="true" resizable="true" layout="Fit">
    <content>
        <ext:FormPanel ID="formPanelSPClientCodeRelationAdd" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
                <ext:ComboBox ID="cmbChannel" runat="server" FieldLabel="通道" StoreID="storeSPChannel"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择通道" AllowBlank="false">
                           <Listeners>
            <Select Handler="#{cmbCode}.clearValue(); #{storeSPCode}.reload();" />
        </Listeners> 
                </ext:ComboBox>
                 <ext:ComboBox ID="cmbCode" runat="server" FieldLabel="代码" StoreID="storeSPCode"
                    AnchorHorizontal="95%" Editable="false" DisplayField="MoCode" ValueField="Id" EmptyText="选择代码" AllowBlank="false">
                </ext:ComboBox>
                <ext:TextField ID="txtPrice" runat="server" FieldLabel="价格" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtInterceptRate" runat="server" FieldLabel="扣率" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSycnNotInterceptCount" runat="server" FieldLabel="免扣量" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="同步数据" Checked="false" AnchorHorizontal="95%">
                    <Listeners>
                        <Check Handler="SetAddSyncUI(#{chkSyncData}.getValue());"></Check>
                    </Listeners>
                </ext:Checkbox>
 
                <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="重发次数" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />
                <ext:TextField ID="txtSycnDataUrl" runat="server" FieldLabel="同步地址" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />
                <ext:TextField ID="txtSycnOkMessage" runat="server" FieldLabel="同步成功标识" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />
                <ext:TextField ID="txtSycnFailedMessage" runat="server" FieldLabel="同步失败标识" AllowBlank="True"
                    AnchorHorizontal="95%" Hidden="true" />
            </Items>
        </ext:FormPanel>
    </content>
    <buttons>
        <ext:Button ID="btnSavelSPClientCodeRelation" runat="server" Text="分配代码" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPClientCodeRelationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientCodeRelation_Click" Success="Ext.MessageBox.alert('操作成功', '分配代码成功！' ,callback);function callback(id) {#{formPanelSPClientCodeRelationAdd}.getForm().reset();#{storeSPClientCodeRelation}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientCodeRelation" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPClientCodeRelationAdd}.getForm().reset();#{winSPClientCodeRelationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </buttons>
    <listeners>
        <BeforeShow Handler="#{storeSPChannel}.reload();SetAddSyncUI(#{chkSyncData}.getValue());">
        </BeforeShow>
    </listeners>
</ext:window>
