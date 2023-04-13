using API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDbContext(builder.Configuration.GetConnectionString("SchoolBankSystem"));
builder.Services.AddRepositories();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServices();
builder.Services.AddAppAuthentication();
builder.Services.AddAppAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseHttpsRedirection();*/

app.UseCors("CORS");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
