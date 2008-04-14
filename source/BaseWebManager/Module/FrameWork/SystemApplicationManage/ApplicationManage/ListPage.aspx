<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true" Theme="Standard"  
 Codebehind="ListPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="系统应用列表管理" OperationName="列表系统应用">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="AdminButton" Text="添加系统应用" OnClick="btnAdd_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <AspAjax:TabContainer ID="tabList" runat="server" ActiveTabIndex="0">
                    <AspAjax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            列表系统应用
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="SystemApplicationID" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="应用程序名称" DataField="SystemApplicationName" />
                                    <asp:BoundField HeaderText="应用程序描述" DataField="SystemApplicationDescription" />
                                    <asp:BoundField HeaderText="应用程序链接" DataField="SystemApplicationUrl" />
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
