using Business.Services;
using Business.Services.IServices;
using DAL;
using DAL.Repositories;
using DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolBankSystemDbContext>(options => options.UseSqlServer("TEST"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService));
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
