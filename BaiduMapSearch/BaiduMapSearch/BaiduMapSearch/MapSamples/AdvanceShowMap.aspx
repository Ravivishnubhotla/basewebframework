<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ExtMaster.Master" AutoEventWireup="true"
    CodeBehind="AdvanceShowMap.aspx.cs" Inherits="BaiduMapSearch.MapSamples.AdvanceShowMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeResult" runat="server" AutoLoad="false">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="Address">
                    </ext:RecordField>
                    <ext:RecordField Name="Longitude" Type="Float">
                    </ext:RecordField>
                    <ext:RecordField Name="Latitude" Type="Float">
                    </ext:RecordField>
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">
        function map_dragend(center) {
            <%= txtCenterLat.ClientID %>.setValue(center.lat);
            <%= txtCenterLng.ClientID %>.setValue(center.lng);
        }
        function map_tilesloaded(center) {
            <%= txtCenterLat.ClientID %>.setValue(center.lat);
            <%= txtCenterLng.ClientID %>.setValue(center.lng);
        }
        
    function ClearStore() {
        var storeResults = <%= storeResult.ClientID %>;
        storeResults.removeAll(false);
    }
    function StoreAddDirection(address,longitude,latitude) {
        var storeResults = <%= storeResult.ClientID %>;
        var DirectionItem = Ext.data.Record.create(
            [
                { name: "Address", type: "string" },
                { name: "Longitude", type: "float" },
                { name: "Latitude", type: "float" }
            ]);
        var record = new DirectionItem(
                {
                    ID: Ext.id(),
                    Address: address,
                    Longitude: longitude,
                    Latitude:latitude
                });
                
        storeResults.add(record); 
        storeResults.commitChanges(); 
    }
    
    function mapSearch(searchText) {
        
        <%= pnlMainMap.ClientID %>.getBody().Search(searchText,map_onSearchComplete); 
    }

    function map_onSearchComplete(results) {

        ClearStore();
        
        var rcount = results.getNumPois();

        var fpoint = null;
        
        if(rcount>0) {
            fpoint = results.getPoi(0).point;
        }

        for (var i = 0; i < rcount; i++) {
            <%= pnlMainMap.ClientID %>.getBody().addMarker(results.getPoi(i).point,i);
            StoreAddDirection(results.getPoi(i).title + "-" + results.getPoi(i).address, results.getPoi(i).point.lng, results.getPoi(i).point.lat);
        }
        
        if (fpoint !=null) {
            <%= pnlMainMap.ClientID %>.getBody().MoveTo(fpoint);
        }

    }
    
        function map_MoveTo(rowIndex) {
            var storeResults = <%= storeResult.ClientID %>;
            var rec = storeResults.getAt(rowIndex);
            
            if(rec!=null) {
                   //alert(rec.data);
                //alert(rec.get('Longitude'));

                    <%= pnlMainMap.ClientID %>.getBody().MoveToPoint(rec.get('Longitude'), rec.get('Latitude'));     
            }


        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" Height="105" Frame="true" Title="搜索"
                        Layout="Fit">
                        <Items>
                            <ext:TabPanel ID="tabSearch" runat="server" ActiveTabIndex="0" TabPosition="Bottom">
                                <Items>
                                    <ext:FormPanel ID="pnlSearch" runat="server" Title="搜索" Frame="true">
                                        <Items>
                                            <ext:CompositeField ID="cfSearch" runat="server" HideLabel="true" FieldLabel="搜索"
                                                AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:TextField ID="txtMapSearch" runat="server" Flex="1" />
                                                    <ext:Button ID="btnMapSearch" runat="server" Text="搜索" Width="60">
                                                        <Listeners>
                                                            <Click Handler="mapSearch(#{txtMapSearch}.getValue());"></Click>
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:FormPanel>
                                    <ext:FormPanel ID="Panel4" runat="server" Title="公交" Frame="true">
                                        <Items>
                                            <ext:CompositeField ID="CompositeField2" runat="server" HideLabel="true" FieldLabel="搜索"
                                                AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:TextField ID="TextField1" runat="server" Flex="1" />
                                                    <ext:Button ID="Button1" runat="server" Icon="ArrowSwitch" Width="30" />
                                                    <ext:TextField ID="TextField4" runat="server" Flex="1" />
                                                    <ext:Button ID="Button4" runat="server" Text="搜索" Width="60" />
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:FormPanel>
                                    <ext:FormPanel ID="Panel5" runat="server" Title="驾车" Frame="true">
                                        <Items>
                                            <ext:CompositeField ID="CompositeField3" runat="server" HideLabel="true" FieldLabel="搜索"
                                                AnchorHorizontal="100%">
                                                <Items>
                                                    <ext:TextField ID="TextField2" runat="server" Flex="1" />
                                                    <ext:Button ID="Button3" runat="server" Icon="ArrowSwitch" Width="30" />
                                                    <ext:TextField ID="TextField5" runat="server" Flex="1" />
                                                    <ext:Button ID="Button5" runat="server" Text="搜索" Width="60" />
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:FormPanel>
                                </Items>
                            </ext:TabPanel>
                        </Items>
                    </ext:Panel>
                </North>
                <Center>
                    <ext:Panel ID="pnlMainMap" runat="server" Title="地图" Frame="true" Layout="Fit">
                        <AutoLoad Url="BaiduMapShowPage.aspx" Mode="IFrame" ShowMask="true" />
                    </ext:Panel>
                </Center>
                <East Collapsible="true" Split="true">
                    <ext:Panel runat="server" ID="Panel1" Width="360" Frame="true" Title="详细信息">
                        <Items>
                            <ext:BorderLayout ID="bl" runat="server">
                                <North>
                                    <ext:Panel ID="pnlInfo" runat="server" AutoHeight="True" Title="信息" Frame="true"
                                        Layout="Form">
                                        <Items>
                                            <ext:DisplayField ID="txtCenterLat" runat="server" FieldLabel="地图中心经度" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="txtCenterLng" runat="server" FieldLabel="地图中心纬度" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Panel>
                                </North>
                                <Center>
                                    <ext:GridPanel ID="grdFindPath" runat="server" StripeRows="true" Height="150" AnchorHorizontal="98%"
                                        Title="查找结果" StoreID="storeResult" AutoExpandColumn="colAddress" Frame="true">
                                        <ColumnModel ID="ColumnModel1" runat="server">
                                            <Columns>
                                                <ext:Column ColumnID="colAddress" Header="地址列表" DataIndex="Address" Sortable="False" />
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                                <Listeners>
                                                    <RowSelect Handler="map_MoveTo(rowIndex);" />
                                                </Listeners>
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                        <BottomBar>
                                            <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                            </ext:PagingToolbar>
                                        </BottomBar> 
                                    </ext:GridPanel>
                                </Center>
                            </ext:BorderLayout>
                        </Items>
                    </ext:Panel>
                </East>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
