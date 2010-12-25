<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemUserAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.UserManage.UCSystemUserAdd" %>



<ext:Window ID="winSystemUserAdd" runat="server" Icon="Add" Title="Add System User" Width="400"
    Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" ConstrainHeader="true"
    Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemUserAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" LabelWidth="100">
            <Items>
                <ext:DropDownField ID="DropDownField1" runat="server" Editable="false" FieldLabel="Department" TriggerIcon="SimpleArrowDown" AnchorHorizontal="95%" >
                    <Component>
                        <ext:TreePanel ID="TreePanel1" 
                            runat="server" 
                            Icon="Accept"
                            Height="300"
                            Shadow="None"
                            UseArrows="true"
                            AutoScroll="true"
                            Animate="true"
                            EnableDD="true"
                            ContainerScroll="true"
                            RootVisible="false">
                            <Buttons>
                                <ext:Button ID="Button1" runat="server" Text="Close">
                                    <Listeners>
                                        <Click Handler="#{DropDownField1}.collapse();" />
                                    </Listeners>
                                </ext:Button>
                            </Buttons>
                            <Listeners>
                                <Click Handler="demo(#{hiddenDepartment1},#{DropDownField1},node)" />
                            </Listeners>
                         </ext:TreePanel>
                    </Component>
                    <Listeners>
                        <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                    </Listeners>
                </ext:DropDownField>
                <ext:TextField ID="txtUserLoginID" runat="server" FieldLabel="Login ID" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserName" runat="server" FieldLabel="Name" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserEmail" runat="server" FieldLabel="Email" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtUserPassword" runat="server" FieldLabel="Password" AllowBlank="False" AnchorHorizontal="95%" />
                <ext:TextField ID="txtComments" runat="server" FieldLabel="Comments" AllowBlank="True" AnchorHorizontal="95%" />
            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemUser" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemUserAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemUser_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success AddedSystem User',callback);function callback(id) {#{formPanelSystemUserAdd}.getForm().reset();#{storeSystemUser}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemUser" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemUserAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<ext:Hidden ID="hiddenDepartment1" runat="server"></ext:Hidden>
<script type="text/javascript">
    function demo(hiddenDepartment1, dropDownField, node) {
        dropDownField.setValue(node.text, node.id, false);
        hiddenDepartment1.setValue(node.attributes.did);
    }
</script>
