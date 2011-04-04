<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemApplicationEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ApplicationManage.UCSystemApplicationEdit" %>
<ext:Window ID="winSystemApplicationEdit" runat="server" Icon="ApplicationEdit" Title="System Application Eidt"
    Width="500" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemApplicationEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="130" AutoScroll=true>
            <Items>
                <ext:Hidden ID="hidSystemApplicationID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
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
        <ext:Button ID="btnSaveSystemApplication" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemApplicationEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemApplication_Click" Success="Ext.MessageBox.alert('Operation successful','System Application Updated Successful',callback);function callback(id) { #{storeSystemApplication}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemApplication" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemApplicationEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>