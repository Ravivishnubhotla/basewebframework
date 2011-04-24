<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemMoudleEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.MoudleManage.UCSystemMoudleEdit" %>

<ext:Window ID="winSystemMoudleEdit" runat="server" Icon="ApplicationEdit" Title="EditSystem Moudle"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemMoudleEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidMoudleID" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtMoudleNameCn" runat="server" FieldLabel="Moudle Name" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMoudleNameEn" runat="server" FieldLabel="Moudle Code" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMoudleNameDb" runat="server" FieldLabel="moudle of Table" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMoudleDescription" runat="server" FieldLabel="Moudle Description" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtApplicationID" runat="server" FieldLabel="Application ID" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkMoudleIsSystemMoudle" runat="server" FieldLabel="Is System Moudle" Checked="false"  AnchorHorizontal="95%"/>
                                       

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemMoudle" runat="server" Text="<%$ Resources : GlobalResource, msgEdit  %>" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemMoudleEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemMoudle_Click" Success="Ext.MessageBox.alert('Operation successful', 'Success upadted System Moudle。',callback);function callback(id) {#{formPanelSystemMoudleEdit}.getForm().reset();#{storeSystemMoudle}.reload(); };
" Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                    <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemMoudle" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemMoudleEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

