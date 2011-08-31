<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryGroupView.ascx.cs" Inherits="Legendigital.Common.WebApp.Moudles.SystemManage.DictionaryManage.UCSystemDictionaryGroupView" %>

<ext:Window ID="winSystemDictionaryGroupView" runat="server" Icon="ApplicationViewDetail" Title="ShowSystemDictionaryGroup"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="Fit">
    <Content>
        <ext:FormPanel ID="formPanelSystemDictionaryGroupView" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100" AutoScroll="true"
            Layout="Form">
            <Items>
                                <ext:Hidden ID="hidSystemDictionaryGroupID" runat="server" AnchorHorizontal="95%">
                                </ext:Hidden>
					<ext:DisplayField ID="lblName" runat="server" FieldLabel="Name" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblCode" runat="server" FieldLabel="Code" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblDescription" runat="server" FieldLabel="Description" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsEnable" runat="server" FieldLabel="IsEnable" AnchorHorizontal="95%" />
					
					<ext:DisplayField ID="lblIsSystem" runat="server" FieldLabel="IsSystem" AnchorHorizontal="95%" />
					

            </Items>
        </ext:FormPanel>
    </Content>
</ext:Window>
