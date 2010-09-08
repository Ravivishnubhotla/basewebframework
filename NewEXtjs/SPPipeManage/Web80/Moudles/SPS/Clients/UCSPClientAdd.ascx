<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientAdd.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCSPClientAdd" %>
<ext:Store ID="storeUsers" runat="server" AutoLoad="false">
    <Proxy>
        <ext:HttpProxy Method="GET" Url="../Users/GetAUserByChannel.ashx" />
    </Proxy>
    <Reader>
        <ext:JsonReader Root="users" TotalProperty="total">
            <Fields>
                <ext:RecordField Name="Id" Type="int" Mapping="UserID" />
                <ext:RecordField Name="Name" Mapping="UserLoginID" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</ext:ScriptManagerProxy>

<script language="javascript">
    Ext.apply(Ext.form.VTypes, { password: function(val, field) { if (field.initialPassField) { var pwd = Ext.getCmp(field.initialPassField); return pwd ? (val == pwd.getValue()) : false; } return true; }, passwordText: "两次输入的密码不匹配！" });
</script>

<ext:Window ID="winSPClientAdd" runat="server" Icon="ApplicationAdd" Title="新建下家"
    ConstrainHeader="true" Width="600" Height="290" AutoShow="false" Maximizable="true"
    Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPClientAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPClient" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtName" runat="server" FieldLabel="名称" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkSyncDate" runat="server" FieldLabel="是否允许同步数据"  Hidden=true Checked="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtRecieveDataUrl" runat="server" FieldLabel="同步数据接口"  Hidden=true AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtOkMessage" runat="server" FieldLabel="同步数据成功信息" Hidden=true AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="同步数据失败信息" Hidden=true AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbSycnType" Editable="false" runat="server" FieldLabel="同步数据类型" Hidden=true
                                    AllowBlank="True" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="即时同步" Text="即时同步"></ext:ListItem>
                                        <ext:ListItem Value="异步同步" Text="异步同步"></ext:ListItem>
                                    </Items>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtRelateUserLoginID" runat="server" FieldLabel="关联用户登陆ID" AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtRelateUserPassword" runat="server" InputType="Password" FieldLabel="关联用户密码"
                                    AllowBlank="False" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtRelateUserRePassword" runat="server" InputType="Password" Vtype="password"
                                    FieldLabel="关联用户重复密码" AllowBlank="False" />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSPClient" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSPClientAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPClient_Click"
                    Success="Ext.MessageBox.alert('操作成功', '成功的添加了下家。',callback);function callback(id) {#{formPanelSPClientAdd}.getForm().reset();#{storeSPClient}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPClient" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPClientAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Show Handler="#{storeUsers}.reload();" />
    </Listeners>
</ext:Window>
