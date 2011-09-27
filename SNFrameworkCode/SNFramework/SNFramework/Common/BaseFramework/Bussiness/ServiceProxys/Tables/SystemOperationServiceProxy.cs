// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Spring.Transaction.Interceptor;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables")]
    public interface ISystemOperationServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemOperationEntity>, ISystemOperationServiceProxyDesigner
    {
        void QuickPatchAddOperation(SystemResourcesEntity entity);
    }

    public partial class SystemOperationServiceProxy : ISystemOperationServiceProxy
    {
        private List<SystemOperationEntity> GetAllCommonOperation(SystemResourcesEntity entity)
        {
            List<SystemOperationEntity> operationEntities = new List<SystemOperationEntity>();
            operationEntities.Add(GetDefaultSystemOperationEntity(entity,"����","Add","����",false,false,true,false,false,1));
            operationEntities.Add(GetDefaultSystemOperationEntity(entity, "�༭", "Edit", "�༭", false, false, true, false, false, 2));
            operationEntities.Add(GetDefaultSystemOperationEntity(entity, "ɾ��", "Delete", "ɾ��", false, false, true, false, false, 3));
            operationEntities.Add(GetDefaultSystemOperationEntity(entity, "�б�", "List", "�б�", false, false, true, false, false, 4));
            operationEntities.Add(GetDefaultSystemOperationEntity(entity, "��ӡ", "Print", "��ӡ", false, false, true, false, false, 5));
            operationEntities.Add(GetDefaultSystemOperationEntity(entity, "����", "Export", "����", false, false, true, false, false, 6));
            return operationEntities;
        }

        private SystemOperationEntity GetDefaultSystemOperationEntity(SystemResourcesEntity entity, string name, string code, string description, bool isCanMutilOperation, bool isCanSingleOperation, bool isInListPage, bool isInSinglePage, bool isSystemOperation, int operationOrder)
        {
            SystemOperationEntity systemOperationEntity = new SystemOperationEntity();
            systemOperationEntity.OperationNameEn = code;
            systemOperationEntity.OperationNameCn = name;
            systemOperationEntity.OperationDescription = description;
            systemOperationEntity.IsCanMutilOperation = isCanMutilOperation;
            systemOperationEntity.IsCanSingleOperation = isCanSingleOperation;
            systemOperationEntity.IsInListPage = isInListPage;
            systemOperationEntity.IsInSinglePage = isInSinglePage;
            systemOperationEntity.IsEnable = true;
            systemOperationEntity.IsSystemOperation = isSystemOperation;
            systemOperationEntity.OperationOrder = operationOrder;
            systemOperationEntity.ResourceID = entity;
            return systemOperationEntity;
        }


        [Transaction(ReadOnly = false)]
        public void QuickPatchAddOperation(SystemResourcesEntity entity)
        {
            List<SystemOperationEntity> allCommonOperation = GetAllCommonOperation(entity);

            foreach (SystemOperationEntity systemOperationEntity in allCommonOperation)
            {
                SystemOperationEntity findOp = this.SelfDataObj.FindByResourceAndCode(entity,
                                                                                      systemOperationEntity.
                                                                                          OperationNameEn);

                if(findOp==null)
                {
                    this.SelfDataObj.Save(systemOperationEntity);
                }
                else
                {
                    CopyValue(findOp, systemOperationEntity);
                    this.SelfDataObj.Update(findOp);
                }
            }
        }

        private void CopyValue(SystemOperationEntity findOp, SystemOperationEntity systemOperationEntity)
        {
            findOp.OperationNameEn = systemOperationEntity.OperationNameEn;
            findOp.OperationNameCn = systemOperationEntity.OperationNameCn;
            findOp.OperationDescription = systemOperationEntity.OperationDescription;
            findOp.IsCanMutilOperation = systemOperationEntity.IsCanMutilOperation;
            findOp.IsCanSingleOperation = systemOperationEntity.IsCanSingleOperation;
            findOp.IsInListPage = systemOperationEntity.IsInListPage;
            findOp.IsInSinglePage = systemOperationEntity.IsInSinglePage;
            findOp.IsEnable = systemOperationEntity.IsEnable;
            findOp.IsSystemOperation = systemOperationEntity.IsSystemOperation;
            findOp.OperationOrder = systemOperationEntity.OperationOrder;
            findOp.ResourceID = systemOperationEntity.ResourceID;
        }
    }
}