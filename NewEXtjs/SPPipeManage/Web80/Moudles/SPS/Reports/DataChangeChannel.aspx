<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DataChangeChannel.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Reports.DataChangeChannel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="storeData" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeData_Refresh"
        OnSubmitData="storeData_Submit">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
        </AutoLoadParams>
        <AjaxEventConfig IsUpload="true"  Timeout="120000" />
        <Proxy>
            <ext:DataSourceProxy />
        </Proxy>
    </ext:Store>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:GridPanel ID="GridPanel1" Header="false" runat="server" StripeRows="true" TrackMouseOver="true"
                        AutoScroll="true">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:ToolbarTextItem Text="省份:">
                                    </ext:ToolbarTextItem>
                                    <ext:ComboBox ID="cmbProvince" Editable="true" runat="server" AllowBlank="True" TriggerAction="All">
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
                                    <ext:ToolbarButton ID='btnRefresh' runat="server" Text="查询" Icon="Find">
                                        <Listeners>
                                            <Click Handler="#{storeData}.reload();" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                    <ext:ToolbarButton ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{GridPanel1}.submitData(false);" />
                                        </Listeners>
                                    </ext:ToolbarButton>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="ColumnModel1" runat="server">
                        </ColumnModel>
                        <View>
                            <ext:GridView ID="GridView1" runat="server" />
                        </View>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="30" DisplayInfo="true"
                                DisplayMsg="Displaying items {0} - {1} total: {2}" EmptyMsg="No items" />
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
