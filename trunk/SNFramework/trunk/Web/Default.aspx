<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<%@ Register Src="UserControls/Sites/UCFooter.ascx" TagName="UCFooter" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>һҹ�ɽ�����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="һҹ��,һҹ�ɽ���,һҹ�ɽ�����,���˽���,���˽�����" name="keywords" />
    <meta content="һҹ���ǹ������Ľ�����" name="description" />
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
                    <b>���棺</b>��վ�Խ�վ��������û�йرչ�����һֱʹ��<b>www.yiyeba.net</b>���Ψһ������!<br>
                    Ϊ�˱�������Ȩ���룺 <a onclick="javascript:window.external.AddFavorite('http://www.yiyeba.net/', 'һҹ�ɽ�����')"
                        href="javascript://" target="_self">�ղر�վ</a> �� <a onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.yiyeba.net/');return(false);"
                            href="javascript://">��Ϊ��ҳ</a> ���յ������������ղؼ�
                    <p>
                        <img height="60" src="~/images/user.gif" alt="" width="300" runat="server"><br />
                    </p>
                    <table id="table1" cellspacing="0" cellpadding="0" width="380" align="center" border="0">
                        <tbody>
                            <tr valign="center">
                                <td width="84" height="35" align="right">
                                    ��Ա�س� ��
                                </td>
                                <td width="228" height="35" align="left">
                                    <input id="txtLoginID" type="text" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="40">
                                    ��Ա���� ��
                                </td>
                                <td height="40" align="left">
                                    <input id="txtPassword" type="password" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="40">
                                    ��֤�� ��
                                </td>
                                <td height="40" align="left">
                                    <img alt="��������������ˢ��!" src="/Handles/VerifyImage.ashx" id="validimg" align="absmiddle"
                                        onclick="validimg.src='/Handles/VerifyImage.ashx?'+Math.random();" height="38px" />
                                    ����������,�����ˢ��!
                                </td>
                            </tr>
                            <tr valign="center">
                                <td align="middle" colspan="2" height="43">
                                    <input class="btn" type="button" value="��¼" id="btnLogin" runat="server" />
                                    <input class="btn" type="reset" value="����" id="btnReset" runat="server" />&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <b><font color="#ff0000">ע�⣺</font>��2010��<font color="#ff0000">10</font>��<font color="#ff0000">17</font>����һҹ�ɵ�������ַ������ַ��Ϊ��</b><br>
                    <span style="font-weight: 700; background-color: #000000"><a href="http://hi.baidu.com/yiyebanet/"
                        target="_blank"><font face="Arial" color="#ff0000">http://hi.baidu.com/yiyebanet/</font></a></span><b>���λ��Ա�ղغ�</b>
                        <p style="font-weight: bold; color: #FF0000">
                        <a href="~/Homes/Reg.aspx" runat="server">���ע��һҹ�ɽ�������Ա</a><br>
                        <br>
                        <a href="~/Homes/ForgetPassword.aspx" runat="server">��������</a></p>
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
