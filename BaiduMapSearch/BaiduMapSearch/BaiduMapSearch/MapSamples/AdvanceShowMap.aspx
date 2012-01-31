<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ExtMaster.Master" AutoEventWireup="true"
    CodeBehind="AdvanceShowMap.aspx.cs" Inherits="BaiduMapSearch.MapSamples.AdvanceShowMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" Height="105" Frame="true" Title="搜索"
                        Layout="Fit">
                        <Items>
                            <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" TabPosition="Bottom">
                                <Items>
                                    <ext:FormPanel ID="Panel3" runat="server" Title="搜索" Frame="true">
                                        <Items>
                                            <ext:CompositeField ID="CompositeField1" runat="server" HideLabel=true FieldLabel="搜索" AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:TextField ID="TextField3" runat="server" Flex="1" />
                                                    <ext:Button ID="Button2" runat="server" Text="搜索" Width="60" />
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:FormPanel>
                                    <ext:FormPanel ID="Panel4" runat="server" Title="公交" Frame="true">
                                        <Items>
                                            <ext:CompositeField ID="CompositeField2" runat="server"  HideLabel=true  FieldLabel="搜索" AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:TextField ID="TextField1" runat="server" Flex="1" />
                                                    <ext:Button ID="Button1" runat="server" Icon=ArrowSwitch Width="30" />
                                                    <ext:TextField ID="TextField4" runat="server" Flex="1" />
                                                    <ext:Button ID="Button4" runat="server" Text="搜索" Width="60" />
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:FormPanel>
                                    <ext:FormPanel ID="Panel5" runat="server" Title="驾车" Frame="true">
                                        <Items>
                                            <ext:CompositeField ID="CompositeField3" runat="server"  HideLabel=true  FieldLabel="搜索" AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:TextField ID="TextField2" runat="server" Flex="1" />
                                                    <ext:Button ID="Button3" runat="server" Icon=ArrowSwitch Width="30" />
                                                    <ext:TextField ID="TextField5" runat="server" Flex="1" />
                                                    <ext:Button ID="Button5" runat="server" Text="搜索" Width="60" />
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:FormPanel>
                                </Items>
                            </ext:TabPanel>
                        </Items>
                    </ext:Panel>
                </North>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="地图" Frame="true" Layout="Fit">
                        <AutoLoad Url="BaiduMapShowPage.aspx" Mode="IFrame" ShowMask="true" />
                    </ext:Panel>
                </Center>
                <East Collapsible="true" Split="true">
                    <ext:Panel runat="server" ID="Panel1" Width="200" Frame="true" Title="详细信息">
                        <Content>
                            2
                        </Content>
                    </ext:Panel>
                </East>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
