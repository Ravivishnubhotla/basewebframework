<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>һҹ�ɽ�����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="һҹ��,һҹ�ɽ���,һҹ�ɽ�����,���˽���,���˽�����" name="keywords" />
    <meta content="һҹ���ǹ������Ľ�����" name="description" />
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
                alert("�����������û�����");
                obj.user_name.focus();
                return false;
            }
            if (obj.user_pass.value == "") {
                alert("�������������룡");
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
                    <b>���棺</b>��վ�Խ�վ��������û�йرչ�����һֱʹ��<b>www.yiyeba.net</b>���Ψһ������!<br>
                    Ϊ�˱�������Ȩ���룺 <a onclick="javascript:window.external.AddFavorite('http://www.yiyeba.net/', 'һҹ�ɽ�����')"
                        href="javascript://" target="_self">�ղر�վ</a> �� <a onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.yiyeba.net/');return(false);"
                            href="javascript://">��Ϊ��ҳ</a> ���յ������������ղؼ�
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
                                        ��Ա�س� ��</div>
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
                                        ��Ա���� ��</div>
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
                                        ��֤�� ��</div>
                                </td>
                                <td height="40">
                                    <div align="left">
                                        <input name="Form_Code">
                                        <img alt="��������������ˢ��!" src="/Home/GetValidateImage" id="validimg" align="absmiddle" onclick="validimg.src='/Home/GetValidateImage?'+Math.random();"
                                            height="38px" />
                                    </div>
                                    ����������,�����ˢ��!
                                </td>
                            </tr>
                            <tr valign="center">
                                <td align="middle" colspan="2" height="43">
                                    <input style="border-right: #000000 1px solid; border-top: #000000 1px solid; font-size: 9pt;
                                        background: #f0f0f0; border-left: #000000 1px solid; width: 40px; border-bottom: #000000 1px solid;
                                        height: 20px" type="submit" value="��¼" name="Submit">
                                    <input style="border-right: #000000 1px solid; border-top: #000000 1px solid; font-size: 9pt;
                                        background: #f0f0f0; border-left: #000000 1px solid; width: 40px; border-bottom: #000000 1px solid;
                                        height: 20px" type="reset" value="����" name="Submit2">&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <b><font color="#ff0000">ע�⣺</font>��2010��<font color="#ff0000">10</font>��<font color="#ff0000">17</font>����һҹ�ɵ�������ַ������ַ��Ϊ��</b><br>
                    <span style="font-weight: 700; background-color: #000000"><a href="http://hi.baidu.com/yiyebanet/"
                        target="_blank"><font face="Arial" color="#ff0000">http://hi.baidu.com/yiyebanet/</font></a></span><b>���λ��Ա�ղغ�</b>
                    <p style="font-weight: bold; color: #ff0000">
                        <%= Html.ActionLink("���ע��һҹ�ɽ�������Ա","Reg", "Home")%>
                        <br />
                        <%= Html.ActionLink("��������", "ForgetPassword", "Home")%>
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
                    һҹ�ɽ�����&nbsp;&nbsp;&nbsp;���������뵽��������顱���ԣ�������鿴�����������ʼ���yiyeba@gmail.com������λ���������ϵ��
                    <br>
                    ע��:�������һ��Ҫ��������棬�����κ�����(��������)���������������Σ�ע�����ұ�����������ҷ�����ʶ��<br>
                    һҹ�ɽ�����Ŀǰ����������<b>17924��&nbsp;&nbsp;&nbsp;&nbsp;
                        <script language="javascript" src="js/2817703.js" type="text/javascript"></script>
                        <a href="http://www.miibeian.gov.cn/" target="_blank">��ICP��09084988��</a> </b>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
