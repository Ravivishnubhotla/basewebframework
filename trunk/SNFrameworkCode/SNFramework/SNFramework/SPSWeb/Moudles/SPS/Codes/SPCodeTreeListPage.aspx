<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPCodeTreeListPage.aspx.cs" Inherits="SPSWeb.Moudles.SPS.Codes.SPCodeTreeListPage" %>

<%@ Register Src="UCSPCodeAdd.ascx" TagName="UCSPCodeAdd" TagPrefix="uc1" %>
<%@ Register Src="UCSPCodeEdit.ascx" TagName="UCSPCodeEdit" TagPrefix="uc2" %>
<%@ Register Src="UCSPCodeView.ascx" TagName="UCSPCodeView" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cellClass
        {
            padding: 5px;
        }
    </style>
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="LoadTree('');"></DocumentReady>
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
    <ext:Store ID="storeAreaCountList" runat="server">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="AreaName" />
                    <ext:RecordField Name="LimitCount" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <script type="text/javascript">
        function showAddForm() {
              Ext.net.DirectMethods.UCSPCodeAdd.Show(
                {
                    failure: function(msg) {
                        Ext.Msg.alert('操作失败', msg,RefreshData);
                    },
                    eventMask: {
                        showMask: true,
                        msg: '处理中...'
                    }
                }              
            );
        }


        function LoadTree(searchfilters) {
            Ext.net.DirectMethods.GetTreeNodes(searchfilters,
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
        

 
        var RefreshData = function(btn) {
            var pnl = <%= this.Panel2.ClientID %>;
            LoadTree(Ext.encode(pnl.getForm().getFieldValues(false, 'dataIndex')));
        };

        function showEditCode(id) {
            Ext.net.DirectMethods.UCSPCodeEdit.Show(id,
                {
                    failure: function(msg) {
                        Ext.Msg.alert('操作失败', msg,RefreshData);
                    },
                    eventMask: {
                        showMask: true,
                        msg: '处理中...'
                    }
                }              
            );
        }
            
        function showViewCode(id) {
            Ext.net.DirectMethods.UCSPCodeView.Show(id,
                {
                    failure: function(msg) {
                        Ext.Msg.alert('操作失败', msg,RefreshData);
                    },
                    eventMask: {
                        showMask: true,
                        msg: '处理中...'
                    }
                }              
            );
        }
            
        function showSendTest(id,cname,cid) {
            //                alert(id);
            //                alert(cname);
            //                alert(cid);
            //                return;
            var win = <%= this.winSendTestRequestForm.ClientID %>;
                

            win.setTitle(' 通道 ' + cname + '  发送模拟数据 ');
                
            win.autoLoad.url = '../Channels/SPChannelSendTestRequestForm.aspx';
                
            win.autoLoad.params.ChannelID = cid;
        
            win.autoLoad.params.CodeID = id;		                
            			                
            win.show(); 
        } 
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc1:UCSPCodeAdd ID="UCSPCodeAdd1" runat="server" />
   <%-- <uc2:UCSPCodeEdit ID="UCSPCodeEdit1" runat="server" />
    <uc3:UCSPCodeView ID="UCSPCodeView1" runat="server" />--%>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Items>
                    <ext:Panel ID="Panel1" Region="North" runat="server" Padding="2" Title="指令代码管理" Height="120"
                        Frame="True">
                        <TopBar>
                            <ext:Toolbar ID="tbTop" runat="server">
                                <Items>
                                    <ext:Button ID='btnAdd' runat="server" Text="添加" Icon="Add">
                                        <Listeners>
                                            <Click Handler="showAddForm();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID='btnRefresh' runat="server" Text="刷新" Icon="Reload">
                                        <Listeners>
                                            <Click Handler="LoadTree(Ext.encode(#{Panel2}.getForm().getFieldValues(false, 'dataIndex')));" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="False" Title="查询条件" AutoHeight="True"
                                Collapsed="False" LabelWidth="75" Layout="Form">
                                <Items>
                                    <ext:FormPanel ID="Panel2" runat="server" AnchorHorizontal="100%" Layout="HBoxLayout">
                                        <Defaults>
                                            <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                                        </Defaults>
                                        <Items>
                                            <ext:ComboBox ID="cmbChannel" FieldLabel="选择通道" LabelWidth="55" Width="180" runat="server"
                                                StoreID="storeSPChannel" ListWidth="200" Editable="True" MinChars="1" DisplayField="Name"
                                                ValueField="Id" EmptyText="选择通道" DataIndex="ChannelID">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();" />
                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ComboBox ID="cmbClient" runat="server" FieldLabel="选择客户" LabelWidth="55" Width="180"
                                                StoreID="storeSPClient" ListWidth="200" Editable="True" MinChars="1" DisplayField="Name"
                                                ValueField="Id" EmptyText="选择客户" DataIndex="ClientID">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();" />
                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:TextField ID="txtMo" runat="server" FieldLabel="指令" LabelWidth="50" Width="120"
                                                DataIndex="Mo" />
                                            <ext:TextField ID="txtSpNumber" runat="server" FieldLabel="端口号" LabelWidth="50" Width="120"
                                                DataIndex="SpNumber" />
                                            <ext:Button ID="Button5" runat="server" Text="搜索">
                                                <Listeners>
                                                    <Click Handler="LoadTree(Ext.encode(#{Panel2}.getForm().getFieldValues(false, 'dataIndex')));">
                                                    </Click>
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:FormPanel>
                                </Items>
                            </ext:FieldSet>
                        </Items>
                    </ext:Panel>
                    <ext:TreeGrid ID="TreeGrid1" Region="Center" runat="server" Header="False" NoLeafIcon="true"
                        EnableDD="true">
                        <Columns>
                            <ext:TreeGridColumn Header="指令代码" Width="230" DataIndex="MoCode" />
                            <ext:TreeGridColumn Header="所属通道" Width="100" DataIndex="ChannelName" />
                            <ext:TreeGridColumn Header="分配下家" Width="100" DataIndex="AssignedClientName" Align="Center">                          
                            </ext:TreeGridColumn>
                            <ext:TreeGridColumn Header="扣率" Width="50" DataIndex="InterceptRate" />
                            <ext:TreeGridColumn Header="禁用" Width="50" DataIndex="Disable" />
                            <ext:TreeGridColumn Header="管理" Width="100" Align="Center">
                                <XTemplate ID="XTemplate1" runat="server">
                                    <Html>
                                        <a href="#" title="编辑" onclick="showEditCode('{CodeID}');"><img src="../Images/application_edit.png"></img></a>
                                        &nbsp;
                                        <a href="#" title="删除" onclick="alert('Node id - {CodeID}')"><img src="../Images/application_delete.png"></img></a>
                                        &nbsp;
                                        <a href="#" title="查看" onclick="showViewCode('{CodeID}');"><img src="../Images/application_view_detail.png"></img></a>
                                        &nbsp;
                                        <a href="#" title="测试" onclick="showSendTest('{CodeID}','{ChannelName}','{ChannelID}');"><img src="../Images/telephone_go.png"></img></a>
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
    <ext:Window ID="winSendTestRequestForm" runat="server" Title="通道模拟数据测试" Frame="true"
        Width="640" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true" AutoScroll="true">
        <AutoLoad Url="../Channels/SPChannelSendTestRequestForm.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="CodeID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
