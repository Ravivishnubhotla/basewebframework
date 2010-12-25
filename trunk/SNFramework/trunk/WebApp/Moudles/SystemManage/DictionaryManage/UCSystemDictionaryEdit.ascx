<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryEdit" %>
<ext:Window ID="winSystemDictionaryEdit" runat="server" Icon="ApplicationEdit" Title="EditSystem Dictionary"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidSystemDictionaryID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtSystemDictionaryCategoryID" runat="server" FieldLabel="Category Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryKey" runat="server" FieldLabel="Key" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryValue" runat="server" FieldLabel="Value" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryDesciption" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryOrder" runat="server" FieldLabel="Order Index" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkSystemDictionaryIsEnable" runat="server" FieldLabel="Is Enable" Checked="false"  AnchorHorizontal="95%"/>
                                       

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemDictionary" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDictionary_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success upadted System Dictionary。',callback);function callback(id) {#{formPanelSystemDictionaryEdit}.getForm().reset();#{storeSystemDictionary}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionary" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDictionaryEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

