<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.MenuManage.UCSystemMenuAdd" %>
<ext:Window ID="winSystemMenuAdd" runat="server" Icon="ApplicationAdd" Title="Add system menu"
    Width="600" Height="460" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMenuAdd" runat="server" Frame="true" Header="false"
            LabelSeparator=":" LabelWidth="100" MonitorValid="true" BodyStyle="padding:5px;">
            <Items>
                <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="false" Header=false
                    AutoHeight="true" Collapsed="false" LabelWidth="75" Layout="Form">
                    <Items>
                        <ext:Hidden ID="hidPMenuID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Hidden ID="hidApplicationID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Label ID="lblApplicationName" runat="server" FieldLabel="Application" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="Parent menu" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:TextField ID="txtMenuName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
                        <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="Descriptiom" AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="Is system menu" Checked="true"
                            AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="Enable" Checked="true"
                            AnchorHorizontal="95%" />
                        <ext:TextField ID="txtMenuIconUrl" runat="server" FieldLabel="Menu icon" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="Is Nav"
                    LabelSeparator=":" LabelWidth="100" AutoHeight="true" Collapsed="true" Layout="form">
                    <Items>
                        <ext:TextField ID="txtMenuUrl" runat="server" FieldLabel="Menu link" AnchorHorizontal="95%" />
                        <ext:ComboBox ID="cmbMenuUrlTarget" Editable="false" runat="server" FieldLabel="Link Type"
                            SelectedIndex="0" AnchorHorizontal="95%">
                            <Items>
                                <ext:ListItem Value="1" Text="Inner link" />
                                <ext:ListItem Value="2" Text="Out link" />
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
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemMenuAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="Ext.MessageBox.alert('Operation success', 'Add system menu successful。',callback);function callback(id) { #{formPanelSystemMenuAdd}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
