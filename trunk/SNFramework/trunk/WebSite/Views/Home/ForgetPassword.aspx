<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<TABLE cellSpacing=0 cellPadding=0 width=780   border=0 align="center">
  <TBODY>
  <TR>
    <TD width=20 height=31>　</TD>
    <TD>当前位置：<A href="http://www.yiyeba.net" target=_blank>一夜吧交友网</A> &gt; 取回密码&nbsp;&gt;&nbsp;第一步：输入用户名/输入密码答案</TD></TR></TBODY></TABLE>
<table border="0" width="1000" cellpadding=0 cellspacing=0 align=center>
	<tr>
		<td></td><br><br>

<table border="0" width="1000" align=center cellpadding=0 cellspacing=0> 
	<tr>
		<td width="1000" align=center>

		<SCRIPT language=JavaScript>
		    function CheckForm1() {
		        if (document.ADDUser1.user_name.value.length == 0) {
		            alert("请输入您的用户名.");
		            document.ADDUser1.user_name.focus();
		            return false;
		        }
		        return true;
		    }
</SCRIPT>
<p><p>
<form action="denglu.asp?www_yiyeba_net=forget" method=post name=ADDUser1 onSubmit="return CheckForm1();">
	<br><br>
	<br><br><br>
	<br>
	<font color="#FF6600">请输入你的用户名</font>：<input type=text name="user_name" size=20 >&nbsp;
		<INPUT class=Tips_bo style="border:1px solid #007DB5; FONT-SIZE: 9pt; BACKGROUND: #F0F0F0; WIDTH: 40; HEIGHT: 20" type=submit value="提 交" name=ok1 ><p>
		　</form><br><br><br><br><br><br>

</td>
	</tr>
</table>


</asp:Content>
