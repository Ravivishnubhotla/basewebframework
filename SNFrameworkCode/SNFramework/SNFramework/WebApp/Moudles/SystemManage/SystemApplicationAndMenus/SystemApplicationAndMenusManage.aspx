<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemApplicationAndMenusManage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus.SystemApplicationAndMenusManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:Panel ID="Panel2" runat="server" Title="系统应用管理" Region="West" Layout="FitLayout"
                Width="300" Split="true">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Title="Settings" Frame="true" Icon="ApplicationOsxCascade"
                        Layout="fit">
                        <Items>
                            <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" Title="Array Grid"
                                Width="600" Height="290" AutoExpandColumn="Company">
                                <Store>
                                    <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
                                        <Reader>
                                            <ext:ArrayReader>
                                                <Fields>
                                                    <ext:RecordField Name="company" />
                                                    <ext:RecordField Name="price" Type="Float" />
                                                    <ext:RecordField Name="change" Type="Float" />
                                                    <ext:RecordField Name="pctChange" Type="Float" />
                                                    <ext:RecordField Name="lastChange" Type="Date" />
                                                </Fields>
                                            </ext:ArrayReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn />
                                        <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="company" />
                                        <ext:Column Header="Price" Width="75" DataIndex="price">
                                            <Renderer Format="UsMoney" />
                                        </ext:Column>
                                        <ext:Column Header="Change" Width="75" DataIndex="change">
                                            <Renderer Fn="change" />
                                        </ext:Column>
                                        <ext:Column Header="Change" Width="75" DataIndex="pctChange">
                                            <Renderer Fn="pctChange" />
                                        </ext:Column>
                                        <ext:DateColumn Header="Last Updated" Width="85" DataIndex="lastChange" Format="H:mm:ss" />
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="1" />
                                                    <ext:ListItem Text="2" />
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Panel>
            <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                <Items>
                    <ext:Panel ID="Panel5" runat="server" Title="菜单管理" Border="false" Padding="6" Html="<h1>Viewport with BorderLayout</h1>" />
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
