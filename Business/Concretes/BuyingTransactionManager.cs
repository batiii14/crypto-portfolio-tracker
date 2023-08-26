using Business.Abstracts;
using Business.Dtos.requests.buyTransactionRequests;
using Business.Dtos.requests.walletRequests;
using DataAccess.Abstracts;
using Entities.concretes;
namespace Business.Concretes
{
    public class BuyingTransactionManager : IBuyingTransactionService
    {
        private IBuyingTransactionDal _buyingTransactionDal;
        private IUserDal _userDal;
        private IWalletService _walletManager;
        private ICoinUpdaterService _coinUpdaterManager;
        private ICoinsBoughtService _coinsBoughtManager;
        private ICoinService _coinService;

        public BuyingTransactionManager(ICoinService coinService, ICoinsBoughtService coinsBoughtManager, IBuyingTransactionDal buyingTransactionDal, ICoinUpdaterService coinUpdaterManager, IUserDal userDal, IWalletService walletManager)
        {
            _coinService = coinService;
            _coinsBoughtManager = coinsBoughtManager;
            _buyingTransactionDal = buyingTransactionDal;
            _userDal = userDal;
            _coinUpdaterManager = coinUpdaterManager;
            _walletManager = walletManager;

        }

        public void AddBuyingTransaction(CreateBuyTransactionRequest createBuyingTransaction)
        {

            BuyingTransaction buyingTransaction = new BuyingTransaction();
            buyingTransaction.Value = createBuyingTransaction.Value;
            buyingTransaction.Quantity = createBuyingTransaction.Quantity;
            buyingTransaction.UserId = createBuyingTransaction.UserId;
            CoinsBought coin = new CoinsBought();
            buyingTransaction.coinBought = coin;
            coin.Name = createBuyingTransaction.CoinName;
            //check if user exist
            bool ısUserExist = _userDal.IsUserExist(buyingTransaction.UserId);
            User user = new User();
            user = _userDal.GetWithWallet(buyingTransaction.UserId);
            bool isWalletExist = _walletManager.IsWalletExist(user.Wallet.WalletId);

            try
            {
                UpdateWalletRequest updateWalletRequest = new UpdateWalletRequest();
                updateWalletRequest.WalletId = user.Wallet.WalletId;
                buyingTransaction.coinBought.WalletId = user.Wallet.WalletId;


                if (user.Wallet.CoinList.Any(c => c.Name == createBuyingTransaction.CoinName))
                {
                    CoinsBought coinToUpdate = user.Wallet.CoinList.Where(c => c.Name == createBuyingTransaction.CoinName).Single();
                    buyingTransaction.coinBought=coinToUpdate;
                    _coinsBoughtManager.Update(coinToUpdate.Id, coinToUpdate.quantity);
                }
                else
                {
                    coin.quantity = createBuyingTransaction.Quantity;
                    user.Wallet.CoinList.Add(buyingTransaction.coinBought);
                    _coinsBoughtManager.Add(buyingTransaction.coinBought);

                }

                _walletManager.Update(updateWalletRequest);
                _buyingTransactionDal.Add(buyingTransaction);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            //BuyingTransaction buyingTransaction1 = new BuyingTransaction();
            //buyingTransaction1.Value = createBuyingTransaction.Value;
            //buyingTransaction1.UserId = createBuyingTransaction.UserId;
            //buyingTransaction1.Quantity = createBuyingTransaction.Quantity;

            //coin.Name = createBuyingTransaction.CoinName;


            //coin.WalletId = user.Wallet.WalletId;
            //buyingTransaction1.coinBought = coin;
            //Wallet usersWallet = user.Wallet;
            //try
            //{

            //    UpdateWalletRequest updateWalletRequest = new UpdateWalletRequest();
            //    updateWalletRequest.WalletId = user.Wallet.WalletId;

            //    //buyingTransaction1.coinBought.WalletId = user.Wallet.WalletId;

            //    if (user.Wallet.CoinList.Any(c => c.Name == createBuyingTransaction.CoinName))
            //    {
            //        coin =user.Wallet.CoinList.Where(c => c.Name == createBuyingTransaction.CoinName).Single();
            //        coin.quantity += buyingTransaction1.Quantity;

            //        //buyingTransaction1.coinBought = _coinsBoughtManager.GetAll().Where(c => c.Name == createBuyingTransaction.CoinName).Single();
            //        _coinsBoughtManager.Update(coin.Id, coin.quantity);





            //    }
            //    else
            //    {
            //        coin.quantity=createBuyingTransaction.Quantity;
            //        user.Wallet.CoinList.Add(buyingTransaction1.coinBought);
            //        _coinsBoughtManager.Add(buyingTransaction1.coinBought);
            //    }



            //    _walletManager.Update(updateWalletRequest);
            //    _buyingTransactionDal.Add(buyingTransaction1);


            //}
            //catch (Exception e)
            //{

            //    throw new Exception(e.Message);
            //}


        }

        public void Delete(int id)
        {
            BuyingTransaction by = _buyingTransactionDal.Get(p => p.Id == id);
            _buyingTransactionDal.Delete(by);
        }

        public List<BuyingTransaction> GetAll()
        {
            return _buyingTransactionDal.GetBuyingTransactionWithCoin();

        }
        public List<BuyingTransaction> GetAllForSpecificUser(int id)
        {

            return _buyingTransactionDal.GetBuyingTransactionWithCoin().Where(p => p.UserId == id).ToList();


        }

        public BuyingTransaction GetById(int id)
        {
            BuyingTransaction by = _buyingTransactionDal.Get(p => p.Id == id);
            return by;
        }

        public void Update(int id, double quantity)
        {
            BuyingTransaction by = _buyingTransactionDal.Get(p => p.Id == id);
            by.coinBought.quantity = quantity;
            _buyingTransactionDal.Update(by);
        }
    }
}
