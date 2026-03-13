using Aplication.Abstractions;
using Aplication.Brand.UseCases;
using Aplication.Product.DTOs;
using Aplication.Product.Mappers;
using Aplication.Product.UseCases;
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
builder.Services.AddTransient<IReadRepository<ProductEntity>, ProductRepository>();
builder.Services.AddTransient<IReadUseCase<ProductDto, ProductEntity>, ProductUseCase>();
builder.Services.AddTransient<IMapper<ProductEntity, ProductDto>, ProductEntityToDtoMapper>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string FrontendPolicy = "FrontendPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FrontendPolicy, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(FrontendPolicy);

app.MapGet("brand", async (IUseCase<BrandEntity> useCase) =>
{
    var brands = await useCase.GetAllAsync();
    return brands;
}).WithName("getbrand");

app.MapPost("brand", async (IUseCase<BrandEntity> useCase, BrandEntity brand) =>
{
    try
    {
        await useCase.AddAsync(brand);
        return Results.Created();
    }
    catch(Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
    
})
    .Produces(StatusCodes.Status201Created)
    .WithName("addbrand");

// app.MapPut("brand/{id}", async (int id, JsonDocument body, IUseCase<BrandEntity> useCase) =>
app.MapPut("brand/{id}", async (int id, BrandEntity brand, IUseCase<BrandEntity> useCase) =>
{
    try
    {
        // var name = body.RootElement.GetProperty("name").GetString();
        var brandEntity = new BrandEntity(id, brand.Name);

        await useCase.UpdateAsync(brandEntity);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

    return Results.NoContent();

})
    .Produces(StatusCodes.Status204NoContent)
    .WithName("updatebrand");

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

})
    .Produces(StatusCodes.Status204NoContent)
    .WithName("deletebrand");

// producto
app.MapGet("/product", async (IReadUseCase<ProductDto, ProductEntity> useCase) =>
{
    return await useCase.GetAllAsync();
});

app.MapGet("/product/{id}", async(int id, IReadUseCase<ProductDto, ProductEntity> useCase) =>
{
    try
    {
        var product = await useCase.GetByIdAsync(id);
        if (product == null)
            return Results.NotFound();

        return Results.Ok(product);
    }
    catch(Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
}).Produces<ProductDto>(StatusCodes.Status200OK)
  .Produces(StatusCodes.Status404NotFound)
  .WithName("getproductbyid");

app.MapGet("/test", () =>
{
    return "online";
}).WithName("test");

app.Run();
