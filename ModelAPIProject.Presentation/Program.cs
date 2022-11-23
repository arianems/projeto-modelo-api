using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ModelAPIProject.Infra.Contracts;
using ModelAPIProject.Infra.Repositories;
using ModelAPIProject.Presentation.Configurations;
using System.Text;
using TokenAPI.Domain.Entities;
using TokenAPI.Infra.Contexts;
using TokenAPI.Infra.Contracts;
using TokenAPI.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "Projeto Web API desenvolvido em .NET 6 com EF Core e banco de dados SQL Server.",
    Contact = new OpenApiContact
    {
        Name = "Ariane Maranha",
        Url = new Uri("https://github.com/arianems")
    }
})); ;


#region Registering the SQLServerContext class

builder.Services.AddDbContext<SQLServerContext>();

#endregion

#region Registering the repositories

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

#endregion

#region Configuring the Authentication and Authorization Services

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(TokenSettings.GetKey()),
            ValidateIssuer = true,
            ValidateAudience = false
        };
    });

builder.Services.AddTransient(map => new TokenSettings());


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
