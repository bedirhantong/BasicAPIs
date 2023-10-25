using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")]int id)
        {
            /*
             LINQ kullandık
            - SingleOrDefault eğer varsa kendisi yoksa null döndürüyor.
             */
            var book = ApplicationContext.
                Books.Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            if (book is null) {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody()] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest(); // 400 
                }

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpPut("{int:id}")]
        public IActionResult ChangeBook([FromRoute(Name="id")] int id,[FromBody]Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest(); // 400 
                }

                ApplicationContext.Books.
                    Where(b => b.Equals(book).;
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
