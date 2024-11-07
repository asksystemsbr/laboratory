using LaboratoryBackEnd.Controllers;
using LaboratoryBackEnd.Data;
using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Extensions;
using LaboratoryBackEnd.Middleware;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using LaboratoryBackEnd.Data.Mpas;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringSQL = builder.Configuration.GetConnectionString("ConnectionSQL");
builder.Services.AddDbContext<APIDbContext>(x => x.UseSqlServer(
    connectionStringSQL
    )
);


#region Permitir CORS Next.Js
// Adiciona serviços ao container.
builder.Services.AddControllersWithViews();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
        builder.WithOrigins("http://localhost:3000", "https://nice-hill-0e9fa5e1e-production.westus2.5.azurestaticapps.net") //mudar aqui para o endereço do front
               .AllowAnyHeader()
               .AllowAnyMethod()
               .WithExposedHeaders("Content-Disposition"));
});
#endregion

builder.Services.AddControllers();




//configuração JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTExtensions.jwtSecret)),
        ValidateIssuer = false, // Pode alterar conforme sua necessidade
        ValidateAudience = false // Pode alterar conforme sua necessidade
    };
    // Adicionando o tratamento de eventos
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            // Log successful token validation
            Console.WriteLine("Token validado com sucesso!");
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            // Log the error
            Console.WriteLine("Falha na autenticação: " + context.Exception.Message);
            return Task.CompletedTask;
        }
    };
});
//fim configuração JWT

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanWrite", policy => policy.Requirements.Add(new DynamicPermissionRequirement("Write")));
    options.AddPolicy("CanRead", policy => policy.Requirements.Add(new DynamicPermissionRequirement("Read")));
});

// Registra o handler de autorização
builder.Services.AddSingleton<IAuthorizationHandler, DynamicPermissionHandler>();

//Registro de repositórios em ordem afabética
builder.Services.AddScoped<IRepository<AuditLog>, Repository<AuditLog>>();
builder.Services.AddScoped<IRepository<Boleto>, Repository<Boleto>>();
builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
builder.Services.AddScoped<IRepository<Contas>, Repository<Contas>>();
builder.Services.AddScoped<IRepository<ContasCategorias>, Repository<ContasCategorias>>();
builder.Services.AddScoped<IRepository<ContasCategorias>, Repository<ContasCategorias>>();
builder.Services.AddScoped<IRepository<ContasHistorico>, Repository<ContasHistorico>>();
builder.Services.AddScoped<IRepository<ContasSubCategorias>, Repository<ContasSubCategorias>>();
builder.Services.AddScoped<IRepository<Convenio>, Repository<Convenio>>();
builder.Services.AddScoped<IRepository<Equipamento>, Repository<Equipamento>>();
builder.Services.AddScoped<IRepository<Empresa>, Repository<Empresa>>();
builder.Services.AddScoped<IRepository<EmpresaCatagoria>, Repository<EmpresaCatagoria>>();
builder.Services.AddScoped<IRepository<Especialidade>, Repository<Especialidade>>();
builder.Services.AddScoped<IRepository<Exame>, Repository<Exame>>();
builder.Services.AddScoped<IRepository<Endereco>, Repository<Endereco>>();
builder.Services.AddScoped<IRepository<ExameApoio>, Repository<ExameApoio>>();
builder.Services.AddScoped<IRepository<FormaPagamento>, Repository<FormaPagamento>>();
builder.Services.AddScoped<IRepository<Fornecedor>, Repository<Fornecedor>>();
builder.Services.AddScoped<IRepository<Funcionario>, Repository<Funcionario>>();
builder.Services.AddScoped<IRepository<GrupoUsuario>, Repository<GrupoUsuario>>();
builder.Services.AddScoped<IRepository<LaboratorioApoio>, Repository<LaboratorioApoio>>();
builder.Services.AddScoped<IRepository<LaboratorioApoioMateriais>, Repository<LaboratorioApoioMateriais>>();
builder.Services.AddScoped<IRepository<LaboratorioApoioExameApoio>, Repository<LaboratorioApoioExameApoio>>();
builder.Services.AddScoped<IRepository<MaterialApoio>, Repository<MaterialApoio>>();
builder.Services.AddScoped<IRepository<MetodoExame>, Repository<MetodoExame>>();
builder.Services.AddScoped<IRepository<MetodosPagamento>, Repository<MetodosPagamento>>();
builder.Services.AddScoped<IRepository<Modalidade>, Repository<Modalidade>>();
builder.Services.AddScoped<IRepository<Modulo>, Repository<Modulo>>();
builder.Services.AddScoped<IRepository<OperationLog>, Repository<OperationLog>>();
builder.Services.AddScoped<IRepository<OrdemDeServico>, Repository<OrdemDeServico>>();
builder.Services.AddScoped<IRepository<OrcamentoCabecalho>, Repository<OrcamentoCabecalho>>();
builder.Services.AddScoped<IRepository<OrcamentoDetalhe>, Repository<OrcamentoDetalhe>>();
builder.Services.AddScoped<IRepository<OrcamentoPagamento>, Repository<OrcamentoPagamento>>();
builder.Services.AddScoped<IRepository<OrdemDeServico>, Repository<OrdemDeServico>>();
builder.Services.AddScoped<IRepository<OrdemServicoEquipamento>, Repository<OrdemServicoEquipamento>>();
builder.Services.AddScoped<IRepository<OrdemServicoExame>, Repository<OrdemServicoExame>>();
builder.Services.AddScoped<IRepository<OrdemServicoServico>, Repository<OrdemServicoServico>>();
builder.Services.AddScoped<IRepository<OrdemServicoTecnico>, Repository<OrdemServicoTecnico>>();
builder.Services.AddScoped<IRepository<Pagamento>, Repository<Pagamento>>();
builder.Services.AddScoped<IRepository<Permissao>, Repository<Permissao>>();
builder.Services.AddScoped<IRepository<Plano>, Repository<Plano>>();
builder.Services.AddScoped<IRepository<Recepcao>, Repository<Recepcao>>();
builder.Services.AddScoped<IRepository<RecipienteAmostra>, Repository<RecipienteAmostra>>();
builder.Services.AddScoped<IRepository<RotinaExame>, Repository<RotinaExame>>();
builder.Services.AddScoped<IRepository<Servico>, Repository<Servico>>();
builder.Services.AddScoped<IRepository<Setor>, Repository<Setor>>();
builder.Services.AddScoped<IRepository<Solicitante>, Repository<Solicitante>>();
builder.Services.AddScoped<IRepository<StatusCliente>, Repository<StatusCliente>>();
builder.Services.AddScoped<IRepository<StatusCliente>, Repository<StatusCliente>>();
builder.Services.AddScoped<IRepository<StatusExame>, Repository<StatusExame>>();
builder.Services.AddScoped<IRepository<StatusOs>, Repository<StatusOs>>();
builder.Services.AddScoped<IRepository<StatusPagamento>, Repository<StatusPagamento>>();
builder.Services.AddScoped<IRepository<SubCategoria>, Repository<SubCategoria>>();
builder.Services.AddScoped<IRepository<TabelaPreco>, Repository<TabelaPreco>>();
builder.Services.AddScoped<IRepository<TabelaPrecoItens>, Repository<TabelaPrecoItens>>();
builder.Services.AddScoped<IRepository<Tecnico>, Repository<Tecnico>>();
builder.Services.AddScoped<IRepository<TipoPermissao>, Repository<TipoPermissao>>();
builder.Services.AddScoped<IRepository<TipoSolicitante>, Repository<TipoSolicitante>>();
builder.Services.AddScoped<IRepository<UF>, Repository<UF>>();
builder.Services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
builder.Services.AddScoped<IRepository<UsuarioRecepcao>, Repository<UsuarioRecepcao>>();

