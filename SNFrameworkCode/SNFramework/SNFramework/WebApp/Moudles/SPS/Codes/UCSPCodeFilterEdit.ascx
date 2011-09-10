<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeFilterEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeFilterEdit" %>
<ext:Window ID="winSPCodeFilterEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPCodeFilter"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeFilterEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtCodeID" runat="server" FieldLabel="CodeID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsName" runat="server" FieldLabel="ParamsName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterType" runat="server" FieldLabel="FilterType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterValue" runat="server" FieldLabel="FilterValue" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPCodeFilter" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeFilterEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPCodeFilter_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPCodeFilterEdit}.getForm().reset();#{storeSPCodeFilter}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCodeFilter" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPCodeFilterEdit}.getForm().reset();#{winSPCodeFilterEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>


