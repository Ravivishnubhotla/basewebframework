<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemOrginationDepartmentManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage.SystemOrginationDepartmentManage" %>

<%@ Register Src="UCSystemOrganizationAdd.ascx" TagName="UCSystemOrganizationAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSystemOrganizationEdit.ascx" TagName="UCSystemOrganizationEdit"
    TagPrefix="uc2" %>
<%@ Register Src="UCSystemPostAdd.ascx" TagName="UCSystemPostAdd" TagPrefix="uc3" %>
<%@ Register Src="UCSystemPostEdit.ascx" TagName="UCSystemPostEdit" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="RefreshList(#{treeMain});" />
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSystemPost" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemPost_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="ID" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="OrganizationID" Type="int" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                    <ext:RecordField Name="CreateAt" Type="Date" />
                    <ext:RecordField Name="LastModifyBy" Type="int" />
                    <ext:RecordField Name="LastModifyAt" Type="Date" />
                    <ext:RecordField Name="LastModifyComment" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Value="#{hidSelectOrgID}.getValue()" Mode="Raw" Name="SelectOrgID">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <script type="text/javascript">
        var RefreshSystemPostData = function(btn) {
            RefreshSystemPostDataList();
        };

        function RefreshSystemPostDataList() {
            <%= this.storeSystemPost.ClientID %>.reload();
        };
        
        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };
        
        function ShowMenu(node,menu,point) {
            menu.items.items[0].setVisible(true);
            menu.items.items[1].setVisible(true);
            menu.items.items[2].setVisible((node.childNodes.length==0));
            menu.showAt(point);
        }
        
                var RefreshData = function(btn) {
            RefreshList(<%= this.treeMain.ClientID %>);
        };
        
        function RefreshList(treepanel) {
            Ext.net.DirectMethods.GetTreeNodes(
                                                {
                                                    failure: function (msg) {
                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                    },
                                                    success: function (result) {
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

        function ShowAddForm(pid) {
            Ext.net.DirectMethods.UCSystemOrganizationAdd.Show(
                                                        pid,
                                                        {
                                                            failure: function (msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                            }
                                                        });
        } 
        
        
                function ShowEditForm(id) {
               Ext.net.DirectMethods.UCSystemOrganizationEdit.Show(id,
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
                

                        function showAddSystemPostForm(pid) {
                            alert(pid);
            Ext.net.DirectMethods.UCSystemPostAdd.Show(
                                                        pid,
                                                        {
                                                            failure: function (msg) {
                                                                Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                            },
                                                            eventMask: {
                                                                showMask: true,
                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>'
                                                            }
                                                        });
        } 
        
        
                function ShowEditSystemPostForm(id) {
               Ext.net.DirectMethods.UCSystemPostEdit.Show(id,
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
        
        
        
        
        
          function RefreshTreeList1() {
            RefreshList(<%= this.treeMain.ClientID %>);
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
          
          
        function SelectOrg(node,hid,pnl)
        {
            hid.setValue(node.attributes.id.toString());
            pnl.setTitle(node.text+'<%= GetLocalResourceObject("msgDepartmentPostManage").ToString() %>');
            pnl.setDisabled(!(node!=null&&node.attributes.id!=null&&node.attributes.id>0));

            RefreshDepartmentPanel();      
            RefreshSystemPostDataList();
        }

        function RefreshDepartmentPanel() {
            var pnlDepartment = <%= pnlDepartment.ClientID %> ;
            var hid = <%= hidSelectOrgID.ClientID %> ;
            pnlDepartment.autoLoad.params.OrginationID = hid.getValue();
            pnlDepartment.reload(); 
        }
        
        
 
       
        
        
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemOrganizationAdd ID="UCSystemOrganizationAdd1" runat="server" />
    <uc2:UCSystemOrganizationEdit ID="UCSystemOrganizationEdit1" runat="server" />
    <ext:Hidden ID="hidSelectOrgID" runat="server">
    </ext:Hidden>
    <ext:Menu ID="cOrg" runat="server">
        <Items>
            <ext:MenuItem ID="AddItems" runat="server" Text="<%$ Resources:msgAddSubOrg %>" Icon="Add">
                <Listeners>
                    <Click Handler="ShowAddForm(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="editItems" runat="server" Text="<%$ Resources:msgEditOrg %>" Icon="Anchor">
                <Listeners>
                    <Click Handler="ShowEditForm(#{treeMain}.selModel.selNode.attributes.id);" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="deleteItems" runat="server" Text="<%$ Resources:msgDeleteOrg %>"
                Icon="Delete">
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
                    <ext:Panel ID="WestPanel" runat="server" Icon="Package" Title="<%$ Resources:msgPanelOrgManage %>"
                        Width="260" Layout="fit">
                        <Content>
                            <ext:TreePanel ID="treeMain" runat="server" Header="false" RootVisible="false" AutoScroll="true">
                                <TopBar>
                                    <ext:Toolbar ID="ToolBar1" runat="server">
                                        <Items>
                                            <ext:Button ID="Button1" runat="server" Icon="Add" Text="<%$ Resources:msgAddRootOrg %>">
                                                <Listeners>
                                                    <Click Handler="ShowAddForm(0);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button3" runat="server" IconCls="icon-expand-all" Text="<%$ Resources : GlobalResource, msgCollapseAll  %>">
                                                <Listeners>
                                                    <Click Handler="#{treeMain}.root.expand(true);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="Button4" runat="server" IconCls="icon-collapse-all" Text="<%$ Resources : GlobalResource, msgExpandAll  %>">
                                                <Listeners>
                                                    <Click Handler="#{treeMain}.root.collapse(true);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Root>
                                    <ext:TreeNode Text="<%$ Resources : msgRootNodeText  %>" Expanded="true" Icon="Folder">
                                    </ext:TreeNode>
                                </Root>
                                <BottomBar>
                                    <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                </BottomBar>
                                <Listeners>
                                    <ContextMenu Handler="e.preventDefault();node.select();ShowMenu(node,#{cOrg},e.getPoint());" />
                                    <Click Handler="<%$ Resources : msgOrgStatusBar  %>" />
                                </Listeners>
                            </ext:TreePanel>
                        </Content>
                    </ext:Panel>
                </Center>
                <East Split="true" Collapsible="true">
                    <ext:Panel ID="pnlEast" runat="server" Icon="Package" Title="<%$ Resources : msgPanelDepartmentPostManage  %>"
                        Width="880" Layout="fit" Disabled="true">
                        <Content>
                            <ext:TabPanel ID="TabPanel1" runat="server" Frame="true">
                                <Items>
                                    <ext:Panel ID="pnlDepartment" Title="<%$ Resources : msgPanelDepartmentManage  %>"
                                        Icon="UserKey" runat="server" Layout="FitLayout">
                                        <AutoLoad Url="../DepartmentManage/SystemDepartmentListPage.aspx" Mode="IFrame" ManuallyTriggered="true"
                                            NoCache="true" ShowMask="true">
                                            <Params>
                                                <ext:Parameter Name="OrginationID" Mode="Raw" Value="0">
                                                </ext:Parameter>
                                            </Params>
                                        </AutoLoad>
                                    </ext:Panel>
                                    <ext:Panel ID="Panel1" Title="<%$ Resources : msgPanelPostManage  %>" Icon="UserKey"
                                        runat="server" Layout="FitLayout">
                                        <Items>
                                            <ext:GridPanel ID="gridPanelSystemPost" runat="server" StoreID="storeSystemPost"
                                                StripeRows="true" Title="<%$ Resources:msgGridPanelPostManage %>" Icon="Table">
                                                <TopBar>
                                                    <ext:Toolbar ID="tbTop" runat="server">
                                                        <Items>
                                                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd %>"
                                                                Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="showAddSystemPostForm(#{hidSelectOrgID}.getValue());" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh %>"
                                                                Icon="Reload">
                                                                <Listeners>
                                                                    <Click Handler="#{storeSystemPost}.reload();" />
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
                                                        <ext:Column ColumnID="colName" DataIndex="Name" Header="<%$ Resources:msgGridPanelColName %>"
                                                            Sortable="true">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="<%$ Resources:msgGridPanelColCode %>"
                                                            Sortable="true">
                                                        </ext:Column>
                                                        <ext:CommandColumn ColumnID="colManage" Header="<%$ Resources : GlobalResource, msgManage  %>"
                                                            Width="60">
                                                            <Commands>
                                                                <ext:SplitCommand Text="<%$ Resources : GlobalResource, msgAction  %>" Icon="ApplicationEdit">
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
                                                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemPost"
                                                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>"
                                                        EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
                                                </BottomBar>
                                                <Listeners>
                                                    <Command Handler="processSystemPostcmd(command, record);" />
                                                </Listeners>
                                            </ext:GridPanel>
                                        </Items>
                                        <Listeners>
                                            <BeforeShow Handler="if(#{hidSelectOrgID}.getValue()!=''){RefreshSystemPostDataList();};" />
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
