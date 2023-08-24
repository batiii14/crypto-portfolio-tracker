using Business.Dtos.requests.walletRequests;
using Business.Dtos.responses.walletResponses;

namespace Business.Abstracts
{
    public interface IWalletService 
    {
        GetWalletWithUserIdResponse GetWalletWithUserId(int id);
        GetWalletWithUserResponse GetWallet();
        void Update(UpdateWalletRequest request);
        void Add(CreateWalletRequest request);
        void Delete(DeleteWalletRequest request);
        Boolean IsWalletExist(int id);
    }
}
