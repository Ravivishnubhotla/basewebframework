<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SPSourceCodeAdd.aspx.cs" Inherits="Legendigital.Common.Web.Moudles.SPS.Channels.SPSourceCodeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ViewPort ID="viewPortMain" runat="server">
        <Body>
            <ext:FitLayout ID="fitLayoutMain" runat="server">
                <Items>
                    <ext:FormPanel ID="FormPanel1" runat="server" Frame="true" Header="False" HideLabels="True" HideLabel="True" ButtonAlign="Right">
                        <Body>
                            <ext:FormLayout ID="FormLayout1" runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="100%">
                                        <ext:TextField ID="txtFileName" runat="server" />
                                    </ext:Anchor>
                                    <ext:Anchor Horizontal="100%" Vertical="-28">
                                        <ext:TextArea ID="txtSource" runat="server" />
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>
                        </Body>
                        <Buttons>
                            <ext:Button ID="btnSaveSource" runat="server" Text="保存" Icon="ScriptEdit">
                                <AjaxEvents>
                                    <Click Before="if(!#{FormPanel1}.getForm().isValid()) return false;" OnEvent="btnSaveSource_Click"
                                        Success="Ext.MessageBox.alert('操作成功', '添加代码成功。',callback);function callback(id) { parent.ReloadData();parent.CloseSourceAdd(); };
"
                                        Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                        <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                                    </Click>
                                </AjaxEvents>
                            </ext:Button>
                            <ext:Button ID="btnDownload" runat="server" Text="下载" Icon="DiskDownload">
                                <Listeners>
                                    <Click Handler="parent.ReloadData();parent.CloseSourceEdit();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:FitLayout>
        </Body>
    </ext:ViewPort>
    
     <!-- <%= this.CopyFilePath %> -->
     <!-- <%= this.SaveFilePath %>-->
</asp:Content>
