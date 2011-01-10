<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="Web.Homes.Reg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function externallinks() {
            if (!document.getElementsByTagName) return;
            var anchors = document.getElementsByTagName("a");
            for (var i = 0; i < anchors.length; i++) {
                var anchor = anchors[i];
                if (anchor.getAttribute("href"))
                    anchor.target = "_blank";
            }
        }
        window.onload = externallinks;
    </script>
    <script type="text/javascript" src="../../Scripts/city-1.0.0.js"></script>
    <table border="0" cellspacing="0" cellpadding="0" width="780" align="center">
        <tbody>
            <tr>
                <td height="5">
                </td>
            </tr>
            <tr>
                <td align="middle">
                    请填写好你的注册信息，方便网友找到你，以下打红星为必填项
                </td>
            </tr>
            <tr>
                <td height="20" align="right">
                    会员登陆名和密码
                </td>
            </tr>
            <tr>
                <td>
                    <hr>
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="5" width="780" align="center" height="202">
        <form onsubmit="return checklogin()" method="post" name="login" action="reg.asp?www_yiyeba_net=reg_save">
        <tbody>
            <td height="1" background="images/_dot.gif" colspan="3">
            </td>
            </TR><input type="hidden" name="user_tj">
            <tr>
                <td height="20" width="19%">
                    <div align="right">
                        <strong>会员登陆呢称<font color="#ff0000">（中文）</font></strong><font color="#ff6600">*</font></div>
                </td>
                <td width="32%">
                    <input onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\u4E00-\u9FA5]/g,''))"
                        onblur="value=value.replace(/[^\u4E00-\u9FA5]/g,'')" id="user_name" onkeyup="value=value.replace(/[^\u4E00-\u9FA5]/g,'')"
                        size="18" name="user_name">
                    <input class="button3" onclick="window.open('reg.asp?www_yiyeba_net=check_reg&amp;user_name='+document.login.user_name.value)"
                        value="检测会员呢称" type="button" name="Submit">
                </td>
                <td class="tdsize" width="48%">
                    欢迎成年人注册，仅限中文；一旦注册成功，不可修改；如“多情郎”
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>密码</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input id="user_pass1" maxlength="21" size="22" type="password" name="user_pass1">
                </td>
                <td>
                    <span class="tdsize">4-15位；只限数字(0-9)和英文(a-z),区分大小写；建议采用易记、难猜的英文数字组合。注意：不能与用户名相同</span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>重复输入密码</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input id="user_pass2" maxlength="21" size="22" type="password" name="user_pass2">
                </td>
                <td class="tdsize">
                    请再输入一遍上面填写的密码。
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>密码提示问题</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input id="user_quest" maxlength="21" name="user_quest">
                </td>
                <td class="tdsize">
                    用于忘记密码时的提示问题，不允许修改。
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>密码提示答案</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input id="user_answer" maxlength="21" name="user_answer">
                </td>
                <td class="tdsize">
                    用于取回密码时要回答的答案，不允许修改。
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong><font color="#ff6600">验</font></strong><font color="#ff6600"><strong>证码</strong>*</font></div>
                </td>
                <td>
                    <input name="Form_Code">
                    <script language="javascript">                        document.write("<img src='http://www.yiyeba.net/coyzm.asp' align=absmiddle id=Image1 onclick=Image1.src='coyzm.asp?'+Math.random(); alt=看不清楚/>");</script>
                </td>
                <td class="tdsize">
                    认真填写后面的数字。
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>您的性别</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input value="男" checked type="radio" name="user_sex">男&nbsp;&nbsp;&nbsp;<input onclick="document.all.t1.style.display='';"
                        value="女" type="radio" name="user_sex">女 &nbsp;
                    <div style="display: none" id="t1">
                        <strong><font color="#ff0000">女性会员需要管理员严格的身份审核，乱填写的将一律删除，删除后将无法重新注册，所有注册资料均保留时间跟IP，如果你是恶意填写别人的联系方式，遭投诉后我们将配合受害者查询！</div>
                    </FONT></STRONG>
                </td>
                <td>
                    注册成功后不允许修改
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    对自己描述和联系方式
                    <hr>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>选择所在省市</strong><font color="#ff6600">*</font></div>
                </td>
                <td colspan="2">
                    <script type="text/javascript">                        showprovince('location_province', 'location_city', ''); showcity('location_province', 'location_city', '');</script>
                    &nbsp;如不选择默认为
                    <input value="天津" size="6" name="user_city1">
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>身高</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input size="4" name="user_sg">厘米
                </td>
                <td>
                    <span class="tdsize">您的身高。 </span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>体重</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input size="4" name="user_tz">KG
                </td>
                <td>
                    <span class="tdsize">您的体重。 </span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>职业</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <select name="user_zy">
                        <option value="工人">工人</option>
                        <option value="干部">干部</option>
                        <option value="军人">军人</option>
                        <option value="农民">农民</option>
                        <option value="教师">教师</option>
                        <option value="学生">学生</option>
                        <option value="技术">技术</option>
                        <option value="企管">企管</option>
                        <option value="职员">职员</option>
                        <option value="党政">党政</option>
                        <option value="机关">机关</option>
                        <option value="法律">法律</option>
                        <option value="环卫">环卫</option>
                        <option value="服务">服务</option>
                        <option value="娱乐">娱乐</option>
                        <option value="餐饮">餐饮</option>
                        <option value="学术">学术</option>
                        <option value="出版">出版</option>
                        <option value="媒体">媒体</option>
                        <option value="文化">文化</option>
                        <option value="电脑">电脑</option>
                        <option value="体育">体育</option>
                        <option selected value="自由">自由</option>
                        <option value="国企">国企</option>
                        <option value="私企">私企</option>
                        <option value="工业">工业</option>
                        <option value="农牧">农牧</option>
                        <option value="渔业">渔业</option>
                        <option value="商业">商业</option>
                        <option value="作家">作家</option>
                        <option value="科研">科研</option>
                        <option value="艺术">艺术</option>
                        <option value="公安">公安</option>
                        <option value="邮电">邮电</option>
                        <option value="交通">交通</option>
                        <option value="医疗">医疗</option>
                        <option value="金融">金融</option>
                        <option value="证券">证券</option>
                        <option value="广告">广告</option>
                        <option value="主妇">主妇</option>
                        <option value="信息">信息</option>
                        <option value="客服">客服</option>
                        <option value="退休">退休</option>
                        <option value="无业">无业</option>
                        <option value="其他">其他</option>
                    </select>
                </td>
                <td>
                    <span class="tdsize">选择你所从事的职业。 </span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>学历</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <select name="user_xl">
                        <option value="小学">小学</option>
                        <option value="初中">初中</option>
                        <option value="高中">高中</option>
                        <option value="中专">中专</option>
                        <option selected value="大专">大专</option>
                        <option value="本科">本科</option>
                        <option value="硕士">硕士</option>
                        <option value="博士">博士</option>
                        <option value="博导">博导</option>
                    </select>
                </td>
                <td>
                    <span class="tdsize">选择你的学历。 </span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>年龄</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input size="4" name="user_age">岁
                </td>
                <td>
                    <span class="tdsize">您现在年龄。 </span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>地址</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input name="user_add">
                </td>
                <td>
                    <span class="tdsize">格式为**省**市**县(区) </span>&nbsp;&nbsp;&nbsp;地址栏填写联系方式将被删除
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>邮箱地址</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input id="user_mail" maxlength="40" name="user_mail">
                </td>
                <td>
                    <span class="tdsize"><strong>系统会把你的注册资料(包括用户名和密码)发送到你的邮箱</strong>,不允许修改。</span>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>QQ</strong><font color="#ff6600">*</font></div>
                </td>
                <td>
                    <input id="user_qq" onkeyup="this.value=this.value.replace(/\D/g, ''); " onpaste="return   false; "
                        maxlength="10" name="user_qq">
                </td>
                <td class="tdsize">
                    请输入您的QQ号码，乱填写将会被删除，QQ邮箱将会收到邮件
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>其它联系方式</strong></div>
                </td>
                <td colspan="2">
                    <select size="1" name="user_bm">
                        <option selected value="01">MSN</option>
                        <option value="02">SKYPE</option>
                        <option value="03">UCALL</option>
                        <option value="04">ICQ</option>
                        <option value="05">E话通</option>
                        <option value="06">GTALK</option>
                        <option value="07">飞信</option>
                        <option value="08">淘宝旺旺</option>
                        <option value="09">朗玛UC</option>
                        <option value="10">网易POPO</option>
                        <option value="11">YAHOO通</option>
                        <option value="12">Google Talk<option value="13">百度HI</option>
                            <option value="14">搜Q</option>
                            <option value="15">hohojob</option>
                    </select>
                    <input id="user_msn" maxlength="30" size="30" name="user_msn">
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right">
                    <div align="right">
                        <strong>视频聊天</strong></div>
                </td>
                <td>
                    <input value="允许" type="radio" name="user_view">允许&nbsp;&nbsp;&nbsp;<input value="不允许"
                        checked type="radio" name="user_view">不允许
                </td>
                <td>
                    是否允许与对方视频聊天，前提是你必须有摄相头并方便与网友视频
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right">
                    <div align="right">
                        <strong>联系电话</strong></div>
                </td>
                <td>
                    <input id="user_phone" onkeyup="this.value=this.value.replace(/\D/g, ''); " onpaste="return   false; "
                        maxlength="21" name="user_phone">
                </td>
                <td>
                    选填项，如果填写必须是数字
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>手机</strong></div>
                </td>
                <td>
                    <input onkeyup="this.value=this.value.replace(/\D/g, ''); " onpaste="return   false; "
                        maxlength="21" name="user_sj">
                </td>
                <td>
                    选填项，如果填写必须是数字
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <p>
                        <br>
                        <span class="text03">说明：<br>
                            1、注册信息必须真实，注册完成后将会下发邮件通知，如乱填写信息会被删除；<br>
                            2、会见网友一要提防各方面，出现任何意外，交友网没有责任。</span><br>
                        <strong>3、如果你填写了别人的联系方式，给别人带来很大的搔扰，对方向我们投诉时我们将提供IP和时间给对方查询，发生的法律责任由自己负责。</strong>
                        <br>
                    </p>
                </td>
            </tr>
            <tr>
                <td height="1" background="images/_dot.gif" colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="center">
                        <a class="text03" href="http://yiyeba.16i8.cn/xy.asp" target="_blank"><font color="#ff0000">
                            点击阅读一夜吧交友网条款</font></a>
                        <br>
                        <input onclick="if(this.checked) {document.login.Submit1.style.display='none';document.login.Submit.style.display='';}else {document.login.Submit.style.display='none';document.login.Submit1.style.display='';}"
                            value="checkbox" checked="CHECKED" type="checkbox" name="checkbox">
                        我是成年人，我已经阅读并接受一夜吧交友网服务条款
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="center">
                        <input value="同意注册条款,提交注册信息  " type="submit" name="Submit">
                        <input style="display: none" disabled value="同意注册条款,提交注册信息  " type="submit" name="Submit1">
                        &nbsp;
                        <input value="  重新填写  " type="reset" name="Submit2">
                    </div>
                    <hr>
                </td>
            </tr>
        </form>
        </TBODY></table>
    <script language="javascript">
        function checklogin() {
            var obj = document.login;
            if (obj.user_name.value == "") {
                alert("请输入要注册的会员名!");
                obj.user_name.focus();
                return false;
            }

            if (obj.user_pass1.value == "") {
                alert("请输入登陆密码!");
                obj.user_pass1.focus();
                return false;
            }
            if (obj.user_pass1.value == obj.user_name.value) {
                alert("登陆密码不能与用户名相同,请重新输入!")
                obj.user_pass1.focus();
                obj.user_pass1.select();
                return false;
            }
            var fiter = /^\s*[A-Za-z0-9]{4,15}\s*$/;
            if (!fiter.test(obj.user_pass1.value)) {
                alert("密码格式错误,长度应为:4-15位；只限数字(0-9)和英文(a-z),区分大小写；建议采用易记、难猜的英文数字组合!");
                obj.user_pass1.focus();
                obj.user_pass1.select();
                return false;
            }
            if (obj.user_pass2.value == "") {
                alert("请输入确认密码!");
                obj.user_pass2.focus();
                return false;
            }
            else {
                if (obj.user_pass2.value != obj.user_pass1.value) {
                    alert("两次输入的密码不一致,请重新输入!");
                    obj.user_pass1.focus();
                    obj.user_pass1.select();
                    obj.user_pass2.value = "";
                    return false;
                }
            }
            if (obj.user_quest.value == "") {
                alert("请输入密码提示问题!");
                obj.user_quest.focus();
                return false;
            }

            if (obj.user_answer.value == "") {
                alert("请输入密码答案!");
                obj.user_answer.focus();
                return false;
            }



            if (obj.user_sg.value == "") {
                alert("请输入您的身高.");
                obj.user_sg.focus();
                return false;
            }
            if (obj.user_tz.value == "") {
                alert("请输入您的体重.");
                obj.user_tz.focus();
                return false;
            }

            if (obj.user_age.value == "") {
                alert("请输入年龄.");
                obj.user_age.focus();
                return false;
            }
            if (obj.user_add.value == "") {
                alert("请输入地址.");
                obj.user_add.focus();
                return false;
            }


            if (obj.user_mail.value == "") {
                alert("请输入您的Email.");
                obj.user_mail.focus();
                return false;
            }
            if (obj.user_mail.value.length > 50) {
                alert("Email不能超过50个字.");
                obj.user_mail.focus();
                return false;
            }
            if (obj.user_mail.value.length > 0 && !obj.user_mail.value.match(/^.+@.+$/)) {
                alert("Email 错误！请重新输入");
                obj.user_mail.focus();
                return false;
            }
            if (obj.user_qq.value == "") {
                alert("请输入您的QQ号码!");
                obj.user_qq.focus();
                return false;
            }
            return true;
        }
    </script>

</asp:Content>
