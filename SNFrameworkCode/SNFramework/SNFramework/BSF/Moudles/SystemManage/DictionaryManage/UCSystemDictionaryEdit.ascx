<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryEdit.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryEdit" %>
<ext:Window ID="winSystemDictionaryEdit" runat="server" Icon="ApplicationEdit" Title="<%$ Resources:msgFormTitle %>"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemDictionaryID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblDictionaryGroup" FieldLabel="<%$ Resources:msgFiledCategory %>"
                    runat="server" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemDictionaryKey" runat="server" FieldLabel="<%$ Resources:msgFiledKey %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemDictionaryCode" runat="server" FieldLabel="<%$ Resources:msgFiledCode %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemDictionaryValue" runat="server" FieldLabel="<%$ Resources:msgFiledValue %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemDictionaryDesciption" runat="server" FieldLabel="<%$ Resources:msgFiledDescription %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemDictionaryOrder" runat="server" FieldLabel="<%$ Resources:msgFiledOrder %>"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemDictionaryIsEnable" runat="server" FieldLabel="<%$ Resources:msgFiledIsEnable %>"
                    Checked="false" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemDictionaryIsSystem" runat="server" FieldLabel="<%$ Resources:msgFiledIsSystem %>"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>"
            Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDictionary_Click" Success="<%$ Resources:msgUpdateScript %>"
                    Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
            Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDictionaryEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
