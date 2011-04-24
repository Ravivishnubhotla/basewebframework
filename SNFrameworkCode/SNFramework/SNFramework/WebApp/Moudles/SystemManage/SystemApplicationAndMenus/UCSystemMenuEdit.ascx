<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemMenuEdit" %>
<ext:Window ID="winSystemMenuEdit" runat="server" Icon="ApplicationEdit" Title="菜单编辑"
    Width="600" Height="460" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"  AutoScroll=true
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMenuEdit" runat="server" Frame="true" Header="false"  
            MonitorValid="true" BodyStyle="padding:5px;" AutoScroll=true>
            <Items>
                <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="false" Header="false"
                    AutoHeight="true" Collapsed="false" LabelWidth="75" Layout="Form">
                    <Items>
                        <ext:Hidden ID="hidPMenuID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Hidden ID="hidMenuID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Hidden ID="hidApplicationID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Label ID="lblApplicationName" runat="server" FieldLabel="所属应用" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="父菜单" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:TextField ID="txtMenuName" runat="server" FieldLabel="名称" AnchorHorizontal="95%" />
                        <ext:TextField ID="txtMenuCode" runat="server" FieldLabel="编码" AnchorHorizontal="95%" />
                        <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="描述" AnchorHorizontal="95%" />

                        <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="系统菜单"
                            AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="是否启用" AnchorHorizontal="95%" />
                                                <ext:TextField ID="txtMenuIconUrl" runat="server" FieldLabel="菜单图标" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="链接菜单"
                    AutoHeight="true" Collapsed="true" Layout="Form">
                    <Items>
                        <ext:TextField ID="txtMenuUrl" runat="server" FieldLabel="菜单链接" AnchorHorizontal="95%" />
                        <ext:ComboBox ID="cmbMenuUrlTarget" Editable="false" runat="server" FieldLabel="链接类型"
                            SelectedIndex="0" AnchorHorizontal="95%">
                            <Items>
                                <ext:ListItem Value="1" Text="Inner link" />
                                <ext:ListItem Value="2" Text="out link" />
                            </Items>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cmbMenuType" Editable="false" runat="server" FieldLabel="菜单类型"
                            SelectedIndex="0" AnchorHorizontal="95%">
                            <Items>
                                <ext:ListItem Value="1" Text="Normal menu" />
                            </Items>
                        </ext:ComboBox>
                    </Items>
                </ext:FieldSet>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="编辑" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemMenuEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="Ext.MessageBox.alert('操作成功', '更新菜单成功.',callback);function callback(id) { #{formPanelSystemMenuEdit}.getForm().reset();ReloadMenus();};
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
