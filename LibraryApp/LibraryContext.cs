using LibraryShared;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) 
        {}

        public LibraryContext() {}

        public virtual DbSet<Readers> Readers { get; set; }

        public virtual DbSet<Books> Books { get; set; } 

        public virtual DbSet<Loaning> Loanings {  get; set; }   
    }
}
