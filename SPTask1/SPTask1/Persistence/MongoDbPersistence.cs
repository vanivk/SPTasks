using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace SPTask1.Persistence
{
    public static class MongoDbPersistence
    {
		[System.Obsolete]
		public static void Configure()
        {
            BookMap.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
           
        }
    }
}
