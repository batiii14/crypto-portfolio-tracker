using Business.Abstracts;
using Business.Dtos.requests.userRequests;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IWalletService _walletService;
        public UserController(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;

        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            return Ok(_userService.GetById(id));
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            return Ok(_userService.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add(CreateUserRequest user)
        {
            _userService.AddUser(user);
            return Ok(user);

        }

        [HttpDelete("delete")]
        public IActionResult Delete(DeleteUserRequest id)
        {
            _userService.delete(id);
            return Ok();
        }
    }
}
