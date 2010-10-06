<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DataArchive.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.DataArchives.DataArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManager1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{dfStart}.setValue(#{dfEnd}.getValue());#{storeSPChannel}.reload();" />
        </Listeners>
    </ext:ScriptManagerProxy>
    <script type="text/javascript">
        function GetChannelID(cmb) {
            if (cmb == null) {
                return 0;
            }
            return cmb.getValue();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Store ID="storeSPChannel" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../Channels/SPChannelHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="channels" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Store ID="storeSPClient" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../Clients/SPClientHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="clients" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="Id" Type="int" Mapping="Id" />
                    <ext:RecordField Name="Name" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="ChannleID" Mode="Raw" Value="GetChannelID(#{cmbChannelID})">
            </ext:Parameter>
            <ext:Parameter Name="DataType" Mode="Value" Value="GetChannelSycnClient">
            </ext:Parameter>
        </BaseParams>
    </ext:Store>
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="高级数据管理">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:MultiField ID="MultiField2" runat="server" FieldLabel="手动生成报表">
                                            <Fields>
                                                <ext:Label ID="lblStart" runat="server" Text="开始时间：" />
                                                <ext:DateField ID="dfStart" runat="server" Vtype="daterange">
                                                    <Listeners>
                                                        <Render Handler="this.endDateField = '#{dfEnd}'" />
                                                    </Listeners>
                                                </ext:DateField>
                                                <ext:Label ID="Label4" runat="server" Text="结束时间：" />
                                                <ext:DateField ID="dfEnd" runat="server" Vtype="daterange">
                                                    <Listeners>
                                                        <Render Handler="this.startDateField = '#{dfStart}'" />
                                                    </Listeners>
                                                </ext:DateField>
                                                <ext:Button ID="btnArchive" runat="server" Text="开始生成报表">
                                                    <AjaxEvents>
                                                        <Click OnEvent="StartLongAction" Success="Ext.MessageBox.alert('操作成功', '成功的手动生成报表.',callback);function callback(id) {};">
                                                            <EventMask ShowMask="true" Msg="处理中..." />
                                                            <Confirmation ConfirmRequest="true" Message="确认进行手动生成报表？" Title="确认操作" />
                                                        </Click>
                                                    </AjaxEvents>
                                                </ext:Button>
                                            </Fields>
                                        </ext:MultiField>
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:MultiField ID="MultiField5" runat="server" FieldLabel="手动重发数据">
                                            <Fields>
                                                <ext:Label ID="lbl1" runat="server" Text="选择通道：" />
                                                <ext:ComboBox ID="cmbChannelID" runat="server" AllowBlank="False" StoreID="storeSPChannel"
                                                    Editable="false" TypeAhead="true" ForceSelection="true" TriggerAction="All" DisplayField="Name"
                                                    ValueField="Id">
                                                    <Listeners>
                                                        <Select Handler="#{cmbClientID}.clearValue(); #{storeSPClient}.reload();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:Label ID="Label5" runat="server" Text="选择下家：" />
                                                <ext:ComboBox ID="cmbClientID" runat="server" AllowBlank="False" StoreID="storeSPClient"
                                                    Editable="false" TypeAhead="true" ForceSelection="true" TriggerAction="All" DisplayField="Name"
                                                    ValueField="Id" />
                                                <ext:Label ID="Label1" runat="server" Text="开始时间：" />
                                                <ext:DateField ID="DateField1" runat="server" Vtype="daterange">
                                                </ext:DateField>
                                                <ext:Label ID="Label2" runat="server" Text="结束时间：" />
                                                <ext:DateField ID="DateField2" runat="server" Vtype="daterange">
                                                </ext:DateField>
                                                <ext:Button ID="Button1" runat="server" Text="开始重发数据">
                                                    <AjaxEvents>
                                                        <Click OnEvent="StartLongAction2" Success="Ext.MessageBox.alert('操作成功', '成功的重发数据.',callback);function callback(id) {};"
                                                            Timeout="10000000">
                                                            <EventMask ShowMask="true" Msg="处理中..." />
                                                            <Confirmation ConfirmRequest="true" Message="确认进行手动重发数据？" Title="确认操作" />
                                                        </Click>
                                                    </AjaxEvents>
                                                </ext:Button>
                                            </Fields>
                                        </ext:MultiField>
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="95%">
                                        <ext:MultiField ID="mfResendAll" runat="server" FieldLabel="手动重发所有数据">
                                            <Fields>
                                                <ext:Button ID="btnResendAll" runat="server" Text="开始重发数据">
                                                    <AjaxEvents>
                                                        <Click OnEvent="btnResendAll_Click" Success="Ext.MessageBox.alert('操作成功', '成功的重发数据.',callback);function callback(id) {};"
                                                            Timeout="10000000">
                                                            <EventMask ShowMask="true" Msg="处理中..." />
                                                            <Confirmation ConfirmRequest="true" Message="确认进行手动重发数据？" Title="确认操作" />
                                                        </Click>
                                                    </AjaxEvents>
                                                </ext:Button>
                                            </Fields>
                                        </ext:MultiField>
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Listeners>
                        </Listeners>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
