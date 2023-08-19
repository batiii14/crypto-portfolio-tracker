using Entities.concretes;

namespace Business.Dtos.requests.walletRequests
{
    public class UpdateWalletRequest
    {
        public int WalletId { get; set; }
        public List<Coin>? coins { get; set; }
    }
}
