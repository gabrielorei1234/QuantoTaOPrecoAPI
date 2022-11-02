using Microsoft.EntityFrameworkCore;
using QuantoTaOPrecoAPI.Data;
using QuantoTaOPrecoAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<dbquantotaoprecoContext>(options => options.UseMySql("server=127.0.0.1;database=dbquantotaopreco;user=root;password=root", ServerVersion.Parse("8.0.31-mysql")));
builder.Services.AddScoped<UsuarioService, UsuarioService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
