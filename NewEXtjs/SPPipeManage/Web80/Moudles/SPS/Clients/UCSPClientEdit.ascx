<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCSPClientEdit" %>
<ext:Store ID="storeSPChannelGroup" runat="server" AutoLoad="false">
    <Proxy>
        <ext:HttpProxy Method="GET" Url="../ClientGroups/SPChannelGroupHandle.ashx" />
    </Proxy>
    <Reader>
        <ext:JsonReader Root="datas" TotalProperty="total">
            <Fields>
                <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                <ext:RecordField Name="Name" Mapping="Name" />
            </Fields>
        </ext:JsonReader>
    </Reader>
    <BaseParams>
        <ext:Parameter Name="DataType" Mode="Value" Value="GetAllClientGroup">
        </ext:Parameter>
    </BaseParams>
    <Listeners>
        <Load Handler="if (GetGroupID()!='') {#{cmbClientGroupID}.setValue(GetGroupID());} #{formPanelSPClientEdit}.setDisabled(false);" />
    </Listeners>
</ext:Store>
<script type="text/javascript">
    function GetGroupID() {
        var hidClientGroupID = <%=  hidClientGroupID.ClientID %>;
        if(hidClientGroupID==null)
            return '';
        return hidClientGroupID.getValue();
    }
</script>
<ext:Window ID="winSPClientEdit" runat="server" Icon="ApplicationEdit" Title="编辑下家"
    ConstrainHeader="true" Width="600" Height="250" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientEdit" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClient" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidId" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidUserID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtAlias" runat="server" FieldLabel="下家显示名" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbClientGroupID" runat="server" FieldLabel="下家组" AllowBlank="False"
                                    StoreID="storeSPChannelGroup" Editable="false" TypeAhead="true" Mode="Local"
                                    ForceSelection="true" TriggerAction="All" DisplayField="Name" ValueField="Id"
                                    EmptyText="请选择下家组">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidClientGroupID" runat="server">
                                </ext:Hidden>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClient" runat="server" Text="编辑" Icon="ApplicationEdit">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientEdit}.getForm().isValid()) return false;" OnEvent="btnSaveSPClient_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的编辑了下家。',callback);function callback(id) { #{storeSPClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Show Handler="#{formPanelSPClientEdit}.setDisabled(true);#{storeSPChannelGroup}.reload();" />
    </Listeners>
</ext:Window>
