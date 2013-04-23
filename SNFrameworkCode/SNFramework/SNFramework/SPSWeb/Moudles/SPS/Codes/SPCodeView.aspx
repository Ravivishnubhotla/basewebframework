<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPCodeView.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Codes.SPCodeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:FormPanel ID="formPanelSPCodeView" runat="server" Frame="true" Title="指令信息"
                MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
                Layout="Form">
                <Items>
                    <ext:DisplayField ID="lblChannelName" runat="server" FieldLabel="所属通道" AnchorHorizontal="95%" />
                    <ext:DisplayField ID="lblMoCodeCode" runat="server" FieldLabel="指令" AnchorHorizontal="95%" />
                    <ext:DisplayField ID="lblIsDiable" runat="server" FieldLabel="是否禁用" AnchorHorizontal="95%" />                   
                    <ext:DisplayField ID="lblPrice" runat="server" FieldLabel="默认价格" AnchorHorizontal="95%" />
                    <ext:DisplayField ID="lblPhoneLimitInfo" runat="server" FieldLabel="限量信息" AnchorHorizontal="95%" />
                    <ext:DisplayField ID="lblProvinceLimitInfo" runat="server" FieldLabel="限省信息" AnchorHorizontal="95%" />
                    <ext:DisplayField ID="lblAssignedClient" runat="server" FieldLabel="当前分配客户" AnchorHorizontal="95%" />
                </Items>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
