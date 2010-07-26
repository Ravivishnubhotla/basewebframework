<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPClientEdit.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCSPClientEdit" %>
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
<ext:Window ID="winSPClientEdit" runat="server" Icon="ApplicationEdit" Title="编辑下家"
    ConstrainHeader="true" Width="600" Height="460" AutoShow="false" Maximizable="true"
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
                                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="描述" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:Checkbox ID="chkSyncDate" runat="server" FieldLabel="是否允许同步数据" Checked="false" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtRecieveDataUrl" runat="server" FieldLabel="同步数据接口" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtOkMessage" runat="server" FieldLabel="同步数据成功信息" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtFailedMessage" runat="server" FieldLabel="同步数据失败信息" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbSycnType" Editable="false" runat="server" FieldLabel="同步数据类型"
                                    AllowBlank="True" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="即时同步" Text="即时同步"></ext:ListItem>
                                        <ext:ListItem Value="异步同步" Text="异步同步"></ext:ListItem>
                                    </Items>
                                </ext:ComboBox>
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
        <Show Handler="#{storeUsers}.reload();if(#{hidUserID}.getValue()!=''){#{cmUserID}.setValue(#{hidUserID}.getValue())}" />
    </Listeners>
</ext:Window>
