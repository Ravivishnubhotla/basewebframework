<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemRoleAssignedMenu.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.SystemRoleAssignedMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <ext:RecordField Name="SystemApplicationDescription" />
                    <ext:RecordField Name="SystemApplicationUrl" Type="String" />
                    <ext:RecordField Name="SystemApplicationIsSystemApplication" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="if(#{storeSystemApplication}.data.items.length>0) {#{cbApplication}.setValue(#{storeSystemApplication}.data.items[0].data.SystemApplicationID);cb_SelectChanged(#{TreePanel1},#{cbApplication},#{storeSystemApplication}.data.items[0], 0);}" />
        </Listeners>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="Panel1" Title="System Menu Assign" runat="server" Frame="true" Layout="fit">
                <Items>
                    <ext:TreePanel ID="TreePanel1" runat="server" UseArrows="true" AutoScroll="true"
                        Animate="true" EnableDD="true" Frame="true">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Label ID="lblApp" runat="server" Text="Select System Application: ">
                                    </ext:Label>
                                    <ext:ComboBox ID="cbApplication" runat="server" EmptyText="select system application"
                                        AutoWidth="true" Editable="false" TypeAhead="true" StoreID="storeSystemApplication"
                                        DisplayField="SystemApplicationName" ValueField="SystemApplicationID" ForceSelection="true"
                                        SelectOnFocus="true">
                                        <Listeners>
                                            <Select Handler="cb_SelectChanged(#{TreePanel1},this,record, index);" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="#{storeSystemApplication}.reload();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Listeners>
                            <CheckChange Handler="checkNode(node,checked);" />
                        </Listeners>
                    </ext:TreePanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSaveSystemRoleAssignedMenu" runat="server" Text="Save" Icon="ApplicationGo">
                        <Listeners>
                            <Click Handler="btn_Save(#{TreePanel1},#{winSystemRoleAssignedMenu},#{cbApplication})" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="btnCancelSystemRoleAssignedMenu" runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>" Icon="Cancel">
                        <Listeners>
                            <Click Handler="parent.CloseWinAssignedMenu();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Panel>
        </Items>
    </ext:Viewport>

    <script type="text/javascript">

        function checkNode(node, checked) {
            var nodes = node.childNodes;
            var l = nodes.length;
            if (l > 0) {
                for (var i = 0; i < l; i++) {
                    nodes[i].ui.toggleCheck(checked);
                }
            }
            else { }
        }
        function cb_SelectChanged(tree, combo, record, index) {
            var app_id = record.data.SystemApplicationID;
            Ext.net.DirectMethods.GetMenuById(app_id,
                                                               {
                                                                   failure: function(msg) {
                                                                       Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                   },
                                                                   success: function(result) {
                                                                       var nodes = eval(result);
                                                                       if (nodes.length > 0) {
                                                                           tree.initChildren(nodes);
                                                                       }
                                                                       else {
                                                                           tree.getRootNode().removeChildren();
                                                                       }
                                                                   },
                                                                   eventMask:
                                                               {
                                                                   showMask: true,
                                                                   msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                               }
                                                               }
                                                             );
        }
        function btn_Save(tree, win, cbapp) {
            Ext.net.DirectMethods.btnSaveRole(
                                                             cbapp.getValue(), getParas(tree),
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
                     arrys.push(node.attributes.qtip);
                 });
                 return arrys.toString();
             }
    
    
    </script>

</asp:Content>

