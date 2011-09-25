
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.ConstClass;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPCodeWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPCodeWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPCodeWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPCodeWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SPCodeWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPCodeWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPCodeWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPCodeWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPCodeWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SPCodeEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPCodeWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc,pageQueryParams);
        }


        public static List<SPCodeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SPCodeWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

        public static List<SPCodeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public static void QuickAddCode(SPCodeWrapper spCodeWrapper, bool hasSubCode, string subCode)
	    {
	        businessProxy.QuickAddCode(spCodeWrapper.entity, hasSubCode, subCode);
	    }

        public bool CheckIsMatchCode(string mo, string spcode, string province, string city)
        {
            return false;
        }

        public bool CheckIsMatchCode(string mo, string spcode)
        {
            return CheckIsMatchCode(mo) && spcode.ToLower().Equals(this.SPCode.ToLower());
        }

        public bool CheckIsMatchCode(string mo)
        {
            switch (this.MOType)
            {
                case DictionaryConst.Dictionary_CodeType_CodeEQ_Key:
                    return mo.ToLower().Equals(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeContain_Key:
                    return mo.ToLower().Contains(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeStartWith_Key:
                    return mo.ToLower().StartsWith(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeEndWith_Key:
                    return mo.ToLower().EndsWith(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeRegex_Key:
                    return Regex.IsMatch(mo.ToLower(), this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeCustom_Key:
                    string newRegCommandCode = this.Mo.ToLower().Replace("*", "[S]*").Replace("?", "[S]{1}");
                    return Regex.IsMatch(mo.ToLower(), newRegCommandCode, RegexOptions.IgnoreCase);
                //case DictionaryConst.di:
                //    return Regex.IsMatch(mo.ToLower(), newRegCommandCode, RegexOptions.IgnoreCase);
                case DictionaryConst.Dictionary_CodeType_CodeDefault_Key:
                    return true;
            }
            return false;
        }

	    public SPSClientWrapper GetRelateClient()
	    {
	        List<SPClientCodeRelationWrapper> findClientInCodes = SPClientCodeRelationWrapper.FindAllByCodeID(this);

	        SPClientCodeRelationWrapper spClientCodeRelation = findClientInCodes.Find(p => (p.IsEnable));

            if (spClientCodeRelation != null)
                return spClientCodeRelation.ClientID;

            SPClientCodeRelationWrapper spDefaultClientCodeRelation = findClientInCodes.Find(p => (p.ClientID.IsDefaultClient.HasValue && p.ClientID.IsDefaultClient.Value));

            if (spDefaultClientCodeRelation != null)
                return spDefaultClientCodeRelation.ClientID;

	        return null;
	    }
    }
}
