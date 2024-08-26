using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Data
{
    public class APIDbContext : DbContext
    {
        //public DbSet<Cliente> Clientes { get; set; }

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