builder.Services.AddScoped<IRepository<LaboratorioApoioExameApoio>, Repository<LaboratorioApoioExameApoio>>();
builder.Services.AddScoped<IRepository<LaboratorioApoioMateriais>, Repository<LaboratorioApoioMateriais>>();
builder.Services.AddScoped<IRepository<OperationLog>, Repository<OperationLog>>();
builder.Services.AddScoped<IRepository<GrupoUsuario>, Repository<GrupoUsuario>>();
builder.Services.AddScoped<IRepository<OrdemServicoEquipamento>, Repository<OrdemServicoEquipamento>>();
builder.Services.AddScoped<IRepository<OrdemServicoExame>, Repository<OrdemServicoExame>>();
builder.Services.AddScoped<IRepository<OrdemServicoServico>, Repository<OrdemServicoServico>>();
builder.Services.AddScoped<IRepository<OrdemServicoTecnico>, Repository<OrdemServicoTecnico>>();
builder.Services.AddScoped<IRepository<RecipienteAmostra>, Repository<RecipienteAmostra>>();
builder.Services.AddScoped<IRepository<RotinaExame>, Repository<RotinaExame>>();
builder.Services.AddScoped<IRepository<Endereco>, Repository<Endereco>>();
builder.Services.AddScoped<IRepository<Empresa>, Repository<Empresa>>();
builder.Services.AddScoped<IRepository<RecepcaoConvenioPlano>, Repository<RecepcaoConvenioPlano>>();
builder.Services.AddScoped<IRepository<RecepcaoEspecialidadeExame>, Repository<RecepcaoEspecialidadeExame>>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();







