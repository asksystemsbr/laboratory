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

        public DbSet<AgendamentoCabecalho> AgendamentoCabecalho { get; set; }
        public DbSet<AgendamentoDetalhe> AgendamentoDetalhe { get; set; }
        public DbSet<AgendamentoPagamento> AgendamentoPagamento { get; set; }
        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Client { get; set; }
        public DbSet<Contas> Contas { get; set; }
        public DbSet<ContasCategorias> CategoriasContas { get; set; }
        public DbSet<ContasHistorico> ContasHistorico { get; set; }
        public DbSet<ContasSubCategorias> ContasSubCategorias { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<ExameApoio> ExameApoio { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<GrupoUsuario> GruposUsuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<LaboratorioApoio> LaboratorioApoio { get; set; }
        public DbSet<LaboratorioApoioExameApoio> LaboratorioApoioExameApoio { get; set; }
        public DbSet<LaboratorioApoioMateriais> LaboratorioApoioMateriais { get; set; }
        public DbSet<MaterialApoio> MaterialApoio { get; set; }
        public DbSet<MetodoExame> MetodoExame { get; set; }
        public DbSet<MetodosPagamento> MetodosPagamentos { get; set; }
        public DbSet<Modalidade> Modalidade { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<OrcamentoCabecalho> OrcamentoCabecalho { get; set; }
        public DbSet<OrcamentoDetalhe> OrcamentoDetalhe { get; set; }
        public DbSet<OrcamentoPagamento> OrcamentoPagamento { get; set; }
        public DbSet<OrdemDeServico> OrdensDeServicos { get; set; }       
        public DbSet<OrdemServicoEquipamento> OrdensServicosEquipamentos { get; set; }
        public DbSet<OrdemServicoExame> OrdensServicosExames { get; set; }
        public DbSet<OrdemServicoServico> OrdensServicosServicos { get; set; }
        public DbSet<OrdemServicoTecnico> OrdensServicosTecnicos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<Recepcao> Recepcoes { get; set; }
        public DbSet<RecipienteAmostra> RecipienteAmostra { get; set; }
        public DbSet<RotinaExame> RotinaExame { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<StatusCliente> StatusClient { get; set; }
        public DbSet<StatusCliente> StatusClientes { get; set; }
        public DbSet<StatusExame> StatusExames { get; set; }
        public DbSet<StatusOs> StatusOs { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<TabelaPreco> TabelaPreco { get; set; }
        public DbSet<TabelaPrecoItens> TabelaPrecoItens { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<TipoPermissao> TipoPermissao { get; set; }
        public DbSet<TipoSolicitante> TipoSolicitante { get; set; }
        public DbSet<UF> UF { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRecepcao> UsuariosRecepcoes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaCatagoria> EmpresaCatagoria { get; set; }
        public DbSet<RecepcaoConvenioPlano> RecepcaoConvenioPlanos { get; set; }
        public DbSet<RecepcaoEspecialidadeExame> RecepcaoEspecialidadeExame { get; set; }

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}