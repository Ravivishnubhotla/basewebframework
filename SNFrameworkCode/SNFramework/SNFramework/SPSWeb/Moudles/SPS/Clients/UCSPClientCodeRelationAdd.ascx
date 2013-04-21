<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientCodeRelationAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Clients.UCSPClientCodeRelationAdd" %>
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
<style type="text/css">
    .list-item
    {
        font: normal 11px tahoma, arial, helvetica, sans-serif;
        padding: 3px 10px 3px 10px;
        border: 1px solid #fff;
        border-bottom: 1px solid #eeeeee;
        white-space: normal;
        color: #555;
    }
    
    .list-item h3
    {
        display: block;
        font: inherit;
        font-weight: bold;
        color: #222;
    }
</style>
<ext:Store ID="storeSPChannel" runat="server" AutoLoad="true" OnRefreshData="storeSPChannel_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="int" />
                <ext:RecordField Name="Name" />
                <ext:RecordField Name="MoCode" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <DirectEventConfig>
        <EventMask ShowMask="true" />
    </DirectEventConfig>
</ext:Store>
<script type="text/javascript">


    var beforeSaveClientCodeRelation = function (btn) {
        alert(btn);
        if (btn == 'ok') {
            Ext.net.DirectMethods.UCSPClientCodeRelationAdd.SaveClientCodeRelation(
                                                                {
                                                                    success: function (result) {
                                                                        Ext.MessageBox.alert('操作成功', '分配代码成功！', RefreshData);
                                                                    },
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '操作中...'
                                                                    }
                                                                });
        }
    };

 

</script>
<ext:Store ID="storeSPCode" runat="server" AutoLoad="false" OnRefreshData="storeSPCode_Refresh">
    <Reader>
        <ext:JsonReader IDProperty="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="int" />
                <ext:RecordField Name="Name" />
                <ext:RecordField Name="MoCode" />
                <ext:RecordField Name="AssignedClientName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <DirectEventConfig>
        <EventMask ShowMask="true" />
    </DirectEventConfig>
</ext:Store>
<ext:Window ID="winSPClientCodeRelationAdd" runat="server" Icon="ApplicationAdd"
    Title="分配代码" Width="520" Height="270" AutoShow="false" Maximizable="true" Modal="true"
    Hidden="true" AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPClientCodeRelationAdd" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
                <ext:ComboBox ID="cmbChannel" runat="server" FieldLabel="通道" StoreID="storeSPChannel"
                    AnchorHorizontal="95%" Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择通道"
                    AllowBlank="false">
                    <Listeners>
                        <Select Handler="#{cmbCode}.clearValue(); #{storeSPCode}.reload();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbCode" runat="server" FieldLabel="代码" StoreID="storeSPCode" AnchorHorizontal="95%"
                    ItemSelector="div.list-item" TypeAhead="true" Editable="false" DisplayField="MoCode"
                    ValueField="Id" EmptyText="选择代码" AllowBlank="false">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						<div class="list-item">
							 <h3>{MoCode}</h3>
 						<tpl if="AssignedClientName == ''">
							<font color="green">未分配</font>
						</tpl>
  						<tpl if="AssignedClientName != ''">
							 已分配 {AssignedClientName}
						</tpl>
 
						</div>
					</tpl>
                        </Html>
                    </Template>
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
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPClientCodeRelation" runat="server" Text="分配代码" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPClientCodeRelationAdd}.getForm().isValid()) return false;"
                    Success="ShowMessage('操作成功','分配指令成功！',1);RefreshSPClientCodeRelationList();"
                    OnEvent="btnSaveSPClientCodeRelation_Click" >
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientCodeRelation" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPClientCodeRelationAdd}.getForm().reset();#{winSPClientCodeRelationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeSPChannel}.reload();SetAddSyncUI(#{chkSyncData}.getValue());">
        </BeforeShow>
    </Listeners>
</ext:Window>
