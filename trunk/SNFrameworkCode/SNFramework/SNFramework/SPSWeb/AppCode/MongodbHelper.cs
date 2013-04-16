using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace SPSWeb.AppCode
{
    public class MongodbHelper
    {
        public static void RefreshDbPhoneArea()
        {
            //var connectionString =
            //    "Server=127.0.0.1:27017;connecttimeout=500000;maxlifetime=400000;minpoolsize=10;maxpoolsize=500;";
            //var client = new MongoClient(connectionString);
            //var server = client.GetServer();

            //var database = server.GetDatabase("SPSMongoDb");

            //var collection = database.GetCollection("PhoneArea");

            //List<SystemPhoneAreaWrapper> phoneAreaWrappers = SystemPhoneAreaWrapper.FindAll();

            //int total = phoneAreaWrappers.Count;

            //int i = 0;

            //foreach (SystemPhoneAreaWrapper phoneAreaWrapper in phoneAreaWrappers)
            //{
            //    i++;

            //    var query = Query<PhoneArea>.EQ(e => e.PhonePrefix, phoneAreaWrapper.PhonePrefix);

            //    if (collection.FindOne(query) != null)
            //        continue;

            //    var entity = new PhoneArea()
            //                     {
            //                         PhonePrefix = phoneAreaWrapper.PhonePrefix,
            //                         Province = phoneAreaWrapper.Province,
            //                         City = phoneAreaWrapper.City,
            //                         OperatorType = phoneAreaWrapper.OperatorType,
            //                     };

            //    MongoInsertOptions mongoInsert = new MongoInsertOptions(){WriteConcern = WriteConcern.Unacknowledged};

            //    collection.Save(entity, mongoInsert);
            //}

            

            
        }
    }
}