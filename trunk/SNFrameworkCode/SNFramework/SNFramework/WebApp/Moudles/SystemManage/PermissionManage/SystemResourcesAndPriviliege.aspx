<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemResourcesAndPriviliege.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage.SystemResourcesAndPriviliege" %>

<%@ Register Src="UCSystemResourcesAdd.ascx" TagName="UCSystemResourcesAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSystemResourcesEdit.ascx" TagName="UCSystemResourcesEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSystemOperationAdd.ascx" TagName="UCSystemOperationAdd" TagPrefix="uc3" %>
<%@ Register Src="UCSystemOperationEdit.ascx" TagName="UCSystemOperationEdit" TagPrefix="uc4" %>
<%@ Register Src="UCSystemPrivilegeAdd.ascx" TagName="UCSystemPrivilegeAdd" TagPrefix="uc5" %>
<%@ Register Src="UCSystemPrivilegeEdit.ascx" TagName="UCSystemPrivilegeEdit" TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{treeMain});" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <script type="text/javascript">

            var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        }

        function RefreshTreeList1() {
            RefreshList(<%= this.treeMain.ClientID %>);
        }

 
         function ShowMenu(node,menu,point) {
            menu.items.items[0].setVisible(true);
            menu.items.items[1].setVisible(true);
            menu.items.items[2].setVisible((node.childNodes.length==0));
            menu.showAt(point);
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

        var RefreshData = function(btn) {
            RefreshList(<%= this.treeMain.ClientID %>);
        };

        var RefreshOperationData = function(btn) {
            RefreshOperationDataList();
        };

        function RefreshOperationDataList() {
            <%= this.storeSystemOperation.ClientID %>.reload();
        };

         var RefreshSystemPrivilegeData = function(btn) {
            RefreshSystemPrivilegeDataList();
        };

        function RefreshSystemPrivilegeDataList() {
            <%= this.storeSystemPrivilege.ClientID %>.reload();
        };



        


        function ShowEditForm(id) {
               Ext.net.DirectMethods.UCSystemResourcesEdit.Show(id,
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


        function ShowAddForm(pid) {
            Ext.net.DirectMethods.UCSystemResourcesAdd.Show(
                                                        pid,
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

        function showAddSystemOperationForm(rid) {
            Ext.net.DirectMethods.UCSystemOperationAdd.Show(
                                                        rid,
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

        function QuickPatchAdd(rid) {
                    Ext.net.DirectMethods.QuickPatchAddOperation(
                                                        rid,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', 'Quick patch add ok!', RefreshOperationData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                            }
                                                        });
        
        }


                function QuickGenerate(rid) {
                    Ext.net.DirectMethods.QuickGeneratePrivilege(
                                                        rid,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', 'Quick patch add ok!', RefreshSystemPrivilegeData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                            }
                                                        });
        
        }

        

        function SelectResources(node,hid,pnl)
        {
            hid.setValue(node.attributes.id.toString());
            pnl.setTitle(node.text+' 操作权限管理');
            pnl.setDisabled(!(node!=null&&node.attributes.id!=null&&node.attributes.id>0));
            RefreshSystemPrivilegeDataList();
            RefreshOperationDataList();
        }


        function DeleteData(id) {
                        Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                    function(e) {
                        if (e == 'yes')
            Ext.net.DirectMethods.DeleteData(
                                                        id,
                                                        {
                                                            failure: function(msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            success: function(result) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>', RefreshData);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                            }
                                                        });
                    }
                    );

        } 
        
        
                function processcmdSystemOperation(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemOperationEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshOperationData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }              
                );
            }
			
			            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSystemOperationView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshOperationData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }              
                );
            }

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('warning','Are you sure delete the record ? ',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteSystemOperationRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete a record success!',RefreshOperationData);            
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing ......'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }

  
    
    </script>
    <ext:Store ID="storeSystemOperation" runat="server" AutoLoad="false" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemOperation_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="OperationID">
                <Fields>
                    <ext:RecordField Name="OperationID" Type="int" />
                    <ext:RecordField Name="OperationNameCn" />
                    <ext:RecordField Name="OperationNameEn" />
                    <ext:RecordField Name="OperationDescription" />
                    <ext:RecordField Name="IsSystemOperation" Type="Boolean" />
                    <ext:RecordField Name="IsCanSingleOperation" Type="Boolean" />
                    <ext:RecordField Name="IsCanMutilOperation" Type="Boolean" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="IsInListPage" Type="Boolean" />
                    <ext:RecordField Name="IsInSinglePage" Type="Boolean" />
                    <ext:RecordField Name="OperationOrder" Type="int" />
                    <ext:RecordField Name="IsCommonOperation" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Value="#{hidSelectResourceID}.getValue()" Mode="Raw" Name="SelectResourceID">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:Store ID="storeSystemPrivilege" runat="server" AutoLoad="false" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemPrivilege_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="20" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="PrivilegeID">
                <Fields>
                    <ext:RecordField Name="PrivilegeID" Type="int" />
 
                    <ext:RecordField Name="OperationName" />
                    
                    <ext:RecordField Name="PrivilegeCnName" />
                    <ext:RecordField Name="PrivilegeEnName" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="PrivilegeOrder" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Value="#{hidSelectResourceID}.getValue()" Mode="Raw" Name="SelectResourceID">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemResourcesAdd ID="UCSystemResourcesAdd1" runat="server" />
    <uc2:UCSystemResourcesEdit ID="UCSystemResourcesEdit1" runat="server" />
    <uc3:UCSystemOperationAdd ID="UCSystemOperationAdd1" runat="server" />
    <uc4:UCSystemOperationEdit ID="UCSystemOperationEdit1" runat="server" />
    <uc5:UCSystemPrivilegeAdd ID="UCSystemPrivilegeAdd1" runat="server" />
    <uc6:UCSystemPrivilegeEdit ID="UCSystemPrivilegeEdit1" runat="server" />
        <ext:Hidden ID="hidSelectResourceID" runat="server">
    </ext:Hidden>
    <ext:Menu ID="cResource" runat="server">
        <Items>
            <ext:MenuItem ID="AddItems" runat="server" Text="Add Sub Resource" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddForm(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="Edit Resource" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditForm(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="Delete Resource" Icon="Delete">
                <Listeners>
                    <Click Handler="DeleteData(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel ID="WestPanel" runat="server" Icon="Package" Title="资源管理" Width="300"
                        Layout="fit">
                        <Content>
                            <ext:TreePanel ID="treeMain" runat="server" Header="false" RootVisible="false" AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button1" runat="server" Icon="Add" Text="添加根资源">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(0);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button3" runat="server" IconCls="icon-expand-all" Text="展开全部">
                                            </ext:Button>
                                            <ext:Button ID="Button4" runat="server" IconCls="icon-collapse-all" Text="收起全部">
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
                                    <ContextMenu Handler="e.preventDefault();node.select();ShowMenu(node,#{cResource},e.getPoint());" />
                                    <Click Handler="#{StatusBar1}.setStatus({text: '当前选中节点: <b>' + node.text + '</b>', clear: false});SelectResources(node,#{hidSelectResourceID},#{pnlEast});" />
                                </Listeners>
                            </ext:TreePanel>
                        </Content>
                    </ext:Panel>
                </Center>
                <East Split="true" Collapsible="true">
                    <ext:Panel ID="pnlEast" runat="server" Icon="Package" Title="操作权限管理" Width="650"
                        Layout="fit" Disabled="true">
                        <Content>
                            <ext:TabPanel ID="TabPanel1" runat="server" Frame="true">
                                <Items>
                                            
           
                                    <ext:Panel ID="Tab1" Title="操作管理" Icon="UserMature" runat="server" Layout="FitLayout">
                                        <Items>
                                            <ext:GridPanel ID="gridPanelSystemOperation" runat="server" StoreID="storeSystemOperation"
                                                StripeRows="true" Title="操作管理" Icon="Table">
                                                <TopBar>
                                                    <ext:Toolbar ID="tbTop" runat="server">
                                                        <Items>
                                                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="showAddSystemOperationForm(#{hidSelectResourceID}.getValue());" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID='btnQuickPatchAdd' runat="server" Text="Quick Patch Add" Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="QuickPatchAdd(#{hidSelectResourceID}.getValue());" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                                                <Listeners>
                                                                    <Click Handler="#{storeSystemOperation}.reload();" />
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
                                                        <ext:RowNumbererColumn>
                                                        </ext:RowNumbererColumn>
                                                        <ext:Column ColumnID="colOperationNameCn" DataIndex="OperationNameCn" Header="Name"
                                                            Sortable="true">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colOperationNameEn" DataIndex="OperationNameEn" Header="Code"
                                                            Sortable="true">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colIsSystemOperation" DataIndex="IsSystemOperation" Header="System"
                                                            Width="55" Sortable="true">
                                                            <Renderer Fn="FormatBool" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colIsCanSingleOperation" DataIndex="IsCanSingleOperation" Header="SingleOp"
                                                            Width="60" Sortable="true">
                                                            <Renderer Fn="FormatBool" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colIsCanMutilOperation" DataIndex="IsCanMutilOperation" Header="MutilOp"
                                                            Width="60" Sortable="true">
                                                            <Renderer Fn="FormatBool" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="Enable" Sortable="true"
                                                            Width="50">
                                                            <Renderer Fn="FormatBool" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colIsInListPage" DataIndex="IsInListPage" Header="List" Width="50"
                                                            Sortable="true">
                                                            <Renderer Fn="FormatBool" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colIsInSinglePage" DataIndex="IsInSinglePage" Header="Single"
                                                            Width="50" Sortable="true">
                                                            <Renderer Fn="FormatBool" />
                                                        </ext:Column>
                                                        <ext:CommandColumn ColumnID="colManage" Header="Action" Width="80">
                                                            <Commands>
                                                                <ext:SplitCommand Text="Action" Icon="ApplicationEdit">
                                                                    <Menu>
                                                                        <Items>
                                                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                                                            </ext:MenuCommand>
                                                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                                                            </ext:MenuCommand>
                                                                        </Items>
                                                                    </Menu>
                                                                </ext:SplitCommand>
                                                            </Commands>
                                                        </ext:CommandColumn>
                                                    </Columns>
                                                </ColumnModel>
                                                <LoadMask ShowMask="true" />
                                                <BottomBar>
                                                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemOperation"
                                                        DisplayInfo="true" DisplayMsg="Display Operations {0} - {1} total {2}" EmptyMsg="No matched Operations" />
                                                </BottomBar>
                                                <Listeners>
                                                    <Command Handler="processcmdSystemOperation(command, record);" />
                                                </Listeners>
                                            </ext:GridPanel>
                                        </Items>
                                     <Listeners>
                                     <BeforeShow Handler="if(#{hidSelectResourceID}.getValue()!=''){ RefreshOperationDataList();};" />
                                     </Listeners>
                                    </ext:Panel>
                                    <ext:Panel ID="Tab2" Title="权限管理" Icon="UserKey" runat="server" Layout="FitLayout">
                                        <Items>
                                            <ext:GridPanel ID="gridPanelSystemPrivilege" runat="server" StoreID="storeSystemPrivilege"
                                                StripeRows="true" Title="System PermissionManagement" Icon="Table">
                                                <TopBar>
                                                    <ext:Toolbar ID="Toolbar2" runat="server">
                                                        <Items>
                                                            <ext:Button ID='Button2' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
                                                                Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="showAddForm();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID='btnQuickGenerate' runat="server" Text="Quick Generate" Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="QuickGenerate(#{hidSelectResourceID}.getValue());" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID='Button5' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>"
                                                                Icon="Reload">
                                                                <Listeners>
                                                                    <Click Handler="#{storeSystemPrivilege}.reload();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>
                                                <View>
                                                    <ext:GridView ForceFit="true" ID="GridView2">
                                                        <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                                                    </ext:GridView>
                                                </View>
                                                <ColumnModel ID="ColumnModel2" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn>
                                                        </ext:RowNumbererColumn>
                                                        <ext:Column ColumnID="colOperationID" DataIndex="OperationName" Header="Operation"
                                                            >
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colPrivilegeCnName" DataIndex="PrivilegeCnName" Header="Name"
                                                            Sortable="true">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colPrivilegeEnName" DataIndex="PrivilegeEnName" Header="Code"
                                                            Sortable="true">
                                                        </ext:Column>
 
                                                        <ext:Column ColumnID="colPrivilegeOrder" DataIndex="PrivilegeOrder" Header="Order"
                                                            Width="50" Sortable="true">
                                                        </ext:Column>
                                                        <ext:CommandColumn ColumnID="colManage" Header="Action" Width="80">
                                                            <Commands>
                                                                <ext:SplitCommand Text="Action" Icon="ApplicationEdit">
                                                                    <Menu>
                                                                        <Items>
                                                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="<%$ Resources : GlobalResource, msgEdit  %>">
                                                                            </ext:MenuCommand>
                                                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="<%$ Resources : GlobalResource, msgDelete  %>">
                                                                            </ext:MenuCommand>
                                                                        </Items>
                                                                    </Menu>
                                                                </ext:SplitCommand>
                                                            </Commands>
                                                        </ext:CommandColumn>
                                                    </Columns>
                                                </ColumnModel>
                                                <LoadMask ShowMask="true" />
                                                <BottomBar>
                                                    <ext:PagingToolbar ID="PagingToolBar2" runat="server" PageSize="20" StoreID="storeSystemPrivilege"
                                                        DisplayInfo="true" DisplayMsg="Show System Permission {0} - {1} total {2}" EmptyMsg="No matched   System Permission" />
                                                </BottomBar>
                                                <Listeners>
                                                    <Command Handler="processPrivilegecmd(command, record);" />
                                                </Listeners>
                                            </ext:GridPanel>
                                        </Items>
                                                                             <Listeners>
                                     <BeforeShow Handler="if(#{hidSelectResourceID}.getValue()!=''){RefreshSystemPrivilegeDataList();};" />
                                     </Listeners>
                                    </ext:Panel>
                                </Items>
                            </ext:TabPanel>
                        </Content>
                    </ext:Panel>
                </East>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>

</asp:Content>
