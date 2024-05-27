using LibraryApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ReadersController : ControllerBase
{
    private readonly IReadersService _readerService;

    public ReadersController(IReadersService readersService)
    {
        _readerService = readersService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Readers readers)
    {
        var existingReader = await _readerService.Get(readers.ReaderId);

        if (existingReader is not null)
        {
            return Conflict();
        }

        await _readerService.Add(readers);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Readers>> Get(Guid id)
    {
        var book = await _readerService.Get(id);

        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Readers newReader)
    {
        if (id != newReader.ReaderId)
        {
            return BadRequest();
        }

        var existingReader = await _readerService.Get(id);

        if (existingReader is null)
        {
            return NotFound();
        }

        await _readerService.Update(newReader);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await _readerService.Get(id);

        if (book is null)
        {
            return NotFound();
        }

        await _readerService.Delete(id);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<Readers>>> GetAll()
    {
        return Ok(await _readerService.GetAll());
    }

    [HttpGet("{id:guid}/loanings")]
    public async Task<ActionResult<List<Books>>> GetLoaningBooksOfReader(Guid id)
    {
        var client = await _readerService.Get(id);

        if (client is null)
        {
            return NotFound();
        }

        return Ok(await _readerService.GetLoaningBooksOfReader(id));
    }
}
