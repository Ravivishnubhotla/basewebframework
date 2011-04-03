<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="SystemSettingEditor.aspx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.SettingManage.SystemSettingEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Title="System Setting" Frame="true"  
                Layout="Center">
                <Items>
                    <ext:Panel ID="Panel2" runat="server" Title="Inner Centered Panel" Width="500" Frame="true"
                        AutoHeight="true">
                        <Content>
                            <ext:FormPanel ID="formPanelSystemSettingEdit" runat="server" Frame="true" Header="false"
                                MonitorValid="true" Layout="form" LabelSeparator=":"
                                LabelWidth="100">
                                <Items>
                                    <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                                    </ext:Hidden>
                                    <ext:TextField ID="txtSystemName" runat="server" FieldLabel="Name" AllowBlank="False"
                                        AnchorHorizontal="95%" />
                                    <ext:TextArea ID="txtSystemDescription" runat="server" FieldLabel="Description" AllowBlank="True"
                                        AnchorHorizontal="95%" />
                                    <ext:TextField ID="txtSystemUrl" runat="server" FieldLabel="Url" AllowBlank="True"
                                        AnchorHorizontal="95%" />
                                    <ext:TextField ID="txtSystemVersion" runat="server" FieldLabel="Version" AllowBlank="False"
                                        AnchorHorizontal="95%" />
                                    <ext:TextArea ID="txtSystemLisence" runat="server" FieldLabel="Lisence" AllowBlank="False"
                                        AnchorHorizontal="95%" />
                                </Items>
                            </ext:FormPanel>
                        </Content>
                         <Buttons>
        <ext:Button ID="btnSaveSystemSetting" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemSettingEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemSetting_Click" Success="Ext.MessageBox.alert('Operation successful', ' Update SystemSetting Success',callback);function callback(id) { };
" Failure="Ext.Msg.alert('Operation Failed', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
    </Buttons>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</asp:Content>
