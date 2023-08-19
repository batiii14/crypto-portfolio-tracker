using Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BuyingTransactionController : ControllerBase
    {
        IBuyingTransactionService _buyingTransactionService;

        public BuyingTransactionController(IBuyingTransactionService buyingTransactionService)
        {
            _buyingTransactionService = buyingTransactionService;
        }

        
    }
}
