<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="SPClientAddToGroup.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.SPClientAddToGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{storeSClienAdd}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <ext:Store ID="storeSClienAdd" runat="server" AutoLoad="false" OnRefreshData="storeSClienAdd_RefreshData">
        <Reader>
            <ext:JsonReader ReaderID="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
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
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="添加下家到下家组" AutoScroll="true">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:Label ID="lblClientGroupName" runat="server" FieldLabel="下家组" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:ComboBox ID="cmbClientID" runat="server" FieldLabel="选择下家" AllowBlank="False"
                                            StoreID="storeSClienAdd" TypeAhead="true" Mode="Local" ForceSelection="true"
                                            TriggerAction="All" DisplayField="Name" ValueField="Id" EmptyText="请选择通道" ValueNotFoundText="加载中..." />
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnSave" runat="server" Text="添加" Icon="Add">
                                <AjaxEvents>
                                    <Click Before="if(!#{FormPanel1}.getForm().isValid()) return false;" OnEvent="btnSave_Click"
                                        Success="Ext.MessageBox.alert('操作成功', '成功的添加了下家到下家组。',callback);function callback(id) {#{FormPanel1}.getForm().reset();parent.RefreshSPClientList();parent.CloseAddToSPClientGroup(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                        <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                                    </Click>
                                </AjaxEvents>
                            </ext:Button>
                            <ext:Button ID="btnCancel" runat="server" Text="取消" Icon="Cancel">
                                <Listeners>
                                    <Click Handler="parent.CloseAddToSPClientGroup();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    <ext:Hidden ID="hidClientGroupID" runat="server">
    </ext:Hidden>
</asp:Content>
