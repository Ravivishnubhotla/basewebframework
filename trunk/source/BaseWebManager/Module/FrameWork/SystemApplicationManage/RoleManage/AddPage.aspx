<%@ Page Language="C#" Theme="Standard" MasterPageFile="~/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" Codebehind="AddPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.RoleManage.AddPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="系统角色管理" OperationName="添加系统角色">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" CssClass="AdminButton" Text="保存" OnClick="btnSave_Click"
                    ValidationGroup="vgSystemRole" />
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
                                        系统角色</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        角色名称:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:TextBox ID="txtRoleName" ToolTip="输入角色名称" MaxLength='50' runat="server" ValidationGroup="vgSystemRole"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="rfvtxtRoleName" runat="server" ControlToValidate="txtRoleName" Display="None"
                                            ErrorMessage="【角色名称】项不能为空！" SetFocusOnError="True" ValidationGroup="vgSystemRole"></asp:RequiredFieldValidator><AspAjax:ValidatorCalloutExtender
                                                ID="vcerfvtxtRoleName" runat="server" TargetControlID="rfvtxtRoleName">
                                            </AspAjax:ValidatorCalloutExtender>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%;" class="table_body" align="left">
                                        角色描述:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:TextBox ID="txtRoleDescription" ToolTip="输入角色描述" MaxLength='2000' TextMode="MultiLine"
                                            runat="server" ValidationGroup="vgSystemRole" Height="105px" Width="476px"></asp:TextBox>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="table_body" style="width: 15%">
                                        是否为系统角色:</td>
                                    <td class="table_none" colspan="3">
                                        <asp:CheckBox ID="chkRoleIsSystemRole" runat="server" ToolTip="是否为系统角色" ValidationGroup="vgSystemRole" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                </AspAjax:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
