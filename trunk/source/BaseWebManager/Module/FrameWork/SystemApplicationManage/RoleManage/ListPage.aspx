<%@ Page Language="C#"  Theme="Standard"  MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"
  Codebehind="ListPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.RoleManage.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="系统角色列表管理" OperationName="列表系统角色">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="AdminButton" Text="添加系统角色" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <AspAjax:TabContainer ID="tabList" runat="server" ActiveTabIndex="0">
                    <AspAjax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            列表系统角色
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="RoleID" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="角色名称" DataField="RoleName" />
                                    <asp:BoundField HeaderText="角色描述" DataField="RoleDescription" />
                                    <asp:BoundField HeaderText="是否为系统角色" DataField="RoleIsSystemRoleString" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnView" runat="server" CommandName="cmdView">查看</asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="cmdDelete" OnClientClick="javascript:return confirm('确定删除?');">删除</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
