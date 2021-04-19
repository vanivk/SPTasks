using MongoDB.Bson;
using MongoDB.Driver;
using SPTask1.Interfaces;
using SPTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoContext context) : base(context)
        {

        }

		public string GetBookCount(string author)
		{
			//var result = Context.Aggregate<Book>()
			//				 .Match(e => e.BookName.ToLower() == author.ToLower())
			//				 .Group(e => e.BookName, g => new { Key = g.Key, Count = g.Count() })
			//				 .ToList();

			var mongoCollection = Context.GetCollection<BsonDocument>("Book");
			var match = new BsonDocument
			{
				{
					"$match",
					new BsonDocument {{"Author", author}}
				}
			};

            var group = new BsonDocument
                {
                    { "$group",
                        new BsonDocument
                            {
                                { "_id", new BsonDocument
                                             {
                                                 {
                                                     "Author","$Author"
                                                 }
                                             }
                                },
                                {
                                    "Count", new BsonDocument
                                                 {
                                                     {
                                                         "$sum", 1
                                                     }
                                                 }
                                }
                            }
                  }
                };

            PipelineDefinition<BsonDocument, BsonDocument> pipeline = new[] { match, group };

            var listOfDocs = new List<BsonDocument>();
            using (var cursor = mongoCollection.Aggregate(pipeline))
            {
                while (cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        listOfDocs.Add(document);
                    }
                }
            }


            return listOfDocs.ToJson();

        }
	}
}
