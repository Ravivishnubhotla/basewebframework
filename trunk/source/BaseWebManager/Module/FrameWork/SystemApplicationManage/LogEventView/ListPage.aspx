<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Theme="Standard" Codebehind="ListPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.LogEventView.ListPage"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="事件日志管理" OperationName="事件日志列表">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <AspAjax:TabContainer ID="tabList" runat="server" ActiveTabIndex="0">
                    <AspAjax:TabPanel ID="tpList" runat="server" HeaderText="List">
                        <HeaderTemplate>
                            日志列表
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:GridView ID="systemLogGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="systemLogGridView_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="LogID" />
                                    <asp:BoundField HeaderText="用户名" DataField="LogUser" />
                                    <asp:BoundField HeaderText="客户端IP" DataField="LogRequestInfo" />
                                    <asp:BoundField HeaderText="事件类型" DataField="LogType" />
                                    <asp:BoundField HeaderText="内容" DataField="LogDescrption" />
                                    <asp:BoundField HeaderText="日志日期" DataField="LogDate" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnView" runat="server" CommandName="cmdView">查看</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                    <AspAjax:TabPanel ID="tpSearch" runat="server" HeaderText="Search">
                        <HeaderTemplate>
                            查询
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="1" cellspacing="3">
                                <tr align="center" valign="middle">
                                    <td colspan="4" class="table_body">
                                        系统事件日志
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        用户名
                                    </td>
                                    <td style="width: 35%;" class="table_none">
                                        <asp:TextBox ID="txtLogUser" ToolTip="输入日志用户关键字" MaxLength='200' runat="server" Width="149px"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        日志类型
                                    </td>
                                    <td style="width: 35%;" class="table_none">
                                        <asp:DropDownList ID="ddlLogType" ToolTip="选择日志类型" runat="server" Width="149px">
                                            <asp:ListItem Value="0">安全访问</asp:ListItem>
                                            <asp:ListItem Value="1">授权</asp:ListItem>
                                            <asp:ListItem Value="2">业务操作</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        应用/模块
                                    </td>
                                    <td style="width: 35%;" class="table_none">
                                        <asp:DropDownList ID="ddlLogRelateMoudleID" ToolTip="选择相关模块" runat="server" Width="149px">
                                            <asp:ListItem Value="0">消息</asp:ListItem>
                                            <asp:ListItem Value="1">警告</asp:ListItem>
                                            <asp:ListItem Value="2">调试</asp:ListItem>
                                            <asp:ListItem Value="3">出错</asp:ListItem>
                                        </asp:DropDownList></td>
                                   <td style="width: 15%;" class="table_body" align="left">
                                        时间
                                    </td>
                                    <td style="width: 35%;" class="table_none">
                                        <asp:TextBox ID="txtLogDateFrom" ToolTip="输入日志起始日期" runat="server" Width="149px"></asp:TextBox>&nbsp;~&nbsp;
                                        <asp:TextBox ID="txtLogDateTo" ToolTip="输入日志结束日期" runat="server" Width="148px"></asp:TextBox>
                                        <AspAjax:CalendarExtender ID="cetxtLogDateFrom" runat="server" TargetControlID="txtLogDateFrom"
                                            Enabled="True">
                                        </AspAjax:CalendarExtender>
                                        <AspAjax:CalendarExtender ID="cetxtLogDateTo" runat="server" TargetControlID="txtLogDateTo"
                                            Enabled="True">
                                        </AspAjax:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                     <td style="width: 15%;" class="table_body" align="left">
                                        内容
                                    </td>
                                    <td style="width: 35%;" class="table_none">
                                        <asp:TextBox ID="txtLogDescrption" ToolTip="输入日志内容关键字" MaxLength='2000' runat="server" Width="100%"></asp:TextBox>
                                    </td>
                                    <td class="table_none" colspan="2"></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="AdminButton" Text="查询" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                </AspAjax:TabContainer>
            </td>
        </tr>
        <tr>
            <td>
                <webdiyer:AspNetPager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
