using Core.Entities;

namespace Entities.concretes
{
    public class BuyingTransaction : IEntity
    {
        public int Id { get; set; }
        public Coin coin { get; set; }
        public double Quantity { get; set; }
        public double BuyingPrice { get; set; }

    }
}
