<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="BussinessCategory.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Infos.BussinessCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
        <items>
                <ext:Panel 
                    runat="server" 
                    Width="150"
                    Height="150"
                    Title="通道状况"
            
                    >

                    <Content>
                                        <table width='100%' border='1' bordercolor="#B3B3B3" cellpadding="5" cellspacing="0" style="border-collapse:collapse;">

            <tr bgcolor="#F5F5F5">
                <td><b>业务</b></td><td><b>支持通道</b></td>
            </tr>
            <tr>
                <td>签名</td><td>&nbsp;暂无</td>
            </tr>
            <tr>
                <td>MTK</td><td><font color=red>10625989</font>&nbsp;<font color=red>1066266</font>&nbsp;<font color=red>10623000</font>&nbsp;<font color=red>10625151</font>&nbsp;<font color=red>106280855</font>&nbsp;<font color=red>1062000666</font></td>
            </tr>
            <tr>
                <td>智能手机软件</td><td>&nbsp;暂无</td>
            </tr>
        </table>
                    </Content>
                    </ext:Panel>        

        </items>
    </ext:Viewport>
</asp:Content>
