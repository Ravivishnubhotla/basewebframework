using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SPS.Bussiness.Code;

namespace SPS.Bussiness.Cache
{
    public class PhoneAreaNOSQLCache : IPhoneAreaCache
    {
        public PhoneArea GetPhoneAreaByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;
            if (phoneNumber.Length < 7)
                return null;
            var client = new MongoClient(NOSQLConfig.NoSQL_DBConnString);

            var server = client.GetServer();

            var database = server.GetDatabase(NOSQLConfig.NoSQL_DbName);

            var collection = database.GetCollection<PhoneArea>(NOSQLConfig.NoSQL_CollectionName);

            var query = Query<PhoneArea>.EQ(e => e.PhonePrefix, phoneNumber.Substring(0, 7));

            return collection.FindOne(query);
        }
    }
}
