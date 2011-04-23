<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ApplicationManage.UCSystemApplicationAdd" %>
<ext:Window ID="winSystemApplicationAdd" runat="server" Icon="ApplicationAdd" Title="System Application Add"
    Width="500" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130"
            AutoScroll="true" Layout="Form">
            <Items>
                <ext:TextField ID="txtSystemApplicationName" runat="server" FieldLabel="Name" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtSystemApplicationDescription" runat="server" FieldLabel="Description"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtSystemApplicationUrl" runat="server" FieldLabel="Url" AllowBlank="false"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkSystemApplicationIsSystemApplication" runat="server" Checked="true"
                    FieldLabel="System Application" AnchorHorizontal="95%">
                </ext:Checkbox>
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="Ext.MessageBox.alert('Operation successful', 'System Application Add Successful',callback);function callback(id) {#{formPanelSystemApplicationAdd}.getForm().reset();#{storeSystemApplication}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
