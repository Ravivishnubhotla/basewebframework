<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.UCSystemUserEdit" %>
<ext:Window ID="winSystemUserEdit" runat="server" Icon="ApplicationEdit" Title="Edit System User"
    Width="430" Height="300" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <content>
        <ext:FormPanel ID="formPanelSystemUserEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidSystemUserID" runat="server">
                </ext:Hidden>

            
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="Name" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserEmail" runat="server" FieldLabel="Email" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtComments" runat="server" FieldLabel="Comments" AllowBlank="True"
                    AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </content>
    <buttons>
        <ext:Button ID="btnSaveSystemUser" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUser_Click" Success="Ext.MessageBox.alert('Operation Successful', 'Edit System User Successful',callback);function callback(id) {#{formPanelSystemUserEdit}.getForm().reset();#{storeSystemUser}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUser" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </buttons>
</ext:Window>
<ext:Hidden ID="hiddenDepartment1" runat="server">
</ext:Hidden>

 

