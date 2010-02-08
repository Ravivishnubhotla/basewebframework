using System;
using System.Web.UI;
using Coolite.Ext.Web;
using PhotoAblum.Web.Codes.Bussiness.Wrappers;
using ScriptManager=Coolite.Ext.Web.ScriptManager;

namespace PhotoAblum.Web.Admin.Moudles.Ablums
{
    public partial class AblumListPage : Page
    {
        #region IAblumsListPage Members

        [AjaxMethod]
        public void Reload()
        {
            storeAblums.DataSource = AlbumWrapper.FindAll();
            storeAblums.DataBind();
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            Server.ScriptTimeout = 1000;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            Reload();
        }

        protected void storeAblums_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            Reload();
        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                //throw new Exception("11111");
                AlbumWrapper.DeleteByID(id);                

                ScriptManager.AjaxSuccess = true;

                Ext.Msg.Alert("操作成功", "成功删除相册", new JFunction { Fn = "RefreshData" }).Show();
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }
    }
}