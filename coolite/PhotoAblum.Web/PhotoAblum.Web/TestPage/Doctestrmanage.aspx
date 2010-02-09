<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Masters/AdminMaster.Master"
    AutoEventWireup="true" CodeBehind="Doctestrmanage.aspx.cs" Inherits="PhotoAblum.Web.TestPage.Doctestrmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .x-check-group-alt
        {
            background: #D1DDEF;
            border-top: 1px dotted #B5B8C8;
            border-bottom: 1px dotted #B5B8C8;
        }
    </style>

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function(value) {
            return String.format(template, (value > 0) ? 'green' : 'red', value);
        }

        var pctChange = function(value) {
            return String.format(template, (value > 0) ? 'green' : 'red', value + '%');
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ScriptManagerProxy>
    <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="company" />
                    <ext:RecordField Name="price" Type="Float" />
                    <ext:RecordField Name="change" Type="Float" />
                    <ext:RecordField Name="pctChange" Type="Float" />
                    <ext:RecordField Name="lastChange" Type="Date" DateFormat="Y-m-dTh:i:s" />
                </Fields>
            </ext:ArrayReader>
        </Reader>
    </ext:Store>
    <ext:ViewPort ID="ViewPort1" runat="server">
        <Body>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North Collapsible="True" Split="True">
                    <ext:Panel runat="server" ID="regionHeader" AutoHeight="true" Header="false">
                        <Body>
                            <div id="header" class="headerDiv">
                                <h1 class="headTitle">
                                    Hk document retieval system</h1>
                            </div>
                        </Body>
                        <BottomBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="Welcome">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblUser" Text="<b>System administrator</b>">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarSpacer>
                                    </ext:ToolbarSpacer>
                                    <ext:ToolbarTextItem ID="lblToday" Text="Today is 2008/1/1">
                                    </ext:ToolbarTextItem>
                                    <ext:ToolbarFill>
                                    </ext:ToolbarFill>
                                    <ext:Button Icon="UserEdit" Text="Personal Setting">
                                    </ext:Button>
                                    <ext:Button Icon="UserKey" Text="Change Password">
                                    </ext:Button>
                                    <ext:Button ID="btnExit" AutoPostBack="true" Icon="UserGo" Text="Logout">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </BottomBar>
                    </ext:Panel>
                </North>
                <South Collapsible="true" Split="true">
                    <ext:Panel runat="server" ID="regionFooter" AutoHeight="true" Border="true" Header="false"
                        BodyBorder="false">
                        <Body>
                            <div class="menu south">
                                @Telamon 2009</div>
                        </Body>
                    </ext:Panel>
                </South>
                <West Collapsible="true" Split="true">
                    <ext:Panel ID="Panel1" runat="server" Title="Document Retrieval" Width="230">
                        <Body>
                            <ext:FitLayout ID="FitLayout2" runat="server">
                                <Items>
                                    <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false">
                                        <Tabs>
                                            <ext:Tab runat="server" ID="Tab1" Frame="true" Closable="false" Title="Type Seach">
                                                <Body>
                                                    <ext:AnchorLayout ID="AnchorLayout1" runat="server">
                                                        <Anchors>
                                                            <ext:Anchor Horizontal="100%" Vertical="35%">
                                                                <ext:MultiSelect ID="MultiSelect1" runat="server" MultiSelect="false">
                                                                    <Items>
                                                                        <ext:ListItem Text="Invoice" Value="1" />
                                                                        <ext:ListItem Text="Statemnets" Value="2" />
                                                                        <ext:ListItem Text="Bill of lading" Value="3" />
                                                                        <ext:ListItem Text="Order ackonwlagement" Value="4" />
                                                                        <ext:ListItem Text="Item 5" Value="5" />
                                                                    </Items>
                                                                </ext:MultiSelect>
                                                            </ext:Anchor>
                                                            <ext:Anchor Horizontal="100%" Vertical="65%">
                                                                <ext:FormPanel ID="FormPanel1" runat="server" Title="Search Condition" MonitorValid="true"
                                                                    Frame="true" ButtonAlign="Right">
                                                                    <Body>
                                                                        <ext:FormLayout ID="FormLayout1" runat="server">
                                                                            <Anchors>
                                                                                <ext:Anchor Horizontal="95%">
                                                                                    <ext:TextField ID="TextField1" runat="server" FieldLabel="Label" />
                                                                                </ext:Anchor>
                                                                                <ext:Anchor Horizontal="95%">
                                                                                    <ext:TextField ID="TextField2" runat="server" FieldLabel="Label" />
                                                                                </ext:Anchor>
                                                                                <ext:Anchor Horizontal="95%">
                                                                                    <ext:NumberField ID="TextField3" runat="server" FieldLabel="Label">
                                                                                    </ext:NumberField>
                                                                                </ext:Anchor>
                                                                                <ext:Anchor Horizontal="95%">
                                                                                    <ext:DateField ID="NumberField1" runat="server" FieldLabel="Label">
                                                                                    </ext:DateField>
                                                                                </ext:Anchor>
                                                                            </Anchors>
                                                                        </ext:FormLayout>
                                                                    </Body>
                                                                    <Buttons>
                                                                        <ext:Button ID="btnSearch" runat="server" Text="Search">
                                                                        </ext:Button>
                                                                        <ext:Button ID="Button1" runat="server" Text="Reset">
                                                                        </ext:Button>
                                                                    </Buttons>
                                                                </ext:FormPanel>
                                                            </ext:Anchor>
                                                        </Anchors>
                                                    </ext:AnchorLayout>
                                                </Body>
                                            </ext:Tab>
                                            <ext:Tab runat="server" ID="Tab2" Frame="true" Closable="false" Title="Global Seach">
                                                <Body>
                                                    <ext:AnchorLayout ID="AnchorLayout2" runat="server">
                                                        <Anchors>
                                                            <ext:Anchor Horizontal="100%">
                                                                <ext:FormPanel ID="FormPanel2" runat="server" MonitorValid="true" Frame="true" ButtonAlign="Right">
                                                                    <Body>
                                                                        <ext:FormLayout ID="FormLayout2" runat="server">
                                                                            <Anchors>
                                                                                <ext:Anchor Horizontal="95%">
                                                                                    <ext:TextField ID="TextField4" runat="server" FieldLabel="Seach Value" />
                                                                                </ext:Anchor>
                                                                                <ext:Anchor Horizontal="95%">
                                                                                    <ext:RadioGroup ID="RadioGroup2" runat="server" ColumnsNumber="1" HideLabel="true">
                                                                                        <Items>
                                                                                            <ext:Radio ID="Radio9" runat="server" BoxLabel="All Keywords" Checked="true" />
                                                                                            <ext:Radio ID="Radio10" runat="server" BoxLabel="Order Number" />
                                                                                            <ext:Radio ID="Radio11" runat="server" BoxLabel="Ship Number" />
                                                                                            <ext:Radio ID="Radio1" runat="server" BoxLabel="Customer Name" />
                                                                                        </Items>
                                                                                    </ext:RadioGroup>
                                                                                </ext:Anchor>
                                                                            </Anchors>
                                                                        </ext:FormLayout>
                                                                    </Body>
                                                                    <Buttons>
                                                                        <ext:Button ID="Button2" runat="server" Text="Search">
                                                                        </ext:Button>
                                                                        <ext:Button ID="Button3" runat="server" Text="Reset">
                                                                        </ext:Button>
                                                                    </Buttons>
                                                                </ext:FormPanel>
                                                            </ext:Anchor>
                                                        </Anchors>
                                                    </ext:AnchorLayout>
                                                </Body>
                                            </ext:Tab>
                                        </Tabs>
                                    </ext:TabPanel>
                                </Items>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:Panel ID="Panel2" runat="server" Title="Main area">
                        <Body>
                            <ext:FitLayout ID="FitLayout1" runat="server">
                                <ext:TabPanel ID="MainTabs" runat="server" ActiveTabIndex="0" Border="false">
                                    <Tabs>
                                        <ext:Tab runat="server" ID="HomeTab" Closable="false" Title="Home">
                                            <Body>
                                                <ext:FitLayout ID="FitLayout3" runat="server">
                                                    <ext:GridPanel ID="GridPanel1" runat="server" StoreID="Store1" StripeRows="true"
                                                        Title="Array Grid" Width="600" Height="290" AutoExpandColumn="Company">
                                                        <ColumnModel ID="ColumnModel1" runat="server">
                                                            <Columns>
                                                                <ext:Column ColumnID="Company" Header="Company" Width="160" Sortable="true" DataIndex="company" />
                                                                <ext:Column Header="Price" Width="75" Sortable="true" DataIndex="price">
                                                                    <Renderer Format="UsMoney" />
                                                                </ext:Column>
                                                                <ext:Column Header="Change" Width="75" Sortable="true" DataIndex="change">
                                                                    <Renderer Fn="change" />
                                                                </ext:Column>
                                                                <ext:Column Header="Change" Width="75" Sortable="true" DataIndex="pctChange">
                                                                    <Renderer Fn="pctChange" />
                                                                </ext:Column>
                                                                <ext:Column Header="Last Updated" Width="85" Sortable="true" DataIndex="lastChange">
                                                                    <Renderer Fn="Ext.util.Format.dateRenderer('G:i:s')" />
                                                                </ext:Column>
                                                            </Columns>
                                                        </ColumnModel>
                                                        <SelectionModel>
                                                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                                                        </SelectionModel>
                                                        <LoadMask ShowMask="true" />
                                                        <BottomBar>
                                                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="10" StoreID="Store1" />
                                                        </BottomBar>
                                                        <Listeners>
                                                            <RowDblClick Handler="#{Window1}.show();" />
                                                        </Listeners>
                                                    </ext:GridPanel>
                                                </ext:FitLayout>
                                            </Body>
                                        </ext:Tab>
                                    </Tabs>
                                </ext:TabPanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
    <ext:Window ID="Window1" runat="server" Width="800" Height="600" Modal="true" Closable="true"
        Maximizable="true" Resizable="true" ShowOnLoad="false">
        <AutoLoad Mode="IFrame" Url="http://localhost:3658/TestPage/1.pdf" NoCache=true>
        </AutoLoad>
    </ext:Window>
</asp:Content>
