using System.Data;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto;
using Controller = PrimeiroProjeto.Controller;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Criação da instância do Controller, passando a instância de Db
Controller control = new Controller(new Db());

app.MapGet("/app/version", () => "0.0.1");

app.MapGet("/app/login", async (context) =>
{
    // Atualização para chamar o método GetQueryAsync
    var result = await control.GetQueryAsync("SELECT * FROM USER;");
    await context.Response.WriteAsJsonAsync(result);
});

app.Run();
