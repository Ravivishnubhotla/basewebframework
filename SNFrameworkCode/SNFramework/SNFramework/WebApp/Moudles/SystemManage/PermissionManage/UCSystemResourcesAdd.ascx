<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemResourcesAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemResourcesAdd" %>
<ext:Window ID="winSystemResourcesAdd" runat="server" Icon="ApplicationAdd" Title="Add Resourcse"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemResourcesAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            AutoScroll="true" Layout="Form">
            <Items>
                 <ext:DisplayField ID="lblParentResourcesName" runat="server" FieldLabel="Parent Resource" AnchorHorizontal="95%">
                </ext:DisplayField>
          
                <ext:Hidden ID="hidParentResourcesID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:TextField ID="txtResourcesNameCn" runat="server" FieldLabel="Name" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtResourcesNameEn" runat="server" FieldLabel="Code" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtResourcesDescription" runat="server" FieldLabel="Description" AllowBlank="True"
                    AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkResourcesIsRelateUser" runat="server" FieldLabel="Relate User"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSystemResources" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemResourcesAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemResources_Click" Success="Ext.MessageBox.alert('Operation successful', 'Add a Resourcse success!' ,callback);function callback(id) {#{formPanelSystemResourcesAdd}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemResources" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemResourcesAdd}.getForm().reset();#{winSystemResourcesAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
