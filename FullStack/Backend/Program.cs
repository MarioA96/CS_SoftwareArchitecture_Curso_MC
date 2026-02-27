using Aplication.Abstractions;
using Aplication.Brand.UseCases;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Raw API JSON https://localhost:7265/openapi/v1.json
builder.Services.AddOpenApi();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreContext>((options) =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddTransient<IRepository<BrandEntity>, BrandRepository>();
builder.Services.AddTransient<IUseCase<BrandEntity>, BrandUseCase>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("brand", async (IUseCase<BrandEntity> useCase) =>
{
    var brands = await useCase.GetAllAsync();
    return brands;
}).WithName("getbrand");

app.MapPost("brand", async (IUseCase<BrandEntity> useCase, BrandEntity brand) =>
{
    await useCase.AddAsync(brand);
    return Results.Created();
}).WithName("addbrand");

app.MapPut("brand/{id}", async (int id, JsonDocument body, IUseCase<BrandEntity> useCase) =>
{
    try
    {
        var name = body.RootElement.GetProperty("name").GetString();
        var brandEntity = new BrandEntity(id, name!);

        await useCase.UpdateAsync(brandEntity);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

    return Results.NoContent();

}).WithName("updatebrand");

app.MapDelete("brand/{id}", async (int id, IUseCase<BrandEntity> useCase) =>
{

    try
    {
        await useCase.DeleteAsync(id);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

    return Results.NoContent();

}).WithName("deletebrand");

app.MapGet("/test", () =>
{
    return "online";
}).WithName("test");

app.Run();
