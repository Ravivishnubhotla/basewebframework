<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="DataArchive.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.DataArchives.DataArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ScriptManagerProxy ID="ScriptManager1" runat="server">
        <Listeners>
            <DocumentReady Handler="#{dfStart}.setValue(#{dfEnd}.getValue());" />
        </Listeners>
    </ext:ScriptManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
