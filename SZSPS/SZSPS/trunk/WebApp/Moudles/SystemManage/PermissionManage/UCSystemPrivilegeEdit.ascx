<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemPrivilegeEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.UCSystemPrivilegeEdit" %>
<ext:Window ID="winSystemPrivilegeEdit" runat="server" Icon="ApplicationEdit" Title="EditSystem Permission"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemPrivilegeEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidPrivilegeID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
										 
						<ext:NumberField ID="radnumOperationID" runat="server" FieldLabel="Operation ID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="radnumResourcesID" runat="server" FieldLabel="Resources ID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
			
						<ext:TextField ID="txtPrivilegeCnName" runat="server" FieldLabel="Permission Name" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPrivilegeEnName" runat="server" FieldLabel="Permission Code" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDefaultValue" runat="server" FieldLabel="Default Value" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDescription" runat="server" FieldLabel="Permission Description" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPrivilegeOrder" runat="server" FieldLabel="Permission Order" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPrivilegeCategory" runat="server" FieldLabel="permission Category" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPrivilegeType" runat="server" FieldLabel="PrivilegeType" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemPrivilege" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemPrivilegeEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemPrivilege_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success upadted System Permission。',callback);function callback(id) {#{formPanelSystemPrivilegeEdit}.getForm().reset();#{storeSystemPrivilege}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemPrivilege" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemPrivilegeEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
