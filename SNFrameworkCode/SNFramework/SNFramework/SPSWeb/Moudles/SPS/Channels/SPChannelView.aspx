<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPChannelView.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.SPChannelView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
        var rooturl = '<%=this.ResolveUrl("~/")%>';

        var FormatBool = function (value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:TabPanel
                ID="tbMainInfo"
                runat="server"
                ActiveTabIndex="0">
                <Items>
                    <ext:Panel ID="formPanelSPChannelView" runat="server" Frame="true" Title="通道基本信息"
                        AutoScroll="true">
                        <Items>
                            <ext:Container ID="Container1" runat="server" Layout="Column" Height="150">
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="lblName" runat="server" FieldLabel="名称" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblChannelType" runat="server" FieldLabel="通道类型" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblIsMonitorRequest" runat="server" FieldLabel="是否监控" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblIsDisable" runat="server" FieldLabel="是否禁用" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblPrice" runat="server" FieldLabel="默认价格" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblChannelStatus" runat="server" FieldLabel="通道状态" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container3" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="lblCode" runat="server" FieldLabel="编码" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblStateReportType" runat="server" FieldLabel="状态报告类型" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblIsLogRequest" runat="server" FieldLabel="是否日志" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblHasFilters" runat="server" FieldLabel="是否过滤" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblDefaultRate" runat="server" FieldLabel="默认扣率" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblUpper" runat="server" FieldLabel="所属上家" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container4" runat="server" Layout="Form">
                                <Items>
                                    <ext:DisplayField ID="lblChannelDetailInfo" runat="server" FieldLabel="详细信息" AnchorHorizontal="95%" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Panel>

                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
