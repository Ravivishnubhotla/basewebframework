<%@ Page Language="C#" AutoEventWireup="true"  Theme="Standard"  CodeBehind="AddPage.aspx.cs" Inherits="BaseWebManager.Module.FrameWork.SystemApplicationManage.MenuManage.AddPage" %>
<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加新的系统菜单</title>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <meta http-equiv="expires" content="Mon, 23 Jan 1978 20:52:30 GMT">
    <link href="../../../../../Css/Site_Css.css" type="text/css" rel="stylesheet" />
        <link href="../../../../../Css/Site_Css.css" type="text/css" rel="stylesheet" />
        <link id="ctl00_AdminCssLink" rel="stylesheet" type="text/css" href="../../../../../css/table/default/Css.css"></link>
    <base target="_self">
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" cellpadding="5" cellspacing="1" border="0">
            <tr align="center" valign="middle">
                <td colspan="4" class="table_body">
                    系统菜单</td>
            </tr>
            <tr>
                <td align="left" class="table_body" style="width: 18%">
                    上级菜单</td>
                <td class="table_none" colspan="3">
                    <asp:Label ID="lblParentMenuName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="table_body" style="width: 18%;" align="left">
                    菜单名&nbsp;</td>
                <td colspan="3" class="table_none">
                    <asp:TextBox ID="txtMenuName" runat="server" Width="60%" MaxLength="50" CssClass="tex_input"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="table_body" style="width: 18%;" align="left">
                    菜单描述&nbsp;</td>
                <td colspan="3" class="table_none">
                    <textarea id="txtMenuDescription" class="tex_input" runat="server" rows="5"></textarea></td>
            </tr>
            <tr>
                <td align="left" class="table_body" style="width: 18%">
                    菜单链接</td>
                <td class="table_none" colspan="3">
                    <asp:TextBox ID="txtMenuUrl" runat="server" Width="80%" CssClass="tex_input"></asp:TextBox></td>
            </tr>
            <tr align="center" valign="middle">
                <td colspan="4" class="table_none" align="left">
                    &nbsp; &nbsp;&nbsp;<anthem:button id="btnSave" CssClass="btnOperation" runat="server" text="保存" OnClick="btnSave_Click"></anthem:button>
                    &nbsp;
                    <input type="button" value="返回" class="btnOperation" id="btnReturn" name="btnReturn"
                        runat="server" onclick="window.close();" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
