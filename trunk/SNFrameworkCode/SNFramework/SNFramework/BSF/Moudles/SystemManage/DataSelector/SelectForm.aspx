<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SelectForm.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.DataSelector.SelectForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var triggerClick = function (el, trigger, tag, index) {
            //alert(el);
            switch (tag) {
                case 'Clear':
                    
                    el.setValue('Clear');
                    break;
                case 'Select':
                    var winSelectUser = <%= winSelectUser.ClientID %>;
                    winSelectUser.show();
                    el.setValue('Select');
                    break;
            }
        }
    </script>
    <ext:Viewport ID="viewPortMain" runat="server">
        <Items>
            <ext:FormPanel ID="formPanelSystemRoleAdd" runat="server" Title="用户角色选择测试表单" Frame="true" Header="false"
                MonitorValid="true" BodyStyle="padding:5px;" LabelSeparator=":" LabelWidth="100"
                Layout="form">
                <Items>
                    <ext:TriggerField ID="TriggerField1" runat="server" FieldLabel="选择用户" Editable="false" AnchorHorizontal="95%">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" Qtip="清除选择" Tag="Clear" />
                            <ext:FieldTrigger Icon="Search" Qtip="选择用户" Tag="Select" />
                        </Triggers>
                        <Listeners>
                            <TriggerClick Handler="triggerClick(this, trigger, tag, 1);" />
                        </Listeners>
                    </ext:TriggerField>
                </Items>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="winSelectUser" runat="server" Title="选择用户" Frame="true"
        Width="800" ConstrainHeader="true" Height="480" Maximizable="true" Closable="true"
        Resizable="true" Modal="true" Hidden="true" AutoScroll="true">
        <AutoLoad Url="UserSelector.aspx" Mode="IFrame" NoCache="true"
            TriggerEvent="show" ReloadOnEvent="true" ShowMask="true">
            <Params>
                <ext:Parameter Name="ChannelID" Mode="Raw" Value="0">
                </ext:Parameter>
                <ext:Parameter Name="CodeID" Mode="Raw" Value="0">
                </ext:Parameter>
            </Params>
        </AutoLoad>
        <Buttons>
            <ext:Button runat="server" Text="<%$ Resources : GlobalResource, msgSelect  %>"
                Icon="Accept">
            </ext:Button>
            <ext:Button runat="server" Text="<%$ Resources : GlobalResource, msgCancel  %>"
                Icon="Cancel">
                <Listeners>
                    <Click Handler="#{winSelectUser}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <Hide Handler="this.clearContent();" />
        </Listeners>
    </ext:Window>
</asp:Content>
