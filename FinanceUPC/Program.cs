using FinanceUPC.API.Shared.Persistence.Repositories;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Persistences.Repositories;
using FinanceUPC.Functions.Services;
using FinanceUPC.Security.Authorization.Handlers.Implementations;
using FinanceUPC.Security.Authorization.Handlers.Interfaces;
using FinanceUPC.Security.Authorization.Middleware;
using FinanceUPC.Security.Authorization.Settings;
using FinanceUPC.Security.Domain.Repositories;
using FinanceUPC.Security.Domain.Services;
using FinanceUPC.Security.Persistence.Repositories;
using FinanceUPC.Security.Services;
using FinanceUPC.Shared.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ACME Learning Center API",
        Description = "ACME Learning Center Web Services",
        Contact = new OpenApiContact
        {
            Name = "ACME.studio",
            Url = new Uri("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "ACME RemodelKing resources License",
            Url = new Uri("https://acme-learning.com/license")
        } 
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "Jwt",
        Description = "Jwt Authorization header using Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            Array.Empty<string>()

        }
    });
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// CORS Service addition
builder.Services.AddCors();

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learning Injection Configuration
builder.Services.AddScoped<IMethodsService, MethodsService>();
builder.Services.AddScoped<IMethodsRepository, MethodsRepository>();
builder.Services.AddScoped<IGermanService, GermanService>();
builder.Services.AddScoped<IGermanRepository, GermanRepository>();
builder.Services.AddScoped<IConversionService, ConversionsService>();
builder.Services.AddScoped<IConversionsRepository, ConversionsRepository>();
builder.Services.AddScoped<IValuesRepository, ValuesRepository>();
builder.Services.AddScoped<IValuesService, ValuesService>();
// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(FinanceUPC.Security.Mapping.ModelToResourceProfile), 
    typeof(FinanceUPC.Security.Mapping.ResourceToModelProfile)
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure CORS

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();