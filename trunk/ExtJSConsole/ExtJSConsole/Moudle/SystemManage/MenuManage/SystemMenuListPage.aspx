<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemMenuListPage.aspx.cs" Inherits="ExtJSConsole.Moudle.SystemManage.MenuManage.SystemMenuListPage" %>

<%@ Register Src="UCSystemMenuAdd.ascx" TagName="UCSystemMenuAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemMenuEdit.ascx" TagName="UCSystemMenuEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemMenuManualResort.ascx" TagName="UCSystemMenuManualResort"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function RefreshList(cmb, treepanel) {
            Coolite.AjaxMethods.GetTreeNodes(
                                                cmb.getValue(),
                                                {
                                                    failure: function(msg) {
                                                        Ext.Msg.alert('操作失败', msg);
                                                    },
                                                    success: function(result) {
                                                        var nodes = eval(result);
                                                        treepanel.root.ui.remove();
                                                        treepanel.initChildren(nodes);
                                                        treepanel.root.render();
                                                    },
                                                    eventMask: {
                                                        showMask: true,
                                                        msg: '正在加载菜单......'
                                                    }
                                                }
                                             );

        }
        
        function AutoReorder(id,appID)
        {
        
                        Coolite.AjaxMethods.AutoMaticSortSubItems(appID,id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    success: function(result) {
                                                                        RefreshTreeList1();
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '处理中...'
                                                                               }
                                                                }); 
        
        
        
        
        
        
        
        }
        
        
               function showReorderForm(id,stores,appID) {
               
stores.autoLoad.params.ParentMenuID = id;

stores.autoLoad.params.AppID = appID;
               
                Coolite.AjaxMethods.UCSystemMenuManualResort.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg,RefreshData);
                                                                    },
                                                                    success: function(result) {
                                                                        stores.reload();
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '加载中...'
                                                                               }
                                                                }); 
                                                                  
        
        }
        



        var RefreshData = function(btn) {
            RefreshList( <%= this.cbApplication.ClientID %>, <%= this.TreePanel1.ClientID %>);
        };
        
        
        
        function RefreshTreeList1() {
            RefreshList( <%= this.cbApplication.ClientID %>, <%= this.TreePanel1.ClientID %>);
        }
        
        
        
        function ShowMenu(node,menu,point) {
            menu.items.items[0].setVisible((node.attributes.IsGroup=='1'));
            menu.items.items[1].setVisible(true);
            menu.items.items[2].setVisible((node.childNodes.length==0));
            menu.items.items[3].setVisible((node.childNodes.length>0));
            menu.items.items[4].setVisible((node.childNodes.length>0));
            menu.showAt(point);
        }
        
        
        function ShowEditForm(id) {
               Coolite.AjaxMethods.UCSystemMenuEdit.Show(id,
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


        function ShowAddForm(appID, parentmenuID) {
            Coolite.AjaxMethods.UCSystemMenuAdd.Show(
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

        function DeleteMenu(menuID) {
                        Ext.MessageBox.confirm('警告','确认要删除所选菜单 ? ',
                    function(e) {
                        if (e == 'yes')
            Coolite.AjaxMethods.DeleteMenu(
                                                        menuID,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('操作失败', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('操作成功', '成功删除系统菜单！', RefreshData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '操作中......'
                                                            }
                                                        });
                    }
                    );

        }    

    
    </script>

    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="true" OnRefreshData="storeSystemApplication_Refresh">
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{cbApplication}.setValue(#{storeSystemApplication}.data.items[0].data.SystemApplicationID);RefreshList(#{cbApplication},#{TreePanel1});#{WestPanel}.setDisabled(false);" />
        </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSystemApplication}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="copyItems" runat="server" Text="添加子菜单" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddForm(#{cbApplication}.getValue(),#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="编辑菜单" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditForm(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="删除菜单" Icon="Delete">
                <Listeners>
                    <Click Handler="DeleteMenu(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem1" runat="server" Text="子菜单排序" Icon="SortAscending">
                <Listeners>
                    <Click Handler="showReorderForm(#{TreePanel1}.selModel.selNode.attributes.id,#{storeSubMenus},#{cbApplication}.getValue());" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem2" runat="server" Text="子菜单自动排序" Icon="SortAscending">
                <Listeners>
                    <Click Handler="AutoReorder(#{TreePanel1}.selModel.selNode.attributes.id,#{cbApplication}.getValue());" />
                </Listeners>
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Title="系统菜单管理" Width="300" Disabled="true">
                        <Body>
                            <ext:FitLayout ID="FitLayout1" runat="server">
                                <ext:TreePanel ID="TreePanel1" runat="server" Header="false" RootVisible="false"
                                    AutoScroll="true">
                                    <TopBar>
                                        <ext:Toolbar ID="ToolBar1" runat="server">
                                            <Items>
                                                <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="所属系统应用： " />
                                                <ext:ComboBox ID="cbApplication" runat="server" EmptyText="选择系统应用" AutoWidth="true"
                                                    Editable="false" TypeAhead="true" StoreID="storeSystemApplication" DisplayField="SystemApplicationName"
                                                    ValueField="SystemApplicationID" ForceSelection="true" SelectOnFocus="true">
                                                    <Listeners>
                                                        <Select Handler="RefreshList(#{cbApplication},#{TreePanel1});" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:ToolbarButton ID="ToolbarButton1" runat="server" Icon="Add" Text="添加根菜单">
                                                    <Listeners>
                                                        <Click Handler="ShowAddForm(#{cbApplication}.getValue(),'');" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton2" runat="server" Icon="SortAscending" Text="根菜单排序">
                                                    <Listeners>
                                                        <Click Handler="showReorderForm(0,#{storeSubMenus},#{cbApplication}.getValue());" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton5" runat="server" Icon="SortAscending" Text="根菜单自动排序">
                                                    <Listeners>
                                                        <Click Handler="AutoReorder(0,#{cbApplication}.getValue());" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton3" runat="server" IconCls="icon-expand-all" Text="全部展开">
                                                    <Listeners>
                                                        <Click Handler="#{TreePanel1}.root.expand(true);" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip1" IDMode="Ignore" runat="server" Html="Expand All" />
                                                    </ToolTips>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID="ToolbarButton4" runat="server" IconCls="icon-collapse-all"
                                                    Text="全部收起">
                                                    <Listeners>
                                                        <Click Handler="#{TreePanel1}.root.collapse(true);" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip2" IDMode="Ignore" runat="server" Html="Collapse All" />
                                                    </ToolTips>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Root>
                                        <ext:TreeNode Text="系统菜单" Expanded="true" Icon="Folder">
                                        </ext:TreeNode>
                                    </Root>
                                    <BottomBar>
                                        <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                    </BottomBar>
                                    <Listeners>
                                        <ContextMenu Handler="e.preventDefault();node.select();ShowMenu(node,#{cmenu},e.getPoint());" />
                                        <Click Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '</b>', clear: true});" />
                                    </Listeners>
                                </ext:TreePanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
    <uc1:UCSystemMenuAdd ID="UCSystemMenuAdd1" runat="server" />
    <uc2:UCSystemMenuEdit ID="UCSystemMenuEdit1" runat="server" />
    <uc3:UCSystemMenuManualResort ID="UCSystemMenuManualResort1" runat="server" />
</asp:Content>
