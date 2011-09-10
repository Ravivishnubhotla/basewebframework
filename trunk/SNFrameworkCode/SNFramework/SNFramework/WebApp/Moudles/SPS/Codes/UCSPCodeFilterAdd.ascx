<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPCodeFilterAdd.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.UCSPCodeFilterAdd" %>
<ext:Window ID="winSPCodeFilterAdd" runat="server" Icon="ApplicationAdd" Title="SPCodeFilter Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPCodeFilterAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtCodeID" runat="server" FieldLabel="CodeID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsName" runat="server" FieldLabel="ParamsName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterType" runat="server" FieldLabel="FilterType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterValue" runat="server" FieldLabel="FilterValue" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPCodeFilter" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPCodeFilterAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPCodeFilter_Click"
                    Success="Ext.MessageBox.alert('Operation successful', 'Add a record success' ,callback);function callback(id) {#{formPanelSPCodeFilterAdd}.getForm().reset();#{storeSPCodeFilter}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPCodeFilter" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPCodeFilterAdd}.getForm().reset();#{winSPCodeFilterAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>

