// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPAdvertisementServiceProxy.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Data.Tables;
using SPS.Entity.Tables;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace SPS.Bussiness.ServiceProxys.Tables
{
	public interface ISPAdvertisementServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPAdvertisementEntity,int> ,ISPAdvertisementServiceProxyDesigner
    {
	    void TestTransateion();
    }

    internal partial class SPAdvertisementServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPAdvertisementEntity,int>, ISPAdvertisementServiceProxy
    {
        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public void TestTransateion()
        {
            SPAdvertisementEntity spAdvertisement = new SPAdvertisementEntity();

            spAdvertisement.UpperID = null;
            spAdvertisement.Name = "";
            spAdvertisement.Code = "";
            spAdvertisement.ImageUrl = "";
            spAdvertisement.AdPrice = "";
            spAdvertisement.AccountType = "";
            //obj.ApplyStatus = this.txtApplyStatus.Text.Trim();
            spAdvertisement.AdType = "";
            spAdvertisement.AdText = "";
            spAdvertisement.Description = "";
            spAdvertisement.IsDisable = false;
            //obj.AssignedClient = Convert.ToInt32(this.numAssignedClient.Value.Trim());
            spAdvertisement.CreateBy = 25;
            spAdvertisement.CreateAt = System.DateTime.Now;
            spAdvertisement.LastModifyBy = 25;
            spAdvertisement.LastModifyAt = System.DateTime.Now;
            spAdvertisement.LastModifyComment = "�����û���";


            SelfDataObj.Save(spAdvertisement);

 

            SelfDataObj.Delete(spAdvertisement);
        }
    }
}
