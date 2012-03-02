<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DefaultClientRecordView.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.RecordViews.DefaultClientRecordView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPClient}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Hidden ID="hidId" runat="server">
    </ext:Hidden>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="false"  OnRefreshData="storeSPClient_Refresh">
        <Reader>
            <ext:JsonReader  ReaderID="Id" >
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="store1" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="store1_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="MobileNumber" />
                    <ext:RecordField Name="RequestContent" />
                    <ext:RecordField Name="Values" />
                    <ext:RecordField Name="Linkid" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="SSycnDataUrl" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                    <ext:RecordField Name="ChannelName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="即时统计" Icon="Table" AutoExpandColumn="colRequestContent">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="默认下家">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbClientID" runat="server" AllowBlank="true" StoreID="storeSPClient"
                                        TypeAhead="true" Mode="Local" TriggerAction="All" DisplayField="Name" ValueField="Id"
                                        EmptyText="全部">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ToolbarTextItem Text="日期从">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfStartDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ToolbarTextItem Text="到">
                                    </ext:ToolbarTextItem>
                                    <ext:DateFieldMenuItem ID="dfEndDate" runat="server">
                                    </ext:DateFieldMenuItem>
                                    <ext:ComboBox ID="cmbParamsMappingName" Editable="false" runat="server" AllowBlank="True"
                                        SelectedIndex="6" Width="110">
                                        <Items>
                                            <ext:ListItem Value="cpid" Text="cpid"></ext:ListItem>
                                            <ext:ListItem Value="mid" Text="mid"></ext:ListItem>
                                            <ext:ListItem Value="mobile" Text="mobile"></ext:ListItem>
                                            <ext:ListItem Value="port" Text="port"></ext:ListItem>
                                            <ext:ListItem Value="linkid" Text="linkid"></ext:ListItem>
                                            <ext:ListItem Value="dest" Text="dest"></ext:ListItem>
                                            <ext:ListItem Value="ywid" Text="ywid"></ext:ListItem>
                                            <ext:ListItem Value="msg" Text="msg"></ext:ListItem>
                                            <ext:ListItem Value="price" Text="price"></ext:ListItem>
                                            <ext:ListItem Value="extendfield1" Text="extendfield1"></ext:ListItem>
                                            <ext:ListItem Value="extendfield2" Text="extendfield2"></ext:ListItem>
                                            <ext:ListItem Value="extendfield3" Text="extendfield3"></ext:ListItem>
                                            <ext:ListItem Value="extendfield4" Text="extendfield4"></ext:ListItem>
                                            <ext:ListItem Value="extendfield5" Text="extendfield5"></ext:ListItem>
                                            <ext:ListItem Value="extendfield6" Text="extendfield6"></ext:ListItem>
                                            <ext:ListItem Value="extendfield7" Text="extendfield7"></ext:ListItem>
                                            <ext:ListItem Value="extendfield8" Text="extendfield8"></ext:ListItem>
                                            <ext:ListItem Value="extendfield9" Text="extendfield9"></ext:ListItem>
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cmbSearchType" Editable="false" runat="server" AllowBlank="True"
                                        SelectedIndex="0" Width="60">
                                        <Items>
                                            <ext:ListItem Value="0" Text="模糊"></ext:ListItem>
                                            <ext:ListItem Value="1" Text="精准"></ext:ListItem>
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:TextField ID="txtUrl" runat="server" AllowBlank="true" Width="90">
                                    </ext:TextField>
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{Store1}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
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
                                <ext:Column ColumnID="colChannelName" DataIndex="ChannelName" Header="通道" Sortable="true"
                                    Width="20">
                                </ext:Column>
                                <ext:Column ColumnID="colReportDate" DataIndex="MobileNumber" Header="手机号" Sortable="true"
                                    Width="20">
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Linkid" Header="LinkID" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Province" Header="省份" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="日期" Sortable="true"
                                    Width="20">
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                        </SelectionModel>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="30" StoreID="store1"
                                DisplayInfo="true" DisplayMsg="显示记录 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的记录" />
                        </BottomBar>
                        <Plugins>
                            <ext:RowExpander ID="RowExpander1" runat="server" Collapsed="true">
                                <Template ID="Template1" runat="server">
                    <br />
                        <b>所有参数：</b> {Values}  <br />

                        <b>同步链接：</b> {SSycnDataUrl}

                                </Template>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
