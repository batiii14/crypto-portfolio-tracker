using Core.Entities;

namespace Entities.concretes
{
    public class BuyingTransaction : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public CoinsBought coinBought { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }


    }
}
