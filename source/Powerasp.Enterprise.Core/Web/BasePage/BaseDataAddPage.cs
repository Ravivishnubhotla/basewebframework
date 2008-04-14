using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Powerasp.Enterprise.Core.BaseManager.Web;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public abstract class BaseDataAddPage<DomainType> : BaseDataManagePage
    {
        protected abstract void SaveData(DomainType obj);

        protected void SaveCurrentData(DomainType domain)
        {
            try
            {
                SaveData(domain);
                WebMessageBox.ShowOperationOkMessage("操作成功", "用户添加" + this.GetModuleNameCn() + "成功", this.ResolveUrl(this.GetListPageUrl()));
            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception e1)
            {
                WebMessageBox.ShowOperationFailedMessageAndHistoryBack("操作失败", "添加" + GetModuleNameCn() + "失败，错误原因：" + e1.Message);
            }
        }


        protected void ReturnListPage()
        {
            this.Response.Redirect(GetListPageUrl());
        }
    }

}
