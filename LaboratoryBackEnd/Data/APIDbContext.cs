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

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<GrupoUsuario> GruposUsuarios { get; set; }
        public DbSet<MetodosPagamento> MetodosPagamentos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<OrdemDeServico> OrdensDeServicos { get; set; }
        public DbSet<OrdemServicoEquipamento> OrdensServicosEquipamentos{ get; set; }
        public DbSet<OrdemServicoExame> OrdensServicosExames { get; set; }
        public DbSet<OrdemServicoServico> OrdensServicosServicos { get; set; }
        public DbSet<OrdemServicoTecnico> OrdensServicosTecnicos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Recepcao> Recepcoes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<StatusCliente> StatusClientes { get; set; }
        public DbSet<StatusExame> StatusExames { get; set; }
        public DbSet<StatusOs> StatusOs { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRecepcao> UsuariosRecepcoes { get; set; }


        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
