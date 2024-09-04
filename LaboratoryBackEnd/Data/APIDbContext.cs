using LaboratoryBackEnd.Model;
using LaboratoryBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace LaboratoryBackEnd.Data
{
    public class APIDbContext : DbContext
    {
        #region Logs
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<OperationLog> OperationLogs { get; set; }
        #endregion

        public DbSet<Boleto> Boleto { get; set; }
        
        public DbSet<Contas> Contas { get; set; }
        public DbSet<ContasCategorias> CategoriasContas { get; set; }
        public DbSet<ContasHistorico> ContasHistorico { get; set; }
        
        public DbSet<ContasSubCategorias> ContasSubCategorias { get; set; }
        
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
