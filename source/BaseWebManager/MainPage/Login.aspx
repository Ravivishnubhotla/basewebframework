<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BaseWebManager.MainPage.Login" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body scroll="no" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
        <tr>
            <td width="100%" height="50" colspan="3" style="border-bottom: 1px solid #000000">
                <table height="49" border="0" cellspacing="0" cellpadding="0" width="100%" class="font_size">
                    <tr>
                        <td style="background-image: url(../images/top-gray.gif); background-repeat: no-repeat;
                            background-position: right top">
                            <asp:Label ID="lblSystemName" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                    <form id="Form1" name="login" method="post" runat="server" defaultfocus="LoginName">
                        <tr>
                            <td>
                                <table width="431" border="0" cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td colspan="2" background="../images/Logon/Logon_1.gif" width="431" height="125">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <img src="../images/Logon/Logon_2.gif" width="431" height="30" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/Logon/Logon_3.gif" width="194" height="28" alt="" /></td>
                                        <td background="../images/Logon/Logon_4.gif" width="237">
                                            <asp:TextBox ID="txtLoginName" class="text_input" title="请输入帐号~!" runat="server" Style="width: 138px;"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/Logon/Logon_5.gif" width="194" height="24" alt="" /></td>
                                        <td background="../images/Logon/Logon_6.gif">
                                            <asp:TextBox ID="txtLoginPassword" runat="server" class="text_input" title="请输入密码~!" TextMode="Password"
                                                Style="width: 138px;"></asp:TextBox></td>
                                    </tr>
                                    <tr style="display:none">
                                        <td>
                                            <img src="../images/Logon/Logon_7.gif" width="194" height="25" alt="" /></td>
                                        <td background="../images/Logon/Logon_8.gif">
                                            <asp:TextBox ID="txtCheckCode" class="text_input" runat="server" Columns="4" title="请输入验证码~4:!"></asp:TextBox>请输入<img
                                                src="" id="ImageCheck" align="absmiddle" style="cursor: pointer"
                                                width="45" height="20" onclick="alert('ssss');" title="点击更换验证码图片!" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/Logon/Logon_9.gif" width="194" height="40" alt="" /></td>
                                        <td background="../images/Logon/Logon_10.gif">
                                            <asp:Button ID="btnLogin" runat="server" Text="确定" class="button_bak" OnClick="btnLogin_Click" />
                                            <input type="reset" value="重填" class="button_bak" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <img src="../images/Logon/Logon_11.gif" width="431" height="39" alt="" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <b>提醒 : </b>本管理系统建议议采用Internet Explorer 5.5 (或以上版本) 的浏览器。请开启浏览器的 Cookies 与 JavaScript
                                            功能。</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </form>
                </table>
            </td>
        </tr>
    </table>
        <tr>
            <td colspan="3" height="20">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="20">
                    <tr>
                        <td class="down_text">
                            <asp:Label ID="lblLisence" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
</body>
</html>


