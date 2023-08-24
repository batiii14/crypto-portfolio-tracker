using Business.Abstracts;
using Business.Dtos.responses.userResponses;
using Entities.concretes;

namespace Business.Profitchecker
{
    public class ProfitChecker
    {
        IBuyingTransactionService _buyingTransactionService;
        ICoinService _coinService;
        IUserService _userService;

        public ProfitChecker(IUserService userService,IBuyingTransactionService buyingTransactionService,ICoinService coinService)
        {
            _userService=userService;
            _buyingTransactionService = buyingTransactionService;
            _coinService = coinService;
                
        }

        public ProfitForPortfolio ShowMeUsersProfit(int userId)
        {
            ProfitForPortfolio profitForPortfolio = new ProfitForPortfolio();

            GetUserByIdResponse user= new GetUserByIdResponse();
            user= _userService.GetById(userId);
            IList<Coin> coins = _coinService.GetAllCoin();
            List<double> moneySpentForeachCoin = new List<double>();

            List<BuyingTransaction> buyingTransactions = _buyingTransactionService.GetAllForSpecificUser(userId);
            double moneySpentOverall = 0;
            double profit = 0;
            double valueOftheWallet = 0;
            double dnm = 0;
          

            foreach (var coinInWallet in buyingTransactions)
            {
                
                moneySpentOverall += coinInWallet.coinBought.Value * coinInWallet.coinBought.quantity;// bu zamana kadar portfolyo için harcanan toplam para
                foreach (var coinToday in coins)
                {
                    if (coinToday.Name == coinInWallet.coinBought.Name)
                    {
                      
                        valueOftheWallet += coinToday.Value * coinInWallet.coinBought.quantity;
                        
                        dnm = coinInWallet.coinBought.Value * coinInWallet.coinBought.quantity - (coinToday.Value * coinInWallet.coinBought.quantity);
                        moneySpentForeachCoin.Add(Math.Abs(dnm));//iki liste de aynı olduğu için bug var. Bitcoin sürekli ekleniyor. Düzelt

                    }

                }

            }
            profit =   valueOftheWallet- moneySpentOverall;



            profitForPortfolio.PerCoin = moneySpentForeachCoin;
            profitForPortfolio.Overall = profit;
            return profitForPortfolio;
        }


        
    }
}


public class ProfitForPortfolio
{
    public List<double> PerCoin { get; set; }
    public double Overall { get; set; }
}



