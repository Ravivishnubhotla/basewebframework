<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSPAdReportEdit.ascx.cs" Inherits="SPSWeb.Moudles.SPS.Reports.UCSPAdReportEdit" %>

<ext:Window ID="winSPAdReportEdit" runat="server" Icon="ApplicationEdit" Title="Edit SPAdReport"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true" AutoScroll="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <Content>
        <ext:FormPanel ID="formPanelSPAdReportEdit" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":" AutoScroll="true"
            LabelWidth="100">
            <Items>

                <ext:Hidden ID="hidId" runat="server" AnchorHorizontal="95%">
                </ext:Hidden>


                <ext:DisplayField ID="lblAdName" runat="server" FieldLabel="���" AnchorHorizontal="95%" />


                <ext:DisplayField ID="lblAdPackName" runat="server" FieldLabel="����" AnchorHorizontal="95%" />


                <ext:DisplayField ID="lblSPClientName" runat="server" FieldLabel="�ͻ�" AnchorHorizontal="95%" />


                <ext:DisplayField ID="dateReportDate" runat="server" FieldLabel="����" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdCount" runat="server" FieldLabel="�ϼҶ�����" AllowBlank="false" AnchorHorizontal="95%" />
                <ext:NumberField ID="numClientCount" runat="server" FieldLabel="�¼Ҷ�����" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdUseCount" runat="server" FieldLabel="�ϼҴ���" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdClientUseCount" runat="server" FieldLabel="�¼Ҵ���" AllowBlank="false" AnchorHorizontal="95%" />


                <ext:NumberField ID="numAdDownCount" runat="server" FieldLabel="�ϼҼ�����" AllowBlank="false" AnchorHorizontal="95%" />

                <ext:NumberField ID="numAdClientDownCount" runat="server" FieldLabel="�¼Ҽ�����" AllowBlank="false" AnchorHorizontal="95%" />





            </Items>
        </ext:FormPanel>
    </Content>
    <Buttons>
        <ext:Button ID="btnSaveSPAdReport" runat="server" Text="Edit" Icon="ApplicationEdit">
            <DirectEvents>
                <Click Before="if(!#{formPanelSPAdReportEdit}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSPAdReport_Click" Success="Ext.MessageBox.alert('�����ɹ�', 'Update a record success',callback);function callback(id) {#{formPanelSPAdReportEdit}.getForm().reset();#{storeSPAdReport}.reload(); };
"
                    Failure="Ext.Msg.alert('����ʧ��', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="Saving,Please waiting....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSPAdReport" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{formPanelSPAdReportEdit}.getForm().reset();#{winSPAdReportEdit}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>







