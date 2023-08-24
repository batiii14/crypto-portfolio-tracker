//using Business.Abstracts;

//namespace APIs
//{
//    public class BackgroundTaskService : BackgroundService
//    {
//        readonly ILogger<BackgroundService> _logger;
//        private readonly IServiceScopeFactory _scopeFactory;
//        ICoinUpdaterService _coinUpdaterService;

//        public BackgroundTaskService(IServiceScopeFactory scopeFactory, ICoinUpdaterService coinUpdaterService, ILogger<BackgroundService> logger)
//        {
//            _scopeFactory = scopeFactory;
//            _logger = logger;
//        }

//        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                _coinUpdaterService.UpdateAlltheCoins();
//                _logger.LogInformation("Updated");
//                await Task.Delay(100000,stoppingToken);
//            }
//        }
//    }
//}
