<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<%@ Register Src="UserControls/Sites/UCFooter.ascx" TagName="UCFooter" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>一夜吧交友网</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="一夜吧,一夜吧交友,一夜吧交友网,成人交友,成人交友网" name="keywords" />
    <meta content="一夜吧是国内最大的交友网" name="description" />
</head>
<body text="#000000" bgcolor="#ffbbff" topmargin="10" marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
    <link href="css/site.css" type="text/css" rel="stylesheet" />
    <table height="400" cellspacing="0" cellpadding="0" width="780" align="center" border="0">
        <tbody>
            <tr>
                <td width="127">
                </td>
                <td width="10">
                </td>
                <td align="middle" width="571">
                    <br>
                    <br>
                    <br>
                    <b>公告：</b>本站自建站以来从来没有关闭过，并一直使用<b>www.yiyeba.net</b>这个唯一的域名!<br>
                    为了保护您的权益请： <a onclick="javascript:window.external.AddFavorite('http://www.yiyeba.net/', '一夜吧交友网')"
                        href="javascript://" target="_self">收藏本站</a> ┃ <a onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.yiyeba.net/');return(false);"
                            href="javascript://">设为首页</a> 或收到到您的网络收藏夹
                    <p>
                        <img height="60" src="~/images/user.gif" alt="" width="300" runat="server"><br />
                    </p>
                    <table id="table1" cellspacing="0" cellpadding="0" width="380" align="center" border="0">
                        <tbody>
                            <tr valign="center">
                                <td width="84" height="35" align="right">
                                    会员呢称 ：
                                </td>
                                <td width="228" height="35" align="left">
                                    <input id="txtLoginID" type="text" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="40">
                                    会员密码 ：
                                </td>
                                <td height="40" align="left">
                                    <input id="txtPassword" type="password" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="40">
                                    验证码 ：
                                </td>
                                <td height="40" align="left">
                                    <img alt="看不清楚，点击可刷新!" src="/Handles/VerifyImage.ashx" id="validimg" align="absmiddle"
                                        onclick="validimg.src='/Handles/VerifyImage.ashx?'+Math.random();" height="38px" />
                                    如果看不清楚,点击可刷新!
                                </td>
                            </tr>
                            <tr valign="center">
                                <td align="middle" colspan="2" height="43">
                                    <input class="btn" type="button" value="登录" id="btnLogin" runat="server" />
                                    <input class="btn" type="reset" value="重置" id="btnReset" runat="server" />&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <b><font color="#ff0000">注意：</font>自2010年<font color="#ff0000">10</font>月<font color="#ff0000">17</font>日起，一夜吧的最新网址公布地址改为：</b><br>
                    <span style="font-weight: 700; background-color: #000000"><a href="http://hi.baidu.com/yiyebanet/"
                        target="_blank"><font face="Arial" color="#ff0000">http://hi.baidu.com/yiyebanet/</font></a></span><b>请各位会员收藏好</b>
                        <p style="font-weight: bold; color: #FF0000">
                        <a href="~/Homes/Reg.aspx" runat="server">免费注册一夜吧交友网会员</a><br>
                        <br>
                        <a href="~/Homes/ForgetPassword.aspx" runat="server">忘记密码</a></p>
                </td>
                <td align="middle" width="72" colspan="3">
                </td>
            </tr>
        </tbody>
    </table>
    <table width="780" align="center">
        <tbody>
            <tr>
                <td>
                    <br>
                    <br>
                    <br>
                    <br>
                </td>
            </tr>
        </tbody>
    </table>
    <uc1:UCFooter ID="UCFooter1" runat="server" />
    </form>
</body>
</html>
