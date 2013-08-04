<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPChannelRuleCheck.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPChannelRuleCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Title="通道规则测试" ButtonAlign="Right">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="100%">
                                        <ext:Label ID="lblRuleTxt" FieldLabel="规则文件" runat="server" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="100%">
                                        <ext:Label ID="lblRuleStatus" FieldLabel="规则文件" runat="server" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="100%">
                                        <ext:TextArea ID="txtUlr" FieldLabel="测试链接" runat="server" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="100%">
                                        <ext:TextArea ID="txtResult" FieldLabel="测试结果" runat="server" />
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnCreateRule" runat="server" Text="创建规则" Icon="ScriptAdd">
                                <AjaxEvents>
                                    <Click OnEvent="onCreateRule" Success="Ext.MessageBox.alert('操作成功', '成功的创建了规则文件。');" Failure="Ext.Msg.alert('操作失败', result.errorMessage);" />
                                </AjaxEvents>
                            </ext:Button>
                            <ext:Button ID="btnUpdate" runat="server" Text="更新缓存" Icon="ScriptEdit">
                                <AjaxEvents>
                                    <Click OnEvent="onUpdateCache" Success="Ext.MessageBox.alert('操作成功', '成功的更新了规则缓存。');" Failure="Ext.Msg.alert('操作失败', result.errorMessage);" />
                                </AjaxEvents>
                            </ext:Button>
                            <ext:Button ID="btnTestRule" runat="server" Text="测试" Icon="ScriptGo">
                                <AjaxEvents>
                                    <Click OnEvent="onTestRule" Success="Ext.MessageBox.alert('操作成功', '成功的测试了规则文件。');" Failure="Ext.Msg.alert('操作失败', result.errorMessage);" />
                                </AjaxEvents>
                            </ext:Button>
                            <ext:Button ID="btnDownload" runat="server" Text="退出" Icon="Decline">
                                <Listeners>
                                    <Click Handler="parent.RefreshSPChannelList();parent.CloseTestRule();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
</asp:Content>
