using Business.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinBackgroundUpdaterService
{
    public class Worker : BackgroundService
    {
        ICoinUpdaterService _coinUpdaterService;
        private readonly IServiceScopeFactory _scopeFactory;


        public Worker(ICoinUpdaterService coinUpdaterService,IServiceScopeFactory serviceScope)
        {
            _scopeFactory = serviceScope;
            _coinUpdaterService = coinUpdaterService;
            
        }
        protected override async Task  ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await Run(stoppingToken);
                Console.WriteLine("Updated");
                await Task.Delay(10000,stoppingToken); 

            }
        }

        private async Task Run(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var coinUpdaterService = scope.ServiceProvider.GetRequiredService<ICoinUpdaterService>();
                coinUpdaterService.UpdateAlltheCoins();
            }
        }
    }
}
