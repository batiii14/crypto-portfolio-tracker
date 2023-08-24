using Business.Abstracts;
using Business.Dtos.requests.walletRequests;
using Business.Dtos.responses.walletResponses;
using DataAccess.Abstracts;
using Entities.concretes;

namespace Business.Concretes
{
    public class WalletManager : IWalletService
    {
        private IWalletDal _walletDal;
        public WalletManager(IWalletDal walletDal)
        {
            _walletDal = walletDal;

        }

        public void Add(CreateWalletRequest request)
        {
            Wallet wallet = new Wallet
            {
                UserId = request.UserId
            };
            _walletDal.Add(wallet);
        }

        public void Delete(DeleteWalletRequest request)
        {
            Wallet wallet = _walletDal.Get(p => p.WalletId == request.WalletId);
            _walletDal.Delete(wallet);
        }

        public GetWalletWithUserResponse GetWallet()
        {
            Wallet wallet = _walletDal.GetWalletWithUser();
            GetWalletWithUserResponse getUserResponse = new GetWalletWithUserResponse();
            getUserResponse.UserId = wallet.UserId;
            getUserResponse.WalletId = wallet.WalletId;
            getUserResponse.CoinList = wallet.CoinList;

            return getUserResponse;

        }

        public GetWalletWithUserIdResponse GetWalletWithUserId(int id)
        {
            Wallet wallet = _walletDal.GetWalletWithUserId(id);
            GetWalletWithUserIdResponse getUserResponse = new GetWalletWithUserIdResponse();
            getUserResponse.UserId = wallet.UserId;
            getUserResponse.WalletId = wallet.WalletId;
            getUserResponse.CoinList= wallet.CoinList;
            return getUserResponse;
        }

        public void Update(UpdateWalletRequest request)
        {
            Wallet wallet =_walletDal.Get(p=>p.WalletId == request.WalletId);
            wallet = _walletDal.GetWalletWithUser();
            wallet.CoinList = request.coins;
            _walletDal.Update(wallet);

        }

        public Boolean IsWalletExist(int id)
        {
            return _walletDal.IsWalletExist(id);
        }
    }
}
