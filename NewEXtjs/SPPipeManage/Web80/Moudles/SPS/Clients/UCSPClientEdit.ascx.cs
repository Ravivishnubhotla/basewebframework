﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = System.Web.UI.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientEdit")]
    public partial class UCSPClientEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientWrapper obj = SPClientWrapper.FindById(id);

                if (obj != null)
                {
                    if (obj.Name!=null)
                        this.txtName.Text = obj.Name.ToString();
                    if (obj.Description != null)
                        this.txtDescription.Text = obj.Description.ToString();


                    if (obj.SPClientGroupID != null)
                        this.hidClientGroupID.Text = obj.SPClientGroupID.Id.ToString();

                    hidId.Text = id.ToString();


                    winSPClientEdit.Show();

                }
                else
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPClient_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientWrapper obj = SPClientWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.SPClientGroupID = SPClientGroupWrapper.FindById(Convert.ToInt32(this.cmbClientGroupID.SelectedItem.Value));

                SPClientWrapper.Update(obj);

                winSPClientEdit.Hide();
                
            }
            catch (Exception ex)
                {
                    Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                    Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                    return;
                }

 
        }
    }
}
 