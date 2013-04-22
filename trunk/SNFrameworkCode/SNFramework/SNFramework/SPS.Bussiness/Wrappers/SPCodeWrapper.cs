
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Code;
using SPS.Bussiness.ConstClass;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPCodeWrapper : BaseSpringNHibernateWrapper<SPCodeEntity, ISPCodeServiceProxy, SPCodeWrapper, int>  
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

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
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

        public static SPCodeWrapper FindById(int id)
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


	    public static void QuickAddCode(SPCodeWrapper spCodeWrapper, string subCode)
	    {
	        bool hasSubCode = !string.IsNullOrEmpty(subCode);

	        businessProxy.QuickAddCode(spCodeWrapper.entity, hasSubCode, subCode);
	    }

        public bool CheckIsMatchSPCode(string spcode)
        {
            return spcode.ToLower().Equals(this.SPCode.ToLower());
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

	    private bool CheckIsMatchCode(string mo)
        {
            switch (this.MOType)
            {
                case DictionaryConst.Dictionary_CodeType_CodeEQ_Key:
                    if(this.IsMatchCase.HasValue && this.IsMatchCase.Value)
                        return mo.Equals(this.Mo);
                    return mo.ToLower().Equals(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeContain_Key:
                    if (this.IsMatchCase.HasValue && this.IsMatchCase.Value)
                        return mo.Contains(this.Mo);
                    return mo.ToLower().Contains(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeStartWith_Key:
                    if (this.IsMatchCase.HasValue && this.IsMatchCase.Value)
                        return mo.StartsWith(this.Mo);
                    return mo.ToLower().StartsWith(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeEndWith_Key:
                    if (this.IsMatchCase.HasValue && this.IsMatchCase.Value)
                        return mo.EndsWith(this.Mo);
                    return mo.ToLower().EndsWith(this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeRegex_Key:
                    if (this.IsMatchCase.HasValue && this.IsMatchCase.Value)
                        return Regex.IsMatch(mo, this.Mo);
                    return Regex.IsMatch(mo.ToLower(), this.Mo.ToLower());
                case DictionaryConst.Dictionary_CodeType_CodeCustom_Key:
                    if (this.IsMatchCase.HasValue && this.IsMatchCase.Value)
                    {
                        return Regex.IsMatch(mo, this.Mo.Replace("*", "[S]*").Replace("?", "[S]{1}"));
                    }
                    string newRegCommandCode = this.Mo.ToLower().Replace("*", "[S]*").Replace("?", "[S]{1}");
                    return Regex.IsMatch(mo.ToLower(), newRegCommandCode, RegexOptions.IgnoreCase);
                //case DictionaryConst.di:
                //    return Regex.IsMatch(mo.ToLower(), newRegCommandCode, RegexOptions.IgnoreCase);
                case DictionaryConst.Dictionary_CodeType_CodeDefault_Key:
                    return true;
            }
            return false;
        }

        public bool CheckIsMatchCode(string mo, string spcode, string province, string city)
        {
            bool codeIsMatch = CheckIsMatchCode(mo);

            if (codeIsMatch && this.LimitProvince.HasValue && this.LimitProvince.Value)
            {
                if (!string.IsNullOrEmpty(this.LimitProvinceArea))
                {
                    List<string> limitProvinceAreaList = new List<string>(this.LimitProvinceArea.Split((",").ToArray(), StringSplitOptions.None));

                    codeIsMatch = limitProvinceAreaList.Contains(province);
                }
                else
                {
                    codeIsMatch = false;
                }
            }
            return codeIsMatch;
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
                List<SPCodeWrapper> codes = FindAllByChannelID(this.ChannelID);

                return GetParentCode(codes);
            }
        }

        //public List<SPCodeWrapper> GetAllSubCode()
        //{
        //    List<SPCodeWrapper> allSubCodes = new List<SPCodeWrapper>();

        //    List<SPCodeWrapper> spCodes = FindAllByChannelID(this.ChannelID);

        //    foreach (SPCodeWrapper spCodeWrapper in spCodes)
        //    {
        //        if(spCodeWrapper.Id==this.Id)
        //        {
        //            allSubCodes.Add(spCodeWrapper);
        //        }
        //    }

        //    return allSubCodes;
        //}

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
                    return this.ChannelID.Name+"-默认指令";


                if (string.IsNullOrEmpty(this.Mo))
                    return "";

                string spcode = "空缺";

                if (!string.IsNullOrEmpty(this.SPCode))
                    spcode = this.SPCode;

                string moCode = string.Empty;
 
                if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeEQ_Key)
                    moCode = this.Mo + " (精准) 到 " + spcode;
                else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeContain_Key)
                    moCode = "包含" + this.Mo + " (模糊) 到 " + spcode;
                else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeStartWith_Key)
                    moCode = this.Mo + " (模糊) 到 " + spcode;
                else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeEndWith_Key)
                    moCode =  "结尾" + this.Mo + " (模糊) 到 " + spcode;
                else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeRegex_Key)
                    moCode =  "正则" + this.Mo + " (模糊) 到 " + spcode;
                else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeCustom_Key)
                    moCode = "自定义" + this.Mo + " (模糊) 到 " + spcode;
                else
                    moCode = this.Mo + " " + this.SPCode;

                string provinceLimit = "";

                if (this.LimitProvince.HasValue && this.LimitProvince.Value)
                {
                    provinceLimit += "--限省(" + this.LimitProvinceArea +")";
                }

                return  moCode + provinceLimit;
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

        public SPCodeWrapper GetParentCode(List<SPCodeWrapper> codes)
	    {
            SPCodeWrapper parentCode;

            if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeStartWith_Key)
            {
                parentCode = (from rap in codes
                              where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                                                                 !this.Mo.Equals(rap.Mo) && this.Mo.StartsWith(rap.Mo))
                              orderby rap.Mo.Length
                              select rap).FirstOrDefault();

                if (parentCode == null)
                    return this;

                return parentCode;
            }
            else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeEndWith_Key)
            {
                parentCode = (from rap in codes
                              where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                                !this.Mo.Equals(rap.Mo) && this.Mo.EndsWith(rap.Mo))
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

	    public List<SPCodeWrapper> GetAllSubCode(List<SPCodeWrapper> allcodes)
	    {
	        List<SPCodeWrapper> subCodes;

            if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeStartWith_Key)
            {
                SPCodeWrapper fcode = (from rap in allcodes
                                 where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                        !this.Mo.Equals(rap.Mo) && rap.Mo.StartsWith(this.Mo))
                                 orderby rap.Mo.Length
                                 select rap).FirstOrDefault();

                if (fcode==null)
                {
                    return new List<SPCodeWrapper>();
                }

                subCodes = (from rap in allcodes
                            where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                   !this.Mo.Equals(rap.Mo) && rap.Mo.StartsWith(this.Mo) && rap.Mo.Length == fcode.Mo.Length)
                            orderby rap.Mo.Length
                            select rap).ToList();

                return subCodes;
            }
            else if (this.MOType == DictionaryConst.Dictionary_CodeType_CodeEndWith_Key)
            {
                SPCodeWrapper fcode = (from rap in allcodes
                                       where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                              !this.Mo.Equals(rap.Mo) && rap.Mo.EndsWith(this.Mo))
                                       orderby rap.Mo.Length
                                       select rap).FirstOrDefault();

                if (fcode == null)
                {
                    return new List<SPCodeWrapper>();
                }


                subCodes = (from rap in allcodes
                              where (rap.ChannelID.Id == this.ChannelID.Id && rap.SPCode == this.SPCode &&
                                                !this.Mo.Equals(rap.Mo) && rap.Mo.EndsWith(this.Mo) && rap.Mo.Length == fcode.Mo.Length)
                              orderby rap.Mo.Length
                            select rap).ToList();

                return subCodes;
            }
            else
            {
                return new List<SPCodeWrapper>();
            }
	    }

        public static List<SPCodeWrapper> FindAllByChannelIDAndClientIDAndMoAndSpNumber(int? channelID, int? clientID, string mo, string spcode)
        {
            return ConvertToWrapperList(businessProxy.FindAllByChannelIDAndClientIDAndMoAndSpNumber(channelID, clientID, mo, spcode));
        }

	    public List<PhoneLimitAreaAssigned> PhoneLimitAreas
	    {
	        get
	        {
                List<PhoneLimitAreaAssigned> phoneLimitAreas = new List<PhoneLimitAreaAssigned>();

                if (!string.IsNullOrEmpty(this.LimitProvinceArea))
                {
                    try
                    {
                        phoneLimitAreas = SerializeUtil.JsonDeserialize<List<PhoneLimitAreaAssigned>>(this.LimitProvinceArea);
                    }
                    catch
                    {
                    }
                }

	            return phoneLimitAreas;
	        }
	    }
    }
}
