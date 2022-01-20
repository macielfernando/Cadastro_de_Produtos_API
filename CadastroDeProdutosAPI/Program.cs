using CadastroDeProdutosAPI.Contexto;
using CadastroDeProdutosAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Server=localhostSQLEXPRESS01;Database=master;Trusted_Connection=True"));


builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();

app.MapPost("AdicionarCategoria", async (Categoria categoria, Contexto contexto) =>
{
     contexto.Categoria.Add(categoria);
     await contexto.SaveChangesAsync();
});

app.MapPost("ExcluirCategoria/{id}", async (int id, Contexto contexto) =>
{
    var categoriaExcluir = await contexto.Categoria.FirstOrDefaultAsync(p => p.Id == id);
    if (categoriaExcluir != null)
    {
        contexto.Categoria.Remove(categoriaExcluir);
        await contexto.SaveChangesAsync();
    }
});

app.MapPost("ListarCategoria", async (Contexto contexto) =>
{
    return await contexto.Categoria.ToListAsync();
   
});

app.MapPost("ObterCategoria/{id}", async (int id, Contexto contexto) =>
{
  return await contexto.Categoria.FirstOrDefaultAsync(p => p.Id == id);
   
});


app.UseSwaggerUI();
app.Run();
