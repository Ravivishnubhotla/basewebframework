<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="AddAddress.aspx.cs" Inherits="GmapApplication.LocationApp.AddAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
 
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

         function ShowAddress(address) {
            var pnlMap = <%= pnlMap.ClientID %>;
            pnlMap.getBody().CheckAddress(address);
         }

         function ShowlatLng(latLng,lat,lng){
            var txtLongitude = <%= txtLongitude.ClientID %>;
            var txtLatitude = <%= txtLatitude.ClientID %>;
            txtLongitude.setValue(lng);
            txtLatitude.setValue(lat);                   
         }


        function ShowFullAddress(lblShow) {
            var fullAddress = "";

            var txtCountry = <%= txtCountry.ClientID %>;
            var txtState = <%= txtState.ClientID %>;
            var txtCity = <%= txtCity.ClientID %>;
            var txtZipCode = <%= txtZipCode.ClientID %>;
            var txtAddress1 = <%= txtAddress1.ClientID %>;
            var txtAddress2 = <%= txtAddress2.ClientID %>;

            //1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA

            var fullAddress = '{0} {1},{2},{3} {4},{5}';

            fullAddress = String.format(fullAddress, txtAddress1.getValue(), txtAddress2.getValue(), txtCity.getValue(), txtState.getValue(), txtZipCode.getValue(), txtCountry.getValue());

            lblShow.setValue(fullAddress);
        }

    </script>
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout runat="server">
                <West>
                    <ext:Panel ID="Panel1" runat="server" Title="Address Information" Width="500" Frame="true">
                        <Items>
                            <ext:FieldSet ID="FieldSet1" runat="server" Title="Base Information" Collapsed="false"
                                Layout="Form">
                                <Items>
                                    <ext:TextField ID="txtCountry" runat="server" FieldLabel="Country" Text="USA" AnchorHorizontal="100%">
                                        <Listeners>
                                            <Change Handler="ShowFullAddress(#{lblFullAddress});" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:TextField ID="txtState" runat="server" FieldLabel="State" AnchorHorizontal="100%">
                                        <Listeners>
                                            <Change Handler="ShowFullAddress(#{lblFullAddress});" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:TextField ID="txtCity" runat="server" FieldLabel="City" AnchorHorizontal="100%">
                                        <Listeners>
                                            <Change Handler="ShowFullAddress(#{lblFullAddress});" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:TextField ID="txtZipCode" runat="server" FieldLabel="ZipCode" AnchorHorizontal="100%">
                                        <Listeners>
                                            <Change Handler="ShowFullAddress(#{lblFullAddress});" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:TextField ID="txtAddress1" runat="server" FieldLabel="Address1" AnchorHorizontal="100%">
                                        <Listeners>
                                            <Change Handler="ShowFullAddress(#{lblFullAddress});" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:TextField ID="txtAddress2" runat="server" FieldLabel="Address2" AnchorHorizontal="100%">
                                        <Listeners>
                                            <Change Handler="ShowFullAddress(#{lblFullAddress});" />
                                        </Listeners>
                                    </ext:TextField>
                                    <ext:DisplayField ID="lblFullAddress" runat="server" FieldLabel="Full Address" AnchorHorizontal="100%" />
                                    <ext:Button FieldLabel="Check Address" ID="btnCheck" runat="server" Text="Check">
                                        <Listeners>
                                            <Click Handler="ShowAddress(#{txtAddress1}.getValue());" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:FieldSet>
                            <ext:FieldSet ID="FieldSet3" runat="server" Title="Geo Results" Collapsed="false"
                                Layout="Form">
                                <Items>
                                    <ext:GridPanel ID="grdFindPath" runat="server" StripeRows="true" Height="150" AnchorHorizontal="98%"
                                        Title="Find Directions" StoreID="storeResult" AutoExpandColumn="colAddress" Frame="true">
                                        <ColumnModel ID="ColumnModel1" runat="server">
                                            <Columns>
                                                <ext:RowNumbererColumn />
                                                <ext:Column ColumnID="colAddress" Header="Address" DataIndex="Address" />
                                                <ext:Column ColumnID="colLongitude" Header="Longitude" DataIndex="Longitude" />
                                                <ext:Column ColumnID="colLatitude" Header="Latitude" DataIndex="Latitude" />
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                                <Listeners>
                                                    <RowSelect Handler="#{pnlMap}.getBody().ChooseOne(rowIndex);" />
                                                </Listeners>
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:FieldSet>
                            <ext:FieldSet ID="FieldSet2" runat="server" Title="Geo Information" Collapsed="false"
                                Layout="Form">
                                <Items>
                                    <ext:NumberField ID="txtLongitude" runat="server" MaxValue="180" MinValue="-180"
                                        DecimalPrecision="2" FieldLabel="Longitude" AnchorHorizontal="100%" />
                                    <ext:NumberField ID="txtLatitude" runat="server" MaxValue="90" MinValue="-90" DecimalPrecision="2"
                                        FieldLabel="Latitude" AnchorHorizontal="100%" />
                                </Items>
                            </ext:FieldSet>
                        </Items>
                        <Buttons>
                            <ext:Button ID="Button1" runat="server" Text="Save" />
                            <ext:Button ID="Button2" runat="server" Text="Cancel" />
                        </Buttons>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="pnlMap" runat="server" Title="Map" Frame="true">
                        <AutoLoad Url="LocatePlace.aspx" Mode="IFrame" ShowMask="true">
                        </AutoLoad>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winLocatePlace" runat="server" Title="Locate a place" Frame="true"
        Width="720" ConstrainHeader="true" Height="600" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true">
        <AutoLoad Url="LocatePlace.aspx" Mode="IFrame" NoCache="true" TriggerEvent="show"
            ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="Address" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
