<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelFiltersEdit.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelFiltersEdit" %>

<ext:Window ID="winSPChannelFiltersEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPChannelFilters"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true"  Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelFiltersEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>
			
			 <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>
			
									
						<ext:TextField ID="txtChannelID" runat="server" FieldLabel="ChannelID" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtParamsName" runat="server" FieldLabel="ParamsName" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterType" runat="server" FieldLabel="FilterType" AllowBlank="True"  AnchorHorizontal="95%" />
              
			
						<ext:TextField ID="txtFilterValue" runat="server" FieldLabel="FilterValue" AllowBlank="True"  AnchorHorizontal="95%" />
              

            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPChannelFilters" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPChannelFiltersEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPChannelFilters_Click" Success="Ext.MessageBox.alert('Operation successful', 'Update a record success',callback);function callback(id) {#{formPanelSPChannelFiltersEdit}.getForm().reset();#{storeSPChannelFilters}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPChannelFilters" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPChannelFiltersEdit}.getForm().reset();#{winSPChannelFiltersEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
