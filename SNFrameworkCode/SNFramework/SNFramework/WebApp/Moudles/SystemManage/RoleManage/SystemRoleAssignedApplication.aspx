<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemRoleAssignedApplication.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.SystemRoleAssignedApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server" />
    <script type="text/javascript">
        function btSave_Click(json) {
            Ext.net.DirectMethods.Save_RoleApplication(json,
                            {
                                failure: function (msg) {
                                    Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg, null);
                                },
                                success: function (result) {
                                    //  Ext.Msg.alert('Operation Successful', 'Save successful System Permission!',function(btn){ });    
                                    parent.CloseWinAssignedApplication();

                                },
                                eventMask:
                               {
                                   showMask: true,
                                   msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                               }
                            }
                );
        }
          
          
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
                                                            tree.root.expand(true);
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


         function SaveMenus(tree, appid) {
            Ext.net.DirectMethods.SaveApplicationAssignedMenus(
                                                             appid, getParas(tree),
                                                            {
                                                                failure: function(msg) {
                                                                    Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                },
                                                                success: function(result) {
                                                                    Ext.MessageBox.alert('Operation successful', 'System Role Assigned menu successfully.', function(btn) { parent.CloseWinAssignedMenu(); });
                                                                },
                                                                eventMask:
                                                                 {
                                                                     showMask: true,
                                                                     msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                 }
                                                            }
                                                        );
        }

        function getParas(tree) {
                 var selNodes = tree.getChecked();
                 var arrys = [];
                 Ext.each(selNodes, function(node) {
                     arrys.push(node.attributes.MenuID);
                 });
                 return arrys.toString();
             }
        
        
        function checkNode(node, checked) {
            for (var i = 0; i < node.childNodes.length; i++) {
                node.childNodes[i].ui.toggleCheck(checked);
            }
        }  
    
    </script>
    <ext:Store runat="server" ID="storeNotAssigned" AutoLoad="true" OnRefreshData="storeNotAssigned_RefreshData">
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" Mapping="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" Mapping="SystemApplicationName" />
                    <ext:RecordField Name="LocaLocalizationName" Mapping="LocaLocalizationName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store runat="server" ID="storeAssigned" OnRefreshData="storeAssigned_RefreshData">
        <Reader>
            <ext:JsonReader IDProperty="SystemApplicationID">
                <Fields>
                    <ext:RecordField Name="SystemApplicationID" Mapping="SystemApplicationID" />
                    <ext:RecordField Name="SystemApplicationName" Mapping="SystemApplicationName" />
                    <ext:RecordField Name="LocaLocalizationName" Mapping="LocaLocalizationName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="if(#{storeAssigned}.data.items.length>0) {#{GridPanel2}.getSelectionModel().selectFirstRow(); }" />
        </Listeners>
    </ext:Store>
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="Panel1" Title="<%$ Resources:msgFormTitle %>" runat="server" Frame="true">
                <Items>
                    <ext:ColumnLayout ID="ColumnLayout1" runat="server" FitHeight="true">
                        <Columns>
                            <ext:LayoutColumn ColumnWidth="0.33">
                                <ext:GridPanel runat="server" ID="GridPanel1" EnableDragDrop="true" Title="<%$ Resources:msgFormAvailableApplcations %>"
                                    Frame="true" StoreID="storeNotAssigned" AutoExpandColumn="columnName" AutoScroll="true">
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="columnID" Header="ID" DataIndex="SystemApplicationID" Width="30" />
                                            <ext:Column ColumnID="columnName" Header="<%$ Resources:msgcolName %>" DataIndex="LocaLocalizationName" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <View>
                                        <ext:GridView ForceFit="true" ID="GridView1">
                                            <GetRowClass FormatHandler="False"></GetRowClass>
                                        </ext:GridView>
                                    </View>
                                    <Plugins>
                                        <ext:GridFilters ID="GridFilters1" runat="server" Local="true">
                                            <Filters>
                                                <ext:StringFilter DataIndex="Name" />
                                            </Filters>
                                        </ext:GridFilters>
                                    </Plugins>
                                </ext:GridPanel>
                            </ext:LayoutColumn>
                            <ext:LayoutColumn>
                                <ext:Panel ID="Panel2" runat="server" Width="35" BodyStyle="background-color: transparent;"
                                    Border="false">
                                    <Items>
                                        <ext:VBoxLayout ID="VBoxLayout1" runat="server" Align="Stretch" Pack="Center">
                                            <BoxItems>
                                                <ext:BoxItem>
                                                    <ext:Panel ID="Panel4" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                                        Padding="5">
                                                        <Items>
                                                            <ext:Button ID="btnAdd" runat="server" Icon="ResultsetNext" StyleSpec="margin-bottom:2px;">
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnAdd_Click" Success="#{GridPanel1}.reload();#{GridPanel2}.reload();"
                                                                        Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                                                                        <ExtraParams>
                                                                            <ext:Parameter Name="addItem" Mode="Raw" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly : true}))">
                                                                            </ext:Parameter>
                                                                        </ExtraParams>
                                                                        <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgProcessing  %>" />
                                                                    </Click>
                                                                </DirectEvents>
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip1" runat="server" Title="<%$ Resources:msgcolAddTitle %>"
                                                                        Html="<%$ Resources:msgcolAddDescription %>" />
                                                                </ToolTips>
                                                            </ext:Button>
                                                            <ext:Button ID="btnAddAll" runat="server" Icon="ResultsetLast" StyleSpec="margin-bottom:2px;">
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnAdd_Click" Success="#{GridPanel1}.reload();#{GridPanel2}.reload();"
                                                                        Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                                                                        <ExtraParams>
                                                                            <ext:Parameter Name="addItem" Mode="Raw" Value="Ext.encode(#{GridPanel1}.getRowsValues())">
                                                                            </ext:Parameter>
                                                                        </ExtraParams>
                                                                        <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgProcessing  %>" />
                                                                    </Click>
                                                                </DirectEvents>
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip2" runat="server" Title="<%$ Resources:msgcolAddAllTitle %>"
                                                                        Html="<%$ Resources:msgcolAddAllDescription %>" />
                                                                </ToolTips>
                                                            </ext:Button>
                                                            <ext:Button ID="btnRemove" runat="server" Icon="ResultsetPrevious" StyleSpec="margin-bottom:2px;">
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnRemove_Click" Success="#{GridPanel1}.reload();#{GridPanel2}.reload();"
                                                                        Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                                                                        <ExtraParams>
                                                                            <ext:Parameter Name="removeItem" Mode="Raw" Value="Ext.encode(#{GridPanel2}.getRowsValues({selectedOnly : true}))">
                                                                            </ext:Parameter>
                                                                        </ExtraParams>
                                                                        <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgProcessing  %>" />
                                                                    </Click>
                                                                </DirectEvents>
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip3" runat="server" Title="<%$ Resources:msgcolRemoveTitle %>"
                                                                        Html="<%$ Resources:msgcolRemoveDescription %>" />
                                                                </ToolTips>
                                                            </ext:Button>
                                                            <ext:Button ID="Button4" runat="server" Icon="ResultsetFirst" StyleSpec="margin-bottom:2px;">
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnRemove_Click" Success="#{GridPanel1}.reload();#{GridPanel2}.reload();"
                                                                        Failure="<%$ Resources : GlobalResource, msgShowError  %>">
                                                                        <ExtraParams>
                                                                            <ext:Parameter Name="removeItem" Mode="Raw" Value="Ext.encode(#{GridPanel2}.getRowsValues())">
                                                                            </ext:Parameter>
                                                                        </ExtraParams>
                                                                        <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgProcessing  %>" />
                                                                    </Click>
                                                                </DirectEvents>
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip4" runat="server" Title="<%$ Resources:msgcolRemoveAllTitle %>"
                                                                        Html="<%$ Resources:msgcolRemoveAllDescription %>" />
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
                            <ext:LayoutColumn ColumnWidth="0.33">
                                <ext:GridPanel runat="server" ID="GridPanel2" Title="<%$ Resources:msgFormAssignedApplcations %>"
                                    Frame="true" EnableDragDrop="false" StoreID="storeAssigned" AutoExpandColumn="columnName"
                                    AutoScroll="true">
                                    <Listeners>
                                    </Listeners>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="columnID" Header="ID" DataIndex="SystemApplicationID" Width="30" />
                                            <ext:Column ColumnID="columnName" Header="<%$ Resources:msgcolName %>" DataIndex="LocaLocalizationName" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true">
                                            <Listeners>
                                                <RowSelect Buffer="100" Handler="SelectApplication(this.getSelected(),#{TreePanel1});" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <SaveMask ShowMask="true" />
                                </ext:GridPanel>
                            </ext:LayoutColumn>
                            <ext:LayoutColumn ColumnWidth="0.33">
                                <ext:TreePanel ID="TreePanel1" runat="server" UseArrows="true" Title="菜单" AutoScroll="true"
                                    RootVisible="false" Frame="true">
                                    <Root>
                                        <ext:TreeNode Text="Composers" Expanded="true">
                                        </ext:TreeNode>
                                    </Root>
                                    <Listeners>
                                        <CheckChange Handler="checkNode(node,checked);" />
                                    </Listeners>
                                    <Buttons>
                                        <ext:Button ID="btnSaveMenus" runat="server" Text="保存菜单分配"
                                            Icon="Disk">
                                            <Listeners>
                                                <Click Handler="SaveMenus(#{TreePanel1},#{hidSelectAppID}.getValue());" />
                                            </Listeners>
                                        </ext:Button>
                                    </Buttons>
                                </ext:TreePanel>
                            </ext:LayoutColumn>
                        </Columns>
                    </ext:ColumnLayout>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSave" runat="server" Text="<%$ Resources : GlobalResource, msgSave  %>"
                        Icon="Disk">
                        <Listeners>
                            <Click Handler="btSave_Click(Ext.encode(#{GridPanel2}.getRowsValues(false)))" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="Button6" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
                        Icon="Cancel">
                        <Listeners>
                            <Click Handler="parent.CloseWinAssignedApplication();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Hidden ID="hidSelectAppID" runat="server">
    </ext:Hidden>
</asp:Content>
