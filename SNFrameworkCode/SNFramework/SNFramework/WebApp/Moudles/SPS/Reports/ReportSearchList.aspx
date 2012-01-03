<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="ReportSearchList.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Reports.ReportSearchList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSPChannel}.reload();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="true" OnRefreshData="storeSPChannel_Refresh">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <DirectEventConfig>
            <EventMask ShowMask="true" />
        </DirectEventConfig>
    </ext:Store>
    <%--<p>Limitations of ajax file downloading: success/failure events don't fired. Therefore the mask is impossible.</p>--%>
    <ext:Store ID="storeData" runat="server" AutoLoad="true" RemoteSort="true" OnRefreshData="storeData_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="50" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" />
                    <ext:RecordField Name="LinkID" />
                    <ext:RecordField Name="Mobile" />
                    <ext:RecordField Name="Mo" />
                    <ext:RecordField Name="SpNumber" />
                    <ext:RecordField Name="Province" />
                    <ext:RecordField Name="City" />
                    <ext:RecordField Name="OperatorType" />
                    <ext:RecordField Name="IsStatOK" Type="Boolean" />
                    <ext:RecordField Name="IsIntercept" Type="Boolean" />
                    <ext:RecordField Name="IsSycnToClient" Type="Boolean" />
                    <ext:RecordField Name="IsSycnSuccessed" Type="Boolean" />
                    <ext:RecordField Name="SycnRetryTimes" Type="Int" />
                    <ext:RecordField Name="SycnDataUrl" />
                    <ext:RecordField Name="SycnReturnMessage" />
                    <ext:RecordField Name="Count" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                    <ext:RecordField Name="Count" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">


        var FormatBool = function (value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var FormatStat = function (value) {
            if (value)
                return '成功';
            else
                return '失败';
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="Fit">
        <Items>
            <ext:GridPanel ID="GridPanel1" Header="false" runat="server" StripeRows="true" TrackMouseOver="true"
                StoreID="storeData" AutoScroll="true">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:ComboBox ID="cmbChannel" LabelWidth="1" Width="120" runat="server" StoreID="storeSPChannel"
                                Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择通道" AllowBlank="false">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:ComboBox ID="cmbCode" runat="server" LabelWidth="1" Width="120" StoreID="storeSPChannel"
                                Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择代码" AllowBlank="false">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:ComboBox ID="cmbClient" runat="server" LabelWidth="1" Width="120" StoreID="storeSPChannel"
                                Editable="false" DisplayField="Name" ValueField="Id" EmptyText="选择客户" AllowBlank="false">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
 
                            <ext:Button ID='btnRefresh' runat="server" Text="搜索" Icon="Find">
                                <Listeners>
                                    <Click Handler="#{storeData}.reload();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnAdd' runat="server" Text="导出" Icon="PageExcel">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.submitData(false);" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="colCreateDate" DataIndex="CreateDate" Header="接收时间" Sortable="true"
                            Width="120">
                            <Renderer Fn="Ext.util.Format.dateRenderer('m/d/Y h:i:s')" />
                        </ext:Column>
                        <ext:Column ColumnID="colLinkID" DataIndex="LinkID" Header="唯一标识" Sortable="true"
                            Width="130">
                        </ext:Column>
                        <ext:Column ColumnID="colMobile" DataIndex="Mobile" Header="手机号码" Sortable="true"
                            Width="80">
                        </ext:Column>
                        <ext:Column ColumnID="colMo" DataIndex="Mo" Header="上行指令" Sortable="true" Width="90">
                        </ext:Column>
                        <ext:Column ColumnID="colSpNumber" DataIndex="SpNumber" Header="通道号码" Sortable="true"
                            Width="95">
                        </ext:Column>
                        <ext:Column ColumnID="colProvince" DataIndex="Province" Header="省份" Sortable="true"
                            Width="35">
                        </ext:Column>
                        <ext:Column ColumnID="colCity" DataIndex="City" Header="地市" Sortable="true" Width="35">
                        </ext:Column>
                        <ext:Column ColumnID="colOperatorType" DataIndex="OperatorType" Header="运营商" Sortable="true"
                            Width="45">
                        </ext:Column>
                        <ext:Column ColumnID="colIsStatOK" DataIndex="IsStatOK" Header="状态" Sortable="true"
                            Width="35">
                            <Renderer Fn="FormatStat" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsIntercept" DataIndex="IsIntercept" Header="扣除" Sortable="true"
                            Width="35">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsSycnToClient" DataIndex="IsSycnToClient" Header="同步" Sortable="true"
                            Width="35">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsSycnSuccessed" DataIndex="IsSycnSuccessed" Header="同步状态"
                            Sortable="true" Width="60">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colSycnRetryTimes" DataIndex="SycnRetryTimes" Header="重试" Sortable="true"
                            Width="35">
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <View>
                    <ext:GridView ID="GridView1" runat="server" />
                </View>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <Plugins>
                    <ext:RowExpander ID="RowExpander1" runat="server">
                        <Template ID="Template1" runat="server">
                            <Html>
                                <p>
                                    <b>同步地址:</b> {SycnDataUrl}
                                <br/><b>失败消息:</b> {SycnReturnMessage}</p>
                            </Html>
                        </Template>
                    </ext:RowExpander>
                </Plugins>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="50" DisplayInfo="true"
                        StoreID="storeData" DisplayMsg="显示记录 {0} - {1} 共: {2}" EmptyMsg="没有记录" />
                </BottomBar>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
