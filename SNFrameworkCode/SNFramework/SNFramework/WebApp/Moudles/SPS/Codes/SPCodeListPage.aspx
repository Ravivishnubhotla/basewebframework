﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPCodeListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.SPCodeListPage" %>

<%@ Register Src="UCSPCodeAdd.ascx" TagName="UCSPCodeAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPCodeEdit.ascx" TagName="UCSPCodeEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPCodeView.ascx" TagName="UCSPCodeView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeMOType}.reload();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return 'true';
            else
                return 'false';
        }


        var RefreshData = function(btn) {
            <%= this.storeSPCode.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSPCodeAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSPCodeEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: 'Processing...'
                                                                               }
                                                                }              
                );
            }
			
			            if (cmd == "cmdView") {
                Ext.net.DirectMethods.UCSPCodeView.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg,RefreshData);
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
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('Operation failed', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('Operation successful', 'Delete a record success!',RefreshData);            
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

    <ext:Store ID="storeSPCode" runat="server" AutoLoad="true" RemoteSort="true" RemotePaging="true"
        OnRefreshData="storeSPCode_Refresh">
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
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="ChannelID" Type="int" />
                    <ext:RecordField Name="MO" />
                    <ext:RecordField Name="MOType" />
                    <ext:RecordField Name="OrderIndex" Type="int" />
                    <ext:RecordField Name="SPCode" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="DisableCity" />
                    <ext:RecordField Name="IsDiable" Type="Boolean" />
                    <ext:RecordField Name="SPType" />
                    <ext:RecordField Name="CodeLength" Type="int" />
                    <ext:RecordField Name="DayLimit" Type="int" />
                    <ext:RecordField Name="MonthLimit" Type="int" />
                    <ext:RecordField Name="Price" Type="int" />
                    <ext:RecordField Name="SendText" />
                    <ext:RecordField Name="HasFilters" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSPCodeAdd ID="UCSPCodeAdd1" runat="server" />
    <uc2:UCSPCodeEdit ID="UCSPCodeEdit1" runat="server" />
    <uc3:UCSPCodeView ID="UCSPCodeView1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSPCode" runat="server" StoreID="storeSPCode" StripeRows="true"
                Title="SPCode Management" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="Add" Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="Refresh" Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSPCode}.reload();" />
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
                        <ext:Column ColumnID="colID" DataIndex="ID" Header="ID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="Name" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="Description"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="Code" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colChannelID" DataIndex="ChannelID" Header="ChannelID" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colMO" DataIndex="MO" Header="MO" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colMOType" DataIndex="MOType" Header="MOType" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colOrderIndex" DataIndex="OrderIndex" Header="OrderIndex" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSPCode" DataIndex="SPCode" Header="SPCode" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colProvince" DataIndex="Province" Header="Province" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDisableCity" DataIndex="DisableCity" Header="DisableCity"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsDiable" DataIndex="IsDiable" Header="IsDiable" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colSPType" DataIndex="SPType" Header="SPType" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCodeLength" DataIndex="CodeLength" Header="CodeLength" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDayLimit" DataIndex="DayLimit" Header="DayLimit" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colMonthLimit" DataIndex="MonthLimit" Header="MonthLimit" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colPrice" DataIndex="Price" Header="Price" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colSendText" DataIndex="SendText" Header="SendText" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colHasFilters" DataIndex="HasFilters" Header="HasFilters" Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="Management" Width="60">
                            <Commands>
                                <ext:SplitCommand Text="Management" Icon="ApplicationEdit">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="Edit">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="Delete">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationViewDetail" CommandName="cmdView" Text="View">
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
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSPCode"
                        DisplayInfo="true" DisplayMsg="Display SPCodes {0} - {1} total {2}" EmptyMsg="No matched SPCode" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
