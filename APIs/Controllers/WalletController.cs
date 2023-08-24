using Business.Abstracts;
using Business.Dtos.requests.walletRequests;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        IWalletService _walletService;
        
        public WalletController(IWalletService walletService   )
        {
                _walletService = walletService;
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            return Ok(_walletService.GetWalletWithUserId(id));
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            return Ok(_walletService.GetWallet());
        }   

        [HttpPost("add")]
        public IActionResult Add(CreateWalletRequest wallet)
        {
            _walletService.Add(wallet);
            return Ok(wallet);

        }
        [HttpDelete("delete")]
        public IActionResult Delete(DeleteWalletRequest id)
        {
            _walletService.Delete(id);
            return Ok();
        }

    }
}
