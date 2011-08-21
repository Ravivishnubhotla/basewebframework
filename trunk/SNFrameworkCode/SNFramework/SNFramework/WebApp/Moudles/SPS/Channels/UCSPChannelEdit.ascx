<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelEdit" %>
<ext:Window ID="winSPChannelEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPChannel"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
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
        <ext:Button ID="btnSaveSPChannel" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannel_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPChannelEdit}.getForm().reset();#{storeSPChannel}.reload(); };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannel" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelEdit}.getForm().reset();#{winSPChannelEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>



