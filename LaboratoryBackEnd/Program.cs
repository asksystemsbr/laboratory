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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringSQL = builder.Configuration.GetConnectionString("ConnectionSQL");
builder.Services.AddDbContext<APIDbContext>(x => x.UseSqlServer(
    connectionStringSQL
    )
);


#region Permitir CORS Vue
// Adiciona servi�os ao container.
builder.Services.AddControllersWithViews();

// Configura��o do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
        builder.WithOrigins("http://localhost:8080", "https://agreeable-plant-0a420b20f.5.azurestaticapps.net") //mudar aqui para o endere�o do front
               .AllowAnyHeader()
               .AllowAnyMethod()
               .WithExposedHeaders("Content-Disposition"));
});
#endregion

builder.Services.AddControllers();

//configura��o JWT
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
            Console.WriteLine("Falha na autentica��o: " + context.Exception.Message);
            return Task.CompletedTask;
        }
    };
});
//fim configura��o JWT

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanWrite", policy => policy.Requirements.Add(new DynamicPermissionRequirement("Write")));
    options.AddPolicy("CanRead", policy => policy.Requirements.Add(new DynamicPermissionRequirement("Read")));
});

// Registra o handler de autoriza��o
builder.Services.AddSingleton<IAuthorizationHandler, DynamicPermissionHandler>();

//Registro de reposit�rios
builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
builder.Services.AddScoped<IRepository<StatusCliente>, Repository<StatusCliente>>();
builder.Services.AddScoped<IRepository<Boleto>, Repository<Boleto>>();

//registro de servi�os
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IBoletoService, BoletoService>();

// Configura��o do servi�o de logger
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Especificar o endpoint JSON do Swagger
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome do seu API v1");
        // Definir o prefixo da URL para acessar o Swagger UI
        //-para funcionar com ip
        //c.RoutePrefix = string.Empty; // Acessar a interface do Swagger na raiz do endere�o base
    });

    #region Permitir CORS Vue
    app.UseDeveloperExceptionPage();
    #endregion
}


#region Permitir CORS Vue
app.UseStaticFiles();

app.UseRouting();

// Aplica o CORS usando a pol�tica configurada
app.UseCors("AllowSpecificOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Adiciona o middleware de tratamento de erros padr�o do ASP.NET Core
app.UseExceptionHandler("/error");

// Adiciona o middleware de logging de erro personalizado
app.UseCustomExceptionHandler();

app.UseMiddleware<ErrorLoggingMiddleware>();

app.Run();
