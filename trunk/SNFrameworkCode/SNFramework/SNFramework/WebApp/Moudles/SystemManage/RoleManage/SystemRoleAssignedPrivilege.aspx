﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemRoleAssignedPrivilege.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage.SystemRoleAssignedPrivilege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server" />
    <ext:Store runat="server" ID="Store1" AutoLoad="true" OnRefreshData="Store1_OnRefreshData">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="id" Mapping="PrivilegeID" />
                    <ext:RecordField Name="name" Mapping="PrivilegeEnName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
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
    </ext:Store>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="Panel1" Title="System Application Assign" runat="server" Frame="true">
                <Items>
                    <ext:ColumnLayout ID="ColumnLayout1" runat="server" FitHeight="true">
                        <Columns>
                            <ext:LayoutColumn ColumnWidth="0.5">
                                <ext:GridPanel runat="server" ID="GridPanel1" EnableDragDrop="true" StoreID="Store1">
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="columnID" Header="ID" DataIndex="id" Width="30" />
                                            <ext:Column ColumnID="columnName" Header="Name" DataIndex="name" />
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
                                        <ext:Panel ID="Panel3" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                            AnchorVertical="40%" />
                                        <ext:Panel ID="Panel4" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                            Padding="5">
                                            <Items>
                                                <ext:Button ID="Button1" runat="server" Icon="ResultsetNext" StyleSpec="margin-bottom:2px;">
                                                    <Listeners>
                                                        <Click Handler="PrivilegeSelector.add(#{GridPanel1}, #{GridPanel2});" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip1" runat="server" Title="Add" Html="Add Selected Rows" />
                                                    </ToolTips>
                                                </ext:Button>
                                                <ext:Button ID="Button2" runat="server" Icon="ResultsetLast" StyleSpec="margin-bottom:2px;">
                                                    <Listeners>
                                                        <Click Handler="PrivilegeSelector.addAll(#{GridPanel1}, #{GridPanel2});" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip2" runat="server" Title="Add all" Html="Add All Rows" />
                                                    </ToolTips>
                                                </ext:Button>
                                                <ext:Button ID="Button3" runat="server" Icon="ResultsetPrevious" StyleSpec="margin-bottom:2px;">
                                                    <Listeners>
                                                        <Click Handler="PrivilegeSelector.remove(#{GridPanel1}, #{GridPanel2});" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip3" runat="server" Title="Remove" Html="Remove Selected Rows" />
                                                    </ToolTips>
                                                </ext:Button>
                                                <ext:Button ID="Button4" runat="server" Icon="ResultsetFirst" StyleSpec="margin-bottom:2px;">
                                                    <Listeners>
                                                        <Click Handler="PrivilegeSelector.removeAll(#{GridPanel1}, #{GridPanel2});" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip4" runat="server" Title="Remove all" Html="Remove All Rows" />
                                                    </ToolTips>
                                                </ext:Button>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:Panel>
                            </ext:LayoutColumn>
                            <ext:LayoutColumn ColumnWidth="0.5">
                                <ext:GridPanel runat="server" ID="GridPanel2" EnableDragDrop="false" AutoExpandColumn="columnID"
                                    StoreID="Store2">
                                    <Listeners>
                                    </Listeners>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="columnID" Header="ID" DataIndex="id"  Width="30" />
                                            <ext:Column ColumnID="columnName" Header="Name" DataIndex="name" />
                                        </Columns>
                                    </ColumnModel>
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
                    <ext:Button ID="btnSave" runat="server" Text="Save" Icon="Disk">
                        <Listeners>
                            <Click Handler="btSave_Click(Ext.encode(#{GridPanel2}.getRowsValues(false)))" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="Button6" runat="server" Text="Cancel" Icon="Cancel">
                        <Listeners>
                            <Click Handler="parent.CloseWinAssignedPermission();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Panel>
        </Items>
    </ext:Viewport>

    <script type="text/javascript">
            function Button5_Click(json,Window1)
            {
                Ext.net.DirectMethods.Save_RolePermission(json,
                            {
                               failure: function(msg) 
                               {
                                    Ext.Msg.alert('Operation failed', msg, null);
                               },
                               success: function(result) 
                               { 
                                    Ext.Msg.alert('Operation Successful', 'Save successful System Permission!', function(btn) { parent.CloseWinAssignedPermission(); });            
                               },
                               eventMask: 
                               {
                                   showMask: true,
                                   msg: 'Processing...'
                               }
                            }              
                );
         }
            
            var PrivilegeSelector = 
            {
                add: function(source, destination) {
                    source = source || GridPanel1;
                    destination = destination || GridPanel2;
                    if (source.hasSelection()) {
                        destination.store.add(source.selModel.getSelections());
                        source.deleteSelected();
                    }
                },
                addAll: function(source, destination) 
                {
                    source = source || GridPanel1;
                    destination = destination || GridPanel2;
                    destination.store.add(source.store.getRange());
                    source.store.removeAll();
                },
                addByName: function(name) 
                {
                    if (!Ext.isEmpty(name)) 
                    {
                        var GridPanel1= <%= GridPanel1.ClientID %>;
                        var GridPanel2= <%= GridPanel2.ClientID %>;
                        var result = Store1.query("Name", name);
                        if (!Ext.isEmpty(result.items)) {
                            GridPanel2.store.add(result.items[0]);
                            GridPanel1.store.remove(result.items[0]);
                        }
                    }
                },
                addByNames: function(name) 
                {
                    for (var i = 0; i < name.length; i++) {
                        this.addByName(name[i]);
                    }
                },
                remove: function(source, destination) 
                {
                    this.add(destination, source);
                },
                removeAll: function(source, destination) 
                {
                    this.addAll(destination, source);
                }
           };
    </script>

</asp:Content>
