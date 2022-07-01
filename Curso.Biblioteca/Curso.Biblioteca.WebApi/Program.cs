using Curso.Biblioteca.Aplicacion.Servicios;
using Curso.Biblioteca.Aplicacion.ServiciosImpl;
using Curso.Biblioteca.Dominio.Repositorios;
using Curso.Biblioteca.Infraestructura;
using Curso.Biblioteca.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BibliotecaDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ILibroRepositorio, LibroRepositorio>();
builder.Services.AddTransient<IEditorialRepositorio, EditorialRepositorio>();
builder.Services.AddTransient<IAutorRepositorio, AutorRepositorio>();


builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IEditorialService, EditorialService>();
builder.Services.AddTransient<IAutorService, AutorService>();

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
