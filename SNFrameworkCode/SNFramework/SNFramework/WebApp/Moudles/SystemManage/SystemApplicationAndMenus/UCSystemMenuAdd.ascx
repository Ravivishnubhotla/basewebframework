<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemMenuAdd" %>
<ext:Window ID="winSystemMenuAdd" runat="server" Icon="ApplicationAdd" Title="<%$ Resources:msgFormTitle %>"
    Width="550" Height="390" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMenuAdd" runat="server" Frame="true" Header="false"
            LabelSeparator=":" LabelWidth="100" MonitorValid="true" BodyStyle="padding:5px;"
            AutoScroll="true">
            <Items>
                <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="false" Header="false"
                    Collapsed="false" LabelWidth="75" Layout="Form">
                    <Items>
                        <ext:Hidden ID="hidPMenuID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Hidden ID="hidApplicationID" runat="server" AnchorHorizontal="95%">
                        </ext:Hidden>
                        <ext:Label ID="lblApplicationName" runat="server" FieldLabel="<%$ Resources:msgFieldApplicationName %>" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="<%$ Resources:msgFieldParentMenuName %>" AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:TextField ID="txtMenuName" runat="server" FieldLabel="<%$ Resources:msgFieldName %>" AnchorHorizontal="95%" />
                        <ext:TextField ID="txtMenuCode" runat="server" FieldLabel="<%$ Resources:msgFieldCode %>" AnchorHorizontal="95%" />
                        <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="<%$ Resources:msgFieldDescription %>" AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="<%$ Resources:msgFieldIsSystem %>" Checked="true"
                            AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="<%$ Resources:msgFieldIsEnable %>" Checked="true"
                            AnchorHorizontal="95%" />
                        <ext:TextField ID="txtMenuIconUrl" runat="server" FieldLabel="<%$ Resources:msgFieldIconUrl %>" AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="<%$ Resources:msgFieldIsCategory %>"
                    LabelSeparator=":" LabelWidth="100" Collapsed="true" Layout="form">
                    <Items>
                        <ext:TextField ID="txtMenuUrl" runat="server" FieldLabel="<%$ Resources:msgFieldUrl %>" AnchorHorizontal="95%" />
                        <ext:ComboBox ID="cmbMenuUrlTarget" Editable="false" runat="server" FieldLabel="<%$ Resources:msgFieldUrlTarget %>"
                            SelectedIndex="0" AnchorHorizontal="95%">
                            <Items>
                                <ext:ListItem Value="1" Text="<%$ Resources:msgFieldInnerLink %>" />
                                <ext:ListItem Value="2" Text="<%$ Resources:msgFieldOutterLink %>" />
                            </Items>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cmbMenuType" Editable="false" runat="server" FieldLabel="<%$ Resources:msgFieldUrlType %>"
                            SelectedIndex="0" AnchorHorizontal="95%">
                            <Items>
                                <ext:ListItem Value="1" Text="<%$ Resources:msgFieldNormalMenu %>" />
                            </Items>
                        </ext:ComboBox>
                    </Items>
                </ext:FieldSet>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemMenuAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="<%$ Resources : msgAddScript  %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
