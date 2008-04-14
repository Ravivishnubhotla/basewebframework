<%@ Page Language="C#"  Theme="Standard"   MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.UserGroupManage.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="用户组列表管理" OperationName="列表用户组">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="AdminButton" Text="添加用户组" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <AspAjax:TabContainer ID="tabList" runat="server" ActiveTabIndex="0">
                    <AspAjax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            列表用户组
                        </HeaderTemplate>
                        <ContentTemplate>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="GroupID"  OnRowCommand="GridView1_RowCommand">
                <Columns>
					<asp:BoundField HeaderText="用户组中文名" DataField="GroupNameCn" />
					<asp:BoundField HeaderText="用户组英文名" DataField="GroupNameEn" />
					<asp:BoundField HeaderText="用户组描述" DataField="GroupDescription" />
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