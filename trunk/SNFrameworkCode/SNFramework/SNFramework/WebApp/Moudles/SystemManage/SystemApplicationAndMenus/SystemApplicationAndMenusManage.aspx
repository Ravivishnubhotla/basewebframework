<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationAndMenusManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.SystemApplicationAndMenusManage" %>

<%@ Register Src="UCSystemApplicationAdd.ascx" TagName="UCSystemApplicationAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemApplicationEdit.ascx" TagName="UCSystemApplicationEdit"
    TagPrefix="uc2" %>
<%@ Register Src="UCSystemMenuAdd.ascx" TagName="UCSystemMenuAdd" TagPrefix="uc3" %>
<%@ Register Src="UCSystemMenuEdit.ascx" TagName="UCSystemMenuEdit" TagPrefix="uc4" %>
<%@ Register Src="UCSystemMenuManualResort.ascx" TagName="UCSystemMenuManualResort"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="false" RemotePaging="true"
        RemoteSort="true" OnRefreshData="storeSystemApplication_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="SystemApplicationCode" />
                    <ext:RecordField Name="LocaLocalizationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{GridPanel1}.getSelectionModel().selectFirstRow();" />
        </Listeners>
    </ext:Store>

    <script type="text/javascript">
        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        }

 

        function dragOver(dragOverEvent) { 
            return (dragOverEvent.point != 'append') && (dragOverEvent.dropNode.getDepth()==dragOverEvent.target.getDepth());
        }

        function AutoReorder(id,appID)
        {
        
                        Ext.net.DirectMethods.AutoMaticSortSubItems(appID,id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshMenuData);
                                                                    },
                                                                    success: function(result) {
                                                                        ReloadMenus();
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }); 
        
        
        
        
        
        
        
        }
        
        
               function showReorderForm(id,appID,hid,hidappID) {
               
               hid.setValue(id);
               
               hidappID.setValue(appID); 
               
                ShowOrderList();
               
                Ext.net.DirectMethods.UCSystemMenuManualResort.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshMenuData);
                                                                    },
                                                                    success: function(result) {
                                                                        ReloadMenus();
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                                               }
                                                                }); 
                                                                  
        
        }


        var RefreshSystemApplicationData = function(btn) {
            <%= this.storeSystemApplication.ClientID %>.reload();
        };

        var RefreshMenuData = function(btn) {
            ReloadMenus();
        };

        function LoadMenus(appid,tree)
        {
            var hidSelectAppID = <%= hidSelectAppID.ClientID %>;

            hidSelectAppID.setValue(appid);

            Ext.net.DirectMethods.GetTreeNodes(
                                                appid,
                                                {
                                                    failure: function (msg) {
                                                        Ext.Msg.alert('操作失败', msg);
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
                                                        msg: '加载中......',
                                                        target: 'customtarget',
                                                        customTarget: '<%= TreePanel1.ClientID %>.el'
                                                    }
                                                }
                                             );    
        }

        function SelectApplication(app, tree) {
            
            tree.setTitle(app.data.LocaLocalizationName + " 子菜单管理");

            //var hidSelectAppID = <%= hidSelectAppID.ClientID %>;

            //hidSelectAppID.setValue(app.id.toString());

            LoadMenus(app.id,tree)

        }

        function ReloadMenus() {
            
            var hidSelectAppID = <%= hidSelectAppID.ClientID %>;

            var treePanel1 = <%= TreePanel1.ClientID %>;

            LoadMenus(hidSelectAppID.getValue(),treePanel1);

        }

        function ShowEditMenuForm(id) {
               Ext.net.DirectMethods.UCSystemMenuEdit.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }   
                );
        }

        function DeleteMenu(menuID) {
                        Ext.MessageBox.confirm('警告','确定要删除选定的菜单?',
                    function(e) {
                        if (e == 'yes')
            Ext.net.DirectMethods.DeleteMenu(
                                                        menuID,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('操作失败', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('操作成功', '删除菜单成功！', RefreshMenuData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '处理中......'
                                                            }
                                                        });
                    }
                    );

        }  


        function ShowMenu(node, menu, point) {
            menu.items.items[0].setVisible((node.attributes.IsGroup == '1'));
            menu.items.items[1].setVisible(true);
            menu.items.items[2].setVisible((node.childNodes.length == 0));
            menu.items.items[3].setVisible((node.childNodes.length > 0));
            menu.items.items[4].setVisible((node.childNodes.length > 0));
            menu.showAt(point);
        }


        function ShowApplicationAddForm() {
            Ext.net.DirectMethods.UCSystemApplicationAdd.Show(
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshSystemApplicationData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '加载中...'
                                                                    }
                                                                });

        }


        function ShowAddMenuForm(appID, parentmenuID) {
            //alert(appID.getValue());
            Ext.net.DirectMethods.UCSystemMenuAdd.Show(
                                                        appID,
                                                        parentmenuID,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('操作失败', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '加载中......'
                                                            }
                                                        });

        }




        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemApplicationEdit.Show(id.id,
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg, RefreshSystemApplicationData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '处理中...'
                                                                    }
                                                                }
                );
            }




            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('警告', '确认要删除当前记录?',
                    function (e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function (msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    },
                                                                    success: function (result) {
                                                                        Ext.Msg.alert('操作成功', '删除记录成功！', RefreshSystemApplicationData);
                                                                    },
                                                                    eventMask: {
                                                                        showMask: true,
                                                                        msg: '处理中...'
                                                                    }
                                                                }
                                                            );
                    }
                    );
            }
        }


    </script>
    <uc1:UCSystemApplicationAdd ID="UCSystemApplicationAdd1" runat="server" />
    <uc2:UCSystemApplicationEdit ID="UCSystemApplicationEdit2" runat="server" />
    <uc3:UCSystemMenuAdd ID="UCSystemMenuAdd1" runat="server" />
    <uc4:UCSystemMenuEdit ID="UCSystemMenuEdit1" runat="server" />
    <uc5:UCSystemMenuManualResort ID="UCSystemMenuManualResort1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Frame="true" Title="应用菜单管理">
                <Items>
                    <ext:BorderLayout ID="BorderLayout1" runat="server">
                        <West Split="true" Collapsible="true">
                            <ext:GridPanel ID="GridPanel1" runat="server" StoreID="storeSystemApplication" StripeRows="true" 
                                Title="系统应用管理" Width="430" Frame="true" AutoScroll="true" AutoExpandColumn="colLocaLocalizationName">
                                <TopBar>
                                    <ext:Toolbar ID="tbTop" runat="server">
                                        <Items>
                                            <ext:Button ID='btnAdd' runat="server" Text="添加" Icon="ApplicationAdd">
                                                <Listeners>
                                                    <Click Handler="ShowApplicationAddForm();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                                <Listeners>
                                                    <Click Handler="#{storeSystemApplication}.reload();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <View>
                                    <ext:GridView ForceFit="true" ID="GridView1">
                                        <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                                    </ext:GridView>
                                </View>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column ColumnID="colLocaLocalizationName" Header="名称" Width="80" Sortable="true"
                                            DataIndex="LocaLocalizationName" />
                                        <ext:Column ColumnID="colSystemApplicationCode" Header="编码" Width="120" Sortable="true"
                                            DataIndex="SystemApplicationCode" />
                                        <ext:Column DataIndex="SystemApplicationIsSystemApplication" Header="系统应用" Width="65">
                                            <Renderer Fn="FormatBool" />
                                        </ext:Column>
                                        <ext:CommandColumn Width="50" Header="管理">
                                            <Commands>
                                                <ext:SplitCommand Text="操作" ToolTip-Text="数据操作">
                                                    <Menu EnableScrolling="true" ShowSeparator="true">
                                                        <Items>
                                                            <ext:MenuCommand Text="编辑" Icon="ApplicationEdit" CommandName="cmdEdit" />
                                                            <ext:MenuCommand Text="删除" Icon="ApplicationDelete" CommandName="cmdDelete" />
                                                        </Items>
                                                    </Menu>
                                                </ext:SplitCommand>
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                        <Listeners>
                                            <RowSelect Buffer="100" Handler="SelectApplication(this.getSelected(),#{TreePanel1});" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10" StoreID="storeSystemApplication"
                                        DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共: {2}" EmptyMsg="没有符合条件的记录" />
                                </BottomBar>
                                <Listeners>
                                    <Command Handler="processcmd(command, record);" />
                                </Listeners>
                            </ext:GridPanel>
                        </West>
                        <Center>
                            <ext:TreePanel ID="TreePanel1" runat="server" Title="菜单管理" AutoScroll="true" RootVisible="false"  EnableDD=true
                               >
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="根菜单操作:" />
                                            <ext:ToolbarSeparator>
                                            </ext:ToolbarSeparator>
                                            <ext:Button ID="tbAddRootMenu" runat="server" Icon="Add" Text="添加">
                                                <Listeners>
                                                    <Click Handler="ShowAddMenuForm(#{hidSelectAppID}.getValue(),'');" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton2" runat="server" Icon="SortAscending" Text="手动排序">
                                                <Listeners>
                                                    <Click Handler="showReorderForm(0,#{hidSelectAppID}.getValue(),#{hidSortPMenuID},#{hidSortAppID});" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton5" runat="server" Icon="SortAscending" Text="自动排序">
                                                <Listeners>
                                                    <Click Handler="AutoReorder(0,#{hidSelectAppID}.getValue())" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton3" runat="server" IconCls="icon-expand-all" Text="全部展开">
                                                <Listeners>
                                                    <Click Handler="#{TreePanel1}.root.expand(true);" />
                                                </Listeners>
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip1" IDMode="Ignore" runat="server" Html="Expand All" />
                                                </ToolTips>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton4" runat="server" IconCls="icon-collapse-all" Text="全部收起">
                                                <Listeners>
                                                    <Click Handler="#{TreePanel1}.root.collapse(true);" />
                                                </Listeners>
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip2" IDMode="Ignore" runat="server" Html="Collapse All" />
                                                </ToolTips>
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Root>
                                    <ext:TreeNode Text="系统菜单" Expanded="true" Icon="Folder">
                                    </ext:TreeNode>
                                </Root>
                                <BottomBar>
                                    <ext:StatusBar ID="StatusBar1" runat="server" />
                                </BottomBar>
                                <Listeners>
                                    <NodeDragOver Fn="dragOver" />
                                    <ContextMenu Handler="e.preventDefault();node.select();ShowMenu(node,#{cmenu},e.getPoint());" />
                                    <Click Handler="#{StatusBar1}.setStatus({text: '当前选中节点: <b>' + node.text + '</b>', clear: false});" />
                                </Listeners>
   
                            </ext:TreePanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="addItem" runat="server" Text="添加子菜单" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddMenuForm(#{hidSelectAppID}.getValue(),#{TreePanel1}.selModel.selNode.attributes.id); " />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItem" runat="server" Text="编辑菜单" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditMenuForm(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItem" runat="server" Text="删除菜单" Icon="Delete">
                <Listeners>
                    <Click Handler="DeleteMenu(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="sortItem" runat="server" Text="子菜单手动排序" Icon="SortAscending">
                <Listeners>
                    <Click Handler="showReorderForm(#{TreePanel1}.selModel.selNode.attributes.id,#{hidSelectAppID}.getValue(),#{hidSortPMenuID},#{hidSortAppID});" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="autoSortItem" runat="server" Text="子菜单自动排序" Icon="SortAscending">
                <Listeners>
                    <Click Handler="AutoReorder(#{TreePanel1}.selModel.selNode.attributes.id,#{hidSelectAppID}.getValue());" />
                </Listeners>
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:Hidden ID="hidSelectAppID" runat="server">
    </ext:Hidden>
</asp:Content>
