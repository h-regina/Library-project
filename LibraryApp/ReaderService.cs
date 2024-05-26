using LibraryShared;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
    public class ReaderService : IReadersService
    {
        private readonly LibraryContext _context;
        private readonly ILogger<ReaderService> _logger;

        public ReaderService(ILogger<ReaderService> logger, LibraryContext context)
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
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while adding reader");
                throw ex;
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
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while removing reader");
                throw ex;
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
            catch(Exception ex)
            {
                _logger.LogError("An error occurred while querying the readers");
                throw ex;
            }
        }

        public async Task<List<Readers>> GetAll()
        {
            return await _context.Readers.ToListAsync();
        }

        public async Task<List<Loaning>> GetLoaningBooksOfReader(Guid ReaderId)
        {
           throw new NotImplementedException();
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
            catch( Exception ex )
            {
                _logger.LogError("An error occurred while updating reader");
                throw ex;
            }
        }
    }
}
