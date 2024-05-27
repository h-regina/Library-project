using LibraryApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Books books)
        {
            var existingBook = await _booksService.Get(books.InventoryNumber);

            if (existingBook is not null)
            {
                return Conflict();
            }

            await _booksService.Add(books);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Books>> Get(Guid id)
        {
            var book = await _booksService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Books newBook)
        {
            if (id != newBook.InventoryNumber)
            {
                return BadRequest();
            }

            var existingBook = await _booksService.Get(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            await _booksService.Update(newBook);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _booksService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.Delete(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> GetAll()
        {
            return Ok(await _booksService.GetAll());
        }
    }
}
