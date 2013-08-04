using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSScriptLibrary;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    public partial class SPChannelRuleCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;



            if (ChannleID <= 0)
                return;

            SPChannelWrapper channel = SPChannelWrapper.FindById(ChannleID);

            this.lblRuleTxt.Text = channel.FuzzyCommand + ".txt";

            bool hasRule = channel.HasConvertRule.HasValue && channel.HasConvertRule.Value;

            btnCreateRule.Disabled = true;
            btnUpdate.Disabled = true;
            btnTestRule.Disabled = true;

            if (!hasRule)
            {
                this.lblRuleStatus.Text = "该通道不包含规则。";
            }
            else
            {
                string status = "";

                string rulePath = this.Server.MapPath("~/ConvertRules/" + channel.FuzzyCommand + ".txt");

                if (!File.Exists(rulePath))
                {
                    status = "规则文件不存在。";
                    btnCreateRule.Disabled = false;
                }
                else
                {
                    btnUpdate.Disabled = false;

                    object ruleCache = this.Cache[SPRecievedHandler.spsRules + channel.FuzzyCommand];

                    if (ruleCache == null)
                    {
                        status = "规则缓存失效。";
                    }
                    else
                    {
                        btnTestRule.Disabled = false;
                        status = "规则生效。";
                    }
                }

                this.lblRuleStatus.Text = "该通道包含规则,当前规则状态：" + status;
            }




        }


        public int ChannleID
        {
            get
            {
                if (this.Request.QueryString["ChannleID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleID"]);
            }

        }

        protected void onTestRule(object sender, AjaxEventArgs e)
        {
            if (ChannleID <= 0)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：ChannelID不存在！";
                return;
            }

            try
            {
                SPChannelWrapper channel = SPChannelWrapper.FindById(ChannleID);

                object ruleCache = this.Cache[SPRecievedHandler.spsRules + channel.FuzzyCommand];

                string urlParams = this.txtUlr.Text.Trim();

                Uri url = new Uri(channel.InterfaceUrl + urlParams);

                Hashtable hb = new Hashtable();

                NameValueCollection col = GetQueryString(url.Query);

                foreach (string key in col.AllKeys)
                {
                    hb.Add(key.ToLower(), col[key]);
                }

                MethodDelegate processMethod = ruleCache as MethodDelegate;

                processMethod(hb);

                this.txtResult.Text = JsonConvert.SerializeObject(hb);

                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                this.txtResult.Text = "转换失败，错误信息：" + ex.Message;
            }



        }

        public static NameValueCollection GetQueryString(string queryString)
        {
            return GetQueryString(queryString, null, true);
        }

        public static string MyUrlDeCode(string str, Encoding encoding)
        {
            if (encoding == null)
            {
                Encoding utf8 = Encoding.UTF8;
                //首先用utf-8进行解码                      
                string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
                //将已经解码的字符再次进行编码. 
                string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
                if (str == encode)
                    encoding = Encoding.UTF8;
                else
                    encoding = Encoding.GetEncoding("gb2312");
            }
            return HttpUtility.UrlDecode(str, encoding);
        }


        public static NameValueCollection GetQueryString(string queryString, Encoding encoding, bool isEncoded)
        {
            queryString = queryString.Replace("?", "");
            NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(queryString))
            {
                int count = queryString.Length;
                for (int i = 0; i < count; i++)
                {
                    int startIndex = i;
                    int index = -1;
                    while (i < count)
                    {
                        char item = queryString[i];
                        if (item == '=')
                        {
                            if (index < 0)
                            {
                                index = i;
                            }
                        }
                        else if (item == '&')
                        {
                            break;
                        }
                        i++;
                    }
                    string key = null;
                    string value = null;
                    if (index >= 0)
                    {
                        key = queryString.Substring(startIndex, index - startIndex);
                        value = queryString.Substring(index + 1, (i - index) - 1);
                    }
                    else
                    {
                        key = queryString.Substring(startIndex, i - startIndex);
                    }
                    if (isEncoded)
                    {
                        result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
                    }
                    else
                    {
                        result[key] = value;
                    }
                    if ((i == (count - 1)) && (queryString[i] == '&'))
                    {
                        result[key] = string.Empty;
                    }
                }
            }
            return result;
        }

        protected void onUpdateCache(object sender, AjaxEventArgs e)
        {
            if (ChannleID <= 0)
                return;

            SPChannelWrapper channel = SPChannelWrapper.FindById(ChannleID);

            this.Cache.Remove(SPRecievedHandler.spsRules + channel.FuzzyCommand);

            string rulePath = this.Server.MapPath("~/ConvertRules/" + channel.FuzzyCommand + ".txt");

            if (!File.Exists(rulePath))
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + "文件‘" + rulePath + "’不存在！";
                return;
            }

            try
            {
                this.Cache.Insert(SPRecievedHandler.spsRules + channel.FuzzyCommand, SPRecievedHandler.GetMethodDelegateFromRecName(rulePath, this.Context), new CacheDependency(rulePath));

                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message + "！";
                return;
            }



        }

        protected void onCreateRule(object sender, AjaxEventArgs e)
        {
            if (ChannleID <= 0)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：ChannelID不存在！";
                return;
            }

            try
            {
                SPChannelWrapper channel = SPChannelWrapper.FindById(ChannleID);

                string rulePath = this.Server.MapPath("~/ConvertRules/" + channel.FuzzyCommand + ".txt");

                if (!File.Exists(rulePath))
                {
                    File.WriteAllText(rulePath, "");
                }

                this.btnCreateRule.Disabled = true;

                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message + "！";
                throw;
            }
        }
    }
}