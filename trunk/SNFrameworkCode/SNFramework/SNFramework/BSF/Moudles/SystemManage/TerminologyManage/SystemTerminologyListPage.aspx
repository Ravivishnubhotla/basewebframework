<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemTerminologyListPage.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.TerminologyManage.SystemTerminologyListPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        }


        var RefreshData = function(btn) {
            <%= this.storeSystemTerminology.ClientID %>.reload();
        };
 
    function getDirValues(grid) {
        var records = grid.store.modified, values = [];
        for (var i = 0; i < records.length; i++) {
            var dataR = grid.store.prepareRecord(records[i].data, records[i], {});
            if (!Ext.isEmptyObj(dataR)) {
                values.push(dataR);
            }
        }
        return values;
    }

    function PatchAdd() {
                                Ext.net.DirectMethods.PatchAdd(
                                                                '<%= this.TerminologyCode %>',
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        <%= this.storeSystemTerminology.ClientID %>.reload();           
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                                                            );      
    }


    </script>
    <ext:Store ID="storeSystemTerminology" runat="server" AutoLoad="true" OnRefreshData="storeSystemTerminology_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="LanguageType" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="Text" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemTerminology" runat="server" StoreID="storeSystemTerminology"
                StripeRows="true" Title="System PermissionManagement" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
                                Icon="Add">
                                <Listeners>
                                    <Click Handler="PatchAdd();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnSave' runat="server" Text="<%$ Resources : GlobalResource, msgSave  %>"
                                Icon="ApplicationEdit">
                                <DirectEvents>
                                    <Click OnEvent="Save_SystemTerminology" Failure="<%$ Resources : GlobalResource, msgShowError  %>"
                                        Success="#{storeSystemTerminology}.commitChanges();#{storeSystemTerminology}.reload();">
                                        <ExtraParams>
                                            <ext:Parameter Name="Values" Value="Ext.encode(getDirValues(#{gridPanelSystemTerminology}))"
                                                Mode="Raw" />
                                        </ExtraParams>
                                        <EventMask ShowMask="true" Msg="<%$ Resources : GlobalResource, msgSavingWaiting  %>" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>"
                                Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemTerminology}.reload();" />
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
                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="Code" Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colLanguageType" DataIndex="LanguageType" Header="Lang" Width="60"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colText" DataIndex="Text" Header="Text" Sortable="true">
                            <Editor>
                                <ext:TextField ID="txtText" runat="server" AllowBlank="false" />
                            </Editor>
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="Description"
                            Sortable="true">
                            <Editor>
                                <ext:TextField ID="txtDescription" runat="server" AllowBlank="false" />
                            </Editor>
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="20" StoreID="storeSystemTerminology"
                        DisplayInfo="true" DisplayMsg="Show Terminology {0} - {1} total {2}" EmptyMsg="No matched Terminology" />
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

