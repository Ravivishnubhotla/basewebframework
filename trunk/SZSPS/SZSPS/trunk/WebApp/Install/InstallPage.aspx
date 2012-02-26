<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InstallPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Install.InstallPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server"></ext:ResourceManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Frame=true Title="安装系统" Layout="Form">
                        <Items>
                            <ext:TextField ID="txtApplicationName" FieldLabel="应用名称"  runat=server AnchorHorizontal="75%"></ext:TextField>
                        </Items>
                        <Buttons>
                        <ext:Button ID="btnCreate" runat=server></ext:Button>
                        </Buttons>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
