<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMenuEdit.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.SystemApplicationAndMenus.UCSystemMenuEdit" %>
<ext:Window ID="winSystemMenuEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="600" Height="460" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMenuEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" AutoScroll="true">
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
                        <ext:Label ID="lblApplicationName" runat="server" FieldLabel="<%$ Resources:msgFieldApplicationName %>"
                            AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:Label ID="lblParentMenuName" runat="server" FieldLabel="<%$ Resources:msgFieldParentMenuName %>"
                            AnchorHorizontal="95%">
                        </ext:Label>
                        <ext:TriggerField ID="txtMenuName" runat="server" FieldLabel="<%$ Resources:msgFieldName %>"
                            AnchorHorizontal="95%">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimpleEdit" />
                            </Triggers>
                            <Listeners>
                                <Change Handler="SetFieldTriggerShow(this,newValue);"></Change>
                                <TriggerClick Handler="ShowTextEdit(this,index);"></TriggerClick>
                            </Listeners>
                        </ext:TriggerField>
                        <ext:TextField ID="txtMenuCode" runat="server" FieldLabel="<%$ Resources:msgFieldCode %>"
                            AnchorHorizontal="95%" />
                        <ext:TextArea ID="txtMenuDescription" runat="server" FieldLabel="<%$ Resources:msgFieldDescription %>"
                            AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsSystemMenu" runat="server" FieldLabel="<%$ Resources:msgFieldIsSystem %>"
                            AnchorHorizontal="95%" />
                        <ext:Checkbox ID="chkMenuIsEnable" runat="server" FieldLabel="<%$ Resources:msgFieldIsEnable %>"
                            AnchorHorizontal="95%" />
                        <ext:TextField ID="txtMenuIconUrl" runat="server" FieldLabel="<%$ Resources:msgFieldIconUrl %>"
                            AnchorHorizontal="95%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="fsMenuIsCategory" runat="server" CheckboxToggle="true" Title="<%$ Resources:msgFieldIsCategory %>"
                    AutoHeight="true" Collapsed="true" Layout="Form">
                    <Items>
                        <ext:TextField ID="txtMenuUrl" runat="server" FieldLabel="<%$ Resources:msgFieldUrl %>"
                            AnchorHorizontal="95%" />
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
        <ext:Button ID="btnSaveSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemMenuEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMenu_Click" Success="<%$ Resources : msgUpdateScript  %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMenu" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMenuEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
        <Listeners>
        <BeforeShow Handler="SetFieldTriggerShow(#{txtMenuName}, #{txtMenuName}.getValue());">
        </BeforeShow>
    </Listeners>
</ext:Window>
