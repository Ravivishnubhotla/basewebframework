<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeAdd" %>
<ext:Window ID="winSPCodeAdd" runat="server" Icon="ApplicationAdd" Title="SPCode Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtID" runat="server" FieldLabel="ID" AllowBlank="False"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtChannelID" runat="server" FieldLabel="ChannelID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMO" runat="server" FieldLabel="MO" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMOType" runat="server" FieldLabel="MOType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtOrderIndex" runat="server" FieldLabel="OrderIndex" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSPCode" runat="server" FieldLabel="SPCode" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtProvince" runat="server" FieldLabel="Province" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDisableCity" runat="server" FieldLabel="DisableCity" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkIsDiable" runat="server" FieldLabel="IsDiable" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtSPType" runat="server" FieldLabel="SPType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtCodeLength" runat="server" FieldLabel="CodeLength" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDayLimit" runat="server" FieldLabel="DayLimit" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtMonthLimit" runat="server" FieldLabel="MonthLimit" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPrice" runat="server" FieldLabel="Price" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtSendText" runat="server" FieldLabel="SendText" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkHasFilters" runat="server" FieldLabel="HasFilters" Checked="false"  AnchorHorizontal="95%"/>
                                       

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPCode" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPCode_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPCodeAdd}.getForm().reset();#{storeSPCode}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCode" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPCodeAdd}.getForm().reset();#{winSPCodeAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

