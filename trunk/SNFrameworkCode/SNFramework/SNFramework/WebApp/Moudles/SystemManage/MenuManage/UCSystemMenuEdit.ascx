<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.MenuManage.UCSystemMenuEdit" %>
<ext:Window ID="winSystemMenuEdit" runat="server" Icon="ApplicationEdit" Title="System Menu Edit"
    Width="600" Height="460" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMenuEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;">
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
                        <ext:Label ID="lblApplicationName" runat="server" FieldLabel="Applcation" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="Parent Menu" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:TextField ID="txtMenuName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
                        <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="Is system menu"
                            AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="Enable" AnchorHorizontal="95%" />
                                                <ext:TextField ID="txtMenuIconUrl" runat="server" FieldLabel="Menu icon" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="Is Nav Link"
                    AutoHeight="true" Collapsed="true" Layout="Form">
                    <Items>
                        <ext:TextField ID="txtMenuUrl" runat="server" FieldLabel="Menu link" AnchorHorizontal="95%" />
                        <ext:ComboBox ID="cmbMenuUrlTarget" Editable="false" runat="server" FieldLabel="Link type"
                            SelectedIndex="0" AnchorHorizontal="95%">
                            <Items>
                                <ext:ListItem Value="1" Text="Inner link" />
                                <ext:ListItem Value="2" Text="out link" />
                            </Items>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cmbMenuType" Editable="false" runat="server" FieldLabel="Menu type"
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
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemMenuEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="Ext.MessageBox.alert('Operation successful.', 'Update menu success.',callback);function callback(id) { #{formPanelSystemMenuEdit}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
