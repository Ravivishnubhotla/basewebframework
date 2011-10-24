<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryGroupAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryGroupAdd" %>
<ext:Window ID="winSystemDictionaryGroupAdd" runat="server" Icon="ApplicationAdd"
    Title="SystemDictionaryGroup Add " Width="400" Height="270" AutoShow="false"
    Maximizable="true" Modal="true" Hidden="true" AutoScroll="true" ConstrainHeader="true"
    Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryGroupAdd" runat="server" Frame="true"
            Header="false" MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":"
            LabelWidth="100" AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True" AnchorHorizontal="95%" />
                <ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkIsSystem" runat="server" FieldLabel="IsSystem" Checked="false"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemDictionaryGroup" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryGroupAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDictionaryGroup_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSystemDictionaryGroupAdd}.getForm().reset();#{storeSystemDictionaryGroup}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionaryGroup" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemDictionaryGroupAdd}.getForm().reset();#{winSystemDictionaryGroupAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
