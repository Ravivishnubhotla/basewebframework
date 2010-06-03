<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemRoleAssignedMenu.ascx.cs"
    Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.UCSystemRoleAssignedMenu" %>
<ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
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
<ext:Window ID="winSystemRoleAssignedMenu" runat="server" Icon="Add" Title="assign apply"
    Width="500" Height="300" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:TreePanel ID="TreePanel1" runat="server" Height="300" Width="250" UseArrows="true"
            AutoScroll="true" Animate="true" EnableDD="true" ContainerScroll="true">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Label ID="lblApp" runat="server" Text="select system application: "></ext:Label>
                        <ext:ComboBox ID="cbApplication" runat="server" EmptyText="select system application" 
                            AutoWidth="true" Editable="false" TypeAhead="true" StoreID="storeSystemApplication"
                            DisplayField="SystemApplicationName" ValueField="SystemApplicationID" ForceSelection="true"
                            SelectOnFocus="true">
                            <Listeners>
                                <Select Handler="cb_SelectChanged(#{TreePanel1},this,record, index);" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
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
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSystemRoleAssignedMenu" runat="server" Text="Save" Icon="ApplicationGo">
            <Listeners>
                <Click Handler="btn_Save(#{TreePanel1},#{winSystemRoleAssignedMenu})" />
            </Listeners>
        </ext:Button>
        <ext:Button ID="btnCancelSystemRoleAssignedMenu" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemRoleAssignedMenu}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Show Handler="#{storeSystemApplication}.reload();" />
    </Listeners>
</ext:Window>
<ext:Hidden ID="HiddenRoleID" runat="server">
</ext:Hidden>

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
    var app_id = "";
    function cb_SelectChanged(tree, combo, record, index) {
        app_id = record.data.SystemApplicationID;
        Ext.net.DirectMethods.UCSystemRoleAssignedMenu.GetMenuById(app_id,
                                                    {
                                                        failure: function(msg) {
                                                            Ext.Msg.alert('Operation failed', msg);
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
                                                            msg: 'Processing...'
                                                        }
                                                    }
                                                );
    }
    function btn_Save(tree, win) {
        Ext.net.DirectMethods.UCSystemRoleAssignedMenu.btnSaveRole(
                                                     app_id, getParas(tree),
                                                    {
                                                        failure: function(msg) {
                                                            Ext.Msg.alert('Operation failed', msg);
                                                        },
                                                        success: function(result) {
                                                            Ext.MessageBox.alert('Operation successful', 'Success Added System Role ', callback);
                                                            function callback(id) {
                                                                debugger;
                                                            };
                                                        },
                                                        eventMask:
                                                        {
                                                            showMask: true,
                                                            msg: 'Processing...'
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

