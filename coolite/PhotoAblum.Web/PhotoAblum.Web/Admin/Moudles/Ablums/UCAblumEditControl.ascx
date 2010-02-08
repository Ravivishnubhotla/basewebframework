<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAblumEditControl.ascx.cs"
    Inherits="PhotoAblum.Web.Admin.Moudles.Ablums.UCAblumEditControl" %>
<%@ Register Src="UCPhotoAdd.ascx" TagName="UCPhotoAdd" TagPrefix="uc5" %>
<%@ Register Src="UCPhotoEdit.ascx" TagName="UCPhotoEdit" TagPrefix="uc6" %>
<%@ Register Src="UCPhotoImport.ascx" TagName="UCPhotoImport" TagPrefix="uc7" %>

<script type="text/javascript">
    var showFile = function(fb, v) {

        if (!v) return;

        var patn = /\.jpg$|\.jpeg$|\.gif$|\.png&/i; //判断文件后缀名

        if (!patn.test(v)) {

            Ext.MessageBox.alert('警告', '您选择的不是图像文件!');

            return;

        }
    }
    
    var RefreshPhotoData = function(btn) {
            <%=this.storePhotos.ClientID%>.reload();
    };
    
            function spcmd(cmd, id) {

            if (cmd == "PhotoEdit") {
                Coolite.AjaxMethods.UCPhotoEdit.Show(id.data.Id);
            }

            if (cmd == "PhotoDelete") {
                Ext.MessageBox.confirm(
                    '警告',
                    '确认要删除所选记录 ? ',
                    function(e) {
                        if (e == 'yes')
                            Coolite.AjaxMethods.UCAblumEditControl.DeletePhoto(
                                                                id.data.Id,
                                                                {
                                                                    failure:
                                                                    function(msg) {
                                                                        Ext.Msg.alert('操作失败', msg);
                                                                    }
                                                                }
                                                            );
                    }
                    );         
            }

        }
                
</script>

<ext:Store ID="storePhotos" runat="server" OnRefreshData="storePhotos_Refresh" AutoLoad="true">
    <Reader>
        <ext:JsonReader ReaderID="Id">
            <Fields>
                <ext:RecordField Name="Id" Type="Int" />
                <ext:RecordField Name="AlbumID" Type="Int" />
                <ext:RecordField Name="SmallImageRUrl" />
                <ext:RecordField Name="FullImage" />
                <ext:RecordField Name="MiddleImage" />
                <ext:RecordField Name="FullImage" />
                <ext:RecordField Name="OrderIndex" Type="Int" />
                <ext:RecordField Name="IsShow" Type="Boolean" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Window ID="winEditAblum" runat="server" Icon="ImageEdit" Title="编辑相册" Width="500"
    Height="339" Maximizable="true" AutoShow="false" Modal="true" ShowOnLoad="false">
    <Body>
        <ext:FitLayout ID="FitLayout1" runat="server">
            <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false">
                <Tabs>
                    <ext:Tab ID="tabInfo" runat="server" Title="相册基本信息" Icon="Information">
                        <Body>
                            <ext:FitLayout ID="fitLayoutMain" runat="server">
                                <ext:FormPanel ID="FormPanel1" runat="server" Header="false" MonitorValid="true"
                                    Frame="true" BodyStyle="padding:5px;" ButtonAlign="Left">
                                    <Body>
                                        <ext:FormLayout ID="FormLayout2" runat="server" LabelSeparator=":" LabelWidth="80">
                                            <Anchors>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtName" runat="server" FieldLabel="相册名" AllowBlank="false" BlankText="请输入【相册名】！" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextArea ID="txtDescription" runat="server" FieldLabel="相册描述" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Checkbox ID="chkIsShow" runat="server" Checked="true" FieldLabel="是否显示">
                                                    </ext:Checkbox>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField runat="server" ID="txtViewPassword" FieldLabel="设置查看密码" />
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:NumberField runat="server" ID="numOrderIndex" FieldLabel="排序号" Width="250" AllowBlank="false"
                                                        AllowNegative="false">
                                                    </ext:NumberField>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:Hidden runat="server" ID="hidID">
                                                    </ext:Hidden>
                                                </ext:Anchor>
                                            </Anchors>
                                        </ext:FormLayout>
                                    </Body>
                                    <Buttons>
                                        <ext:Button ID="btnSaveEditAblumBaseInfo" runat="server" Text="编辑" Icon="ImageEdit">
                                            <AjaxEvents>
                                                <Click OnEvent="btnSaveEditAblumBaseInfo_Click" Before="if(!#{FormPanel1}.getForm().isValid()) return false;"
                                                    Success="Ext.MessageBox.alert('操作成功', '成功的编辑了相册。',callback);function callback(id) { #{storeAblums}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Buttons>
                                </ext:FormPanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Tab>
                    <ext:Tab ID="tab1" runat="server" Title="相册封面" Icon="PhotoPaint">
                        <Body>
                            <ext:FitLayout ID="fitLayout2" runat="server">
                                <ext:FormPanel ID="FormPanel2" runat="server" Header="false" MonitorValid="true"
                                    Frame="true" BodyStyle="padding:5px;" ButtonAlign="Left">
                                    <Body>
                                        <ext:FormLayout ID="FormLayout1" runat="server">
                                            <Anchors>
                                                <ext:Anchor>
                                                    <ext:Image ID="imgFullImage" FieldLabel="相册封面" runat="server" Width="100" Height="100"
                                                        ImageUrl="~/Admin/Images/no_image.gif">
                                                    </ext:Image>
                                                </ext:Anchor>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:FileUploadField ID="fufFullImage" runat="server" Width="250" FieldLabel="上传封面图片"
                                                        AllowBlank="false">
                                                        <Listeners>
                                                            <FileSelected Fn="showFile" />
                                                        </Listeners>
                                                    </ext:FileUploadField>
                                                </ext:Anchor>
                                            </Anchors>
                                        </ext:FormLayout>
                                    </Body>
                                    <Buttons>
                                        <ext:Button ID="btnUploadCover" runat="server" Text="上传" Icon="Attach">
                                            <AjaxEvents>
                                                <Click OnEvent="btnUploadCover_Click" Before="if(!#{FormPanel2}.getForm().isValid()) return false;"
                                                    Success="Ext.MessageBox.alert('操作成功', '成功的上传了相册封面。',callback);function callback(id) { #{storeAblums}.reload(); };
