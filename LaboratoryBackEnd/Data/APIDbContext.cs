using LaboratoryBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Data
{
    public class APIDbContext : DbContext
    {        
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<OperationLog> OperationLogs { get; set; }
        public DbSet<Cliente> Client { get; set; }
        public DbSet<StatusCliente> StatusClient { get; set; }


        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
