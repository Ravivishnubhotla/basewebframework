<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientChannelSettingAdd.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings.UCSPClientChannelSettingAdd" %>
<ext:Store ID="storeSPChannelAdd" runat="server" AutoLoad="false">
    <Proxy>
        <ext:HttpProxy Method="GET" Url="../Channels/SPChannelHandler.ashx" />
    </Proxy>
    <Reader>
        <ext:JsonReader Root="channels" TotalProperty="total">
            <Fields>
                <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                <ext:RecordField Name="Name" Mapping="Name" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Store ID="storeSPClientAdd" runat="server" AutoLoad="false">
    <Proxy>
        <ext:HttpProxy Method="GET" Url="../Clients/SPClientHandler.ashx" />
    </Proxy>
    <Reader>
        <ext:JsonReader Root="clients" TotalProperty="total">
            <Fields>
                <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                <ext:RecordField Name="Name" Mapping="Name" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>
<ext:Window ID="winSPClientChannelSettingAdd" runat="server" Icon="ApplicationAdd"
    Title="新建通道下家设置" Width="400" Height="270" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientChannelSettingAdd" runat="server" Frame="true"
                Header="false" MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClientChannelSetting" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbChannelID" runat="server" FieldLabel="通道" AllowBlank="False"
                                    StoreID="storeSPChannelAdd" Editable="false" TypeAhead="true" Mode="Local" ForceSelection="true"
                                    TriggerAction="All" DisplayField="Name" ValueField="Id" EmptyText="请选择通道" ValueNotFoundText="加载中..." />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbClinetID" runat="server" FieldLabel="下家" AllowBlank="False"
                                    StoreID="storeSPClientAdd" Editable="false" TypeAhead="true" Mode="Local" ForceSelection="true"
                                    TriggerAction="All" DisplayField="Name" ValueField="Id" EmptyText="请选择下家" ValueNotFoundText="加载中..." />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:NumberField ID="txtInterceptRate" runat="server" FieldLabel="扣率(%)" AllowBlank="False"
                                    Text="50" DecimalPrecision="0" MinValue="1" MaxValue="99"  />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbCommandType" runat="server" FieldLabel="指令匹配规则" AllowBlank="False"
                                    Editable="false" TypeAhead="true" ForceSelection="true" Mode="Local" TriggerAction="All"
                                    EmptyText="请选择指令匹配规则">
                                    <Items>
                                        <ext:ListItem Text="完全匹配" Value="1" />
                                        <ext:ListItem Text="包含" Value="2" />
                                        <ext:ListItem Text="以开头" Value="3" />
                                        <ext:ListItem Text="以结尾" Value="4" />
                                        <ext:ListItem Text="正则表达式" Value="5" />
                                        <ext:ListItem Text="自定义解析" Value="6" />
                                        <ext:ListItem Text="无条件匹配" Value="7" />
                                    </Items>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtCommandCode" runat="server" FieldLabel="指令代码" AllowBlank="False" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClientChannelSetting" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientChannelSettingAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPClientChannelSetting_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了通道下家设置。',callback);function callback(id) {#{formPanelSPClientChannelSettingAdd}.getForm().reset();#{storeSPClientChannelSetting}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClientChannelSetting" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientChannelSettingAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Show Handler="#{storeSPChannelAdd}.reload();#{storeSPClientAdd}.reload();" />
    </Listeners>
</ext:Window>