" Failure="Ext.Msg.alert('操作失败', result.errorMessage);">
                                                    <EventMask ShowMask="true" Msg="文件上传中，请稍候....." />
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Buttons>
                                </ext:FormPanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Tab>
                    <ext:Tab ID="tab2" runat="server" Title="照片管理" Icon="Photos">
                        <Body>
                            <ext:FitLayout ID="fitLayout3" runat="server">
                                <ext:GridPanel ID="GridPanel2" runat="server" StoreID="storePhotos" AutoExpandColumn="SmallImageRUrl"
                                    Frame="true" BodyStyle="padding:5px;">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:ToolbarButton ID='ToolbarButton1' runat="server" Text="添加" Icon="ImageAdd">
                                                    <Listeners>
                                                        <Click Handler="Coolite.AjaxMethods.UCPhotoAdd.Show(#{hidID}.value);" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID='ToolbarButton3' runat="server" Text="批量导入" Icon="DatabaseGo">
                                                    <Listeners>
                                                        <Click Handler="Coolite.AjaxMethods.UCPhotoImport.Show(#{hidID}.value);" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                                <ext:ToolbarButton ID='ToolbarButton2' runat="server" Text="刷新" Icon="Reload">
                                                    <Listeners>
                                                        <Click Handler="#{storePhotos}.reload();" />
                                                    </Listeners>
                                                </ext:ToolbarButton>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:Column DataIndex="SmallImageRUrl" Header="照片">
                                                <Renderer Fn="ShowImage" />
                                            </ext:Column>
                                            <ext:Column DataIndex="OrderIndex" Header="排序号">
                                            </ext:Column>
                                            <ext:Column DataIndex="IsShow" Header="是否显示">
                                                <Renderer Fn="isShowDisplay" />
                                            </ext:Column>
                                            <ext:CommandColumn Width="60">
                                                <Commands>
                                                    <ext:GridCommand Icon="PhotoEdit" CommandName="PhotoEdit">
                                                        <ToolTip Text="编辑" />
                                                    </ext:GridCommand>
                                                    <ext:GridCommand Icon="PhotoDelete" CommandName="PhotoDelete">
                                                        <ToolTip Text="删除" />
                                                    </ext:GridCommand>
                                                </Commands>
                                            </ext:CommandColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <LoadMask ShowMask="true" />
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolBar2" runat="server" PageSize="5" StoreID="storePhotos"
                                            DisplayInfo="true" DisplayMsg="显示照片 {0} - {1} 共 {2}" EmptyMsg="没有符合条件的照片" />
                                    </BottomBar>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
                                    </SelectionModel>
                                    <Listeners>
                                        <Command Handler="spcmd(command, record);" />
                                    </Listeners>
                                </ext:GridPanel>
                            </ext:FitLayout>
                        </Body>
                        <Listeners>
                            <Activate Handler="#{storePhotos}.reload();" />
                        </Listeners>
                    </ext:Tab>
                    <ext:Tab ID="tab3" runat="server" Title="更改相册文件夹目录" Icon="DriveRename">
                        <Body>
                            <ext:FitLayout ID="fitLayout4" runat="server">
                                <ext:FormPanel ID="FormPanel3" runat="server" Header="false" MonitorValid="true"
                                    Frame="true" BodyStyle="padding:5px;" ButtonAlign="Left">
                                    <Body>
                                        <ext:FormLayout ID="FormLayout3" runat="server" LabelSeparator=":" LabelWidth="80">
                                            <Anchors>
                                                <ext:Anchor Horizontal="95%">
                                                    <ext:TextField ID="txtDirName" runat="server" FieldLabel="目录名" AllowBlank="false" />
                                                </ext:Anchor>
                                            </Anchors>
                                        </ext:FormLayout>
                                    </Body>
                                    <Buttons>
                                        <ext:Button ID="Button1" runat="server" Text="更改" Icon="ImageEdit">
                                            <AjaxEvents>
                                                <Click Before="if(!#{FormPanel1}.getForm().isValid()) return false;">
                                                    <EventMask ShowMask="true" Msg="数据保存中，请稍候....." />
                                                </Click>
                                            </AjaxEvents>
                                        </ext:Button>
                                    </Buttons>
                                </ext:FormPanel>
                            </ext:FitLayout>
                        </Body>
                    </ext:Tab>
                </Tabs>
            </ext:TabPanel>
        </ext:FitLayout>
    </Body>
</ext:Window>
<uc5:UCPhotoAdd ID="UCPhotoAdd1" runat="server" />
<uc6:UCPhotoEdit ID="UCPhotoEdit1" runat="server" />
<uc7:UCPhotoImport ID="UCPhotoImport1" runat="server" />
