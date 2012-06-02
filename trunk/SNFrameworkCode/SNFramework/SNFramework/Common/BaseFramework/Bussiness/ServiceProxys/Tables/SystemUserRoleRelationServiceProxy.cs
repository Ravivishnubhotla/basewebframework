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


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables")]
    public interface ISystemUserRoleRelationServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemUserRoleRelationEntity, int>, ISystemUserRoleRelationServiceProxyDesigner
    {
        [OperationContract]
        List<SystemUserEntity> GetUserByRole(SystemRoleEntity systemRoleEntity);
    }

    public partial class SystemUserRoleRelationServiceProxy : ISystemUserRoleRelationServiceProxy
    {

        public List<SystemUserEntity> GetUserByRole(SystemRoleEntity systemRoleEntity)
        {

            List<SystemUserEntity> usersId = new List<SystemUserEntity>();


            //roleTypes.Add(systemRoleEntity.RoleType);

            //List < SystemUserRoleRelationEntity > systemUserRoleRelationEntities= this.SelfDataObj.GetUserByRole(systemRoleEntity);

            foreach (SystemUserRoleRelationEntity list in this.FindAll())
            {

                if (Convert.ToInt32(list.RoleID.RoleType) >= Convert.ToInt32(systemRoleEntity.RoleType) && list.UserID.UserLoginID != SystemUserWrapper.DEV_USER_ID)

                    usersId.Add(list.UserID);

            }

            return usersId;

        }
    }
}
