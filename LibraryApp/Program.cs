using LibraryApp;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog(
    config =>
        config
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("log.txt"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
    options.UseLazyLoadingProxies();
}, ServiceLifetime.Singleton);

builder.Services.AddSingleton<IReadersService, ReadersService>();
builder.Services.AddSingleton<IBooksService, BooksService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();