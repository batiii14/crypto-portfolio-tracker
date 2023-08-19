using Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinUpdaterController : ControllerBase
    {
        private readonly ICoinUpdaterService _coinUpdaterService;

        public CoinUpdaterController(ICoinUpdaterService coinUpdaterService)
        {
            _coinUpdaterService = coinUpdaterService;
        }

        [HttpGet("{coinName}")]
        public async Task<IActionResult> UpdateCoinValue(string coinName)
        {
            await _coinUpdaterService.GetCoinValueFromApi(coinName);
            
            return Ok($"Coin value for {coinName} updated successfully.");
        }
    }
}
