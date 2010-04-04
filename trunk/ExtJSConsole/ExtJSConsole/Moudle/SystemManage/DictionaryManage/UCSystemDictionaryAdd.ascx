<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSystemDictionaryAdd.ascx.cs"
    Inherits="ExtJSConsole.Moudle.SystemManage.DictionaryManage.UCSystemDictionaryAdd" %>
<ext:Window ID="winSystemDictionaryAdd" runat="server" Icon="Add" Title="添加SystemDictionary"
    Width="400" Height="270" AutoShow="false" Maximizable="true" Modal="true" Hidden="true"
    ConstrainHeader="true" Resizable="true" Layout="fit">
    <content>
        <ext:FormPanel ID="formPanelSystemDictionaryAdd" runat="server" Frame="true" Header="false"
            MonitorValid="true" BodyStyle="padding:5px;" Layout="form" LabelSeparator=":"
            LabelWidth="100">
 <items>
                
                            <ext:TextField ID="txtSystemDictionaryCategoryID" runat="server" FieldLabel="字典类型"
                                AllowBlank="True"  AnchorHorizontal="95%"  />
                       
                            <ext:TextField ID="txtSystemDictionaryKey" runat="server" FieldLabel="键" AllowBlank="True"  AnchorHorizontal="95%"  />
                
                            <ext:TextField ID="txtSystemDictionaryValue" runat="server" FieldLabel="值" AllowBlank="True"  AnchorHorizontal="95%"  />
               
                            <ext:TextArea ID="txtSystemDictionaryDesciption" runat="server" FieldLabel="描述" AllowBlank="True"  AnchorHorizontal="95%"  />
              
                            <ext:NumberField ID="txtSystemDictionaryOrder" runat="server" FieldLabel="序号" AllowBlank="True"  AnchorHorizontal="95%"  />
              
                            <ext:Checkbox ID="chkSystemDictionaryIsEnable" runat="server" FieldLabel="是否有效" Checked="false"  AnchorHorizontal="95%"  />
                    
 </items>
        </ext:FormPanel>
    </content>
    <buttons>
        <ext:Button ID="btnSaveSystemDictionary" runat="server" Text="添加" Icon="Add">
            <DirectEvents>
                <Click Before="if(!#{formPanelSystemDictionaryAdd}.getForm().isValid()) return false;"
                    OnEvent="btnSaveSystemDictionary_Click" Success="Ext.MessageBox.alert('操作成功', '成功的添加了SystemDictionary。',callback);function callback(id) {#{formPanelSystemDictionaryAdd}.getForm().reset();#{storeSystemDictionary}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCancelSystemDictionary" runat="server" Text="取消" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winSystemDictionaryAdd}.hide();" />
            </Listeners>
        </ext:Button>
    </buttons>
</ext:Window>
