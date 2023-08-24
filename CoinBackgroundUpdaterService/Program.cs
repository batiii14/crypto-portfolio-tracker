using Business.Abstracts;
using Business.Concretes;
using Business.Profitchecker;
using CoinBackgroundUpdaterService;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host=Host.CreateDefaultBuilder(args).UseWindowsService().
    ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<ICoinUpdaterService,CoinUpdaterManager>();
        services.AddSingleton<ICoinUpdaterDal,CoinUpdaterDal>();
        services.AddSingleton<ICoinService, CoinManager>();
        services.AddSingleton<ICoinDal, CoinDal>();

    }).Build();

await host.RunAsync();
