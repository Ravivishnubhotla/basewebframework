<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuAdd.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.UCSystemMenuAdd" %>
<ext:Window ID="winSystemMenuAdd" runat="server" Icon="ApplicationAdd" Title="新建系统菜单"
    Width="420" Height="460" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSystemMenuAdd" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:ContainerLayout runat="server">
                        <ext:Panel runat="server">
                            <Body>
                                <ext:FormLayout ID="FormLayout2" runat="server" LabelSeparator=":" LabelWidth="100">
                                    <Anchors>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:Hidden ID="hidPMenuID" runat="server">
                                            </ext:Hidden>
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:Hidden ID="hidApplicationID" runat="server">
                                            </ext:Hidden>
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:Label ID="lblApplicationName" runat="server" FieldLabel="所属应用">
                                            </ext:Label>
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="父菜单">
                                            </ext:Label>
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:TextField ID="txtMenuName" runat="server" FieldLabel="菜单名" />
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="菜单描述" />
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="是否为系统菜单" />
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="95%">
                                            <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="是否可用" />
                                        </ext:Anchor>
                                    </Anchors>
                                </ext:FormLayout>
                            </Body>
                        </ext:Panel>
                        <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="是否为链接菜单项"
                            AutoHeight="true" Collapsed="true">
                            <Body>
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
                            </Body>
                        </ext:FieldSet>
                    </ext:ContainerLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="添加" Icon="Add">
            <AjaxEvents>
                <Click Before="if(!#{formPanelSystemMenuAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了系统菜单。',callback);function callback(id) { #{formPanelSystemMenuAdd}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </AjaxEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
