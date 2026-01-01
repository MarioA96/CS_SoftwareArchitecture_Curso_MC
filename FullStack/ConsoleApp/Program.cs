

using Aplication.Abstractions;
using Aplication.Brand.UseCases;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Repository;

var services = new ServiceCollection();

services.AddTransient<IRepository<BrandEntity>, BrandRepository>();
services.AddTransient<IUseCase<BrandEntity>, BrandUseCase>();

var serviceProvider = services.BuildServiceProvider();

var brandUseCase = serviceProvider.GetRequiredService<IUseCase<BrandEntity>>();