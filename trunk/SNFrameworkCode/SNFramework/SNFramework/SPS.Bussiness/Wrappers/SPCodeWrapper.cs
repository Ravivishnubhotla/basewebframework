
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.ConstClass;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPCodeWrapper : BaseSpringNHibernateWrapper<SPCodeEntity, ISPCodeServiceProxy, SPCodeWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPCodeWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPCodeWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPCodeWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SPCodeWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPCodeWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPCodeWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPCodeWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPCodeWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPCodeWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPCodeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPCodeWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPCodeWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
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

        public int Priority
	    {
	        get
	        {
	            switch (this.MOType)
	            {
                    case DictionaryConst.Dictionary_CodeType_CodeEQ_Key:
                        return 1;
                    case DictionaryConst.Dictionary_CodeType_CodeContain_Key:
                        return 2;
                    case DictionaryConst.Dictionary_CodeType_CodeStartWith_Key:
                        return 3;
                    case DictionaryConst.Dictionary_CodeType_CodeEndWith_Key:
                        return 3;
                    case DictionaryConst.Dictionary_CodeType_CodeRegex_Key:
                        return 3;
                    case DictionaryConst.Dictionary_CodeType_CodeCustom_Key:
                        return 3;
                    case DictionaryConst.Dictionary_CodeType_CodeExpression_Key:
                        return 3;
                    case DictionaryConst.Dictionary_CodeType_CodeMutilCondition_Key:
                        return 5;
                    case DictionaryConst.Dictionary_CodeType_CodeDefault_Key:
                        return 6;                
	            }

	            return 9999;
	        }
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



        private SPClientCodeRelationWrapper clientCodeRelation = null;
        private bool hasGetClientCodeRelation = false;

	    public SPClientCodeRelationWrapper ClientCodeRelation
	    {
	        get
	        {
                if (!hasGetClientCodeRelation)
                {
                    clientCodeRelation = GetRelateClientCodeRelation();
                    hasGetClientCodeRelation = true;
                }
	            return clientCodeRelation;
	        }
	    }


	    public SPClientCodeRelationWrapper GetRelateClientCodeRelation()
	    {
	        List<SPClientCodeRelationWrapper> findClientInCodes = SPClientCodeRelationWrapper.FindAllByCodeID(this);

	        SPClientCodeRelationWrapper spClientCodeRelation = findClientInCodes.Find(p => (p.IsEnable));

            if (spClientCodeRelation != null)
            {
                return spClientCodeRelation;
            }


            SPClientCodeRelationWrapper spDefaultClientCodeRelation = findClientInCodes.Find(p => (p.ClientID.IsDefaultClient.HasValue && p.ClientID.IsDefaultClient.Value));

            if (spDefaultClientCodeRelation != null)
            {
                return spDefaultClientCodeRelation;
            }

            return null;
        }


        public string  CodeAssignedClientName 
        {
            get
            {
                SPClientCodeRelationWrapper clientCodeRelationWrapper = GetRelateClientCodeRelation();

                if (clientCodeRelationWrapper == null)
                    return "未分配";

                if (clientCodeRelationWrapper.ClientID.IsDefaultClient.HasValue && clientCodeRelationWrapper.ClientID.IsDefaultClient.Value)
                    return "未分配";

                return clientCodeRelationWrapper.ClientID.Name;        
            }

        }

        public SPCodeWrapper ParentCode
        {
            get
            {
                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeStartWith_Key || this.MOType == DictionaryConst.Dictionary_CodeType_CodeContain_Key || this.MOType == DictionaryConst.Dictionary_CodeType_CodeEndWith_Key)
                {
                    List<SPCodeWrapper> codes = FindAllByChannelID(this.ChannelID);

                    SPCodeWrapper parentCode = (from rap in codes  where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                                                                     !this.Mo.Equals(rap.Mo) && this.Mo.Contains(rap.Mo))
                                                orderby rap.Mo.Length
                                                                                select rap).FirstOrDefault();

                    if (parentCode == null)
                        return this;

                    return parentCode;
                }
                else
                {
                    return this;
                }
            }
        }

	    public string AssignedClientName
	    {
	        get
	        {
                if (ClientCodeRelation == null)
                    return  "";
                else
                    return  ClientCodeRelation.ClientID.Name;
	        }
	    }

	    public string MoCode
        {
            get
            {
                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeDefault_Key)
                    return "默认指令";


                if (string.IsNullOrEmpty(this.Mo))
                    return "";

                string spcode = "空缺";

                if (!string.IsNullOrEmpty(this.SPCode))
                    spcode = this.SPCode;



                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeEQ_Key)
                    return this.Mo + " (精准) 到 " + spcode;

                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeContain_Key)
                    return "包含" + this.Mo + " (模糊) 到 " + spcode;

                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeStartWith_Key)
                    return this.Mo + " (模糊) 到 " + spcode;

                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeEndWith_Key)
                    return "结尾" + this.Mo + " (模糊) 到 " + spcode;

                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeRegex_Key)
                    return "正则" + this.Mo + " (模糊) 到 " + spcode;

                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeCustom_Key)
                    return "自定义" + this.Mo + " (模糊) 到 " + spcode;

                return this.Mo + " " + this.SPCode;
            }
        }

        public static List<SPCodeWrapper> GetAvaiableCodeForClient(SPChannelWrapper spChannelWrapper, SPSClientWrapper spsClientId)
        {
            List<SPCodeWrapper> spCodes = FindAllByChannelID(spChannelWrapper);

            return
                spCodes.FindAll(
                    p =>
                    (!p.IsDiable && p.MOType != DictionaryConst.Dictionary_CodeType_CodeDefault_Key && ((p.ClientCodeRelation==null) || (p.ClientCodeRelation != null &&
                     p.ClientCodeRelation.ClientID.Id != spsClientId.Id))));



        }
    }
}
