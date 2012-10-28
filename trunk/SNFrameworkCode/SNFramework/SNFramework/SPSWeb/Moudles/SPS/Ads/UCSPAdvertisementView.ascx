<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdvertisementView.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Ads.UCSPAdvertisementView" %>

<ext:Window ID="winSPAdvertisementView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPAdvertisement"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdvertisementView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSPAdvertisementID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblImageUrl" runat="server" FieldLabel="ImageUrl" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblAdPrice" runat="server" FieldLabel="AdPrice" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblAccountType" runat="server" FieldLabel="AccountType" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblApplyStatus" runat="server" FieldLabel="ApplyStatus" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblAdType" runat="server" FieldLabel="AdType" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblAdText" runat="server" FieldLabel="AdText" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsDisable" runat="server" FieldLabel="IsDisable" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblAssignedClient" runat="server" FieldLabel="AssignedClient" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateBy" runat="server" FieldLabel="CreateBy" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCreateAt" runat="server" FieldLabel="CreateAt" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyBy" runat="server" FieldLabel="LastModifyBy" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyAt" runat="server" FieldLabel="LastModifyAt" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblLastModifyComment" runat="server" FieldLabel="LastModifyComment" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>