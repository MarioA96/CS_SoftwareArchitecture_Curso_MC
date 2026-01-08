

using Aplication.Abstractions;
using Aplication.Brand.UseCases;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

// conexion
var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");

var services = new ServiceCollection();

services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(connectionString)
          );

services.AddTransient<IRepository<BrandEntity>, BrandRepository>();
services.AddTransient<IUseCase<BrandEntity>, BrandUseCase>();

var serviceProvider = services.BuildServiceProvider();

var brandUseCase = serviceProvider.GetRequiredService<IUseCase<BrandEntity>>();