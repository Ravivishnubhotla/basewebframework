<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemResourcesEdit.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemResourcesEdit" %>
<ext:Window ID="winSystemResourcesEdit" runat="server" Icon="ApplicationEdit" Title="Edit resource"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemResourcesEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            AutoScroll="true" LabelWidth="100">
            <Items>
                <ext:Hidden ID="hidResourcesID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
                <ext:DisplayField ID="lblParentResourcesName" runat="server" FieldLabel="Parent Resource Name"
                    AnchorHorizontal="95%">
                </ext:DisplayField>
                <ext:TextField ID="txtResourcesNameCn" runat="server" FieldLabel="Name" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtResourcesNameEn" runat="server" FieldLabel="Code" AllowBlank="False"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtResourcesDescription" runat="server" FieldLabel="Description"
                    AllowBlank="True" AnchorHorizontal="95%" />
                <ext:Checkbox ID="chkResourcesIsRelateUser" runat="server" FieldLabel="Relate User"
                    Checked="false" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemResources" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemResourcesEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemResources_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSystemResourcesEdit}.getForm().reset();RefreshTreeList1(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemResources" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemResourcesEdit}.getForm().reset();#{winSystemResourcesEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
