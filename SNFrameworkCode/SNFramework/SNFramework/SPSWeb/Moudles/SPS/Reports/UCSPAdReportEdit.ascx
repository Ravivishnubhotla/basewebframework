

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdReportEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Reports.UCSPAdReportEdit" %>

<ext:Window ID="winSPAdReportEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPAdReport"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdReportEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
										 
						<ext:NumberField ID="numID" runat="server" FieldLabel="ID"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPAdID" runat="server" FieldLabel="SPAdID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPPackID" runat="server" FieldLabel="SPPackID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPClientID" runat="server" FieldLabel="SPClientID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateReportDate" runat="server" FieldLabel="ReportDate" AllowBlank="True"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numClientCount" runat="server" FieldLabel="ClientCount"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numAdCount" runat="server" FieldLabel="AdCount"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numAdAmount" runat="server" FieldLabel="AdAmount"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numCreateBy" runat="server" FieldLabel="CreateBy"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateCreateAt" runat="server" FieldLabel="CreateAt" AllowBlank="False"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numLastModifyBy" runat="server" FieldLabel="LastModifyBy"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateLastModifyAt" runat="server" FieldLabel="LastModifyAt" AllowBlank="True"   AnchorHorizontal="95%"/>
                
			
						<ext:TextField ID="txtLastModifyComment" runat="server" FieldLabel="LastModifyComment" AllowBlank="False"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPAdReport" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdReportEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPAdReport_Click" Success="Ext.MessageBox.alert('操作成功', 'Update a record success',callback);function callback(id) {#{formPanelSPAdReportEdit}.getForm().reset();#{storeSPAdReport}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdReport" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdReportEdit}.getForm().reset();#{winSPAdReportEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>







