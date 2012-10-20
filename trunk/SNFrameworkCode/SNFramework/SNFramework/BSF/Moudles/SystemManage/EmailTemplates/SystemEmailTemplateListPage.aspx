<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SystemEmailTemplateListPage.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.EmailTemplates.SystemEmailTemplateListPage" %>

<%@ Register Src="UCSystemEmailTemplateAdd.ascx" TagName="UCSystemEmailTemplateAdd"
    TagPrefix="uc1" %>
<%@ Register Src="UCSystemEmailTemplateEdit.ascx" TagName="UCSystemEmailTemplateEdit"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ScriptManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
    <script type="text/javascript">
        var rooturl ='<%=this.ResolveUrl("~/")%>';

        var FormatBool = function(value) {
            if (value)
                return '<%= GetGlobalResourceObject("GlobalResource","msgTrue").ToString() %>';
            else
                return '<%= GetGlobalResourceObject("GlobalResource","msgFalse").ToString() %>';
        };


        var RefreshData = function(btn) {
            <%= this.storeSystemEmailTemplate.ClientID %>.reload();
        };
        
        function showAddForm() {
                Ext.net.DirectMethods.UCSystemEmailTemplateAdd.Show( 
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                });    
        
        }

        function processcmd(cmd, id) {

            if (cmd == "cmdEdit") {
                Ext.net.DirectMethods.UCSystemEmailTemplateEdit.Show(id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg,RefreshData);
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }              
                );
            }
			
 

            if (cmd == "cmdDelete") {
                Ext.MessageBox.confirm('<%= GetGlobalResourceObject("GlobalResource","msgWarning").ToString() %>','<%= GetGlobalResourceObject("GlobalResource","msgDeleteWarning").ToString() %>',
                    function(e) {
                        if (e == 'yes')
                            Ext.net.DirectMethods.DeleteRecord(
                                                                id.id,
                                                                {
                                                                    failure: function(msg) {
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpFailed").ToString() %>', msg);
                                                                    },
                                                                    success: function(result) { 
                                                                        Ext.Msg.alert('<%= GetGlobalResourceObject("GlobalResource","msgOpSuccessful").ToString() %>', '<%= GetGlobalResourceObject("GlobalResource","msgDeleteSuccessful").ToString() %>',RefreshData);               
                                                                    },
                                                                    eventMask: {
                                                                                showMask: true,
                                                                                msg: '<%= GetGlobalResourceObject("GlobalResource","msgProcessing").ToString() %>'
                                                                               }
                                                                }
                                                            );
                    }
                    );
            }
        }

    </script>
    <ext:Store ID="storeSystemEmailTemplate" runat="server" AutoLoad="true" RemoteSort="true"
        RemotePaging="true" OnRefreshData="storeSystemEmailTemplate_Refresh">
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="limit" Value="8" Mode="Raw" />
        </AutoLoadParams>
        <Proxy>
            <ext:PageProxy />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="EmailTemplateID">
                <Fields>
                    <ext:RecordField Name="EmailTemplateID" Type="int" />
                    <ext:RecordField Name="Name" />
                    <ext:RecordField Name="Code" />
                    <ext:RecordField Name="Description" />
                    <ext:RecordField Name="TemplateType" />
                    <ext:RecordField Name="TitleTemplate" />
                    <ext:RecordField Name="IsHtmlEmail" Type="Boolean" />
                    <ext:RecordField Name="IsEnable" Type="Boolean" />
                    <ext:RecordField Name="CreateDate" Type="Date" />
                    <ext:RecordField Name="CreateBy" Type="int" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCSystemEmailTemplateAdd ID="UCSystemEmailTemplateAdd1" runat="server" />
    <uc2:UCSystemEmailTemplateEdit ID="UCSystemEmailTemplateEdit1" runat="server" />
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridPanelSystemEmailTemplate" runat="server" StoreID="storeSystemEmailTemplate"
                StripeRows="true" Title="<%$ Resources:msgGridTitle %>" Icon="Table">
                <TopBar>
                    <ext:Toolbar ID="tbTop" runat="server">
                        <Items>
                            <ext:Button ID='btnAdd' runat="server" Text="<%$ Resources : GlobalResource, msgAdd  %>"
                                Icon="Add">
                                <Listeners>
                                    <Click Handler="showAddForm();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID='btnRefresh' runat="server" Text="<%$ Resources : GlobalResource, msgRefresh  %>"
                                Icon="Reload">
                                <Listeners>
                                    <Click Handler="#{storeSystemEmailTemplate}.reload();" />
                                </Listeners>
                            </ext:Button>
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
                        <ext:Column ColumnID="colEmailTemplateID" DataIndex="EmailTemplateID" Header="<%$ Resources:msgcolEmailTemplateID %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colName" DataIndex="Name" Header="<%$ Resources:msgcolName %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colCode" DataIndex="Code" Header="<%$ Resources:msgcolCode %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colDescription" DataIndex="Description" Header="<%$ Resources:msgcolDescription %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colTemplateType" DataIndex="TemplateType" Header="<%$ Resources:msgcolTemplateType %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colTitleTemplate" DataIndex="TitleTemplate" Header="<%$ Resources:msgcolTitleTemplate %>"
                            Sortable="true">
                        </ext:Column>
                        <ext:Column ColumnID="colIsHtmlEmail" DataIndex="IsHtmlEmail" Header="<%$ Resources:msgcolIsHtmlEmail %>"
                            Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:Column ColumnID="colIsEnable" DataIndex="IsEnable" Header="<%$ Resources:msgcolIsEnable %>"
                            Sortable="true">
                            <Renderer Fn="FormatBool" />
                        </ext:Column>
                        <ext:CommandColumn ColumnID="colManage" Header="<%$ Resources : GlobalResource, msgManage  %>"
                            Width="80">
                            <Commands>
                                <ext:SplitCommand Text="<%$ Resources : GlobalResource, msgAction  %>" ToolTip-Text="<%$ Resources : GlobalResource, msgDataAction  %>">
                                    <Menu>
                                        <Items>
                                            <ext:MenuCommand Icon="ApplicationEdit" CommandName="cmdEdit" Text="<%$ Resources : GlobalResource, msgEdit  %>">
                                            </ext:MenuCommand>
                                            <ext:MenuCommand Icon="ApplicationDelete" CommandName="cmdDelete" Text="<%$ Resources : GlobalResource, msgDelete  %>">
                                            </ext:MenuCommand>
                                        </Items>
                                    </Menu>
                                </ext:SplitCommand>
                            </Commands>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="8" StoreID="storeSystemEmailTemplate"
                        DisplayInfo="true" DisplayMsg="<%$ Resources : GlobalResource, msgPageInfo  %>"
                        EmptyMsg="<%$ Resources : GlobalResource, msgNoRecordInfo  %>" />
                </BottomBar>
                <Listeners>
                    <Command Handler="processcmd(command, record);" />
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
