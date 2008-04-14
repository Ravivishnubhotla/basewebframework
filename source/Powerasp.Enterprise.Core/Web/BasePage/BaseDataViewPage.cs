using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Powerasp.Enterprise.Core.Attribute;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Business;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public abstract class BaseDataViewPage<DomainType> : BaseDataManagePage
    {


        protected int GetID
        {
            get
            {
                try
                {
                    return int.Parse(this.Request.QueryString[GetIDQueryStringKey()]);
                }
                catch
                {
                    return 0;
                }
            }
        }

        protected bool LoadData()
        {
            int id = GetID;
            if (id == 0)
            {
                WebMessageBox.ShowOperationOkMessage("操作失败", "无法获取ID。", this.ResolveUrl(GetListPageUrl()));
                return false;
            }

            object obj = LoadDataByID(id);

            if (obj == null)
            {
                WebMessageBox.ShowOperationOkMessage("操作失败", "该条数据已不存在。", this.ResolveUrl(GetListPageUrl()));
                return false;
            }
            else
            {
                this.Context.Items[GetDataItemContextKey()] = obj;
            }
            return true;
        }

        protected DomainType CurrentDataItem
        {
            get
            {
                if (this.Context.Items[GetDataItemContextKey()] == null)
                    return default(DomainType);
                else
                    return (DomainType)this.Context.Items[GetDataItemContextKey()];
            }
        }

        protected void ReturnListPage()
        {
            this.Response.Redirect(GetListPageUrl());
        }

        protected void GoToEditPage()
        {
            this.Response.Redirect("" + GetEditPageUrl() + "?" + this.GetIDQueryStringKey() + "=" + this.GetID);
        }

        protected void DeleteCurrentObject()
        {
            //添加数据
            try
            {
                DeleteDataByID(this.GetID);
                WebMessageBox.ShowOperationOkMessage("操作成功", "用户删除"+this.GetModuleNameCn()+"成功", this.ResolveUrl(GetListPageUrl()));
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e1)
            {
                WebMessageBox.ShowOperationFailedMessage("操作失败", "用户删除" + this.GetModuleNameCn() + "+失败，错误原因：" + e1.Message, this.ResolveUrl(GetListPageUrl()));
            }
        }



        protected abstract DomainType LoadDataByID(int id);

        protected abstract void DeleteDataByID(int id);



    }
}
