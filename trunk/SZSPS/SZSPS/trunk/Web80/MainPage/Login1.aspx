﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="Legendigital.Common.Web.MainPage.Login1" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<style>
BODY {
	FONT-SIZE: 12px; FONT-FAMILY: "Verdana", "Arial", "细明体", "sans-serif";
     }
table
{
    FONT-SIZE: 12px; FONT-FAMILY: "Verdana", "Arial", "细明体", "sans-serif";
}

.middlecss
{
	background-color:#FFFFFF; 
	border-right:1px solid #C7C5D9;
}

.AdminButton 
{
	border:1px solid #C6D2E3; 
	background:url("../images/button_bg.gif"); 
    cursor:pointer;font-family: "Arial","宋体"; font-size: 9pt; 
}

.cbutton 
{
    border: 1px solid #000000; margin: 0px; padding: 2px;
    cursor:pointer;font-family: "Arial","宋体"; font-size: 9pt; color: #000000; 
    background-color: #EAEFF2;line-height: 10px; 
    Padding-top: 4px; padding-bottom: 2px; 
    Padding-left: 2px; padding-right:2px;
    border-top-color:#FFFFFF; border-right-color: #91ABC4; 
    border-left-color: #FFFFFF; border-bottom-color: #91ABC4}
.button_bak {
	BORDER-RIGHT: medium none; 
	BORDER-TOP: medium none; 
	BACKGROUND-IMAGE: url(../images/button_On.gif); 
	BORDER-LEFT: medium none; 
	WIDTH: 60px; 
	CURSOR: pointer; 
	BORDER-BOTTOM: medium none; 
	HEIGHT: 20px;
	FONT-SIZE: 9pt; 
	FONT-FAMILY: tahoma,宋体;
}
.TD_Class
{
    font-size:12px;   FONT-FAMILY: "Verdana", "Arial", "细明体", "sans-serif";  
}


A:hover{TEXT-DECORATION: none}
A{COLOR: #000000;}

             

.text_input  
{
BORDER-TOP-WIDTH: 1px;	
PADDING-RIGHT: 2px;	
PADDING-LEFT: 2px;	
BORDER-LEFT-WIDTH: 1px;	
BORDER-LEFT-COLOR: #ddd;	
BORDER-BOTTOM-WIDTH: 1px;
BORDER-BOTTOM-COLOR: #ddd;	
PADDING-BOTTOM: 2px;	
BORDER-TOP-COLOR: #ddd;	
PADDING-TOP: 3px;	
BORDER-RIGHT-WIDTH: 1px;
BORDER-RIGHT-COLOR: #ddd;
height:22px;
FONT: Trebuchet MS, Helvetica, Arial, sans-serif;	
COLOR: #000;
background-color:expression((this.readOnly && this.readOnly==true)?"#a0a0a0":"");
}
.tex_input  
{
BORDER-TOP-WIDTH: 1px;	
PADDING-RIGHT: 2px;	
PADDING-LEFT: 2px;	
BORDER-LEFT-WIDTH: 1px;	
BORDER-LEFT-COLOR: #ddd;	
BORDER-BOTTOM-WIDTH: 1px;
BORDER-BOTTOM-COLOR: #ddd;	
PADDING-BOTTOM: 2px;	
BORDER-TOP-COLOR: #ddd;	
PADDING-TOP: 2px;	
BORDER-RIGHT-WIDTH: 1px;
BORDER-RIGHT-COLOR: #ddd;
FONT: 12px/1.6em Trebuchet MS, Helvetica, Arial, sans-serif;	
COLOR: #000;
width:100%;
background-color:expression((this.readOnly && this.readOnly==true)?"#a0a0a0":"");
}
.Table_yellow {  font-family: "Verdana", "Arial", "Helvetica", "sans-serif"; font-size: 12px; background-color: #FFFF99}
.Table_blue {  font-family: "Verdana", "Arial", "Helvetica", "sans-serif"; font-size: 12px; background-color: #336699; color: #FFFFFF}
.Table_blue1 {  font-family: "Verdana", "Arial", "Helvetica", "sans-serif"; font-size: 12px; color: #FFFFFF; background-color: #3366CC}
.no_input { border :#665b8e 0px solid; color: #333333; cursor: text; font-family: "Arial"; font-size: 12px; height: 20px; padding: 1px}
.down_text {
	font-family: Arial;	font-size:8pt;background-color:#000000;color:#FFFFFF
	}
.down_tools_button {	
	border-left:1px solid #FFFFFF; border-right:1px solid #000000; 
	width: 80; height: 20; position:relative;
	letter-spacing:1; FONT-FAMILY: "Arial"; 
	FONT-SIZE: 9pt; LINE-HEIGHT: 7px; 
	PADDING-TOP: 0px; PADDING-BOTTOM: 0px; 
	PADDDING-LEFT: 2px; PADDING-RIGHT: 2px; 
	background-color:#000000; cursor:pointer;color:#FFFFFF}
.menubar_button { 
	border:1pt solid #FFFFFF; height: 20; 
	position:relative;letter-spacing:1;
	FONT-FAMILY: "Arial"; FONT-SIZE: 9pt; 
	LINE-HEIGHT: 7px; PADDDING-LEFT: 0px; 
	background-color:#FFFFFF; 
	position:relative; top:-1; cursor:pointer; padding-left:2px; padding-right:2px; padding-top:0; padding-bottom:0}

.menubar_button_on { 
	border-left:1pt solid #000000; border-right:1pt outset #000000; border-top:1pt outset #000000; border-bottom:1pt outset #000000; height: 20; 
	position:relative;letter-spacing:1;
	FONT-FAMILY: "Arial"; FONT-SIZE: 9pt; 
	LINE-HEIGHT: 7px; PADDDING-LEFT: 0px; 
	background-color:#FFCC00; 
	position:relative; top:-1; cursor:pointer; padding-left:2px; padding-right:2px; padding-top:0px; padding-bottom:0px}

.menubar_table {
	border-bottom:3px solid #000000; 
	border-collapse: collapse; 
	padding: 0; border-left-width:1;
	border-right-width:1; border-top-width:1; }

.menubar_title {FONT-FAMILY: "Verdana", "Arial", "细明体", "sans-serif"; font-size:14px; font-weight:bold;}
	
.menubar_readme_text {font-size:9pt;FONT-FAMILY: "Arial"; 
	color:#808080; text-align:right; padding-bottom:5px }

.menubar_down_text {
	border-top:1px solid #000000; font-size:9pt;
	FONT-FAMILY: "Arial"; position:relative; 
	color:#808080; text-align:center; border-left-width:1; 
	border-right-width:1; border-bottom-width:1; padding-top:3 }

.menubar_function_text {
	border-top:3px solid #000000; font-size:9pt;
	FONT-FAMILY: "Arial"; position:relative; 
	color:#808080; border-left-width:1; 
	border-right-width:1; border-bottom-width:1; padding-top:3; padding-left:10 }

.menubar_menu_td {
	border-top:3px solid #000000; font-size:8pt;
	FONT-FAMILY: "Arial"; position:relative; 
	color:#808080; border-left-width:1; 
	border-right-width:1; border-bottom-width:1; padding-top:3; padding-left:10 }
.tab {
	PADDING-RIGHT: 15px; PADDING-LEFT: 10px; FONT-SIZE: 12px; PADDING-BOTTOM: 1px; CURSOR: pointer; PADDING-TOP: 5px; LETTER-SPACING: 1px
}

#ld 
{    
filter: alpha(opacity=100);
-moz-opacity:.100;
opacity:1.0;
position:absolute;
left:0px;
top:0px;
width: expression(body.scrollWidth);
height: expression(body.scrollHeight);
width:100%; 
height: 100%;
z-index:1;
background-color: #000000;
}
.topmenuoff { cursor: pointer;color: #FFFFFF; font-size: 9 pt }
.topmenuon { cursor: pointer;color: #FFCC00; font-size: 9 pt }
.topmenuoff2 { cursor: pointer;color: #000000; font-size: 9 pt }
.topmenuon2 { cursor: pointer;color: #000000; font-size: 9 pt }
</style>
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
                                        <img src="../images/Logon/Logon_2.gif" width="431" height="30" alt="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../images/Logon/Logon_3.gif" width="194" height="28" alt="" />
                                    </td>
                                    <td background="../images/Logon/Logon_4.gif" width="237">
                                        <asp:TextBox ID="txtLoginName" class="text_input" title="请输入帐号~!" runat="server"
                                            Style="width: 138px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../images/Logon/Logon_5.gif" width="194" height="24" alt="" />
                                    </td>
                                    <td background="../images/Logon/Logon_6.gif">
                                        <asp:TextBox ID="txtLoginPassword" runat="server" class="text_input" title="请输入密码~!"
                                            TextMode="Password" Style="width: 138px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../images/Logon/Logon_7.jpg" width="194" height="25" alt="" />
                                    </td>
                                    <td background="../images/Logon/Logon_8.gif">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../images/Logon/Logon_9.gif" width="194" height="40" alt="" />
                                    </td>
                                    <td background="../images/Logon/Logon_10.gif">
                                        <asp:Button ID="btnLogin" runat="server" Text="确定" class="button_bak" OnClick="btnLogin_Click" />
                                        <input type="reset" value="重填" class="button_bak" /><asp:Label ID="lblMessage" runat="server"
                                            EnableViewState="False" ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <img src="../images/Logon/Logon_11.gif" width="431" height="39" alt="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>提醒 : </b>本管理系统建议议采用Internet Explorer 5.5 (或以上版本) 的浏览器。请开启浏览器的 Cookies 与 JavaScript
                                        功能。
                                    </td>
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
                        <asp:Label ID="lblLisence" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</body>
</html>
