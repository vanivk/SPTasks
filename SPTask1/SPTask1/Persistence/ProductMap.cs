using MongoDB.Bson.Serialization;
using SPTask1.Models;

namespace SPTask1.Persistence
{
    public class BookMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Book>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Author).SetIsRequired(true);
                map.MapMember(x => x.BookName).SetIsRequired(true);
                map.MapMember(x => x.Price).SetIsRequired(true);

            });
        }
    }
}