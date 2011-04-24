<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemMenuListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.MenuManage.SystemMenuListPage" %>

<%@ Register Src="UCSystemMenuAdd.ascx" TagName="UCSystemMenuAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemMenuEdit.ascx" TagName="UCSystemMenuEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemMenuManualResort.ascx" TagName="UCSystemMenuManualResort"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function RefreshList(cmb, treepanel) {
            Ext.net.DirectMethods.GetTreeNodes(
                                                cmb.getValue(),
                                                {
                                                    failure: function(msg) {
                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                    },
                                                    success: function(result) {
                                                        var nodes = eval(result);
                                                        if(nodes.length > 0){
                                                            treepanel.initChildren(nodes);
                                                        }
                                                        else{
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
        
        function AutoReorder(id,appID)
        {
        
                        Ext.net.DirectMethods.AutoMaticSortSubItems(appID,id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    success: function(result) {
                                                                        RefreshTreeList1();
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }); 
        
        
        
        
        
        
        
        }
        
        
               function showReorderForm(id,stores,appID,hid,hidappID) {
               
               hid.setValue(id);
               
               hidappID.setValue(appID); 
               
//stores.autoLoad.params.ParentMenuID = id;

//stores.autoLoad.params.AppID = appID;
               
                Ext.net.DirectMethods.UCSystemMenuManualResort.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    success: function(result) {
                                                                        stores.reload();
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
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
               Ext.net.DirectMethods.UCSystemMenuEdit.Show(id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                                               }
                                                                }   
                );
        }


        function ShowAddForm(appID, parentmenuID) {
            Ext.net.DirectMethods.UCSystemMenuAdd.Show(
                                                        appID,
                                                        parentmenuID,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                            }
                                                        });

        }

        function DeleteMenu(menuID) {
                        Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','Are you sure to delete selected Menu?',
                    function(e) {
                        if (e == 'yes')
            Ext.net.DirectMethods.DeleteMenu(
                                                        menuID,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('Operation successful', 'Delete menu successful!', RefreshData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: 'Processing......'
                                                            }
                                                        });
                    }
                    );

        }    

    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSystemApplication}.reload();" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSystemApplication" runat="server" AutoLoad="true" OnRefreshData="storeSystemApplication_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" />
                    <ext:RecordField Name="LocaLocalizationName" />
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="if(#{storeSystemApplication}.data.items.length>0) {#{cbApplication}.setValue(#{storeSystemApplication}.data.items[0].data.SystemApplicationID);RefreshList(#{cbApplication},#{TreePanel1});#{WestPanel}.setDisabled(false);}" />
        </Listeners>
    </ext:Store>
    <ext:Menu ID="cmenu" runat="server">
        <Items>
            <ext:MenuItem ID="copyItems" runat="server" Text="Add sub menu" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddForm(#{cbApplication}.getValue(),#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="Edit Menu" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditForm(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="Delete Menu" Icon="Delete">
                <Listeners>
                    <Click Handler="DeleteMenu(#{TreePanel1}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem1" runat="server" Text="Sub menu sort" Icon="SortAscending">
                <Listeners>
                    <Click Handler="showReorderForm(#{TreePanel1}.selModel.selNode.attributes.id,#{storeSubMenus},#{cbApplication}.getValue(),#{hidSortPMenuID},#{hidSortAppID});" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem2" runat="server" Text="Sub menu automatic sort" Icon="SortAscending">
                <Listeners>
                    <Click Handler="AutoReorder(#{TreePanel1}.selModel.selNode.attributes.id,#{cbApplication}.getValue());" />
                </Listeners>
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Title="System Menu Manage" Width="300" Disabled="true"
                        Layout="fit">
                        <Content>
                            <ext:TreePanel ID="TreePanel1" runat="server" Header="false" RootVisible="false"
                                AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="Application: " />
                                            <ext:ComboBox ID="cbApplication" runat="server" EmptyText="Select application" AutoWidth="true"
                                                Editable="false" TypeAhead="true" StoreID="storeSystemApplication" DisplayField="LocaLocalizationName"
                                                ValueField="SystemApplicationID" ForceSelection="true" SelectOnFocus="true">
                                                <Listeners>
                                                    <Select Handler="RefreshList(#{cbApplication},#{TreePanel1});" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:Button ID="ToolbarButton1" runat="server" Icon="Add" Text="Add root menu">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(#{cbApplication}.getValue(),'');" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton2" runat="server" Icon="SortAscending" Text="Root menu sort">
                                                <Listeners>
                                                    <Click Handler="showReorderForm(0,#{storeSubMenus},#{cbApplication}.getValue(),#{hidSortPMenuID},#{hidSortAppID});" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton5" runat="server" Icon="SortAscending" Text="Root menu auto sort">
                                                <Listeners>
                                                    <Click Handler="AutoReorder(0,#{cbApplication}.getValue());" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton3" runat="server" IconCls="icon-expand-all" Text="Expand all">
                                                <Listeners>
                                                    <Click Handler="#{TreePanel1}.root.expand(true);" />
                                                </Listeners>
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip1" IDMode="Ignore" runat="server" Html="Expand All" />
                                                </ToolTips>
                                            </ext:Button>
                                            <ext:Button ID="ToolbarButton4" runat="server" IconCls="icon-collapse-all" Text="Collapse all">
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
                                    <ext:TreeNode Text="System menu" Expanded="true" Icon="Folder">
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
                        </Content>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    <uc1:UCSystemMenuAdd ID="UCSystemMenuAdd1" runat="server" />
    <uc2:UCSystemMenuEdit ID="UCSystemMenuEdit1" runat="server" />
    <uc3:UCSystemMenuManualResort ID="UCSystemMenuManualResort1" runat="server" />
    <%-- --%>
</asp:Content>