//registro de serviços
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IContasCategoriasService, ContasCategoriasService>();
builder.Services.AddScoped<IContasHistoricoService, ContasHistoricoService>();
builder.Services.AddScoped<IContasService, ContasService>();
builder.Services.AddScoped<IContasSubCategoriasService, ContasSubCategoriasService>();
builder.Services.AddScoped<IConvenioService, ConvenioService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEmpresaCategoriaService, EmpresaCategoriaService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEquipamentoService, EquipamentoService>();
builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();
builder.Services.AddScoped<IExameApoioService, ExameApoioService>();
builder.Services.AddScoped<IExameService, ExameService>();
builder.Services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IGrupoUsuarioService, GrupoUsuarioService>();
builder.Services.AddScoped<ILaboratorioApoioService, LaboratorioApoioService>();
builder.Services.AddScoped<ILaboratorioApoioExameApoioService, LaboratorioApoioExameApoioService>();
builder.Services.AddScoped<ILaboratorioApoioMateriaisService, LaboratorioApoioMateriaisService>();
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<IMaterialApoioService, MaterialApoioService>();
builder.Services.AddScoped<IMetodoExameService, MetodoExameService>();
builder.Services.AddScoped<IMetodosPagamentoService, MetodosPagamentoService>();
builder.Services.AddScoped<IModalidadeService, ModalidadeService>();
builder.Services.AddScoped<IModuloService, ModuloService>();
builder.Services.AddScoped<IOperationLogService, OperationLogService>();
builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();
builder.Services.AddScoped<IOrdemDeServicoService, OrdemDeServicoService>();
builder.Services.AddScoped<IOrdemServicoEquipamentoService, OrdemServicoEquipamentoService>();
builder.Services.AddScoped<IOrdemServicoExameService, OrdemServicoExameService>();
builder.Services.AddScoped<IOrdemServicoServicoService, OrdemServicoServicoService>();
builder.Services.AddScoped<IOrdemServicoTecnicoService, OrdemServicoTecnicoService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();
builder.Services.AddScoped<IPlanoService, PlanoService>();
builder.Services.AddScoped<IRecepcaoService, RecepcaoService>();
builder.Services.AddScoped<IRecipienteAmostraService, RecipienteAmostraService>();
builder.Services.AddScoped<IRotinaExameService, RotinaExameService>();
builder.Services.AddScoped<ISetorService, SetorService>();
builder.Services.AddScoped<ISolicitanteService, SolicianteService>();
builder.Services.AddScoped<IStatusClienteService, StatusClienteService>();
builder.Services.AddScoped<IStatusExameService, StatusExameService>();
builder.Services.AddScoped<IStatusPagamentoService, StatusPagamentoService>();
builder.Services.AddScoped<ISubCategoriaService, SubCategoriaService>();
builder.Services.AddScoped<ITabelaPrecoService, TabelaPrecoService>();
builder.Services.AddScoped<ITabelaPrecoItensService, TabelaPrecoItensService>();
builder.Services.AddScoped<ITipoSolicitanteService, TipoSolicianteService>();
builder.Services.AddScoped<IUFService, UFService>();
builder.Services.AddScoped<IUsuarioRecepcaoService, UsuarioRecepcaoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


builder.Services.AddScoped<ILaboratorioApoioExameApoioService, LaboratorioApoioExameApoioService>();
builder.Services.AddScoped<ILaboratorioApoioMateriaisService, LaboratorioApoioMateriaisService>();
builder.Services.AddScoped<IOperationLogService, OperationLogService>();
builder.Services.AddScoped<IGrupoUsuarioService, GrupoUsuarioService>();
builder.Services.AddScoped<IOrdemServicoEquipamentoService, OrdemServicoEquipamentoService>();
builder.Services.AddScoped<IOrdemServicoExameService, OrdemServicoExameService>();
builder.Services.AddScoped<IOrdemServicoServicoService, OrdemServicoServicoService>();
builder.Services.AddScoped<IOrdemServicoTecnicoService, OrdemServicoTecnicoService>();
builder.Services.AddScoped<IRecipienteAmostraService, RecipienteAmostraService>();
builder.Services.AddScoped<IRotinaExameService, RotinaExameService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IRecepcaoConvenioPlanoService, RecepcaoConvenioPlanoService>();
builder.Services.AddScoped<IRecepcaoEspecialidadeExameService, RecepcaoEspecialidadeExameService>();


builder.Services.AddAutoMapper(typeof(ExameMappingProfile));

// Configuração do serviço de logger
builder.Services.AddScoped<ILoggerService, LoggerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            //Scheme = "oauth2",
            Scheme = "Bearer",
            Name= "Bearer",
            In = ParameterLocation.Header,
        },
        new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Especificar o endpoint JSON do Swagger
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome do seu API v1");
        // Definir o prefixo da URL para acessar o Swagger UI
        //-para funcionar com ip
        //c.RoutePrefix = string.Empty; // Acessar a interface do Swagger na raiz do endereço base
    });

    #region Permitir CORS Vue
    app.UseDeveloperExceptionPage();
    #endregion
}


#region Permitir CORS Vue
app.UseStaticFiles();

app.UseRouting();

// Aplica o CORS usando a política configurada
app.UseCors("AllowSpecificOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Adiciona o middleware de tratamento de erros padrão do ASP.NET Core
app.UseExceptionHandler("/error");

// Adiciona o middleware de logging de erro personalizado
app.UseCustomExceptionHandler();

app.UseMiddleware<ErrorLoggingMiddleware>();

app.Run();
