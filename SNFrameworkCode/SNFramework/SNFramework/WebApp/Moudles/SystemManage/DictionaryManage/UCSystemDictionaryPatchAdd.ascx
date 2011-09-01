<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryPatchAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryPatchAdd" %>
<ext:Window ID="winSystemDictionaryPatchAdd" runat="server" Icon="ApplicationAdd"
    Title="<%$ Resources:msgFormTitle %>" Width="500" Height="390" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true" Resizable="true"
    Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryPatchAdd" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" Layout="Form">
            <Items>
                            <ext:DisplayField ID="lblDictionaryGroup"  FieldLabel="<%$ Resources:msgFiledCategory %>"  runat="server"  AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkHasValue" runat="server" FieldLabel="<%$ Resources:msgFiledIsHasValue %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemDictionaryItems" runat="server" FieldLabel="<%$ Resources:msgFiledDictionaryItem %>"
                    AnchorVertical="78%" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnPatchSavelSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
            Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryPatchAdd}.getForm().isValid()) return false;"
                    OnEvent="btnPatchSavelSystemDictionary_Click" Success="<%$ Resources : msgAddScript  %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDictionaryPatchAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{storeGroup}.reload();" />
    </Listeners>
</ext:Window>
