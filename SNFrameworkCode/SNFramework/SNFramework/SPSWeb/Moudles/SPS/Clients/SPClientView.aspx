<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPClientView.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Clients.SPClientView" %>

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
                    <ext:Panel ID="formPanelSPChannelView" runat="server" Frame="true" Title="客户基本信息"
                        AutoScroll="true" Border="True">
                        <Items>
                            <ext:Container ID="Container1" runat="server" Layout="Column" Height="110">
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Layout="Form" ColumnWidth=".5" >
                                        <Items>
                                            <ext:DisplayField ID="lblName" runat="server" FieldLabel="名称" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblInterceptRate" runat="server" FieldLabel="默认扣率" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblDefaultPrice" runat="server" FieldLabel="默认价格" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container3" runat="server" Layout="Form" ColumnWidth=".5" >
                                        <Items>
                                            <ext:DisplayField ID="lblUserID" runat="server" FieldLabel="关联用户ID" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblSycnNotInterceptCount" runat="server" FieldLabel="默认免扣数" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblDefaultShowRecordDays" runat="server" FieldLabel="默认数据保留天数" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container4" runat="server" Layout="Form">
                                <Items>
                                    <ext:DisplayField ID="lblSycnDataInfo" runat="server" FieldLabel="数据同步信息" AnchorHorizontal="95%" />
                                    <ext:DisplayField ID="lblDescription" runat="server" FieldLabel="描述" AnchorHorizontal="95%" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel1" runat="server" Frame="true" Title="当前分配指令"
                        AutoScroll="true">
                        <Content>
                            客户分配指令
                        </Content>
                    </ext:Panel>
                    <ext:Panel ID="Panel2" runat="server" Frame="true" Title="分配指令历史"
                        AutoScroll="true">
                        <Content>
                            分配指令历史
                        </Content>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
