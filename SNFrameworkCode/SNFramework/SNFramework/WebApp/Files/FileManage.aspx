﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="FileManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Files.FileManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="LoadDirectorys('/');#{storeFiles}.reload();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeFiles" runat="server" OnRefreshData="storeFiles_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="name">
                <Fields>
                    <ext:RecordField Name="name" />
                    <ext:RecordField Name="size" Type="Int" />
                    <ext:RecordField Name="lastmod" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig>
            <EventMask ShowMask="True"></EventMask>
        </DirectEventConfig>
    </ext:Store>
    <script type="text/javascript">
        function LoadSubDir(subdir) {
            var hidcPath = <%=cPath.ClientID  %>;
            //alert(subdir);
            hidcPath.setValue(subdir);
            var storeFiles = <%=storeFiles.ClientID  %>;
            storeFiles.reload();
        }
        function LoadDirectorys(rootPath) {
            var tree = <%=treeDirectorys.ClientID  %>;
            Ext.net.DirectMethods.GetTreeNodes(
                rootPath,
                {
                    failure: function (msg) {
                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                    },
                    success: function (result) {
                        var nodes = eval(result);
                        if (nodes.length > 0) {
                            tree.initChildren(nodes);
                        }
                        else {
                            tree.getRootNode().removeChildren();
                        }

                    },
                    eventMask: {
                        showMask: true,
                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>',
                        target: 'customtarget',
                        customTarget: '<%= treeDirectorys.ClientID %>.el'
                    }
                }
            );    
        }
    </script>
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:TreePanel ID="treeDirectorys" runat="server" Title="Directory"  Icon="Folder" 
                Region="West" Layout="Fit" Width="225" MinWidth="225" MaxWidth="400" Split="true"
                Collapsible="true" RootVisible="false" AutoScroll="true">
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
                            <ext:Button ID="btnReload" runat="server" Text="Reload" Icon="Reload">
                                <Listeners>
                                    <Click Handler="LoadDirectorys('/');" />
                                </Listeners>
                            </ext:Button>
                        </Items> 
                    </ext:Toolbar>
                </TopBar>
                <Root>
                    <ext:TreeNode Text="Composers" Expanded="true">
                    </ext:TreeNode>
                </Root>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                </BottomBar>
                <Listeners>
                    <Click Handler=" #{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text +   '<br />', clear: true});LoadSubDir(node.attributes.Path);" />
                    <ExpandNode Handler="#{StatusBar1}.setStatus({text: 'Node Expanded: <b>' + node.text + '<br />', clear: true});"
                        Delay="30" />
                    <CollapseNode Handler="#{StatusBar1}.setStatus({text: 'Node Collapsed: <b>' + node.text + '<br />', clear: true});" />
                </Listeners>
            </ext:TreePanel>
            <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                <Items>
                    <ext:Panel ID="Panel5" runat="server" Title="Files" Layout="Fit">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <ext:Button ID="Button5" runat="server" Text="Reload" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeFiles}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:ListView ID="ListView1" runat="server" MultiSelect="true" ReserveScrollOffset="true"
                                EmptyText="No Images to Display" StoreID="storeFiles">
                                <Columns>
                                    <ext:ListViewColumn Header="File" Width="0.35" DataIndex="name" />
                                    <ext:ListViewColumn Header="Last Modified" Width="0.3" DataIndex="lastmod" Template='{lastmod:date("m-d h:i a")}' />
                                    <ext:ListViewColumn Header="Size" Width="0.2" DataIndex="size" Align="Right" Template="{size:fileSize}" />
                                </Columns>
                            </ext:ListView>
                        </Items>
                    </ext:Panel>
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
    <ext:Hidden ID="cPath" runat="server" />
</asp:Content>