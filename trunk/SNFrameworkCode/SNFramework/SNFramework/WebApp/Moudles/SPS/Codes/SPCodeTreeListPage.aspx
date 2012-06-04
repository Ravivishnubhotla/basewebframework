<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPCodeTreeListPage.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SPS.Codes.SPCodeTreeListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="LoadTree();"></DocumentReady>
        </Listeners>
    </ext:ResourceManagerProxy>
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="True">
        <Proxy>
            <ext:HttpProxy Method="POST" Url="../Channels/SPChannelHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="Datas" IDProperty="Id" TotalProperty="Total">
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
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="true">
        <Proxy>
            <ext:HttpProxy Method="POST" Url="../Clients/SPClientHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="Datas" IDProperty="Id" TotalProperty="Total">
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
    <script type="text/javascript">
        function LoadTree() {
            Ext.net.DirectMethods.GetTreeNodes(
                                                '',
                                                {
                                                    failure: function (msg) {
                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                    },
                                                    success: function (result) {
                                                        var tree = <%= TreeGrid1.ClientID %>;
                                                        var nodes = eval(result);
                                                        if (nodes.length > 0) {
                                                            tree.initChildren(nodes);
                                                        }
                                                        else {
                                                            tree.getRootNode().removeChildren();
                                                        }

                                                    },
                                                    eventMask: {
                                                        showMask: true,
                                                        msg: '<%= GetGlobalResourceObject("GlobalResource","msgLoading").ToString() %>',
                                                        target: 'customtarget',
                                                        customTarget: '<%= TreeGrid1.ClientID %>.el'
                                                    }
                                                }
                                             );    
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Items>
                    <ext:Panel ID="Panel1" Region="North" runat="server" Padding="2" Title="指令代码管理" Height="120"
                        Frame="True">
                        <Items>
                            <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="False" Title="查询条件" AutoHeight="True"
                                Collapsed="False" LabelWidth="75" Layout="Form">
                                <Items>
                                    <ext:Panel ID="Panel2" runat="server" AnchorHorizontal="100%" Layout="HBoxLayout">
                                        <LayoutConfig>
                                            <ext:HBoxLayoutConfig Padding="10" />
                                        </LayoutConfig>
                                        <Defaults>
                                            <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                                        </Defaults>
                                        <Items>
                                            <ext:ComboBox ID="cmbChannel" FieldLabel="选择通道" LabelWidth="60" Width="180" runat="server"
                                                StoreID="storeSPChannel" ListWidth="200" Editable="True" MinChars="1" DisplayField="Name" ValueField="Id"
                                                EmptyText="选择通道">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();" />
                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ComboBox ID="cmbClient" runat="server" FieldLabel="选择客户" LabelWidth="60" Width="180" 
                                                StoreID="storeSPClient"  ListWidth="200" Editable="True" MinChars="1"  DisplayField="Name" ValueField="Id"
                                                EmptyText="选择客户">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();" />
                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:TextField ID="txtMo" runat="server" FieldLabel="指令" LabelWidth="60" Width="180" />
                                            <ext:TextField ID="txtSpNumber" runat="server" FieldLabel="端口号" LabelWidth="60" Width="180" />
                                            <ext:Button ID="Button5" runat="server" Text="搜索" OnClientClick="replace(#{pnlAlignStretchMax});" />
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:FieldSet>
                        </Items>
                    </ext:Panel>
                    <ext:TreeGrid ID="TreeGrid1" Region="Center" runat="server" Header="False" NoLeafIcon="true"
                        EnableDD="true">
                        <Columns>
                            <ext:TreeGridColumn Header="指令代码" Width="230" DataIndex="MoCode" />
                            <ext:TreeGridColumn Header="所属通道" Width="230" DataIndex="ChannelName" />
                            <ext:TreeGridColumn Header="分配下家" Width="100" DataIndex="AssignedClientName" Align="Center">
                            </ext:TreeGridColumn>
                            <ext:TreeGridColumn Header="禁用" Width="150" DataIndex="Disable" />
                            <ext:TreeGridColumn Header="管理" Width="150" Align="Center">
                                <XTemplate ID="XTemplate1" runat="server">
                                    <Html>
                                        <a href="#" title="编辑" onclick="alert('Node id - {id}')"><img src="../Images/application_edit.png"></img></a>
                                        &nbsp;
                                        <a href="#" title="删除" onclick="alert('Node id - {id}')"><img src="../Images/application_delete.png"></img></a>
                                        &nbsp;
                                        <a href="#" title="查看" onclick="alert('Node id - {id}')"><img src="../Images/application_view_detail.png"></img></a>
                                        &nbsp;
                                        <a href="#" title="测试" onclick="alert('Node id - {id}')"><img src="../Images/telephone_go.png"></img></a>
                                    </Html>
                                </XTemplate>
                            </ext:TreeGridColumn>
                        </Columns>
                        <Root>
                        </Root>
                    </ext:TreeGrid>
                </Items>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</asp:Content>
