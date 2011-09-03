// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Spring.Transaction.Interceptor;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables")]
    public interface ISystemDictionaryServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemDictionaryEntity>, ISystemDictionaryServiceProxyDesigner
    {
        [OperationContract]
        IList<SystemDictionaryEntity> GetDictionaryByGroupCode(string groupCode);
        [OperationContract]
        string ParseDictionaryValueByGroupCodeAndKey(string groupCode, string key);
        List<SystemDictionaryEntity> FindAllByGroupIdAndOrder();
        void PatchAdd(string groupCode, bool hasValue, string categoryItems);
    }

    public partial class SystemDictionaryServiceProxy : ISystemDictionaryServiceProxy
    {
        public IList<SystemDictionaryEntity> GetDictionaryByGroupCode(string groupCode)
        {
            SystemDictionaryGroupEntity groupEntity =
                this.DataObjectsContainerIocID.SystemDictionaryGroupDataObjectInstance.FindByCode(groupCode);

            return this.SelfDataObj.GetDictionaryByGroupID(groupEntity);
        }

        public string ParseDictionaryValueByGroupCodeAndKey(string groupCode, string key)
        {
            SystemDictionaryGroupEntity groupEntity =
    this.DataObjectsContainerIocID.SystemDictionaryGroupDataObjectInstance.FindByCode(groupCode);

            SystemDictionaryEntity dictionaryEntity = this.SelfDataObj.GetDictionaryByGroupIDAndKey(groupEntity,
                                                                                                         key);
            if(dictionaryEntity==null)
                return key;
            else
                return dictionaryEntity.SystemDictionaryValue;
        }

 

        public List<SystemDictionaryEntity> FindAllByGroupIdAndOrder()
        {
            return this.SelfDataObj.FindAllByGroupIdAndOrder();
        }

        [Transaction(ReadOnly = false)]
        public void PatchAdd(string groupCode, bool hasValue, string categoryItems)
        {
            SystemDictionaryGroupEntity groupEntity =
this.DataObjectsContainerIocID.SystemDictionaryGroupDataObjectInstance.FindByCode(groupCode);

            int orderIndex = 0;

            orderIndex = FindMaxOrderByGroup(groupEntity);

            List<string> items = new List<string>();

            if (!string.IsNullOrEmpty(categoryItems))
            {
                string[] arrays = categoryItems.Trim().Replace("\r\n", "\n").Replace("\n", "@").Split('@');

                foreach (string line in arrays)
                {
                    if (!string.IsNullOrEmpty(line.Trim()))
                    {
                        items.Add(line);
                    }
                }
            }

            foreach (string item in items)
            {
                orderIndex++;

                string key = "";

                string value = "";

                if(hasValue)
                {
                    key = item.Split('|')[0];
                    value = item.Split('|')[1];
                }
                else
                {
                    key = item;
                    value = item;                    
                }

                SystemDictionaryEntity obj = new SystemDictionaryEntity();

                obj.SystemDictionaryGroupID = groupEntity;
                obj.SystemDictionaryKey = key;
                obj.SystemDictionaryValue = value;
                if (item.Split('|').Length>2)
                {
                    obj.SystemDictionaryCode = item.Split('|')[2];
                }
                else
                {
                    obj.SystemDictionaryCode = value;
                }
                obj.SystemDictionaryDesciption = "";
                obj.SystemDictionaryOrder = orderIndex;
                obj.SystemDictionaryIsEnable = true;
                obj.SystemDictionaryIsSystem = false;

                this.DataObjectsContainerIocID.SystemDictionaryDataObjectInstance.Save(obj);

            }
        }

        public int FindMaxOrderByGroup(SystemDictionaryGroupEntity groupID)
        {
            SystemDictionaryEntity systemDictionary = this.SelfDataObj.FindMaxOrderItemByGroupID(groupID);

            if (systemDictionary == null)
                return 0;

            if (systemDictionary.SystemDictionaryOrder == null)
                return 0;

            return systemDictionary.SystemDictionaryOrder.Value;
        }
    }
}