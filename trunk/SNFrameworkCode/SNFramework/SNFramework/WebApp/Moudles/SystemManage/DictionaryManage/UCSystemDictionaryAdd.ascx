<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryAdd.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryAdd" %>
<ext:Window ID="winSystemDictionaryAdd" runat="server" Icon="ApplicationAdd" Title="AddSystem Dictionary"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <content>
        <ext:FormPanel ID="formPanelSystemDictionaryAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtSystemDictionaryCategoryID" runat="server" FieldLabel="Category Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryKey" runat="server" FieldLabel="Key" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryValue" runat="server" FieldLabel="Value" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryDesciption" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSystemDictionaryOrder" runat="server" FieldLabel="Order Index" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkSystemDictionaryIsEnable" runat="server" FieldLabel="Is Enable" Checked="false"  AnchorHorizontal="95%"/>
                                       

            </Items>
        </ext:FormPanel>
    </content>
    <buttons>
        <ext:Button ID="btnSavelSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSystemDictionary_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Success AddedSystem Dictionary。',callback);function callback(id) {#{formPanelSystemDictionaryAdd}.getForm().reset();#{storeSystemDictionary}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionary" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDictionaryAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </buttons>
</ext:Window>