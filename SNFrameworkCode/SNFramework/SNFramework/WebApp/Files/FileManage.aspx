<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="FileManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Files.FileManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:TreePanel ID="TreePanel1" runat="server" Icon="BookOpen"  Title="Directory" Region="West" Layout="Fit"
                Width="225" MinWidth="225" MaxWidth="400" Split="true" Collapsible="true" RootVisible="false"
                AutoScroll="true">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="Button1" runat="server" Text="Expand All">
                                <Listeners>
                                    <Click Handler="#{TreePanel1}.expandAll();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button2" runat="server" Text="Collapse All">
                                <Listeners>
                                    <Click Handler="#{TreePanel1}.collapseAll();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Root>
                    <ext:TreeNode Text="Composers" Expanded="true">
                        <Nodes>
                            <ext:TreeNode Text="Beethoven" Icon="UserGray">
                                <Nodes>
                                    <ext:TreeNode Text="Concertos">
                                        <Nodes>
                                            <ext:TreeNode Text="No. 1 - C" Icon="Music" />
                                            <ext:TreeNode Text="No. 2 - B-Flat Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 3 - C Minor" Icon="Music" />
                                            <ext:TreeNode Text="No. 4 - G Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 5 - E-Flat Major" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Quartets">
                                        <Nodes>
                                            <ext:TreeNode Text="Six String Quartets" Icon="Music" />
                                            <ext:TreeNode Text="Three String Quartets" Icon="Music" />
                                            <ext:TreeNode Text="Grosse Fugue for String Quartets" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Sonatas">
                                        <Nodes>
                                            <ext:TreeNode Text="Sonata in A Minor" Icon="Music" />
                                            <ext:TreeNode Text="sonata in F Major" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Symphonies">
                                        <Nodes>
                                            <ext:TreeNode Text="No. 1 - C Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 2 - D Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 3 - E-Flat Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 4 - B-Flat Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 5 - C Minor" Icon="Music" />
                                            <ext:TreeNode Text="No. 6 - F Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 7 - A Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 8 - F Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 9 - D Minor" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode Text="Brahms" Icon="UserGray">
                                <Nodes>
                                    <ext:TreeNode Text="Concertos">
                                        <Nodes>
                                            <ext:TreeNode Text="Violin Concerto" Icon="Music" />
                                            <ext:TreeNode Text="Double Concerto - A Minor" Icon="Music" />
                                            <ext:TreeNode Text="Piano Concerto No. 1 - D Minor" Icon="Music" />
                                            <ext:TreeNode Text="Piano Concerto No. 2 - B-Flat Major" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Quartets">
                                        <Nodes>
                                            <ext:TreeNode Text="Piano Quartet No. 1 - G Minor" Icon="Music" />
                                            <ext:TreeNode Text="Piano Quartet No. 2 - A Major" Icon="Music" />
                                            <ext:TreeNode Text="Piano Quartet No. 3 - C Minor" Icon="Music" />
                                            <ext:TreeNode Text="Piano Quartet No. 3 - B-Flat Minor" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Sonatas">
                                        <Nodes>
                                            <ext:TreeNode Text="Two Sonatas for Clarinet - F Minor" Icon="Music" />
                                            <ext:TreeNode Text="Two Sonatas for Clarinet - E-Flat Major" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Symphonies">
                                        <Nodes>
                                            <ext:TreeNode Text="No. 1 - C Minor" Icon="Music" />
                                            <ext:TreeNode Text="No. 2 - D Minor" Icon="Music" />
                                            <ext:TreeNode Text="No. 3 - F Major" Icon="Music" />
                                            <ext:TreeNode Text="No. 4 - E Minor" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode Text="Mozart" Icon="UserGray">
                                <Nodes>
                                    <ext:TreeNode Text="Concertos">
                                        <Nodes>
                                            <ext:TreeNode Text="Piano Concerto No. 12" Icon="Music" />
                                            <ext:TreeNode Text="Piano Concerto No. 17" Icon="Music" />
                                            <ext:TreeNode Text="Clarinet Concerto" Icon="Music" />
                                            <ext:TreeNode Text="Violin Concerto No. 5" Icon="Music" />
                                            <ext:TreeNode Text="Violin Concerto No. 4" Icon="Music" />
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                        </Nodes>
                    </ext:TreeNode>
                </Root>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                </BottomBar>
                <Listeners>
                    <Click Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '<br />', clear: true});" />
                    <ExpandNode Handler="#{StatusBar1}.setStatus({text: 'Node Expanded: <b>' + node.text + '<br />', clear: true});"
                        Delay="30" />
                    <CollapseNode Handler="#{StatusBar1}.setStatus({text: 'Node Collapsed: <b>' + node.text + '<br />', clear: true});" />
                </Listeners>
            </ext:TreePanel>
<%--            <ext:Panel ID="Panel2" runat="server">
                <Items>
                </Items>
            </ext:Panel>--%>
            <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                <Items>
                    <ext:Panel ID="Panel5" runat="server" Title="Files" Border="false" Padding="6" Html="<h1>Viewport with BorderLayout</h1>" />
                </Items>
            </ext:TabPanel>
            <ext:Panel ID="Panel7" runat="server" Title="File Info" Region="East" Collapsible="True"
                Collapsed="True" Split="true" MinWidth="225" Width="225" Layout="Fit">
                <Items>
                    <ext:TabPanel ID="TabPanel2" runat="server" Border="false">
                        <Items>
                            <ext:Panel ID="Panel8" runat="server" Title="Property" Layout="Fit">
                                <Items>
                                    <ext:PropertyGrid ID="PropertyGrid1" runat="server" Width="300" AutoHeight="true">
                                        <Source>
                                            <ext:PropertyGridParameter Name="(name)" Value="Properties Grid" />
                                            <ext:PropertyGridParameter Name="grouping" Value="false" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="autoFitColumns" Value="true" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="productionQuality" Value="false" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="created" Value="10/15/2006">
                                            </ext:PropertyGridParameter>
                                            <ext:PropertyGridParameter Name="tested" Value="false" Mode="Raw">
                                            </ext:PropertyGridParameter>
                                            <ext:PropertyGridParameter Name="version" Value="0.01" />
                                            <ext:PropertyGridParameter Name="borderWidth" Value="5" Mode="Raw">
                                            </ext:PropertyGridParameter>
                                        </Source>
                                        <View>
                                            <ext:GridView ID="GridView1" ForceFit="true" ScrollOffset="2" runat="server" />
                                        </View>
                                    </ext:PropertyGrid>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
