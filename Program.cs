using Microsoft.EntityFrameworkCore;
using MinimalAPiTeste;
using MinimalAPiTeste.Entities;
using MinimalAPiTeste.Routing;
using System;

#region configurando as dependencias de inicialização
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando o DbContext com PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPiTeste");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
#endregion

#region Rotas da Api
app.MapGet("/Users", async (AppDbContext db) =>
{
    return  await UsersRoute.GetUserLog(db);
})
.WithName("Users")
.WithOpenApi();

app.MapPost("/CreateUserLog", async (AppDbContext db, Users_Log user) =>
{
    return await UsersRoute.CreateUserLog(db, user);
}).WithOpenApi();

app.MapPut("/EditUserLog/{id}", async (int id, AppDbContext db, Users_Log user) =>
{
    return await UsersRoute.EditUserLog(db, id, user);

}).WithOpenApi();



app.MapDelete("/DeleteUserLog", async (AppDbContext db, int userID) =>
{
    return await UsersRoute.DeleteUserLog(db, userID);

}).WithOpenApi();




#endregion



app.Run();
