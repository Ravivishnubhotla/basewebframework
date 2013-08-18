<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPChannelView.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Channels.UCSPChannelView" %>
<ext:Window ID="winSPChannelView" runat="server" Icon="ApplicationViewDetail" Title="ShowSPChannel"
    Width="600" Height="350" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    AutoScroll="true" ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:TabPanel
            ID="TabPanel1"
            runat="server"
            ActiveTabIndex="0">
            <Items>
                <ext:Panel ID="formPanelSPChannelView" runat="server" Frame="true" Title="通道基本信息"
                    AutoScroll="true">
                    <Items>
                        <ext:Container ID="Container1" runat="server" Layout="Column" Height="150">
                            <Items>
                                <ext:Container ID="Container2" runat="server" Layout="Form" ColumnWidth=".5">
                                    <Items>
                                        <ext:DisplayField ID="lblName" runat="server" FieldLabel="名称" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField2" runat="server" FieldLabel="通道类型" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField4" runat="server" FieldLabel="是否监控" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField6" runat="server" FieldLabel="是否禁用" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField8" runat="server" FieldLabel="默认价格" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField10" runat="server" FieldLabel="通道状态" AnchorHorizontal="95%" />
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container3" runat="server" Layout="Form" ColumnWidth=".5">
                                    <Items>
                                        <ext:DisplayField ID="DisplayField1" runat="server" FieldLabel="编码" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField3" runat="server" FieldLabel="状态报告类型" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField5" runat="server" FieldLabel="是否日志" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField7" runat="server" FieldLabel="是否过滤" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField9" runat="server" FieldLabel="默认扣率" AnchorHorizontal="95%" />
                                        <ext:DisplayField ID="DisplayField11" runat="server" FieldLabel="所属上家" AnchorHorizontal="95%" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container4" runat="server" Layout="Form">
                            <Items>
                                <ext:DisplayField ID="lblChannelDetailInfo" runat="server" FieldLabel="详细信息" AnchorHorizontal="95%" />
                                <ext:Hidden ID="hidSPChannelID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Panel>
                <ext:Panel
                    ID="Panel1"
                    runat="server"
                    Title="接收参数信息"
                    Html="You can close this Tab." />
                <ext:Panel
                    ID="Panel2"
                    runat="server"
                    Title="同步参数信息"
                    Html="You can close this Tab." />
                <ext:Panel
                    ID="Tab2"
                    runat="server"
                    Title="指令信息"
                    Html="You can close this Tab." />

            </Items>
        </ext:TabPanel>

    </Content>
</ext:Window>
