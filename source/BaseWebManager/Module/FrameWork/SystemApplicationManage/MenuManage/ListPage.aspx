<%@ Page Language="C#" Theme="Standard" MasterPageFile="~/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" Codebehind="ListPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.MenuManage.ListPage"
    Title="Untitled Page" %>

<%@ Register Assembly="InputDialog" Namespace="SCS.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="菜单管理" OperationName="查看菜单">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Red"
                    Width="100%"></asp:Label><asp:Button ID="btnReset" class="btnOperation" runat="server"
                        Style="display: none;" OnClick="btnReset_Click" Text="重置" />
                <input id="hidSelectMenu" runat="server" name="hidSelectMenu" type="hidden" /></td>
        </tr>
        <tr>
            <td align="left">
                选择系统应用：
                <asp:DropDownList ID="ddlSelectApplication" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectApplication_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div style="margin: 0px; padding: 0px; width: 100%; overflow: hidden;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 442px;
                        border: solid 1px #6699CC;">
                        <tr style="height: 200px;">
                            <td runat="server" id="tdTree1" style="width: 250px; height: 442px;" align="left"
                                valign="top">
                                <div runat="server" id="divTree1" style="width: 250px; height: 100%; overflow: auto;
                                    padding: 0px; margin: 0px;">
                                    <asp:TreeView ID="tvMenus" runat="server" ShowLines="True" Style="width: 235px; height: 400px;
                                        padding: 0px; margin: 0px;" OnSelectedNodeChanged="tvMenus_SelectedNodeChanged">
                                        <HoverNodeStyle CssClass="HoverTreeNode" />
                                        <SelectedNodeStyle CssClass="SelectedTreeNode" />
                                        <NodeStyle CssClass="TreeNode" />
                                    </asp:TreeView>
                                </div>
                            </td>
                            <td id="tdMid1" style="height: 442px; width: 6px; background-color: lightsteelblue;">
                            </td>
                            <td id="tdEdit1" align="left" valign="top" style="height: 442px;">
                                <table width="100%" cellpadding="1" cellspacing="3" border="0">
                                    <tr>
                                        <td>
                                            <table width="100%" cellpadding="5" cellspacing="1" border="0">
                                                <tr align="center" valign="middle">
                                                    <td colspan="4" class="table_body">
                                                        系统菜单</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="table_body" style="width: 15%">
                                                        上级菜单</td>
                                                    <td class="table_none" colspan="3">
                                                        <asp:Label ID="lblParentMenuName" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="table_body" style="width: 15%;" align="left">
                                                        菜单名&nbsp;</td>
                                                    <td colspan="3" class="table_none">
                                                        <asp:TextBox ID="txtMenuName" runat="server" Width="200px" MaxLength="50" CssClass="tex_input"
                                                            ForeColor="Black"></asp:TextBox>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="table_body" style="width: 15%;" align="left">
                                                        菜单描述&nbsp;</td>
                                                    <td colspan="3" class="table_none">
                                                        <textarea id="txtMenuDescription" runat="server" class="tex_input" rows="5"></textarea></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="table_body" style="width: 15%">
                                                        菜单链接</td>
                                                    <td class="table_none" colspan="3">
                                                        <asp:TextBox ID="txtMenuUrl" runat="server" Width="60%" CssClass="tex_input"></asp:TextBox></td>
                                                </tr>
                                                <tr align="center" valign="middle">
                                                    <td colspan="4" align="left">
                                                        &nbsp;<input id="btnAddSubMenu" type="button" value="新增子菜单" class="AdminButton" runat="server"
                                                            disabled="disabled" visible="false" />
                                                        <input id="btnSave" type="button" value="修　　改" runat="server" class="AdminButton"
                                                            onserverclick="btnSave_ServerClick" disabled="disabled" visible="false" />
                                                        <input id="btnDelete" type="button" value="删　  除" runat="server" class="AdminButton"
                                                            onserverclick="btnDelete_ServerClick" disabled="disabled" visible="false" />
                                                        <input id="btnUp" type="button" value="上　  移" runat="server" class="AdminButton"
                                                            onserverclick="btnUp_ServerClick" disabled="disabled" visible="false" />
                                                        <input id="btnDown" type="button" value="下　  移" runat="server" class="AdminButton"
                                                            onserverclick="btnDown_ServerClick" disabled="disabled" visible="false" />
                                                        <input id="btnReSorted" runat="server" onserverclick="btnReSorted_ServerClick" type="button"
                                                            class="AdminButton" value="重新排序" disabled="disabled" visible="false" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <PowerAspWebUI:SplitterBar runat="server" ID="vsbSplitter1" LeftResizeTargets="tdTree1;divTree1"
                    MinWidth="100" MaxWidth="700" BackgroundColor="lightsteelblue" BackgroundColorLimit="firebrick"
                    BackgroundColorHilite="steelblue" BackgroundColorResizing="purple" SaveWidthToElement="txtWidth1"
                    Style="background-image: url(../../../../images/SplitterBar/vsplitter.gif); background-position: center center;
                    background-repeat: no-repeat;" />
            </td>
        </tr>
    </table>
</asp:Content>
