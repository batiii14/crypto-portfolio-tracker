using Business.Abstracts;
using Business.Dtos.requests.buyTransactionRequests;
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


        [HttpPost("add")]
        public ActionResult CreateBuyingTransaction(BuyingTransaction buyingTransaction)
        {
            _buyingTransactionService.AddBuyingTransaction(buyingTransaction);
            return Ok(buyingTransaction);
        }

        [HttpGet("getAll")]
        public ActionResult GetAllBuyingTransaction()
        {
            var buyingTransactions= _buyingTransactionService.GetAll().ToList();
            return Ok(buyingTransactions);
        }

        [HttpDelete("delete")]
        public ActionResult DeleteBuyingTransaction(int id)
        {
            BuyingTransaction buyingTransaction=_buyingTransactionService.GetById(id);
            _buyingTransactionService.Delete(id);
            return Ok(buyingTransaction);
        }

        [HttpPut("update")] 
        public ActionResult Update(int id,double quantity)
        {
            BuyingTransaction transaction = _buyingTransactionService.GetById(id);
            _buyingTransactionService.Update(id, quantity);
            return Ok(transaction);
        }

        [HttpGet("getAllForSpecificUser")]
        public ActionResult GetAllBuyingTransaction(int id)
        {
            var buyingTransactions = _buyingTransactionService.GetAllForSpecificUser(id).ToList();
            return Ok(buyingTransactions);
        }

    }
}
