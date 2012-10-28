<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdPackView.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdPackView" %>
<ext:Window ID="winSPAdPackView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPAdPack"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdPackView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPAdPackID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblID" runat="server" FieldLabel="ID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblSPAdID" runat="server" FieldLabel="SPAdID" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>