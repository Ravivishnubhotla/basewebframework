<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPSendClientParamsClone.ascx.cs"
    Inherits="Legendigital.Common.Web.Moudles.SPS.Clients.UCSPSendClientParamsClone" %>
<ext:Store ID="storeSPChannelAdd" runat="server" AutoLoad="false">
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
<ext:Window ID="winSPSendClientParamsClone" runat="server" Icon="ApplicationAdd" Title="复制通道参数" ConstrainHeader=true
    Width="400" Height="120" AutoShow="false" Maximizable="true" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="fitLayoutMain" runat="server">
            <ext:FormPanel ID="formPanelSPSendClientParamsClone" runat="server" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;">
                <Body>
                    <ext:FormLayout ID="FormLayoutSPSendClientParams" runat="server" LabelSeparator=":"
                        LabelWidth="100">
                        <Anchors>
                            <ext:Anchor Horizontal="95%">
                                <ext:Hidden ID="hidClientID" runat="server" FieldLabel="下家ID" AllowBlank="True" />
                            </ext:Anchor>
                            <ext:Anchor Horizontal="95%">
                                <ext:ComboBox ID="cmbChannelID" runat="server" FieldLabel="通道" AllowBlank="False"
                                    StoreID="storeSPChannelAdd" Editable="false" TypeAhead="true" Mode="Local" ForceSelection="true"
                                    TriggerAction="All" DisplayField="Name" ValueField="Id" EmptyText="请选择通道" ValueNotFoundText="加载中..." />
                            </ext:Anchor>
                        </Anchors>
                    </ext:FormLayout>
                </Body>
            </ext:FormPanel>
        </ext:FitLayout>
    </Body>
    <Buttons>
   
        <ext:Button ID="btnCancelSPSendClientParams" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSPSendClientParamsClone}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
        <Listeners>
        <Show Handler="#{storeSPChannelAdd}.reload();" />
    </Listeners>
</ext:Window>
