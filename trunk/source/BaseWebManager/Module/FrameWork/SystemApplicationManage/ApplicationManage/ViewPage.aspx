<%@ Page Language="C#"  MasterPageFile="~/MasterPage/PageTemplate.Master"  Theme="Standard"   AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="应用列表管理" OperationName="查看应用">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">               <asp:Button ID="btnDelete" runat="server" CssClass="AdminButton" Text="删除" OnClick="btnDelete_Click"  OnClientClick="javascript:return confirm('确定删除?');" />&nbsp;<asp:Button ID="btnEdit" runat="server" CssClass="AdminButton" Text="编辑" OnClick="btnEdit_Click" />&nbsp;<asp:Button ID="btnReturn" CssClass="AdminButton" runat="server" CausesValidation="False" Text="返回列表" OnClick="btnReturn_Click" />
            </td>
        </tr>
        <tr>
            <td>
                            <AspAjax:TabContainer ID="tabList" runat="server" ActiveTabIndex="0">
                    <AspAjax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            基本信息
                        </HeaderTemplate>
                        <ContentTemplate>
                <table width="100%" cellpadding="1" cellspacing="3" border="0">
                    <tr align="center" valign="middle">
                        <td colspan="4" class="table_body">
                            系统应用</td>
                    </tr>
                    <tr>
                        <td style="width: 15%;" class="table_body" align="left">
                            应用程序名称:</td>
                        <td class="table_none" colspan="3"><asp:Label ID="lblSystemApplicationName"  ToolTip="应用程序名称"  runat="server" Text=""></asp:Label>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15%;" class="table_body" align="left">
                            应用程序描述:</td>
                        <td class="table_none" colspan="3">
                            <asp:Label ID="lblSystemApplicationDescription"  ToolTip="应用程序描述"  runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" class="table_body" style="width: 15%">
                            应用程序链接:</td>
                        <td class="table_none" colspan="3"><asp:Label ID="lblSystemApplicationUrl"  ToolTip="应用程序链接"  runat="server" Text=""></asp:Label>
                            &nbsp; &nbsp;
                            </td>
                    </tr>
                </table>                        </ContentTemplate>
                    </AspAjax:TabPanel>
                </AspAjax:TabContainer>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState=False ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


