<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Theme="Standard" Codebehind="AddPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.ApplicationManage.AddPage" %>

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
            <td align="right">
                <asp:Button ID="btnSave" runat="server" CssClass="AdminButton" Text="保存" OnClick="btnSave_Click"
                    ValidationGroup="vgApplication" />
                &nbsp;&nbsp;<asp:Button ID="btnReturn" CssClass="AdminButton" runat="server" CausesValidation="False"
                    Text="返回列表" OnClick="btnReturn_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>&nbsp;</td>
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
                                    <td class="table_none" colspan="3">
                                        <asp:TextBox ID="txtSystemApplicationName" ToolTip="输入应用程序名称" MaxLength='200' runat="server"
                                            ValidationGroup="vgApplication"></asp:TextBox>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        应用程序描述:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:TextBox ID="txtSystemApplicationDescription" ToolTip="输入应用程序描述" MaxLength='2000'
                                            runat="server" Height="141px" TextMode="MultiLine" ValidationGroup="vgApplication"
                                            Width="321px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" style="width: 15%">
                                        应用程序链接:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:TextBox ID="txtSystemApplicationUrl" ToolTip="输入应用程序链接" MaxLength='200' runat="server"
                                            ValidationGroup="vgApplication"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtSystemApplicationUrl" runat="server" ControlToValidate="txtSystemApplicationUrl"
                                            Display="None" ErrorMessage="【应用程序链接】项不能为空！" SetFocusOnError="True" ValidationGroup="vgApplication"></asp:RequiredFieldValidator>
                                        <AspAjax:ValidatorCalloutExtender ID="vcerfvtxtSystemApplicationUrl" runat="server"
                                            TargetControlID="rfvtxtSystemApplicationUrl">
                                        </AspAjax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                </AspAjax:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
