<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PageResourcesManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.ReSourcesManage.PageResourcesManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Icon=UserHome Title="管理文件语言包" Width="300" Layout="fit">
                        <Content>
                            <ext:TreePanel ID="TreePanel1" runat="server" Header="false" RootVisible="false"
                                AutoScroll="true">
                                <Root>
                                    <ext:TreeNode Text="System menu" Expanded="true" Icon="Folder">
                                    </ext:TreeNode>
                                </Root>
                                <BottomBar>
                                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                </BottomBar>
                            </ext:TreePanel>
                        </Content>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
