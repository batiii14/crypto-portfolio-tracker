using Entities.concretes;

namespace Business.Dtos.responses.walletResponses
{
    public class GetWalletWithUserResponse
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public List<CoinsBought>? CoinList { get; set; } = new List<CoinsBought>();
    }
}
