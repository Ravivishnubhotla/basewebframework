<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="ViewPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.UserGroupManage.ViewPage"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="用户组列表管理" OperationName="查看用户组">
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
                                        用户组</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%; height: 17px;" class="table_body" align="left">
                                        用户组中文名:</td>
                                    <td style="height: 17px;" class="table_none" colspan="3">
                                        <asp:Label ID="lblGroupNameCn" ToolTip="用户组中文名" runat="server" Text=""></asp:Label>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        用户组英文名:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:Label ID="lblGroupNameEn" ToolTip="用户组英文名" runat="server" Text=""></asp:Label>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" style="width: 15%">
                                        用户组描述:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:Label ID="lblGroupDescription" ToolTip="用户组描述" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                                        <AspAjax:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            用户组分配的角色
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%" cellpadding="1" cellspacing="3" border="0">
                                <tr align="center" valign="middle">
                                    <td colspan="4" class="table_body" align="right">
                                        <asp:Button ID="btnSaveAssignedRole" CssClass="AdminButton" runat="server"
                                            CausesValidation="False" Text="保存分配的角色" OnClick="btnSaveAssignedRole_Click" /></td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" rowspan="3" style="width: 15%">
                                        选择需要分配的角色：</td>
                                    <td class="table_none" colspan="3" rowspan="3">
                                        <asp:DataList ID="dgAssignedRole" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                            Width="100%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAssignedRole" runat="server" Text='<%# Eval("RoleName") %>'
                                                    value='<%# Eval("RoleID") %>' />
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
