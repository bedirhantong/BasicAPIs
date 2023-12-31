﻿using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

           


        // Id URI üzerinden yani endpointten geleceği için böyle yaptık.
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name="id")] int id,
            [FromBody]Book book)
        {
            // kitap listede var mı yok mu?
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound(); // 404
            }

            // id ile parametre book id eşleşmiyorsa!
            if (id != book.Id)
            {
                return BadRequest("Given id and the book id does not match!"); // 400
            }

            ApplicationContext.Books.Remove(entity);
            // her ihtimale karşı id değerlerini eşitleyelim
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);

            return Ok(book);
        }





        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")]int id) {
            // kitap listede var mı yok mu?
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Book with the {id} could not found"
                }); 
            }

            ApplicationContext.Books.Remove(entity);

            return StatusCode(201, "Succesfully Removed");
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }




        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check existance
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if(entity is null) {
                return NotFound(); // 404 
            }

            bookPatch.ApplyTo(entity);
            return NoContent(); //204
        }


    }
}
