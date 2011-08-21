<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelSycnParamsView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Channels.UCSPChannelSycnParamsView" %>
<ext:Window ID="winSPChannelSycnParamsView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPChannelSycnParams"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPChannelSycnParamsView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPChannelSycnParamsID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsEnable" runat="server" FieldLabel="IsEnable" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblChannelID" runat="server" FieldLabel="ChannelID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblMappingParams" runat="server" FieldLabel="MappingParams" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblTitle" runat="server" FieldLabel="Title" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblParamsValue" runat="server" FieldLabel="ParamsValue" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblParamsType" runat="server" FieldLabel="ParamsType" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
