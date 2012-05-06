using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SLHotSpot.Web
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            List<BrandCompetitionScoreResult> brandCompetitionScoreResults = new List<BrandCompetitionScoreResult>(HotSpotWebService.GetBrandCompetitionScoreResult("M001001", "F1_0", context.Request.Params["shopbrandinfo"]));

 
            DataRecordArray<BrandCompetitionScoreResult> datas = new DataRecordArray<BrandCompetitionScoreResult>(brandCompetitionScoreResults);

            string dataString = JsonConvert.SerializeObject(datas);

            context.Response.ContentType = "text/plain";
            context.Response.Write(dataString);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}