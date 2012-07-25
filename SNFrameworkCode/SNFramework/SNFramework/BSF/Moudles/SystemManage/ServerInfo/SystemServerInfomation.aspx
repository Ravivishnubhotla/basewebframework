<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemServerInfomation.aspx.cs" Inherits="SNFramework.BSF.Moudles.SystemManage.ServerInfo.SystemServerInfomation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Viewport ID="viewPortMain" runat="server" Layout="fit">
        <Items>
            <ext:TabPanel ID="MainTabs" runat="server" Border="false" EnableTabScroll="true">
                <Items>
                    <ext:Panel ID="Panel3" runat="server" Title="基本信息" Frame="true" LabelWidth="150"
                        Layout="Form">
                        <Items>
                            <ext:Container ID="Container1" runat="server" Layout="Column">
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="lblServerName" runat="server" FieldLabel="计算机名" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblServerDomain" runat="server" FieldLabel="域名" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblServerOS" runat="server" FieldLabel="操作系统" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField8" runat="server" FieldLabel=".NET 语言" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField2" runat="server" FieldLabel="执行文件绝对路径" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField4" runat="server" FieldLabel="站点虚拟目录名称" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField11" runat="server" FieldLabel="上次启动到现在已运行" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField7" runat="server" FieldLabel="应用程序安装目录" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container3" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="lblServerIP" runat="server" FieldLabel="IP地址" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblServerPort" runat="server" FieldLabel="端口" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="lblServerIIS" runat="server" FieldLabel="IIS版本" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField9" runat="server" FieldLabel=".NET 版本" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField3" runat="server" FieldLabel="虚拟目录绝对路径" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField6" runat="server" FieldLabel="操作系统安装目录" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField10" runat="server" FieldLabel="服务器当前时间" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container4" runat="server" LabelWidth="130" Layout="Form">
                                <Items>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel1" runat="server" Title="硬件信息" Frame="true" LabelWidth="150"
                        Layout="Form">
                        <Items>
                            <ext:Container ID="Container5" runat="server" Layout="Column">
                                <Items>
                                    <ext:Container ID="Container6" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="DisplayField1" runat="server" FieldLabel="物理内存总数" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField5" runat="server" FieldLabel="正使用的内存" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField12" runat="server" FieldLabel="交换文件大小" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField13" runat="server" FieldLabel="总虚拟内存" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container7" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="DisplayField18" runat="server" FieldLabel="可用物理内存" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField19" runat="server" FieldLabel="逻辑驱动器" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField20" runat="server" FieldLabel="交换文件可用大小" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField21" runat="server" FieldLabel="剩余虚拟内存" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container8" runat="server" LabelWidth="130" Layout="Form">
                                <Items>
                                    <ext:DisplayField ID="DisplayField14" runat="server" FieldLabel="CPU 总数" AnchorHorizontal="95%" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel2" runat="server" Title="组件安装检测" Frame="true" LabelWidth="150"
                        Layout="Form">
                        <Items>
                            <ext:Container ID="Container9" runat="server" Layout="Column">
                                <Items>
                                    <ext:Container ID="Container10" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="DisplayField25" runat="server" FieldLabel="计算机名" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField26" runat="server" FieldLabel="域名" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField27" runat="server" FieldLabel="操作系统" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField28" runat="server" FieldLabel=".NET 语言" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField29" runat="server" FieldLabel="执行文件绝对路径" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField30" runat="server" FieldLabel="站点虚拟目录名称" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField31" runat="server" FieldLabel="上次启动到现在已运行" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField32" runat="server" FieldLabel="应用程序安装目录" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container11" runat="server" Layout="Form" ColumnWidth=".5">
                                        <Items>
                                            <ext:DisplayField ID="DisplayField33" runat="server" FieldLabel="IP地址" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField34" runat="server" FieldLabel="端口" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField35" runat="server" FieldLabel="IIS版本" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField36" runat="server" FieldLabel=".NET 版本" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField37" runat="server" FieldLabel="虚拟目录绝对路径" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField38" runat="server" FieldLabel="操作系统安装目录" AnchorHorizontal="95%" />
                                            <ext:DisplayField ID="DisplayField39" runat="server" FieldLabel="服务器当前时间" AnchorHorizontal="95%" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container12" runat="server" LabelWidth="130" Layout="Form">
                                <Items>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>
