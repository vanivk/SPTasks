using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Models
{
	public class Book
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Author { get; set; }

        public Book(string name, decimal price, string author)
        {
            BookName = name;
            Price = price;
            Author = author;
        }

        public Book(string id, string name, decimal price, string author)
        {
            Id = id;
            BookName = name;
            Price = price;
            Author = author;
        }
    }
}
