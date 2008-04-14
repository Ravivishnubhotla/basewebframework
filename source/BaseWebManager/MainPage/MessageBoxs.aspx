<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MessageBoxs.aspx.cs" Inherits="BaseWebManager.MainPage.MessageBoxs" %>
<%@ Import namespace="Powerasp.Enterprise.Core.BaseManager.Web"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" href="/css/Site_Css.css" type="text/css">
    <style type="text/css">
<!--
.style3 {
	font-size: 18px;
	font-weight: bold;
}
-->
</style>
</head>
<body bgcolor="#EEEEEE">
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="MessageDispBox" runat="server" OnItemDataBound="MessageDispBox_ItemDataBound">
                <ItemTemplate>
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr height="20%">
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <table width="200" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td runat="server" id="tdHead" height="48" valign="middle" background="~/images/MessageIcon/MessageHead.gif">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="7%" height="8">
                                                    </td>
                                                    <td width="93%" align="left">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td align="left">
                                                        <span class="style3">
                                                            <%# Eval("M_Title")%>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="tdBody" background="~/images/MessageIcon/MessageBody.gif">
                                            <table width="100%" style="table-layout: fixed;" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="6%">
                                                        &nbsp;</td>
                                                    <td width="11%" height="120">
                                                        <img id="imgMessageIcon" runat="server" src='<%#  "~/images/MessageIcon/" + Get_M_IconType((Icon_Type)Eval("M_IconType"))%>'></td>
                                                    <td width="77%" align="left">
                                                        <table width="100%" border="0" cellspacing="10" cellpadding="0">
                                                            <tr>
                                                                <td style="word-break: break-all;">
                                                                    <%# Eval("M_Body")%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="6%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td align="left">
                                                        <%# Get_M_ButtonList((System.Collections.Generic.List<WebNavigationUrl>)Eval("M_ButtonList"))%>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img id="imgEnd" runat="server" src="~/images/MessageIcon/MessageEnd.gif" width="459"
                                                height="29" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
<%=ReturnScript %>
</html>
