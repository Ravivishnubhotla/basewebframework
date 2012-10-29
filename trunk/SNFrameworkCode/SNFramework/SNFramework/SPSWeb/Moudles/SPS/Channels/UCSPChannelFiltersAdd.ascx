<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelFiltersAdd.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.UCSPChannelFiltersAdd" %>
<ext:Window ID="winSPChannelFiltersAdd" runat="server" Icon="ApplicationAdd" Title="SPChannelFilters Add "
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelFiltersAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"  AutoScroll="true"
            Layout="Form">
            <Items>
			
						<ext:TextField ID="txtChannelID" runat="server" FieldLabel="ChannelID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsName" runat="server" FieldLabel="ParamsName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterType" runat="server" FieldLabel="FilterType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterValue" runat="server" FieldLabel="FilterValue" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSavelSPChannelFilters" runat="server" Text="Add" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelFiltersAdd}.getForm().isValid()) return false;" OnEvent="btnSaveSPChannelFilters_Click"
                    Success="Ext.MessageBox.alert('操作成功', 'Add a record success' ,callback);function callback(id) {#{formPanelSPChannelFiltersAdd}.getForm().reset();#{storeSPChannelFilters}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelFilters" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelFiltersAdd}.getForm().reset();#{winSPChannelFiltersAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
