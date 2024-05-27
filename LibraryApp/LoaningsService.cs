using LibraryApp.Shared;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp
{
    public class LoaningsService : ILoaningsService
    {
        private readonly LibraryContext _context;
        private readonly ILogger<LoaningsService> _logger;

        public LoaningsService(LibraryContext context, ILogger<LoaningsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Add(Loaning loaning)
        {
            try
            {
                await _context.Loanings.AddRangeAsync(loaning);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Loaning added: @{LoaningDate}", loaning.LoaningDate);
            }
            catch
            {
                _logger.LogError("An error occurred while adding loaning");
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var loaning = await Get(id);
                _context.Loanings.Remove(loaning);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Loaning removed: @{LoaningId}", loaning);
            }
            catch
            {
                _logger.LogError("An error occurred while removing loaning");
                throw;
            }
        }

        public async Task<Loaning> Get(Loaning loaning)
        {
            try
            {
                var loanings = await _context.Loanings.FindAsync(loaning);
                _logger.LogInformation("Loanings retrieved: {@Loanings}", loanings);
                return loanings;
            }
            catch
            {
                _logger.LogError("An error occurred while querying the loanings");
                throw;
            }
        }

        public async Task Update(Loaning newLoaning)
        {
            try
            {
                var loaning = await Get(newLoaning);
                loaning.LoaningDate = newLoaning.LoaningDate;
                loaning.ReturnDate = newLoaning.ReturnDate;
                loaning.InventoryNumber = newLoaning.InventoryNumber;

                await _context.SaveChangesAsync();
            }
            catch
            {
                _logger.LogError("An error occurred while updating loaning");
                throw;
            }
        }

        public async Task<Loaning> Get(Guid id)
        {
            try
            {
                var loaning = await _context.Loanings.FindAsync(id);
                _logger.LogInformation("Loanings retrieved: {@Loanings}", loaning);
                return loaning;
            }
            catch
            {
                _logger.LogError("An error occurred while querying the Loanings");
                throw;
            }
        }
    }
}
