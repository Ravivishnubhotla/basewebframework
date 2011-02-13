<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="RecordSearch.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.RecordSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:Store ID="store1" runat="server" AutoLoad="false" RemoteSort="true" OnRefreshData="store1_Refresh">
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
                    <ext:RecordField Name="Ywid" />
                    <ext:RecordField Name="Cpid" />
                    <ext:RecordField Name="SSycnDataUrl" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:BorderLayout runat="server">
                <North CollapseMode="Default" Collapsible="true">
                    <ext:FormPanel ID="pnlSeach" runat="server" Title="检索条件" AutoScroll="true" Height="300" Frame=true>
                        <Body>
                            <ext:FormLayout ID="FormLayoutSPChannel" runat="server" LabelSeparator=":" LabelWidth="100">
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:ComboBox ID="cmbProvince" Editable="true" runat="server" AllowBlank="True" FieldLabel="省份" TriggerAction="All">
                                            <Items>
                                                <ext:ListItem Value="安徽" Text="安徽"></ext:ListItem>
                                                <ext:ListItem Value="北京" Text="北京"></ext:ListItem>
                                                <ext:ListItem Value="福建" Text="福建"></ext:ListItem>
                                                <ext:ListItem Value="甘肃" Text="甘肃"></ext:ListItem>
                                                <ext:ListItem Value="广东" Text="广东"></ext:ListItem>
                                                <ext:ListItem Value="广西" Text="广西"></ext:ListItem>
                                                <ext:ListItem Value="贵州" Text="贵州"></ext:ListItem>
                                                <ext:ListItem Value="海南" Text="海南"></ext:ListItem>
                                                <ext:ListItem Value="河北" Text="河北"></ext:ListItem>
                                                <ext:ListItem Value="河南" Text="河南"></ext:ListItem>
                                                <ext:ListItem Value="黑龙江" Text="黑龙江"></ext:ListItem>
                                                <ext:ListItem Value="湖北" Text="湖北"></ext:ListItem>
                                                <ext:ListItem Value="湖南" Text="湖南"></ext:ListItem>
                                                <ext:ListItem Value="吉林" Text="吉林"></ext:ListItem>
                                                <ext:ListItem Value="江苏" Text="江苏"></ext:ListItem>
                                                <ext:ListItem Value="江西" Text="江西"></ext:ListItem>
                                                <ext:ListItem Value="辽宁" Text="辽宁"></ext:ListItem>
                                                <ext:ListItem Value="内蒙古" Text="内蒙古"></ext:ListItem>
                                                <ext:ListItem Value="宁夏" Text="宁夏"></ext:ListItem>
                                                <ext:ListItem Value="青海" Text="青海"></ext:ListItem>
                                                <ext:ListItem Value="山东" Text="山东"></ext:ListItem>
                                                <ext:ListItem Value="陕西" Text="陕西"></ext:ListItem>
                                                <ext:ListItem Value="上海" Text="上海"></ext:ListItem>
                                                <ext:ListItem Value="四川" Text="四川"></ext:ListItem>
                                                <ext:ListItem Value="天津" Text="天津"></ext:ListItem>
                                                <ext:ListItem Value="西藏" Text="西藏"></ext:ListItem>
                                                <ext:ListItem Value="新疆" Text="新疆"></ext:ListItem>
                                                <ext:ListItem Value="云南" Text="云南"></ext:ListItem>
                                                <ext:ListItem Value="浙江" Text="浙江"></ext:ListItem>
                                                <ext:ListItem Value="重庆" Text="重庆"></ext:ListItem>
                                                <ext:ListItem Value="NULL" Text="未知地区"></ext:ListItem>
                                            </Items>
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                    </ext:FormPanel>
                </North>
                <Center>
                    <ext:GridPanel ID="gridPanelSPClientChannelSetting" runat="server" StoreID="store1"
                        StripeRows="true" Title="检索结果" Icon="Table" AutoExpandColumn="colRequestContent"
                        AutoScroll="true" AutoWidth=true>
                        <View>
                            <ext:GridView ID="GridView1">
                                <GetRowClass Handler="" FormatHandler="False"></GetRowClass>
                            </ext:GridView>
                        </View>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn>
                                </ext:RowNumbererColumn>
                                <ext:Column ColumnID="colReportDate" DataIndex="MobileNumber" Header="手机号" Sortable="true"
                                     >
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Linkid" Header="LinkID" Sortable="false">
                                </ext:Column>
                                <ext:Column ColumnID="colRequestContent" DataIndex="Province" Header="省份" Sortable="false"
                                    >
                                </ext:Column>
                                <ext:Column ColumnID="colYwid" DataIndex="Ywid" Header="上行内容" Sortable="false" >
                                </ext:Column>
                                <ext:Column ColumnID="colCpid" DataIndex="Cpid" Header="长号码" Sortable="false" >
                                </ext:Column>
                                <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="日期" Sortable="true"
                                     >
                                    <Renderer Fn="Ext.util.Format.dateRenderer('n/d/Y H:i:s A')" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" />
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
                </Center>
            </ext:BorderLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
