using Business.Abstracts;
using Business.Dtos.requests.walletRequests;
using DataAccess.Abstracts;
using Entities.concretes;
using Business.Profitchecker;
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

        public void AddBuyingTransaction(BuyingTransaction buyingTransaction)
        {



            bool ısUserExist = _userDal.IsUserExist(buyingTransaction.UserId);
            User user = new User();
            user = _userDal.GetWithWallet(buyingTransaction.UserId);
            bool isWalletExist = _walletManager.IsWalletExist(user.Wallet.WalletId);
            Wallet usersWallet = user.Wallet;
            try
            {
                //if (user != null)
                //{


                //if(user.Wallet != null)
                //{
                UpdateWalletRequest updateWalletRequest = new UpdateWalletRequest();
                updateWalletRequest.WalletId = user.Wallet.WalletId;
                buyingTransaction.coinBought.WalletId = user.Wallet.WalletId;
                foreach (var item in user.Wallet.CoinList)
                {
                    if (item.Name == buyingTransaction.coinBought.Name)
                    {

                        item.quantity += buyingTransaction.coinBought.quantity;

                        _coinsBoughtManager.Update(item.Id, item.quantity);
                        buyingTransaction.coinBought.Id = item.Id;


                    }
                    else
                    {

                        user.Wallet.CoinList.Add(buyingTransaction.coinBought);
                        _coinsBoughtManager.Add(buyingTransaction.coinBought);
                    }



                }

                _walletManager.Update(updateWalletRequest);
                _buyingTransactionDal.Add(buyingTransaction);
                //}
                //else
                //{
                //    throw new Exception("Wallet for this user couldn't found!");
                //}
                //}
                //else
                //{
                //    throw new Exception("User couldn't found!");
                //}

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


            //Wallet? wallet = new Wallet()
            //{
            //    WalletId = user.Wallet.WalletId,
            //    CoinList=user.Wallet.CoinList,
            //    User=user,
            //    UserId=user.UserId
            //};
            //CoinsBought coin = buyingTransaction.coinBought;
            //List<CoinsBought> coinsBoughtList= new List<CoinsBought>();
            //if (wallet.CoinList==null||wallet.CoinList.Count()==0)
            //{
            //    coin.WalletId = user.Wallet.WalletId;
            //    coin.Value= _coinUpdaterManager.GetCoinValueFromApi(coin.Name).Result;
            //    user.Wallet.CoinList.Add(coin);
            //    _userDal.Update(user);
            //    coinsBoughtList.Add(coin);
            //    _coinsBoughtManager.Add(coin);
            //}
            //else
            //{
            //    foreach (var item in wallet.CoinList)
            //    {
            //        if (item.Name == coin.Name)
            //        {
            //            item.Value = _coinUpdaterManager.GetCoinValueFromApi(item.Name).Result;
            //            item.quantity += coin.quantity;
            //            coinsBoughtList.Add(coin);


            //        }
            //        else
            //        {
            //            coinsBoughtList.Add(coin);
            //            _coinsBoughtManager.Add(coin);

            //        }


            //    }

            //}

            //UpdateWalletRequest upt = new UpdateWalletRequest()
            //{
            //    WalletId = wallet.WalletId,
            //    coins = wallet.CoinList

            //};
            //_walletManager.Update(upt);

            //_buyingTransactionDal.Add(buyingTransaction);
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

            return _buyingTransactionDal.GetBuyingTransactionWithCoin().Where(p=>p.UserId == id).ToList();
            

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
