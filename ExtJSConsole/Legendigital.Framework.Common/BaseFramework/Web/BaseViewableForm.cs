using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Legendigital.Framework.Common.BaseFramework.Web
{
    public abstract class BaseViewableForm<TBussinessObjectType> : BaseUserControl
    {
        protected abstract void ShowReturnMessage(string title, Color fontColor);

        protected abstract TBussinessObjectType FindDataByID(int id);

        protected abstract string IDQueryStringName();

        public int DataID
        {
            get
            {
                int dataID = 0;

                string idValue = this.Request.QueryString[IDQueryStringName()];

                if (!string.IsNullOrEmpty(idValue))
                    int.TryParse(idValue, out dataID);

                if (dataID == 0)
                {
                    if (this.ViewState[IDQueryStringName()] == null)
                        this.ViewState[IDQueryStringName()] = 0;
                    int.TryParse(this.ViewState[IDQueryStringName()].ToString(), out dataID);
                }

                return dataID;
            }
            set
            {
                this.ViewState[IDQueryStringName()] = value;             
            }
        }

        public const string ContextDataItemKey = "CurrentDataObjert";

        public TBussinessObjectType DataObject
        {
            get
            {
                if (this.Context.Items[ContextDataItemKey] == null)
                    return default(TBussinessObjectType);
                else
                    return (TBussinessObjectType)this.Context.Items[ContextDataItemKey];
            }
            set
            {
                this.Context.Items[ContextDataItemKey] = value;
            }
        }

        protected bool LoadData()
        {
            int id = DataID;
            if (id == 0)
            {
                ShowReturnMessage("operation failure: Can not get id.", Color.Red);

                return false;
            }

            TBussinessObjectType obj = FindDataByID(id);

            if (obj == null)
            {
                ShowReturnMessage("operation failure: This record is not existed.", Color.Red);
            }
            else
            {
                DataObject = obj;
            }

            return (obj!=null);
        }
    }
}