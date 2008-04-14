<%@ Page Language="C#"  Theme="Standard"  MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"
 Codebehind="ViewPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.RoleManage.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="系统角色列表管理" OperationName="查看系统角色">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnDelete" runat="server" CssClass="AdminButton" Text="删除" OnClick="btnDelete_Click"
                    OnClientClick="javascript:return confirm('确定删除?');" />&nbsp;<asp:Button ID="btnEdit"
                        runat="server" CssClass="AdminButton" Text="编辑" OnClick="btnEdit_Click" />&nbsp;<asp:Button
                            ID="btnReturn" CssClass="AdminButton" runat="server" CausesValidation="False"
                            Text="返回列表" OnClick="btnReturn_Click" />
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
                                        系统角色</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        角色名称:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:Label ID="lblRoleName" ToolTip="角色名称" runat="server" Text=""></asp:Label>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        角色描述:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:Label ID="lblRoleDescription" ToolTip="角色描述" runat="server" Text=""></asp:Label>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" style="width: 15%">
                                        是否为系统角色:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:Label ID="lblRoleIsSystemRole" ToolTip="是否为系统角色" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                    <AspAjax:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            角色分配的应用
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%" cellpadding="1" cellspacing="3" border="0">
                                <tr align="center" valign="middle">
                                    <td colspan="4" class="table_body" align="right">
                                        <asp:Button ID="btnSaveAssignedApplication" CssClass="AdminButton" runat="server"
                                            CausesValidation="False" Text="保存分配的应用程序" OnClick="btnSaveAssignedApplication_Click" /></td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" rowspan="3" style="width: 15%">
                                        选择需要分配的应用：</td>
                                    <td class="table_none" colspan="3" rowspan="3">
                                        <asp:DataList ID="dgAssignedRole" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                            Width="100%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAssignedRole" runat="server" Text='<%# Eval("SystemApplicationName") %>'
                                                    value='<%# Eval("SystemApplicationID") %>' />
                                            </ItemTemplate>
                                        </asp:DataList></td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                    <AspAjax:TabPanel ID="TabPanel3" runat="server">
                        <HeaderTemplate>
                            角色分配的菜单
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%" cellpadding="1" cellspacing="3" border="0">
                                <tr align="center" valign="middle">
                                    <td colspan="4" class="table_body" align="right">
                                        <asp:Button ID="btnSaveAssignedMenu" CssClass="AdminButton" runat="server" CausesValidation="False"
                                            Text="保存分配的菜单" OnClick="btnSaveAssignedMenu_Click" /></td>
                                </tr>
                                <tr align="center" valign="middle">
                                    <td align="left" class="table_body" colspan="4">
                                        选择系统应用：
                                        <asp:DropDownList ID="ddlSelectApplication" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectApplication_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" rowspan="3" style="width: 15%">
                                        选择需要分配的菜单：</td>
                                    <td class="table_none" style="height: 350px;" colspan="3" rowspan="3">
                                        <asp:TreeView ID="tvMenus" runat="server" ShowLines="True" Style="width: 100%; height: 100%;
                                            padding: 0px; margin: 0px;" ShowCheckBoxes="All"
>
                                            <HoverNodeStyle CssClass="HoverTreeNode" />
                                            <SelectedNodeStyle CssClass="SelectedTreeNode" />
                                            <NodeStyle CssClass="TreeNode" />
                                        </asp:TreeView>
                                        <PowerAspWebUI:TreeViewExenter ID="TreeViewExenter1" runat="server" TargetTreeViewID="tvMenus">
                                        </PowerAspWebUI:TreeViewExenter>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                </AspAjax:TabContainer>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
