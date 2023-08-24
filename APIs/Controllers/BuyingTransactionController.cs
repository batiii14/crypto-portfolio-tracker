using Business.Abstracts;
using Entities.concretes;
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


        [HttpPost]
        public ActionResult CreateBuyingTransaction(BuyingTransaction buyingTransaction)
        {
            _buyingTransactionService.AddBuyingTransaction(buyingTransaction);
            return Ok(buyingTransaction);
        }
        
    }
}
