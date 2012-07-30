<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemRoleAssignedPrivilege.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.RoleManage.SystemRoleAssignedPrivilege" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{treeMain});" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
 
 var PrivilegeSelector = {
            add : function (source, destination) {
                source = source || <%= this.GridPanel1.ClientID %>;
                destination = destination || <%= this.GridPanel2.ClientID %>;
                if (source.hasSelection()) {
                    var records = source.selModel.getSelections();
                    source.deleteSelected();
                    Ext.each(records, function(record){
                        destination.store.addSorted(record);                    
                    });                   
                }
            },
            addAll : function (source, destination) {
                source = source || <%= this.GridPanel1.ClientID %>;
                destination = destination || <%= this.GridPanel2.ClientID %>;
                var records = source.store.getRange();
                source.store.removeAll();
                Ext.each(records, function(record){
                    destination.store.addSorted(record);                    
                });                 
            },
            addByName : function (name) {
                if (!Ext.isEmpty(name)) {
                    var result = Store1.query("Name", name);
                    if (!Ext.isEmpty(result.items)) {
                        <%= this.GridPanel1.ClientID %>.store.remove(result.items[0]);
                        <%= this.GridPanel2.ClientID %>.store.add(result.items[0]);                        
                    }
                }
            },
            addByNames : function (name) {
                for (var i = 0; i < name.length; i++) {
                    this.addByName(name[i]);
                }
            },
            remove : function (source, destination) {
                this.add(destination, source);
            },
            removeAll : function (source, destination) {
                this.addAll(destination, source);
            }
        };
 
 
     function RefreshTreeList1() {
            RefreshList(<%= this.treeMain.ClientID %>);
        }

 
         function SelectResources(node,hid,pnl)
        {
            hid.setValue(node.attributes.id.toString());
            pnl.setTitle(node.text+'<%= this.GetLocalResourceObject("msgManagePermission") %>');
            pnl.setDisabled(!(node!=null&&node.attributes.id!=null&&node.attributes.id>0));
            <%= this.Store1.ClientID %>.reload();
            <%= this.Store2.ClientID %>.reload();
        }


        function RefreshList(treepanel) {
            Ext.net.DirectMethods.GetTreeNodes(
                                                {
                                                    failure: function(msg) {
                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                    },
                                                    success: function(result) {
                                                        var nodes = eval(result);
                                                        if (nodes.length > 0) {
                                                            treepanel.initChildren(nodes);
                                                        }
                                                        else {
                                                            treepanel.getRootNode().removeChildren();
                                                        }
                                                    },
                                                    eventMask: {
                                                        showMask: true,
                                                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                    }
                                                }
                                             );

        }
    </script>
    <script type="text/javascript">
        function btSave_Click(json, rid) {
            Ext.net.DirectMethods.Save_RolePermission(json, rid,
                            {
                                failure: function (msg) {
                                    Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg, null);
                                },
                                success: function (result) {
                                    Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= this.GetLocalResourceObject("msgAssignedPermissionSuccessful") %>', function (btn) { parent.CloseWinAssignedPermission(); });
                                },
                                eventMask:
                               {
                                   showMask: true,
                                   msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                               }
                            }
                );
        }
            
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Hidden ID="hidSelectResourceID" runat="server">
    </ext:Hidden>
    <ext:Store runat="server" ID="Store1" OnRefreshData="Store1_OnRefreshData">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="id" Mapping="PrivilegeID" />
                    <ext:RecordField Name="name" Mapping="PrivilegeEnName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Value="#{hidSelectResourceID}.getValue()" Mode="Raw" Name="SelectResourceID">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Store runat="server" ID="Store2" OnRefreshData="Store2_OnRefreshData">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="id" Mapping="PrivilegeID" />
                    <ext:RecordField Name="name" Mapping="PrivilegeEnName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Value="#{hidSelectResourceID}.getValue()" Mode="Raw" Name="SelectResourceID">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="Panel5" Title="<%$ Resources:msgFormTitle %>" Frame="true" runat="server" Layout="fit">
                        <Content>
                            <ext:TreePanel ID="treeMain" runat="server" Header="false" RootVisible="false" AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button7" runat="server" IconCls="icon-expand-all" Text="<%$ Resources : GlobalResource, msgExpandAll  %>">
                                                <Listeners>
                                                    <Click Handler="#{treeMain}.root.expand(true);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button8" runat="server" IconCls="icon-collapse-all" Text="<%$ Resources : GlobalResource, msgCollapseAll  %>">
                                                <Listeners>
                                                    <Click Handler="#{treeMain}.root.collapse(true);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Root>
                                    <ext:TreeNode Text="System menu" Expanded="true" Icon="Folder">
                                    </ext:TreeNode>
                                </Root>
                                <BottomBar>
                                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                </BottomBar>
                                <Listeners>
                                    <Click Handler="<%$ Resources:msgSetStatus %>" />
                                </Listeners>
                            </ext:TreePanel>
                        </Content>
                    </ext:Panel>
                </Center>
                <East Split="true" Collapsible="true">
                    <ext:Panel ID="pnlEast" Title="<%$ Resources:msgPanelTitle %>" Width="390" runat="server" Frame="true" Disabled="true">
                        <Items>
                            <ext:ColumnLayout ID="ColumnLayout1" runat="server" FitHeight="true">
                                <Columns>
                                    <ext:LayoutColumn ColumnWidth="0.5">
                                        <ext:GridPanel runat="server" ID="GridPanel1" EnableDragDrop="true" StoreID="Store1"
                                            Frame="true" Title="<%$ Resources:msgFormAvailablePermissions %>">
                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="columnID" Header="<%$ Resources:msgcolID %>" DataIndex="id" Width="39" />
                                                    <ext:Column ColumnID="columnName" Header="<%$ Resources:msgcolName %>" DataIndex="name" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                                            </SelectionModel>
                                            <Plugins>
                                                <ext:GridFilters ID="GridFilters1" runat="server" Local="true">
                                                    <Filters>
                                                        <ext:StringFilter DataIndex="name" />
                                                    </Filters>
                                                </ext:GridFilters>
                                            </Plugins>
                                            <LoadMask ShowMask="true" />
                                            <View>
                                                <ext:GridView ForceFit="true" ID="GridView1">
                                                    <GetRowClass FormatHandler="False"></GetRowClass>
                                                </ext:GridView>
                                            </View>
                                        </ext:GridPanel>
                                    </ext:LayoutColumn>
                                    <ext:LayoutColumn>
                                        <ext:Panel ID="Panel2" runat="server" Width="35" BodyStyle="background-color: transparent;"
                                            Border="false" Layout="Anchor">
                                            <Items>
                                                <ext:VBoxLayout ID="VBoxLayout1" runat="server" Align="Stretch" Pack="Center">
                                                    <BoxItems>
                                                        <ext:BoxItem>
                                                            <ext:Panel ID="Panel4" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                                                Padding="5">
                                                                <Items>
                                                                    <ext:Button ID="Button1" runat="server" Icon="ResultsetNext" StyleSpec="margin-bottom:2px;">
                                                                        <Listeners>
                                                                            <Click Handler="PrivilegeSelector.add();" />
                                                                        </Listeners>
                                                                        <ToolTips>
                                                                            <ext:ToolTip ID="ToolTip1" runat="server" Title="<%$ Resources : GlobalResource, msgDoubleSelectAddTitle  %>" Html="<%$ Resources : GlobalResource, msgDoubleSelectAddContent  %>"  />
                                                                        </ToolTips>
                                                                    </ext:Button>
                                                                    <ext:Button ID="Button2" runat="server" Icon="ResultsetLast" StyleSpec="margin-bottom:2px;">
                                                                        <Listeners>
                                                                            <Click Handler="PrivilegeSelector.addAll();" />
                                                                        </Listeners>
                                                                        <ToolTips>
                                                                            <ext:ToolTip ID="ToolTip2" runat="server" Title="<%$ Resources : GlobalResource, msgDoubleSelectAddAllTitle  %>" Html="<%$ Resources : GlobalResource, msgDoubleSelectAddAllContent  %>"  />
                                                                        </ToolTips>
                                                                    </ext:Button>
                                                                    <ext:Button ID="Button3" runat="server" Icon="ResultsetPrevious" StyleSpec="margin-bottom:2px;">
                                                                        <Listeners>
                                                                            <Click Handler="PrivilegeSelector.remove(#{GridPanel1}, #{GridPanel2});" />
                                                                        </Listeners>
                                                                        <ToolTips>
                                                                            <ext:ToolTip ID="ToolTip3" runat="server" Title="<%$ Resources : GlobalResource, msgDoubleSelectRemoveTitle  %>" Html="<%$ Resources : GlobalResource, msgDoubleSelectRemoveContent  %>"  />
                                                                        </ToolTips>
                                                                    </ext:Button>
                                                                    <ext:Button ID="Button4" runat="server" Icon="ResultsetFirst" StyleSpec="margin-bottom:2px;">
                                                                        <Listeners>
                                                                            <Click Handler="PrivilegeSelector.removeAll(#{GridPanel1}, #{GridPanel2});" />
                                                                        </Listeners>
                                                                        <ToolTips>
                                                                            <ext:ToolTip ID="ToolTip4" runat="server" Title="<%$ Resources : GlobalResource, msgDoubleSelectRemoveAllTitle  %>" Html="<%$ Resources : GlobalResource, msgDoubleSelectRemoveAllContent  %>" />
                                                                        </ToolTips>
                                                                    </ext:Button>
                                                                </Items>
                                                            </ext:Panel>
                                                        </ext:BoxItem>
                                                    </BoxItems>
                                                </ext:VBoxLayout>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    <ext:LayoutColumn ColumnWidth="0.5">
                                        <ext:GridPanel runat="server" ID="GridPanel2" EnableDragDrop="false" AutoExpandColumn="columnID"
                                            Frame="true" Title="<%$ Resources:msgFormAssignedPermissions %>" StoreID="Store2">
                                            <Listeners>
                                            </Listeners>
                                            <ColumnModel ID="ColumnModel2" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="columnID" Header="<%$ Resources:msgcolID %>" DataIndex="id"  Width="39" />
                                                    <ext:Column ColumnID="columnName" Header="<%$ Resources:msgcolName %>" DataIndex="name" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
                                            </SelectionModel>
                                            <SaveMask ShowMask="true" />
                                        </ext:GridPanel>
                                    </ext:LayoutColumn>
                                </Columns>
                            </ext:ColumnLayout>
                        </Items>
                        <Buttons>
                            <ext:Button ID="btnSave" runat="server" Text="<%$ Resources : GlobalResource, msgSave  %>" Icon="Disk">
                                <Listeners>
                                    <Click Handler="btSave_Click(Ext.encode(#{GridPanel2}.getRowsValues(false)),#{hidSelectResourceID}.getValue())" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button6" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
                                Icon="Cancel">
                                <Listeners>
                                    <Click Handler="parent.CloseWinAssignedPermission();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                </East>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
