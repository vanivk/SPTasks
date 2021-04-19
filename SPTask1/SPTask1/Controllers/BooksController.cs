using Microsoft.AspNetCore.Mvc;
using SPTask1.Dto;
using SPTask1.Interfaces;
using SPTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTask1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _uow;

        public BooksController(IBookRepository bookRepository, IUnitOfWork uow)
        {
            _bookRepository = bookRepository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _bookRepository.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _bookRepository.GetById(id);

            return Ok(book);
        }

        [HttpGet]
        [Route("GetCount")]
        public ActionResult<dynamic> GetBookCount(string author)
        {
            var product = _bookRepository.GetBookCount(author);

            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] BookDto value)
        {
            var book = new Book(value.BookName, value.Price, value.Author);
            _bookRepository.Add(book);

            // it will be null
            var testbook = await _bookRepository.GetById(book.Id);

            // If everything is ok then:
            await _uow.Commit();

            // The product will be added only after commit
            testbook = await _bookRepository.GetById(book.Id);

            return Ok(testbook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(string id, [FromBody] BookDto value)
        {
            var book = new Book(id, value.BookName, value.Price, value.Author);

            _bookRepository.Update(book);

            await _uow.Commit();

            return Ok(await _bookRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            _bookRepository.Remove(id);

            // it won't be null
            var testbook = await _bookRepository.GetById(id);

            // If everything is ok then:
            await _uow.Commit();

            // not it must by null
            testbook = await _bookRepository.GetById(id);

            return Ok();
        }



    }
}
