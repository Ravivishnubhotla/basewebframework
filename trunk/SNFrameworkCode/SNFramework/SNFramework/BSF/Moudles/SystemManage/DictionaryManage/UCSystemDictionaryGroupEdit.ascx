<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryGroupEdit.ascx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryGroupEdit" %>



<ext:Window ID="winSystemDictionaryGroupEdit" runat="server" Icon="ApplicationEdit" Title="Edit SystemDictionaryGroup"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryGroupEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
					                                         
                                            <ext:Checkbox ID="chkIsEnable" runat="server" FieldLabel="IsEnable" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkIsSystem" runat="server" FieldLabel="IsSystem" Checked="false"  AnchorHorizontal="95%"/>
                                       

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemDictionaryGroup" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryGroupEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDictionaryGroup_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSystemDictionaryGroupEdit}.getForm().reset();#{storeSystemDictionaryGroup}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionaryGroup" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSystemDictionaryGroupEdit}.getForm().reset();#{winSystemDictionaryGroupEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>