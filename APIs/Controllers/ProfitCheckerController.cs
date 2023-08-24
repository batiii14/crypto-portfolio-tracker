using Business.Profitchecker;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    public class ProfitCheckerController : Controller
    {
        ProfitChecker _profitChecker;
        public ProfitCheckerController(ProfitChecker profitChecker)
        {
            _profitChecker = profitChecker;
            
        }
        [HttpGet("{id}")]
        public ActionResult ShowMe([FromRoute]int id)
        {
            ProfitForPortfolio profitForPortfolio = _profitChecker.ShowMeUsersProfit(id);
            return Ok(profitForPortfolio);
        }
    }
}
