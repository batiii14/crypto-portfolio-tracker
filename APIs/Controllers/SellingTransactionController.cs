using Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SellingTransactionController : ControllerBase
    {
        ISellingTransactionService _sellingTransactionService;
        public SellingTransactionController(ISellingTransactionService sellingTransactionService)
        {
            _sellingTransactionService = sellingTransactionService;
        }
        
    }
}
