using Business.Abstracts;
using Business.Dtos.requests.coinRequests;
using Entities.concretes;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        ICoinService _coinService;

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;

        }

        [HttpPost("add")]
        public ActionResult AddCoin(AddCoinRequest coin)
        {
            _coinService.Add(coin);
            return Ok(coin);
            
        }
        [HttpGet("getById")]
        public ActionResult GetCoins(int id)
        {
            var coins = _coinService.GetAllCoin().Where(p=>p.Id==id);
            return Ok(coins);
        }
        [HttpGet("getAll")]
        public ActionResult GetAllCoins()
        {
            var coins = _coinService.GetAllCoin().ToList();
            return Ok(coins);
        }


    }
}
