using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Interfaces
{
	public interface IMongoContext : IDisposable
	{
		void AddCommand(Func<Task> func);
		Task<int> SaveChanges();
		IMongoCollection<T> GetCollection<T>(string name);

		public IAggregateFluent<TDocument> Aggregate<TDocument>();
	}
}
