<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPCodeChangeClient.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Codes.SPCodeChangeClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        function SetDefaultValue(record) {
            if (record != null) {
            
                <%= this.txtPrice.ClientID %>.setValue(record.data.DefaultPrice);      
                <%= this.txtInterceptRate.ClientID %>.setValue(record.data.InterceptRate);    
                <%= this.txtSycnNotInterceptCount.ClientID %>.setValue(record.data.SycnNotInterceptCount);   
                <%= this.chkSyncData.ClientID %>.setValue(record.data.SyncData);

                SetAddSyncUI(record.data.SyncData);

 
                

                if(record.data.SyncData){
                <%= this.txtSycnRetryTimes.ClientID %>.setValue(record.data.SyncDataSetting_SycnRetryTimes);      
                <%= this.txtSycnDataUrl.ClientID %>.setValue(record.data.SyncDataSetting_SycnMOUrl);    
                <%= this.txtSycnOkMessage.ClientID %>.setValue(record.data.SyncDataSetting_SycnMOOkMessage);   
                <%= this.txtSycnFailedMessage.ClientID %>.setValue(record.data.SyncDataSetting_SycnMOFailedMessage);
                } else {
                  <%= this.txtSycnRetryTimes.ClientID %>.setValue('3');      
                    <%= this.txtSycnDataUrl.ClientID %>.setValue('');    
                    <%= this.txtSycnOkMessage.ClientID %>.setValue('ok');   
                    <%= this.txtSycnFailedMessage.ClientID %>.setValue('failed');
                }

 
            }
        }
    
</script>
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true">
        <Proxy>
            <ext:HttpProxy Method="POST" Url="../Clients/SPClientHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="Datas" IDProperty="Id" TotalProperty="Total">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="RecieveDataUrl" />
                    <ext:RecordField Name="SyncData" Type="Boolean" />
                    <ext:RecordField Name="DataOkMessage" />
                    <ext:RecordField Name="FailedMessage" />
                    <ext:RecordField Name="InterceptRate" Type="int" />
                    <ext:RecordField Name="DefaultPrice" Type="int" />
                    <ext:RecordField Name="SycnNotInterceptCount" Type="int" />
                                        <ext:RecordField Name="SyncDataSetting_SycnRetryTimes" Type="int" />  
                                        <ext:RecordField Name="SyncDataSetting_SycnMOUrl"   />  
                                        <ext:RecordField Name="SyncDataSetting_SycnMODataOkMessage"   />  
                                        <ext:RecordField Name="SyncDataSetting_SycnMOFailedMessage"   />                    
                    
                    
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig>
            <EventMask ShowMask="true" />
        </DirectEventConfig>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:FormPanel ID="formPanelSPCodeChanegClient" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" Height="400" LabelWidth="100" AutoScroll="true"
                Layout="Column">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Border="false" Header="false" ColumnWidth=".5" Layout="Form">
                        <Items>
                            <ext:DisplayField ID="lblChannelName" runat="server" FieldLabel="所属通道" AnchorHorizontal="95%" />
 
                            
                            <ext:DisplayField ID="lblPrice" runat="server" FieldLabel="默认价格" AnchorHorizontal="95%" />
                            <ext:DisplayField ID="lblProvinceLimitInfo" runat="server" FieldLabel="限省信息" AnchorHorizontal="95%" />
                            <ext:DisplayField ID="lblAssignedClient" runat="server" FieldLabel="当前分配客户" AnchorHorizontal="95%" />
                            <ext:TextField ID="txtPrice" runat="server" FieldLabel="价格" AllowBlank="True" AnchorHorizontal="95%" />
                            <ext:TextField ID="txtSycnNotInterceptCount" runat="server" FieldLabel="免扣量" AllowBlank="True"
                                AnchorHorizontal="95%" />
                            <ext:TextField ID="txtSycnRetryTimes" runat="server" FieldLabel="重发次数" AllowBlank="True"
                                AnchorHorizontal="95%" Hidden="true" />
                            <ext:TextField ID="txtSycnDataUrl" runat="server" FieldLabel="同步地址" AllowBlank="True"
                                AnchorHorizontal="95%" Hidden="true" />
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel2" runat="server" Border="false" Layout="Form" ColumnWidth=".5" Header="False">
                        <Items>
                            <ext:DisplayField ID="lblMoCodeCode" runat="server" FieldLabel="指令" AnchorHorizontal="95%" />
                            <ext:DisplayField ID="lblIsDiable" runat="server" FieldLabel="是否禁用" AnchorHorizontal="95%" />
                            <ext:DisplayField ID="lblPhoneLimitInfo" runat="server" FieldLabel="限量信息" AnchorHorizontal="95%" />
 
                            <ext:ComboBox ID="cmbAssignedClient" runat="server" FieldLabel="选择客户" LabelWidth="55"
                                StoreID="storeSPClient" ListWidth="200" Editable="True" MinChars="1" DisplayField="Name" AnchorHorizontal="95%"
                                ValueField="Id" EmptyText="选择客户" DataIndex="ClientID">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();SetDefaultValue(record);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:TextField ID="txtInterceptRate" runat="server" FieldLabel="扣率" AllowBlank="True"
                                AnchorHorizontal="95%" />
                            <ext:Checkbox ID="chkSyncData" runat="server" FieldLabel="同步数据" Checked="false" AnchorHorizontal="95%">
                                <Listeners>
                                    <Check Handler="SetAddSyncUI(#{chkSyncData}.getValue());"></Check>
                                </Listeners>
                            </ext:Checkbox>
                            <ext:TextField ID="txtSycnOkMessage" runat="server" FieldLabel="同步成功标识" AllowBlank="True"
                                AnchorHorizontal="95%" Hidden="true" />
                            <ext:TextField ID="txtSycnFailedMessage" runat="server" FieldLabel="同步失败标识" AllowBlank="True"
                                AnchorHorizontal="95%" Hidden="true" />
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSaveSPCode" runat="server" Text="分配客户" Icon="UserGo">
                        <DirectEvents>
                            <Click Before="if(!#{formPanelSPCodeChanegClient}.getForm().isValid()) return false;" OnEvent="btnSaveSPCode_Click"
                                Success="#{formPanelSPCodeChanegClient}.getForm().reset();parent.ShowMessage('操作成功','指令分配客户成功！',1);parent.reloadCodes();parent.CloseChangeClient();"
                                Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                <EventMask ShowMask="true" Msg="保存中,请稍后....." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnCancelSPCode" runat="server" Text="取消" Icon="Cancel">
                        <Listeners>
                            <Click Handler="#{formPanelSPCodeChanegClient}.getForm().reset();parent.CloseChangeClient();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
