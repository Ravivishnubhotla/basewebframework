<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="DistanceQuery.aspx.cs" Inherits="GmapApplication.Distance.DistanceQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:Store ID="storeResult" runat="server" AutoLoad="false">
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="DistanceText">
                    </ext:RecordField>
                    <ext:RecordField Name="DurationText">
                    </ext:RecordField>
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">
    function ClearStore() {
        var storeResults = <%= storeResult.ClientID %>;
        storeResults.removeAll(false);
    }
    function StoreAddDirection(distanceText,durationText) {
        var storeResults = <%= storeResult.ClientID %>;
        var DirectionItem = Ext.data.Record.create(
            [
                { name: "ID", type: "string" },
                { name: "DistanceText", type: "string" },
                { name: "DurationText", type: "string" }
            ]);
        var record = new DirectionItem(
                {
                    ID: Ext.id(),
                    DistanceText: distanceText,
                    DurationText: durationText
                });
                
        storeResults.add(record); 
        storeResults.commitChanges(); 

 
    }

    function selectRowIndex(index)
    {
        var grdFindPath = <%= grdFindPath.ClientID %>;
        grdFindPath.getSelectionModel().selectRow(index);
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <West>
                    <ext:Panel ID="Panel2" runat="server" Title="Address Information" Width="350" Frame="true"
                        Layout="FitLayout">
                        <Items>
                            <ext:BorderLayout runat="server">
                                <North>
                                    <ext:Panel ID="Panel1" runat="server" Height="120" Title="Address Information" ButtonAlign="Right"
                                        Frame="true" Layout="FormLayout">
                                        <Items>
                                            <ext:TextField ID="txtStart" runat="server" FieldLabel="Start" Text="Elkhart, IN, US"
                                                AnchorHorizontal="95%">
                                            </ext:TextField>
                                            <ext:TextField ID="txtEnd" runat="server" FieldLabel="End" Text="Gary, IN, US" AnchorHorizontal="95%">
                                            </ext:TextField>
                                        </Items>
                                        <Buttons>
                                            <ext:Button ID="btnQuery" runat="server" Text="Query">
                                                <Listeners>
                                                    <Click Handler="#{pnlMap}.getBody().showRoute(#{txtStart}.getValue(),#{txtEnd}.getValue());" />
                                                </Listeners>
                                            </ext:Button>
                                        </Buttons>
                                    </ext:Panel>
                                </North>
                                <Center>
                                    <ext:GridPanel ID="grdFindPath" runat="server" StripeRows="true" Height="200" Title="Find Directions"
                                        StoreID="storeResult" Frame="true">
                                        <ColumnModel ID="ColumnModel1" runat="server">
                                            <Columns>
                                                <ext:RowNumbererColumn />
                                                <ext:Column ColumnID="colDistanceText" Header="Distance" DataIndex="DistanceText" />
                                                <ext:Column ColumnID="colDurationText" Header="Duration" DataIndex="DurationText" />
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                                <Listeners>
                                                    <RowSelect Handler="#{pnlMap}.getBody().setRoute(rowIndex);" />
                                                </Listeners>
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                    </ext:GridPanel>
                                </Center>
                            </ext:BorderLayout>
                        </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="pnlMap" runat="server" Title="Map" Frame="true">
                        <AutoLoad Url="ShowDirections.aspx" Mode="IFrame" ShowMask="true">
                        </AutoLoad>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
