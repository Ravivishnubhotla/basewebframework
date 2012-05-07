using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SLHotSpot.Web
{
    /// <summary>
    /// Summary description for HotSpotWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HotSpotWebService : System.Web.Services.WebService
    {

 
 

        public string GetRootUrl()
        {
            HttpContext context = HttpContext.Current;

            if (context == null)
                return "";

            string rootUrl = "";

            if (context.Request.Url.Port == 80)
                rootUrl = string.Format("{0}://{1}/{0}{2}", context.Request.Url.Scheme,
                                     context.Request.Url.Host, context.Request.ApplicationPath);
            else
            {
                rootUrl = string.Format("{0}://{1}:{2}{3}", context.Request.Url.Scheme,
                                 context.Request.Url.Host,
                                 context.Request.Url.Port, context.Request.ApplicationPath);
            }




            return rootUrl;
        }

        [WebMethod]
        public void SaveShopMallFloorHotspotData(ShopMallFloorHotspotData shopMallFloorHotspot,List<ROSHotSpot> rosHotSpots)
        {
            DataSet dsDataSet = GetHotSpotInfoByFloorNo(shopMallFloorHotspot.ShopMallNo,
                                                           shopMallFloorHotspot.ShopMallFloorNo); 

            //List<string> delHotspots = new List<string>();

            foreach (DataRow dr in dsDataSet.Tables[0].Rows)
            {
                string seatNo = dr["SeatNo"].ToString();

                if(!rosHotSpots.Exists(p=>(p.SeatNO.ToLower()==seatNo.ToLower())))
                {
                   DelHotspots(shopMallFloorHotspot.ShopMallNo,
                                shopMallFloorHotspot.ShopMallFloorNo, seatNo);
                }
            }
            
            
            foreach (ROSHotSpot rosHotSpot in rosHotSpots)
            {
                DataSet dsHotspotdata = GetHotSpotInfoByNo(shopMallFloorHotspot.ShopMallNo,
                                                           shopMallFloorHotspot.ShopMallFloorNo, rosHotSpot.SeatNO);

                if(dsHotspotdata.Tables[0].Rows.Count>0)
                {
                    UpdateHotSpot(shopMallFloorHotspot.ShopMallNo,
                                  shopMallFloorHotspot.ShopMallFloorNo, rosHotSpot.SeatNO, rosHotSpot);
                }
                else
                {
                    InsertHotSpot(shopMallFloorHotspot.ShopMallNo,
                                 shopMallFloorHotspot.ShopMallFloorNo, rosHotSpot.SeatNO, rosHotSpot);                   
                }

            }



        }

        private void DelHotspots(string shopMallNo, string shopMallFloorNo, string seatNo)
        {
            string sql =
                @"Delete from [dbo].HotSpot where [SeatNo] =@SeatNo and [ShopMallNo]=@ShopMallNo and [FloorNo]=@FloorNo";


            SqlParameter[] parameters = {  
			BuildStringSqlParameter("@SeatNo", SqlDbType.NVarChar,100,seatNo) 
			,BuildStringSqlParameter("@ShopMallNo", SqlDbType.NVarChar,100,shopMallNo) 
			,BuildStringSqlParameter("@FloorNo", SqlDbType.NVarChar,100,shopMallFloorNo) 
		};
            SqlHelper.ExecuteNonQuery(cnnstring, CommandType.Text, sql, parameters);
        }

        private void InsertHotSpot(string shopMallNo, string shopMallFloorNo, string shopNo, ROSHotSpot rosHotSpot)
        {
            string sql =
                @"INSERT INTO [dbo].HotSpot
		(
			[SeatNo]
			,[HotspotInfo]
			,[ShopMallNo]
			,[FloorNo]
		) 
		VALUES
        (
			@SeatNo
			,@HotspotInfo
			,@ShopMallNo
			,@FloorNo
		) ";

		SqlParameter[] parameters = {  
			BuildStringSqlParameter("@SeatNo", SqlDbType.NVarChar,100,shopNo) 
			,BuildNoStringSqlParameter("@HotspotInfo",SqlDbType.NText ,JsonConvert.SerializeObject(rosHotSpot)) 
			,BuildStringSqlParameter("@ShopMallNo", SqlDbType.NVarChar,100,shopMallNo) 
			,BuildStringSqlParameter("@FloorNo", SqlDbType.NVarChar,100,shopMallFloorNo) 
		};
		    SqlHelper.ExecuteNonQuery(cnnstring, CommandType.Text, sql, parameters);
        }

        private void UpdateHotSpot(string shopMallNo, string shopMallFloorNo, string shopNo, ROSHotSpot rosHotSpot)
        {
            string sql =
                @"Update [dbo].HotSpot set [HotspotInfo] = @HotspotInfo where [SeatNo] =@SeatNo and [ShopMallNo]=@ShopMallNo and [FloorNo]=@FloorNo";
 

            SqlParameter[] parameters = {  
			BuildStringSqlParameter("@SeatNo", SqlDbType.NVarChar,100,shopNo) 
			,BuildNoStringSqlParameter("@HotspotInfo",SqlDbType.NText ,JsonConvert.SerializeObject(rosHotSpot)) 
			,BuildStringSqlParameter("@ShopMallNo", SqlDbType.NVarChar,100,shopMallNo) 
			,BuildStringSqlParameter("@FloorNo", SqlDbType.NVarChar,100,shopMallFloorNo) 
		};
            SqlHelper.ExecuteNonQuery(cnnstring, CommandType.Text, sql, parameters);
        }

        public DataSet GetHotSpotInfoByFloorNo(string shopMallNo, string floorNo)
        {
            string sql = @"SELECT [HotSpotId],[SeatNo],[HotspotInfo],[ShopMallNo],[FloorNo] FROM  [dbo].[HotSpot]";

            sql += string.Format(" where [ShopMallNo] = '{0}' and [FloorNo] = '{1}'   ", shopMallNo, floorNo);

            return SqlHelper.ExecuteDataset(cnnstring, CommandType.Text, sql);
        }

        public DataSet GetHotSpotInfoByNo(string shopMallNo, string floorNo, string seatNo)
        {
            string sql = @"SELECT [HotSpotId],[SeatNo],[HotspotInfo],[ShopMallNo],[FloorNo] FROM  [dbo].[HotSpot]";

            sql += string.Format(" where [ShopMallNo] = '{0}' and [FloorNo] = '{1}' and [SeatNo] ='{2}'  ", shopMallNo, floorNo, seatNo);

            return SqlHelper.ExecuteDataset(cnnstring, CommandType.Text, sql);
        }


        public static List<BrandCompetitionScoreResult> GetBrandCompetitionScoreResult(string shopMallNo, string floorNo,string shopBrandInfoDatas)
        {
            List<RosShopInfo> shopDatas = HotSpotWebService.LoadShopData(shopMallNo, floorNo, true);

            List<ShopBrandInfo> oldshopBrandInfos = new List<ShopBrandInfo>();

            foreach (RosShopInfo shopInfo in shopDatas)
            {
                ShopBrandInfo shopBrandInfo = new ShopBrandInfo();
                shopBrandInfo.SeatNo = shopInfo.SeatNO;
                shopBrandInfo.BrandName = shopInfo.ShopBrandInfo;
                oldshopBrandInfos.Add(shopBrandInfo);
            }
 
            List<BrandCompetitionScore> oldbrandCompetitionScores = CaculateBrandCompetitionScore(shopMallNo, floorNo, oldshopBrandInfos);

            List<ShopBrandInfo> newshopBrandInfos = null;

            List<BrandCompetitionScore> newbrandCompetitionScores = null;

            if(!string.IsNullOrEmpty(shopBrandInfoDatas))
            {
                newshopBrandInfos = JsonConvert.DeserializeObject<List<ShopBrandInfo>>(shopBrandInfoDatas);

                newbrandCompetitionScores  = CaculateBrandCompetitionScore(shopMallNo, floorNo, newshopBrandInfos);
            }

            List<BrandCompetitionScoreResult> brandCompetitionScoreResults = new List<BrandCompetitionScoreResult>();

            foreach (BrandCompetitionScore brandCompetitionScoreResult in oldbrandCompetitionScores)
            {
                BrandCompetitionScoreResult brandCompetition = new BrandCompetitionScoreResult();

                brandCompetition.BrandName = brandCompetitionScoreResult.BrandName;
                brandCompetition.OldCompetitionScore = brandCompetitionScoreResult.CompetitionScore;

                if(newbrandCompetitionScores!=null)
                {
                    BrandCompetitionScore newBrandCompetitionScore =
                        newbrandCompetitionScores.Find(p => (p.BrandName == brandCompetition.BrandName));

                    brandCompetition.NewCompetitionScore = newBrandCompetitionScore.CompetitionScore;
                }
                else
                {
                    brandCompetition.NewCompetitionScore = brandCompetitionScoreResult.CompetitionScore;
                }

                brandCompetitionScoreResults.Add(brandCompetition);
            }

            return brandCompetitionScoreResults;

        }

        public static List<BrandCompetitionScore> CaculateBrandCompetitionScore(string shopMallNo, string floorNo, List<ShopBrandInfo> shopBrandInfos)
        {
            string sql = "select a.*,b.ShopMallAreaID,b.ShopMallAreaName,b.ShopMallBigAreaID,b.ShopMallBigAreaName,b.ShopMallCityCode,b.ShopMallCityName,b.ShopMallProvinceCode,b.ShopMallProvinceName,b.ShopMallTownCode,b.ShopMallTownName from ITMall a left join A_ShopMall b on a.ShopMallNo = b.ShopMallNo";

            sql += string.Format(" where a.ShopMallNo = '{0}' and FloorName = '{1}' order by a.SeatNo ", shopMallNo, floorNo.Substring(0, 2));

            DataSet ds = SqlHelper.ExecuteDataset(cnnstring, CommandType.Text, sql);

            List<BrandData> allBrandData = BrandData.GetAllBrandInfos();

            List<BrandCompetitionScore> brandCompetitions = new List<BrandCompetitionScore>();

            double allCount = shopBrandInfos.Count;

            foreach (BrandData brandData in allBrandData)
            {
                double brandCount = shopBrandInfos.Count(p => (p.BrandName.ToLower() == brandData.Name.ToLower()));
 
                brandCompetitions.Add(new BrandCompetitionScore() { BrandName = brandData.Name, CompetitionScore = brandCount*100d /allCount  });
            }

            return brandCompetitions;
        }

        [WebMethod]
        public ShopMallFloorHotspotData LoadShopMallLayoutData(string shopMallNo, string floorNo)
        {
            ShopMallFloorHotspotData shopMallFloorHotspotData = new ShopMallFloorHotspotData();

            shopMallFloorHotspotData.ShopMallNo = shopMallNo;
            shopMallFloorHotspotData.ShopMallFloorNo = floorNo;
            shopMallFloorHotspotData.ImageUrl = GetRootUrl() + "Images/" + string.Format("{0}_{1}-3.png", shopMallNo, floorNo);

            shopMallFloorHotspotData.Brands = BrandData.GetAllBrandInfos();
            
            shopMallFloorHotspotData.ShopInfos = new List<RosShopInfo>();

            string sql = "select a.*,b.ShopMallAreaID,b.ShopMallAreaName,b.ShopMallBigAreaID,b.ShopMallBigAreaName,b.ShopMallCityCode,b.ShopMallCityName,b.ShopMallProvinceCode,b.ShopMallProvinceName,b.ShopMallTownCode,b.ShopMallTownName from ITMall a left join A_ShopMall b on a.ShopMallNo = b.ShopMallNo";

            sql += string.Format(" where a.ShopMallNo = '{0}' and FloorName = '{1}' order by a.SeatNo ", shopMallNo, floorNo.Substring(0,2));

            DataSet ds = SqlHelper.ExecuteDataset(cnnstring, CommandType.Text, sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count ; i++)
            {
                string brand = ds.Tables[0].Rows[i]["Brand"].ToString();

                string shopType = ds.Tables[0].Rows[i]["ShopType"].ToString();

                string seatNO = ds.Tables[0].Rows[i]["SeatNO"].ToString();

                if (!shopMallFloorHotspotData.ShopInfos.Exists(p => (p.SeatNO.ToLower() == seatNO.ToLower())))
                {
                    RosShopInfo rosShopInfo = new RosShopInfo(ds.Tables[0].Rows[i], shopType);
 ;
                    shopMallFloorHotspotData.ShopInfos.Add(rosShopInfo);
                }
            }

            return shopMallFloorHotspotData;
        }

        private static SqlParameter BuildStringSqlParameter(string parameterName, SqlDbType dbType, int size, string parameterValue)
        {
            SqlParameter sqlParameter = new SqlParameter(parameterName, dbType, size);

            sqlParameter.Value = parameterValue;

            return sqlParameter;
        }

        private static SqlParameter BuildNoStringSqlParameter(string parameterName, SqlDbType dbType, string parameterValue)
        {
            SqlParameter sqlParameter = new SqlParameter(parameterName, dbType);

            sqlParameter.Value = parameterValue;

            return sqlParameter;
        }

        public const string cnnstring = "Data Source=(local);initial catalog=ThinkROS;user id=sa;password=admP@$$w0rd";

        public static List<RosShopInfo> LoadShopData(string shopMallNo, string floorNo, bool allBrandInfo)
        {
            string sql = @"select a.*,h.HotspotInfo,b.ShopMallAreaID,b.ShopMallAreaName,b.ShopMallBigAreaID,b.ShopMallBigAreaName,b.ShopMallCityCode,b.ShopMallCityName,b.ShopMallProvinceCode,b.ShopMallProvinceName,b.ShopMallTownCode,b.ShopMallTownName 
from ITMall a left join A_ShopMall b on a.ShopMallNo = b.ShopMallNo
 inner join dbo.HotSpot h on h.SeatNo = a.SeatNo and h.ShopMallNo = a.ShopMallNo and h.FloorNo = a.FloorName+'_0'";

            sql += string.Format(" where a.ShopMallNo = '{0}' and FloorName = '{1}' order by a.SeatNo ", shopMallNo, floorNo.Substring(0, 2));

            DataSet ds = SqlHelper.ExecuteDataset(cnnstring, CommandType.Text, sql);

            List<RosShopInfo> shopInfos = new List<RosShopInfo>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //loop through rows
            {
                string brand = ds.Tables[0].Rows[i]["Brand"].ToString();

                string shopType = ds.Tables[0].Rows[i]["ShopType"].ToString();

                string seatNO = ds.Tables[0].Rows[i]["SeatNO"].ToString();

                if (!allBrandInfo && (brand != "ThinkPad" || shopType != "品牌"))
                {
                    continue;
                }
 
                if (!shopInfos.Exists(p => (p.SeatNO.ToLower() == seatNO.ToLower())))
                {
                    RosShopInfo rosShopInfo = new RosShopInfo(ds.Tables[0].Rows[i], shopType);

                    rosShopInfo.HotSpotInfo = JsonConvert.DeserializeObject<ROSHotSpot>(ds.Tables[0].Rows[i]["HotspotInfo"].ToString());
                    ;
                    shopInfos.Add(rosShopInfo);
                }
            }

            shopInfos.Sort();

            return shopInfos;
        }
 
    }
}
