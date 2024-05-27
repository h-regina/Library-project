using LibraryApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
    public class ReadersService : IReadersService
    {
        private readonly LibraryContext _context;
        private readonly ILogger<ReadersService> _logger;

        public ReadersService(ILogger<ReadersService> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Add(Readers readers)
        {
            try {
                await _context.Readers.AddRangeAsync(readers);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Reader added: @{ReaderId}", readers.ReaderId);
            }
            catch
            {
                _logger.LogError("An error occurred while adding reader");
                throw;
            }
           
        }

        public async Task Delete(Guid id)
        {
          try
            {
                var reader = await Get(id);
                _context.Readers.Remove(reader);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Reader removed: @{ReaderId}", reader);
            }
            catch
            {
                _logger.LogError("An error occurred while removing reader");
                throw;
            }
        }

        public async Task<Readers> Get(Guid id)
        {
           try
            {
                var reader = await _context.Readers.FindAsync(id);
                _logger.LogInformation("Reader retrieved: {@Readers}", reader);
                return reader;
            }
            catch
            {
                _logger.LogError("An error occurred while querying the readers");
                throw;
            }
        }

        public async Task<List<Readers>> GetAll()
        {
            return await _context.Readers.ToListAsync();
        }

        public async Task<List<Loaning>> GetLoaningBooksOfReader(Guid ReaderId)
        {
           return await _context.Loanings.Where(id => id.ReaderId == ReaderId).ToListAsync();
        }

        public async Task Update(Readers newReader)
        {
           try
            {
                var reader = await Get(newReader.ReaderId);
                reader.Name = newReader.Name;
                reader.Address = newReader.Address;
                reader.BirthDate = newReader.BirthDate;

                await _context.SaveChangesAsync();
            }
            catch
            {
                _logger.LogError("An error occurred while updating reader");
                throw;
            }
        }
    }
}
