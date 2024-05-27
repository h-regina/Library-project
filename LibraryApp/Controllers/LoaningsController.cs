using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryApp;
using LibraryApp.Shared;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaningsController : ControllerBase
    {
        private readonly ILoaningsService _loaningService;

        public LoaningsController(ILoaningsService loaningsService)
        {
            _loaningService = loaningsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Loaning loanings)
        {
            var existingLoaning = await _loaningService.Get(loanings.LoaningId);

            if (existingLoaning is not null)
            {
                return Conflict();
            }

            await _loaningService.Add(loanings);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Loaning>> Get(Guid id)
        {
            var loaning = await _loaningService.Get(id);

            if (loaning is null)
            {
                return NotFound();
            }

            return Ok(loaning);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Loaning newLoaning)
        {
            if (id != newLoaning.LoaningId)
            {
                return BadRequest();
            }

            var existingLoaning = await _loaningService.Get(id);

            if (existingLoaning is null)
            {
                return NotFound();
            }

            await _loaningService.Update(newLoaning);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var loaning = await _loaningService.Get(id);

            if (loaning is null)
            {
                return NotFound();
            }

            await _loaningService.Delete(loaning);

            return Ok();
        }

    }   
        
}
