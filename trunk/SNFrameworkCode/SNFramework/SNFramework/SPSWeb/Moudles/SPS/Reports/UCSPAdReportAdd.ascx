

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdReportAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Reports.UCSPAdReportAdd" %>
<ext:Window ID="winSPAdReportAdd" runat="server" Icon="ApplicationAdd" Title="SPAdReport Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdReportAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
				 
 
				 
<%--						<ext:NumberField ID="numSPAdID" runat="server" FieldLabel="SPAdID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPPackID" runat="server" FieldLabel="SPPackID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPClientID" runat="server" FieldLabel="SPClientID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	--%>
                 
						<ext:DateField  ID="dateReportDate" runat="server" FieldLabel="报表日期" AllowBlank="True"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numClientCount" runat="server" FieldLabel="ClientCount"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numAdCount" runat="server" FieldLabel="AdCount"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
<%--						<ext:NumberField ID="numAdAmount" runat="server" FieldLabel="AdAmount"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
 --%>

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPAdReport" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdReportAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPAdReport_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPAdReportAdd}.getForm().reset();#{storeSPAdReport}.reload(); };
" Failure="Ext.Msg.alert('Operation failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdReport" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdReportAdd}.getForm().reset();#{winSPAdReportAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
 

