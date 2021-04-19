using SPTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        public string GetBookCount(string author);
    }
}
