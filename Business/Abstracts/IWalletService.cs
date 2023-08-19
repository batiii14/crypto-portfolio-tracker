using Business.Dtos.requests.walletRequests;
using Business.Dtos.responses.walletResponses;

namespace Business.Abstracts
{
    public interface IWalletService 
    {
        GetWalletWithUserIdResponse getWalletWithUserId(int id);
        GetWalletWithUserResponse getWallet();
        void update(UpdateWalletRequest request);
        void Add(CreateWalletRequest request);
        void Delete(DeleteWalletRequest request);
    }
}
