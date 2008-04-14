using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Powerasp.Enterprise.Core.BaseManager.Web;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public abstract class BaseDataEditPage<DomainType> : BaseDataViewPage<DomainType>
    {
        protected abstract void UpdateData(DomainType obj);

        protected void UpdateCurrentData(DomainType domain)
        {
            try
            {
                UpdateData(domain);
                WebMessageBox.ShowOperationOkMessage("操作成功", "用户修改" + this.GetModuleNameCn() + "成功", this.ResolveUrl(this.GetListPageUrl()));
            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception e1)
            {
                WebMessageBox.ShowOperationFailedMessageAndHistoryBack("操作失败", "更新" + GetModuleNameCn() + "失败，错误原因：" + e1.Message);
            }
        }
    }
}