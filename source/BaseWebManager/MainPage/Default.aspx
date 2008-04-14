<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="BaseWebManager.MainPage.Default" %>

<html>
<head runat="server">
    <link rel="stylesheet" href="../css/Site_Css.css" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
.navPoint
	{
	font-family: Webdings;
	font-size:9pt;
	color:white;
	cursor:pointer;
	}
p{
	font-size:9pt;
}
.font_size {  font-family: "Verdana", "Arial", "Helvetica", "sans-serif"; font-size: 12px; font-weight: normal; font-variant: normal; text-transform: none}
</style>
</head>
<body scroll="no" onbeforeunload="return CloseEvent();" leftmargin="0" topmargin="0"
    marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
        <tr>
            <td width="100%" height="50" colspan="3" style="border-bottom: 1px solid #000000">
                <table height="49" border="0" cellspacing="0" cellpadding="0" width="100%" class="font_size">
                    <tr>
                        <td width="300">
                            <asp:Label ID="lblLoginMessage" runat="server"></asp:Label>
                        </td>
                        <td style="background-image: url(../images/top-gray.gif); background-repeat: no-repeat;
                            background-position: right top" valign="bottom">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%
            switch (MenuStyle)
            {
                case 0:
        %>
        <tr>
            <td id="frmTitle" name="frmTitle" nowrap="nowrap" valign="middle" align="center"
                width="198" style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 198; z-index: 2"
                    scrolling="auto" frameborder="0" src="left.aspx"></iframe>
            </td>
            <td style="width: 10pt" bgcolor="#7898A8" width="10" title="关闭/打开左栏" class="navPoint">
                <table border="0" cellpadding="0" cellspacing="0" width="11" height="100%" align="right">
                    <tr>
                        <td valign="middle" align="right" class="middleCss">
                            <img border="0" src="../images/Menu/close.gif" id="menuimg" alt="隐藏左栏" onmouseover="javascript: menuonmouseover();"
                                onmouseout="javascript: menuonmouseout();" onclick="javascript:switchSysBar()"
                                style="cursor: hand" width="11" height="76" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%">
                <iframe id="mainFrame" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;
        case 1:
            
        %>
        <tr>
            <td id="Td1" name="frmTitle" nowrap="nowrap" valign="middle" align="center" width="115"
                style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 100%;
                    z-index: 2" scrolling="no" frameborder="0" src="Menu1.aspx"></iframe>
            </td>
            <td style="width: 10pt" bgcolor="#7898A8" width="10" title="关闭/打开左栏" class="navPoint">
                <table border="0" cellpadding="0" cellspacing="0" width="11" height="100%" align="right">
                    <tr>
                        <td valign="middle" align="right" class="middleCss">
                            <img border="0" src="images/Menu/close.gif" id="Img1" alt="隐藏左栏" onmouseover="javascript: menuonmouseover();"
                                onmouseout="javascript: menuonmouseout();" onclick="javascript:switchSysBar()"
                                style="cursor: hand" width="11" height="76" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%">
                <iframe id="Iframe" name="mainFrame" style="height: 100%; visibility: inherit; width: 100%;
                    z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;
        case 2:
        %>
        <tr>
            <td height="51px">
                <iframe name="MainTop" style="height: 100%; visibility: inherit; width: 100%; z-index: 1"
                    scrolling="no" frameborder="0" src="Menu2.aspx"></iframe>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <iframe id="Iframe1" name="mainFrame" style="height: 100%; visibility: inherit; width: 100%;
                    z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;

    }
        %>
        <tr>
            <td colspan="3" height="20">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="20">
                    <tr>
                        <td class="down_text">
                            <asp:Label ID="lblLisence" runat="server"></asp:Label></td>
                        <td align="right" width="400" bgcolor="#000000">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="javascript:showPopWin('About','about.aspx',510, 170, null,false)">
                                        &nbsp;<img src="../images/about.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">版本信息</font></td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="javascript:showPopWin('个人设定','UserSet.aspx?rand'+rand(100000000),400, 255, AlertMessageBox,true)">
                                        &nbsp;<img src="../images/userset.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">个人设定</font></td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="javascript: window.mainFrame.location.href='right.aspx'">
                                        &nbsp;<img src="../images/house.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">回到首页</font></td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;">
                                        &nbsp;<img src="../images/logout.gif" style="margin-bottom: -3px">&nbsp;<asp:LinkButton
                                            ID="lbtnLogout" runat="server" ForeColor=white OnClick="lbtnLogout_Click" OnClientClick="return confirm('确认退出系统？');">退出系统</asp:LinkButton></td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="javascript:window.open('http://framework.supesoft.com/help/');">
                                        &nbsp;<img src="../images/help.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">帮助手册</font></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table></form>
</body>
</html>

<script language="JavaScript" type="text/javascript">

var DispClose = true;

function CloseEvent()
{
    if (DispClose)
    {
        return "是否离开当前页面?";
    }
}
    rnd.today=new Date(); 

    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    
    function AlertMessageBox(Messages)
    {
        DispClose = false; 
        window.location.href = location.href+"?"+rand(1000000);
        alert(Messages);
    }
    
var menuimg = document.getElementById("menuimg");

function switchSysBar(){

 	if (document.all("frmTitle").style.display=="none") {
		document.all("frmTitle").style.display=""
		menuimg.src="../images/Menu/close.gif";
		menuimg.alt="隐藏左栏"
		}
	else {
		document.all("frmTitle").style.display="none"
		menuimg.src="../images/Menu/open.gif";
		menuimg.alt="开启左栏"
	 }
	 
	 

}

 function menuonmouseover(){
 		if (document.all("frmTitle").style.display=="none") {
 		menuimg.src="../images/Menu/open_on.gif";
 		}
 		else{
 		menuimg.src="../images/Menu/close_on.gif";
 		}
 }
 function menuonmouseout(){
 		if (document.all("frmTitle").style.display=="none") {
 		menuimg.src="images/Menu/open.gif";
 		}
 		else{
 		menuimg.src="../images/Menu/close.gif";
 		}
 }
     if(top!=self)
    {
        top.location.href = "default.aspx";
    }
</script>

