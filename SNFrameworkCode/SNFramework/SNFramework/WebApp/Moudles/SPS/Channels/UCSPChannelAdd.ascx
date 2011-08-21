<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelAdd" %>
<ext:Window ID="winSPChannelAdd" runat="server" Icon="ApplicationAdd" Title="SPChannel Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtName" runat="server" FieldLabel="Name" AllowBlank="True"  AnchorHorizontal="95%" />
              
					
						<ext:TextArea ID="txtDescription" runat="server" FieldLabel="Description" AllowBlank="True"  AnchorHorizontal="95%"/>
                   
			
						<ext:TextField ID="txtCode" runat="server" FieldLabel="Code" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkOtherRecieved" runat="server" FieldLabel="OtherRecieved" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtOtherRecievedUrl" runat="server" FieldLabel="OtherRecievedUrl" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtRecievedName" runat="server" FieldLabel="RecievedName" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkIsAllowNullLinkID" runat="server" FieldLabel="IsAllowNullLinkID" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkIsMonitorRequest" runat="server" FieldLabel="IsMonitorRequest" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkIsDisable" runat="server" FieldLabel="IsDisable" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtDataOkMessage" runat="server" FieldLabel="DataOkMessage" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDataFailedMessage" runat="server" FieldLabel="DataFailedMessage" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtReportOkMessage" runat="server" FieldLabel="ReportOkMessage" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtReportFailedMessage" runat="server" FieldLabel="ReportFailedMessage" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkStatSendOnce" runat="server" FieldLabel="StatSendOnce" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkTypeRequest" runat="server" FieldLabel="TypeRequest" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtDataParamName" runat="server" FieldLabel="DataParamName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDataParamValue" runat="server" FieldLabel="DataParamValue" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtReportParamName" runat="server" FieldLabel="ReportParamName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtReportParamValue" runat="server" FieldLabel="ReportParamValue" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkHasFilters" runat="server" FieldLabel="HasFilters" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtStatusParamName" runat="server" FieldLabel="StatusParamName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtStatusParamValue" runat="server" FieldLabel="StatusParamValue" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtPrice" runat="server" FieldLabel="Price" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtDefaultRate" runat="server" FieldLabel="DefaultRate" AllowBlank="True"  AnchorHorizontal="95%" />
              
					                                         
                                            <ext:Checkbox ID="chkHasStatReport" runat="server" FieldLabel="HasStatReport" Checked="false"  AnchorHorizontal="95%"/>
                                       
			
						<ext:TextField ID="txtChannelDetailInfo" runat="server" FieldLabel="ChannelDetailInfo" AllowBlank="True"  AnchorHorizontal="95%" />
              
					 <ext:ComboBox ID="cmbUpperID" Editable="false" runat="server" FieldLabel="UpperID"   AllowBlank="True" 
                                                SelectedIndex="0" AnchorHorizontal="95%">
                                                <Items>

                                                </Items>
                                            </ext:ComboBox> 
					                                         
                                            <ext:Checkbox ID="chkIsIVR" runat="server" FieldLabel="IsIVR" Checked="false"  AnchorHorizontal="95%"/>
                                       
					                                         
                                            <ext:Checkbox ID="chkIsLogRequest" runat="server" FieldLabel="IsLogRequest" Checked="false"  AnchorHorizontal="95%"/>
                                       

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannel" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannel_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPChannelAdd}.getForm().reset();#{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelAdd}.getForm().reset();#{winSPChannelAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
