<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelFiltersView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelFiltersView" %>

<ext:Window ID="winSPChannelFiltersView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPChannelFilters"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelFiltersView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPChannelFiltersID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblChannelID" runat="server" FieldLabel="ChannelID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblParamsName" runat="server" FieldLabel="ParamsName" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblFilterType" runat="server" FieldLabel="FilterType" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblFilterValue" runat="server" FieldLabel="FilterValue" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
