<%@ Page Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.UserGroupManage.EditPage" Title="Untitled Page" Theme="Standard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="用户组管理" OperationName=" 编辑用户组">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">				
				<asp:Button ID="btnDelete" runat="server" CssClass="AdminButton" Text="删除" OnClick="btnDelete_Click"  OnClientClick="javascript:return confirm('确定删除?');" />&nbsp;
                <asp:Button ID="btnSave" runat="server" CssClass="AdminButton" Text="保存" OnClick="btnSave_Click"  ValidationGroup="vgSystemUserGroup" />&nbsp;<asp:Button ID="btnReturn" CssClass="AdminButton" runat="server" CausesValidation="False" Text="返回列表" OnClick="btnReturn_Click" />			
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState=False ForeColor="Red"></asp:Label>&nbsp;</td>
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
					<td colspan="4"    class="table_body">用户组</td>
				</tr>
				<tr>
                  <td  style="width:15%;"  class="table_body" align="left">用户组中文名:</td>
					<td  class="table_none" colspan="3">
					<asp:textbox id="txtGroupNameCn" ToolTip="输入用户组中文名"  MaxLength='200'   runat="server"   ValidationGroup="vgSystemUserGroup" Width="298px"></asp:textbox>&nbsp;</td>
	            </tr>
    <tr>
        <td align="left" class="table_body" style="width: 15%">
            用户组英文名:</td>
        <td class="table_none" colspan="3">
					<asp:textbox id="txtGroupNameEn" ToolTip="输入用户组英文名"  MaxLength='200'   runat="server"   ValidationGroup="vgSystemUserGroup" Width="297px"></asp:textbox></td>
    </tr>
				<tr>
                  <td  style="width:15%;"  class="table_body" align="left">用户组描述:</td>
					<td  class="table_none" colspan="3">
					<asp:textbox id="txtGroupDescription" ToolTip="输入用户组描述"  MaxLength='2000'   runat="server"   ValidationGroup="vgSystemUserGroup" Height="80px" TextMode="MultiLine" Width="298px"></asp:textbox>
                        &nbsp;
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
