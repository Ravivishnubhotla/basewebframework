<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>一夜吧交友网</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="一夜吧,一夜吧交友,一夜吧交友网,成人交友,成人交友网" name="keywords" />
    <meta content="一夜吧是国内最大的交友网" name="description" />
    <style type="text/css">
        .STYLE2
        {
            color: #ff0000;
        }
    </style>
</head>
<body text="#000000" bgcolor="#ffbbff" topmargin="10" marginheight="0" marginwidth="0">
    <link href="../../Content/site.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
        function checklogin() {
            var obj = document.login;

            if (obj.user_name.value == "") {
                alert("请输入您的用户名！");
                obj.user_name.focus();
                return false;
            }
            if (obj.user_pass.value == "") {
                alert("请输入您的密码！");
                obj.user_pass.focus();
                return false;
            }



            return true;
        }
    </script>
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
                    <form name="login" onsubmit="return checklogin()" action="reg.asp?www_yiyeba_net=denglu"
                    method="post">
                    <p>
                        <img height="60" src="../../images/user.gif" width="300"><br>
                    </p>
                    <table id="table1" height="123" cellspacing="0" cellpadding="0" width="312" align="center"
                        border="0">
                        <tbody>
                            <tr valign="center">
                                <td align="middle" width="84" height="35">
                                    <div align="right">
                                        会员呢称 ：</div>
                                </td>
                                <td width="228" height="35">
                                    <div align="left">
                                        <input class="wenbenkuang" maxlength="20" size="25" name="user_name">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="middle" height="40">
                                    <div align="right">
                                        会员密码 ：</div>
                                </td>
                                <td height="40">
                                    <div align="left">
                                        <input class="wenbenkuang" type="password" maxlength="20" size="28" name="user_pass">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="middle" height="40">
                                    <div align="right">
                                        验证码 ：</div>
                                </td>
                                <td height="40">
                                    <div align="left">
                                        <input name="Form_Code">
                                        <img alt="看不清楚，点击可刷新!" src="/Home/GetValidateImage" id="validimg" align="absmiddle" onclick="validimg.src='/Home/GetValidateImage?'+Math.random();"
                                            height="38px" />
                                    </div>
                                    如果看不清楚,点击可刷新!
                                </td>
                            </tr>
                            <tr valign="center">
                                <td align="middle" colspan="2" height="43">
                                    <input style="border-right: #000000 1px solid; border-top: #000000 1px solid; font-size: 9pt;
                                        background: #f0f0f0; border-left: #000000 1px solid; width: 40px; border-bottom: #000000 1px solid;
                                        height: 20px" type="submit" value="登录" name="Submit">
                                    <input style="border-right: #000000 1px solid; border-top: #000000 1px solid; font-size: 9pt;
                                        background: #f0f0f0; border-left: #000000 1px solid; width: 40px; border-bottom: #000000 1px solid;
                                        height: 20px" type="reset" value="重置" name="Submit2">&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <b><font color="#ff0000">注意：</font>自2010年<font color="#ff0000">10</font>月<font color="#ff0000">17</font>日起，一夜吧的最新网址公布地址改为：</b><br>
                    <span style="font-weight: 700; background-color: #000000"><a href="http://hi.baidu.com/yiyebanet/"
                        target="_blank"><font face="Arial" color="#ff0000">http://hi.baidu.com/yiyebanet/</font></a></span><b>请各位会员收藏好</b>
                    <p style="font-weight: bold; color: #ff0000">
                        <%= Html.ActionLink("免费注册一夜吧交友网会员","Reg", "Home")%>
                        <br />
                        <%= Html.ActionLink("忘记密码", "ForgetPassword", "Home")%>
                    </p>
                    </form>
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
    <table cellspacing="0" cellpadding="0" width="780" align="center" border="0">
        <tbody>
            <tr>
                <td height="40">
                    <hr>
                </td>
            </tr>
            <tr>
                <td>
                    一夜吧交友网&nbsp;&nbsp;&nbsp;如有问题请到“经验或建议”留言，更多请查看“帮助”或发邮件到yiyeba@gmail.com，需广告位请与吧主联系。
                    <br>
                    注意:会见网友一定要提防各方面，出现任何意外(谨防酒托)，交友网不负责任；注意自我保护，提高自我防护意识。<br>
                    一夜吧交友网目前在线人数：<b>17924人&nbsp;&nbsp;&nbsp;&nbsp;
                        <script language="javascript" src="js/2817703.js" type="text/javascript"></script>
                        <a href="http://www.miibeian.gov.cn/" target="_blank">京ICP备09084988号</a> </b>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
