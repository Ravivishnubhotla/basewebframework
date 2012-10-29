

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdAssignedHistortyEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdAssignedHistortyEdit" %>

<ext:Window ID="winSPAdAssignedHistortyEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPAdAssignedHistorty"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdAssignedHistortyEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
										 
						<ext:NumberField ID="numSPAdID" runat="server" FieldLabel="SPAdID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPAdPackID" runat="server" FieldLabel="SPAdPackID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
				 
						<ext:NumberField ID="numSPClientID" runat="server" FieldLabel="SPClientID"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateStartDate" runat="server" FieldLabel="StartDate" AllowBlank="True"   AnchorHorizontal="95%"/>
                
                 
						<ext:DateField  ID="dateEndDate" runat="server" FieldLabel="EndDate" AllowBlank="True"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numCreateBy" runat="server" FieldLabel="CreateBy"  AllowBlank="False"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateCreateAt" runat="server" FieldLabel="CreateAt" AllowBlank="False"   AnchorHorizontal="95%"/>
                
				 
						<ext:NumberField ID="numLastModifyBy" runat="server" FieldLabel="LastModifyBy"  AllowBlank="True"   AnchorHorizontal="95%"/>
                 	
                 
						<ext:DateField  ID="dateLastModifyAt" runat="server" FieldLabel="LastModifyAt" AllowBlank="True"   AnchorHorizontal="95%"/>
                
			
						<ext:TextField ID="txtLastModifyComment" runat="server" FieldLabel="LastModifyComment" AllowBlank="False"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPAdAssignedHistorty" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdAssignedHistortyEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPAdAssignedHistorty_Click" Success="Ext.MessageBox.alert('操作成功', 'Update a record success',callback);function callback(id) {#{formPanelSPAdAssignedHistortyEdit}.getForm().reset();#{storeSPAdAssignedHistorty}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdAssignedHistorty" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdAssignedHistortyEdit}.getForm().reset();#{winSPAdAssignedHistortyEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>







