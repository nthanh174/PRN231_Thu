using AutoMapper;
using CodeFirst;
using CodeFirst.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace CodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository bookRepository = new BookRepository();
        private IMapper mapper;

        public BookController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> books = bookRepository.GetAll();
            List<BookDTO> BookDTO = mapper.Map<List<BookDTO>>(books);
            return Ok(BookDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = bookRepository.Get(id);
            if (book == null) return NotFound("Book not found!");
            BookDTO bookDTO = mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }

        [HttpGet("find-by-keyword")]
        public IActionResult FindByKeyword(string keyword)
        {
            List<Book> books = bookRepository.FindByKeyword(keyword);
            List<BookDTO> booksDTO = mapper.Map<List<BookDTO>>(books);
            return Ok(booksDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDTO);
                bookRepository.Insert(book);
                return Created(Request.GetDisplayUrl(), bookDTO);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDTO bookDTO)
        {
            if (id != bookDTO.Id) return BadRequest("Cannot update id of the book");
            var book = bookRepository.Get(id);
            if (book == null) return NotFound("Book not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Book bookUpdate = mapper.Map<Book>(bookDTO);
            bookUpdate.Id = bookDTO.Id;
            bookRepository.Update(bookUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = bookRepository.Get(id);
            if (book == null) return NotFound("Book not found!");
            bookRepository.Delete(id);
            return NoContent();
        }
    }
}
