<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuAdd.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.UCSystemMenuAdd" %>
<ext:Window ID="winSystemMenuAdd" runat="server" Icon="ApplicationAdd" Title="新建系统菜单"
    Width="420" Height="460" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMenuAdd" runat="server" Frame="true" Header="false"
            LabelSeparator=":" LabelWidth="100" MonitorValid="true" BodyStyle="padding:5px;"
            Layout="form">
            <Items>
                <ext:Hidden ID="hidPMenuID" runat="server">
                </ext:Hidden>
                <ext:Hidden ID="hidApplicationID" runat="server">
                </ext:Hidden>
                <ext:Label ID="lblApplicationName" runat="server" FieldLabel="所属应用">
                </ext:Label>
                <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="父菜单">
                </ext:Label>
                <ext:TextField ID="txtMenuName" runat="server" FieldLabel="菜单名" />
                <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="菜单描述" />
                <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="是否为系统菜单" Checked="true" />
                <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="是否可用" Checked="true" />
            </Items>
            </ext:FormLayout>
            <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="是否为链接菜单项"
                AutoHeight="true" Collapsed="true">
                <body>
                    <ext:FormLayout ID="FormLayout1" runat="server" LabelSeparator=":" LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMenuIconUrl" runat="server" FieldLabel="菜单图标" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:TextField ID="txtMenuUrl" runat="server" FieldLabel="菜单链接" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbMenuUrlTarget" Editable="false" runat="server" FieldLabel="链接类型"
                                    SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="1" Text="系统内链接" />
                                        <ext:ListItem Value="2" Text="系统外链接" />
                                    </Items>
                                </ext:ComboBox>
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbMenuType" Editable="false" runat="server" FieldLabel="菜单类型"
                                    SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="1" Text="普通菜单" />
                                    </Items>
                                </ext:ComboBox>
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </body>
            </ext:FieldSet>
    </Content>
    </ext:FormPanel> </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="添加" Icon="Add">
            <ajaxevents>
                <Click Before="if(!#{formPanelSystemMenuAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了系统菜单。',callback);function callback(id) { #{formPanelSystemMenuAdd}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </ajaxevents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
