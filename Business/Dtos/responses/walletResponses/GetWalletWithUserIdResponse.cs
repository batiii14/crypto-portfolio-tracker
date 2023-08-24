using Entities.concretes;

namespace Business.Dtos.responses.walletResponses
{
    public class GetWalletWithUserIdResponse
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public List<CoinsBought>? CoinList { get; set; } = new List<CoinsBought>();
    }
}
