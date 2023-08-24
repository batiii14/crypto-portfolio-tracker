using Entities.concretes;

namespace Business.Dtos.requests.walletRequests
{
    public class UpdateWalletRequest
    {
        public int WalletId { get; set; }
        public List<CoinsBought> coins { get; set; } = new List<CoinsBought>();
    }
}
