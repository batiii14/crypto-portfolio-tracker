using Entities.concretes;

namespace Business.Dtos.responses.walletResponses
{
    public class GetWalletWithUserIdResponse
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public List<Coin>? CoinList { get; set; } = new List<Coin>();
    }
}
